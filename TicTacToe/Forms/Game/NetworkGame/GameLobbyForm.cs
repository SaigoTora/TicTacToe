using System.Configuration;

using TicTacToe.Models.GameClientServer;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities.FormUtilities;

namespace TicTacToe.Forms.Game.NetworkGame
{
	internal partial class GameLobbyForm : BaseForm
	{
		private readonly MainForm _mainForm;
		private readonly Player _player;
		private readonly RoundManager _roundManager;
		private readonly GameServer _gameServer;


		internal GameLobbyForm(MainForm mainForm, Player player, RoundManager roundManager)
		{
			customTitleBar = new CustomTitleBar(this, "Lobby");
			IsResizable = true;
			InitializeComponent();

			_mainForm = mainForm;
			_player = player;
			_roundManager = roundManager;
			int port = int.Parse(ConfigurationManager.AppSettings["port"]);
			_gameServer = new GameServer(_player, port);
		}
		private void GameLobbyForm_Load(object sender, System.EventArgs e)
		{
			_gameServer.Start();
		}

		private void GameLobbyForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			_gameServer.Stop();
			_mainForm.Show();
		}
	}
}