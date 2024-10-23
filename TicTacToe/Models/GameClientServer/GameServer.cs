using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;

namespace TicTacToe.Models.GameClientServer
{
	internal class GameServer
	{
		private const string FIREWALL_RULE_NAME_PREFIX = "Tic Tac Toe";

		private readonly HttpListener _httpListener;
		private readonly FirewallManager _firewallManager;
		private readonly Player _player;
		private readonly int _port;

		internal GameServer(Player player, int port)
		{
			_httpListener = new HttpListener();
			_httpListener.Prefixes.Add($"http://+:{port}/");
			_player = player;
			_port = port;
			_firewallManager = new FirewallManager($"{FIREWALL_RULE_NAME_PREFIX} {_port}");
		}

		internal void Start()
		{
			_httpListener.Start();
			_firewallManager.AddFirewallRule(_port);

			Task.Run(() => HandleRequests());
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

			if (context.Request.RawUrl.Contains("/game-lobby"))
			{
				if (context.Request.HttpMethod == HttpMethod.Get.Method)
				{
					NetworkGameSettings networkGameSettings = CloneAndModifySettings();
					string response = JsonConvert.SerializeObject(networkGameSettings, Formatting.Indented);

					byte[] responseBytes = Encoding.UTF8.GetBytes(response);
					context.Response.StatusCode = (int)HttpStatusCode.OK;
					context.Response.ContentLength64 = responseBytes.Length;

					await context.Response.OutputStream.WriteAsync(responseBytes, 0, responseBytes.Length);
				}
			}

			context.Response.Close();
		}
		private NetworkGameSettings CloneAndModifySettings()
		{// The method creates a new NetworkGameSettings, where it inserts the player's avatar and nickname.
			NetworkGameSettings settings = _player.NetworkGameSettings;
			NetworkGameSettings networkGameSettings = new NetworkGameSettings(settings.Description,
				settings.CoinsBet, _player.Name, _player.VisualSettings.Avatar,
				settings.NumberOfRounds, settings.FieldSize,
				settings.IsTimerEnabled, settings.IsGameAssistsEnabled, 0);

			return networkGameSettings;
		}

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