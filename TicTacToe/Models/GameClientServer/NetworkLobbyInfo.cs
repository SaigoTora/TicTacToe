using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;

namespace TicTacToe.Models.GameClientServer
{
	internal class NetworkLobbyInfo
	{
		[JsonProperty]
		internal readonly int MaxPlayerCount = 2;
		[JsonProperty]
		internal NetworkGameSettings Settings;
		[JsonProperty]
		private List<Player> _players = new List<Player>();
		internal List<Player> Players => _ipToPlayers.Values.ToList();

		private readonly Dictionary<string, Player> _ipToPlayers = new Dictionary<string, Player>();

		internal NetworkLobbyInfo() { }
		internal NetworkLobbyInfo(NetworkGameSettings settings)
		{ Settings = settings; }

		internal void AddPlayer(string ipAddress, Player player)
		{
			_ipToPlayers.Add(ipAddress, player);
			_players.Add(player);
		}
		internal void RemovePlayer(string ipAddress)
		{
			_players.Remove(_ipToPlayers[ipAddress]);
			_ipToPlayers.Remove(ipAddress);
		}

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