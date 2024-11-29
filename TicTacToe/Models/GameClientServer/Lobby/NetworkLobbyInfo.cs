using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using TicTacToe.Models.GameInfo.Settings;

namespace TicTacToe.Models.GameClientServer.Lobby
{
	internal class NetworkLobbyInfo
	{
		[JsonProperty]
		internal readonly int MaxPlayerCount = 2;
		[JsonProperty]
		internal NetworkGameSettings Settings;
		[JsonProperty("Players")]
		private readonly List<NetworkPlayer> _players = new List<NetworkPlayer>();
		internal List<NetworkPlayer> Players => _ipToPlayers.Values.ToList();
		[JsonProperty]
		internal bool HasGameStarted { get; private set; }

		private readonly Dictionary<string, NetworkPlayer> _ipToPlayers = new Dictionary<string, NetworkPlayer>();

		internal NetworkLobbyInfo() { }
		internal NetworkLobbyInfo(NetworkGameSettings settings)
		{ Settings = settings; }

		internal void AddPlayer(string ipAddress, NetworkPlayer player)
		{
			_ipToPlayers.Add(ipAddress, player);
			_players.Add(player);
		}
		internal NetworkPlayer GetPlayer(long id)
			=> _players.First((player) => player.Id == id);
		internal NetworkPlayer ChangePlayerLobbyStatus(string ipAddress, PlayerLobbyStatus status)
		{
			NetworkPlayer player = _ipToPlayers[ipAddress];

			player.SetReady(status.IsReady);

			return player;
		}
		internal NetworkPlayer GetPlayerOrNull(string ipAddress)
			=> _ipToPlayers?.FirstOrDefault((item) => item.Key == ipAddress).Value;
		internal void RemovePlayer(string ipAddress)
		{
			_players.Remove(_ipToPlayers[ipAddress]);
			_ipToPlayers.Remove(ipAddress);
		}
		internal void StartGame()
			=> HasGameStarted = true;

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{// Fill the dictionary after deserialization, where IP addresses are not specified.
		 // This is done so that players do not have the IP addresses of other players.
			int i = 0;
			foreach (var player in _players)
				_ipToPlayers.Add((i++).ToString(), player);
		}
	}
}