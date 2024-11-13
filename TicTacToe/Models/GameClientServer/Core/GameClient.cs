using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using TicTacToe.Models.GameClientServer.Lobby;
using TicTacToe.Models.PlayerInfo;

namespace TicTacToe.Models.GameClientServer.Core
{
	internal class GameClient
	{
		private static readonly HttpClient httpClient = new HttpClient();
		private string _serverAddress;

		private readonly string _gameLobbyUrl = ConfigurationManager.AppSettings["gameLobbyUrl"];

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
				return JsonConvert.DeserializeObject<NetworkLobbyInfo>(jsonResponse);
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
	}
}