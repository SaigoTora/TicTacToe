using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.GameClientServer.Chat;
using TicTacToe.Models.GameClientServer.Game;
using TicTacToe.Models.GameClientServer.Lobby;
using TicTacToe.Models.PlayerInfo;

namespace TicTacToe.Models.GameClientServer.Core
{
	internal class GameClient
	{
		private static readonly HttpClient httpClient;
		private string _serverAddress;

		internal long PlayerId { get; private set; }
		private readonly string _gameLobbyUrl = ConfigurationManager.AppSettings["gameLobbyUrl"];
		private readonly string _gameUrl = ConfigurationManager.AppSettings["gameUrl"];
		private readonly string _gameLobbyChatUrl = ConfigurationManager.AppSettings["gameLobbyChatUrl"];

		static GameClient()
		{
			httpClient = new HttpClient()
			{
				Timeout = TimeSpan.FromSeconds(3)
			};
		}

		#region Lobby
		internal async Task<NetworkLobbyInfo> GetGameSettingsAsync(IPAddress ip, int port)
		{
			HttpResponseMessage response = await httpClient.GetAsync($"http://{ip}:{port}{_gameLobbyUrl}");
			response.EnsureSuccessStatusCode();

			string jsonResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<NetworkLobbyInfo>(jsonResponse);
		}
		internal async Task<NetworkLobbyInfo> JoinGameLobbyAsync(string fullIPAddress, Player player)
		{
			string jsonContent = JsonConvert.SerializeObject(player, Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
			{
				HttpResponseMessage response = await httpClient.PostAsync($"http://{fullIPAddress}{_gameLobbyUrl}", httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				_serverAddress = fullIPAddress;
				NetworkLobbyInfo networkLobbyInfo = JsonConvert.DeserializeObject<NetworkLobbyInfo>(jsonResponse);
				PlayerId = networkLobbyInfo.Players[networkLobbyInfo.Players.Count - 1].Id;
				return networkLobbyInfo;
			}
		}
		internal async Task<NetworkLobbyInfo> UpdateGameLobbyAsync(PlayerLobbyStatus status)
		{
			string jsonContent = JsonConvert.SerializeObject(status, Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
			{
				HttpResponseMessage response = await httpClient.PutAsync($"http://{_serverAddress}{_gameLobbyUrl}", httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<NetworkLobbyInfo>(jsonResponse);
			}
		}
		internal async Task LeaveGameLobbyAsync()
		{
			if (string.IsNullOrEmpty(_serverAddress))
				throw new InvalidOperationException("No server address is set. Cannot leave game lobby.");

			await httpClient.DeleteAsync($"http://{_serverAddress}{_gameLobbyUrl}");
		}
		#endregion

		#region Game
		internal async Task<Game.GameInfo> MoveAsync(MoveInfo info)
		{
			string jsonContent = JsonConvert.SerializeObject(info, Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
			{
				HttpResponseMessage response = await httpClient.PostAsync($"http://{_serverAddress}{_gameUrl}", httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<Game.GameInfo>(jsonResponse);
			}
		}
		internal async Task<Game.GameInfo> UpdateGameAsync()
		{
			HttpResponseMessage response = await httpClient.GetAsync($"http://{_serverAddress}{_gameUrl}");
			response.EnsureSuccessStatusCode();

			string jsonResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<Game.GameInfo>(jsonResponse);
		}
		internal async Task LeaveGameAsync()
		{
			if (string.IsNullOrEmpty(_serverAddress))
				throw new InvalidOperationException("No server address is set. Cannot leave game.");

			await httpClient.DeleteAsync($"http://{_serverAddress}{_gameUrl}");
		}
		#endregion

		#region Chat
		internal async Task<ChatManager> SendMessageAsync(Message message)
		{
			string jsonContent = JsonConvert.SerializeObject(message, Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
			{
				HttpResponseMessage response = await httpClient.PostAsync($"http://{_serverAddress}{_gameLobbyChatUrl}", httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<ChatManager>(jsonResponse);
			}
		}
		internal async Task<ChatManager> UpdateLobbyChatAsync()
		{
			HttpResponseMessage response = await httpClient.GetAsync($"http://{_serverAddress}{_gameLobbyChatUrl}");
			response.EnsureSuccessStatusCode();

			string jsonResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<ChatManager>(jsonResponse);
		}
		#endregion
	}
}