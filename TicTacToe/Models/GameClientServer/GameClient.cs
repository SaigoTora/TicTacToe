using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;

namespace TicTacToe.Models.GameClientServer
{
	internal class GameClient
	{
		private static readonly HttpClient httpClient = new HttpClient();

		internal async Task<NetworkGameSettings> GetGameSettings(IPAddress ip, int port)
		{
			HttpResponseMessage response = await httpClient.GetAsync($"http://{ip}:{port}/game-lobby");
			response.EnsureSuccessStatusCode();

			string jsonResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<NetworkGameSettings>(jsonResponse);
		}
		internal async Task<NetworkGameSettings> JoinGameLobby(string fullIPAddress, Player player)
		{
			string jsonContent = JsonConvert.SerializeObject(player, Formatting.Indented);

			using (var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
			{
				HttpResponseMessage response = await httpClient.PostAsync($"http://{fullIPAddress}/game-lobby", httpContent);
				response.EnsureSuccessStatusCode();

				string jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<NetworkGameSettings>(jsonResponse);
			}
		}
	}
}