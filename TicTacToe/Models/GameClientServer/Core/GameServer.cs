using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using TicTacToe.Models.GameClientServer.Chat;
using TicTacToe.Models.GameClientServer.Game;
using TicTacToe.Models.GameClientServer.Lobby;
using TicTacToe.Models.GameClientServer.Network;
using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;
using TicTacToeLibrary.Core;

namespace TicTacToe.Models.GameClientServer.Core
{
	internal class GameServer
	{
		private const string FIREWALL_RULE_NAME_PREFIX = "Tic Tac Toe";
		internal EventHandler<NetworkPlayerEventArgs> PlayerJoined;
		internal EventHandler<NetworkPlayerEventArgs> PlayerStatusChanged;
		internal EventHandler<NetworkPlayerEventArgs> PlayerLeftLobby;
		internal EventHandler<ChatMessageEventArgs> PlayerPostMessage;

		internal EventHandler<MoveGameEventArgs> PlayerMoveGame;
		internal EventHandler<NetworkPlayerEventArgs> PlayerLeftGame;

		private readonly HttpListener _httpListener;
		private readonly int _port;
		private readonly FirewallManager _firewallManager;
		private readonly Player _player;
		private readonly NetworkLobbyInfo _networkLobbyInfo;
		internal readonly ChatManager LobbyChat = new ChatManager();
		private Game.GameInfo _gameInfo;
		private bool _readyToGetMoveInfo = false;

		internal GameServer(Player player, int port)
		{
			_httpListener = new HttpListener();
			_httpListener.Prefixes.Add($"http://+:{port}/");
			_port = port;
			_firewallManager = new FirewallManager($"{FIREWALL_RULE_NAME_PREFIX} {port}");
			_player = player;
			_networkLobbyInfo = new NetworkLobbyInfo(_player.NetworkGameSettings);
		}

		internal void Start()
		{
			_httpListener.Start();
			_firewallManager.AddFirewallRule(_port);
			UpdateLobbySettings();

			Task.Run(() => HandleRequests());
		}

		internal List<NetworkPlayer> GetOpponents()
			=> _networkLobbyInfo.Players;
		internal NetworkPlayer GetPlayerByIp(string ipAddress)
			=> _networkLobbyInfo.GetPlayerOrNull(ipAddress);
		internal int GetMaxPlayerCount()
			=> _networkLobbyInfo.MaxPlayerCount;
		internal bool AllPlayersReady()
		{
			foreach (NetworkPlayer player in _networkLobbyInfo.Players)
				if (!player.IsReady)
					return false;

			return true;
		}

		private async Task HandleRequests()
		{
			while (_httpListener.IsListening)
			{
				var context = await _httpListener.GetContextAsync();
				_ = ProcessRequest(context);
			}
		}
		private async Task ProcessRequest(HttpListenerContext context)
		{
			if (context.Request.RawUrl == "/favicon.ico")
			{// Ignore request for favicon.ico
				context.Response.StatusCode = (int)HttpStatusCode.NotFound;
				context.Response.Close();
				return;
			}

			string clientIPAddress = context.Request.RemoteEndPoint?.Address.ToString();

			if (context.Request.RawUrl.Contains(ConfigurationManager.AppSettings["gameLobbyChatUrl"]))
				await HandleChatRequest(context, clientIPAddress);
			else if (context.Request.RawUrl.Contains(ConfigurationManager.AppSettings["gameLobbyUrl"]))
				await HandleLobbyRequest(context, clientIPAddress);
			else if (context.Request.RawUrl.Contains(ConfigurationManager.AppSettings["gameUrl"]))
				await HandleGameRequest(context, clientIPAddress);

			context.Response.Close();
		}

		#region Lobby
		private async Task HandleLobbyRequest(HttpListenerContext context,
			string clientIPAddress)
		{
			NetworkPlayer joinedPlayer = null, updatedPlayer = null;

			if (context.Request.HttpMethod == HttpMethod.Post.Method)
				joinedPlayer = await HandlePostLobbyRequestAsync(context, clientIPAddress);
			if (context.Request.HttpMethod == HttpMethod.Put.Method)
				updatedPlayer = await HandlePutLobbyRequestAsync(context, clientIPAddress);

			if (context.Request.HttpMethod == HttpMethod.Delete.Method)
				DeletePlayerFromLobby(clientIPAddress);
			else
			{
				UpdateLobbySettings();
				string response = JsonConvert.SerializeObject(_networkLobbyInfo, Formatting.Indented);
				await SendResponseToClient(context, response);

				if (joinedPlayer != null && clientIPAddress != null)
					OnPlayerJoined(new NetworkPlayerEventArgs(joinedPlayer, clientIPAddress));
				else if (updatedPlayer != null && clientIPAddress != null)
					OnPlayerStatusChanged(new NetworkPlayerEventArgs(updatedPlayer, clientIPAddress));
			}
		}
		private async Task<NetworkPlayer> HandlePostLobbyRequestAsync(HttpListenerContext context,
			string clientIPAddress)
		{
			NetworkPlayer joinedPlayer;
			using (var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
			{
				string jsonData = await reader.ReadToEndAsync();
				Player player = JsonConvert.DeserializeObject<Player>(jsonData);
				joinedPlayer = new NetworkPlayer(player.Name, player.VisualSettings);
				joinedPlayer.AssignId();
				_networkLobbyInfo.AddPlayer(clientIPAddress, joinedPlayer);
			}
			return joinedPlayer;
		}
		private async Task<NetworkPlayer> HandlePutLobbyRequestAsync(HttpListenerContext context,
			string clientIPAddress)
		{
			NetworkPlayer updatedPlayer;
			using (var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
			{
				string jsonData = await reader.ReadToEndAsync();
				PlayerLobbyStatus playerStatus = JsonConvert.DeserializeObject<PlayerLobbyStatus>(jsonData);

				updatedPlayer = _networkLobbyInfo.ChangePlayerLobbyStatus(clientIPAddress, playerStatus);
			}
			return updatedPlayer;
		}
		private async Task SendResponseToClient(HttpListenerContext context, string response)
		{
			byte[] responseBytes = Encoding.UTF8.GetBytes(response);
			context.Response.StatusCode = (int)HttpStatusCode.OK;
			context.Response.ContentLength64 = responseBytes.Length;

			await context.Response.OutputStream.WriteAsync(responseBytes, 0, responseBytes.Length);
		}

		private void UpdateLobbySettings()
		{
			NetworkGameSettings settings = _player.NetworkGameSettings;
			_networkLobbyInfo.Settings = new NetworkGameSettings(settings.Description,
				settings.CoinsBet, _player.Name, _player.VisualSettings.Avatar,
				settings.NumberOfRounds, settings.FieldSize, settings.GameMode,
				settings.IsTimerEnabled, settings.IsGameAssistsEnabled);
		}
		internal void DeletePlayerFromLobby(string clientIPAddress)
		{
			NetworkPlayer playerWhoLeftLobby = _networkLobbyInfo.GetPlayerOrNull(clientIPAddress);

			if (playerWhoLeftLobby != null)
			{
				OnPlayerLeftLobby(new NetworkPlayerEventArgs(null, clientIPAddress));
				_networkLobbyInfo.RemovePlayer(clientIPAddress);
			}
		}

		private void OnPlayerJoined(NetworkPlayerEventArgs e)
		{
			var temp = System.Threading.Volatile.Read(ref PlayerJoined);
			temp?.Invoke(this, e);
		}
		private void OnPlayerStatusChanged(NetworkPlayerEventArgs e)
		{
			var temp = System.Threading.Volatile.Read(ref PlayerStatusChanged);
			temp?.Invoke(this, e);
		}
		private void OnPlayerLeftLobby(NetworkPlayerEventArgs e)
		{
			var temp = System.Threading.Volatile.Read(ref PlayerLeftLobby);
			temp?.Invoke(this, e);
		}
		#endregion

		#region Game
		internal void StartGame()
		{
			_gameInfo = new Game.GameInfo(_networkLobbyInfo.Settings.FieldSize);
			_networkLobbyInfo.StartGame();
			_readyToGetMoveInfo = true;
		}
		internal void Move(MoveInfo info)
		{
			if (info.IsMoveCancelled)
			{
				_gameInfo.CancelLastMove();
				_gameInfo.CancelLastMove();
			}
			else
				_gameInfo.Move(info.Cell, info.CellType);
		}
		internal CellType WhoseMove() => _gameInfo.WhoseMove;
		internal void FinishGame()
		{
			_readyToGetMoveInfo = false;
			_gameInfo.ClearField();
		}

		private async Task HandleGameRequest(HttpListenerContext context,
			string clientIPAddress)
		{
			MoveInfo moveInfo = null;

			if (context.Request.HttpMethod == HttpMethod.Post.Method)
				moveInfo = await HandlePostGameRequestAsync(context);

			if (context.Request.HttpMethod == HttpMethod.Delete.Method)
				DeletePlayerFromGame(clientIPAddress);
			else
			{
				string response = JsonConvert.SerializeObject(_gameInfo, Formatting.Indented);
				await SendResponseToClient(context, response);

				if (moveInfo != null)
					OnPlayerMoveGame(new MoveGameEventArgs(moveInfo));
			}
		}
		private async Task<MoveInfo> HandlePostGameRequestAsync(HttpListenerContext context)
		{
			MoveInfo moveInfo;
			using (var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
			{
				string jsonData = await reader.ReadToEndAsync();
				moveInfo = JsonConvert.DeserializeObject<MoveInfo>(jsonData);
				while (!_readyToGetMoveInfo)
					await Task.Delay(100);
				Move(moveInfo);
			}
			return moveInfo;
		}
		private void DeletePlayerFromGame(string clientIPAddress)
		{
			NetworkPlayer playerWhoLeftGame = _networkLobbyInfo.GetPlayerOrNull(clientIPAddress);
			if (playerWhoLeftGame != null)
			{
				OnPlayerLeftGame(new NetworkPlayerEventArgs(playerWhoLeftGame, clientIPAddress));
				_networkLobbyInfo.RemovePlayer(clientIPAddress);
			}
		}

		private void OnPlayerMoveGame(MoveGameEventArgs e)
		{
			var temp = System.Threading.Volatile.Read(ref PlayerMoveGame);
			temp?.Invoke(this, e);
		}
		private void OnPlayerLeftGame(NetworkPlayerEventArgs e)
		{
			var temp = System.Threading.Volatile.Read(ref PlayerLeftGame);
			temp?.Invoke(this, e);
		}
		#endregion

		#region Chat
		private async Task HandleChatRequest(HttpListenerContext context,
	string clientIPAddress)
		{
			Message postedMessage = null;
			if (context.Request.HttpMethod == HttpMethod.Post.Method)
				postedMessage = await HandlePostChatRequestAsync(context);

			string response = JsonConvert.SerializeObject(LobbyChat, Formatting.Indented);
			await SendResponseToClient(context, response);

			if (postedMessage != null && clientIPAddress != null)
				OnMessagePosted(new ChatMessageEventArgs(postedMessage));
		}
		private async Task<Message> HandlePostChatRequestAsync(HttpListenerContext context)
		{
			Message postedMessage;
			using (var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
			{
				string jsonData = await reader.ReadToEndAsync();
				postedMessage = JsonConvert.DeserializeObject<Message>(jsonData);
				LobbyChat.AddMessage(postedMessage);
			}
			return postedMessage;
		}

		private void OnMessagePosted(ChatMessageEventArgs e)
		{
			var temp = System.Threading.Volatile.Read(ref PlayerPostMessage);
			temp?.Invoke(this, e);
		}
		#endregion
		internal void Stop()
		{
			if (_httpListener.IsListening)
			{
				_httpListener.Stop();
				_httpListener.Close();
				_firewallManager.RemoveFirewallRule();
			}
		}
	}
}