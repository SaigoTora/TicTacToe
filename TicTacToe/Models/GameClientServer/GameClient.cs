using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using TicTacToe.Models.GameInfo.Settings;

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
	}
}