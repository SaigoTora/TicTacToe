using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;

using TicTacToe.Models.GameClientServer;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities.FormUtilities;

namespace TicTacToe.Forms.Game.NetworkGame
{
	internal partial class StartNetworkGameForm : BaseForm
	{
		private const int LOBBY_PREVIEW_PANEL_HEIGHT = 75;

		internal bool NeedToOpenMainForm = true;

		private readonly MainForm _mainForm;
		private readonly Player _player;
		private readonly RoundManager _roundManager;

		private readonly GameClient _gameClient;
		private readonly LocalNetworkScanner _localNetworkScanner;

		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private int _lobbyPreviewNumber = 1;

		internal StartNetworkGameForm(MainForm mainForm, Player player, RoundManager roundManager)
		{
			InitializeComponent();

			_mainForm = mainForm;
			_player = player;
			_roundManager = roundManager;

			int port = int.Parse(ConfigurationManager.AppSettings["port"]);
			_gameClient = new GameClient();
			_localNetworkScanner = new LocalNetworkScanner(_gameClient, port, CreateLobbyPreview);

			customTitleBar = new CustomTitleBar(this, "Start Local Game", minimizeBox: false, maximizeBox: false);
		}
		private async void StartNetworkGameForm_Load(object sender, EventArgs e)
		{
			_buttonEventHandlers.SubscribeToHover(buttonCreateGame);
			await _localNetworkScanner.ScanLocalNetworkAsync();


			CreateLobbyPreview(this, new LobbyPreviewEventArgs(new System.Net.IPAddress(new byte[] { 192, 168, 1, 10 }), 7755,
			new Models.GameInfo.Settings.NetworkGameSettings("Description Text", 25, "WWWWWWWWWWWWWWWWWWWW", // Example Data
			new Models.PlayerItem.Avatar(), 99, Models.GameInfo.Settings.FieldSize.Size5on5, false, false)));
		}

		private void CreateLobbyPreview(object sender, LobbyPreviewEventArgs e)
		{
			Panel panel = CreatePanel();
			Label labelOpponentName = CreateOpponentLabelName($"#{_lobbyPreviewNumber++}  {e.NetworkGameSettings.OpponentName}");

			panel.Controls.Add(labelOpponentName);
			flpLobbyPreviews.Controls.Add(panel);
		}
		private Panel CreatePanel()
		{
			Panel panel = new Panel
			{
				Size = new Size(flpLobbyPreviews.Width -
				flpLobbyPreviews.Margin.Right - flpLobbyPreviews.Margin.Left,
				LOBBY_PREVIEW_PANEL_HEIGHT),
				BackColor = Color.Red
			};

			return panel;
		}
		private Label CreateOpponentLabelName(string name)
		{
			Label label = new Label
			{
				AutoSize = true,
				ForeColor = Color.White,
				BackColor = Color.Transparent,
				Text = name,
				Font = new Font("Trebuchet MS", 14F, FontStyle.Bold),
			};
			label.Location = new Point(0, (LOBBY_PREVIEW_PANEL_HEIGHT - label.Height) / 2);

			return label;
		}
		private void ButtonCreateGame_Click(object sender, EventArgs e)
		{
			if (!IsRunningAsAdministrator())
			{
				DialogResult result = CustomMessageBox.Show("To create a game over the network you need to " +
					"run the application as administrator.\nDo you really want to create a game?", "Restart application",
					CustomMessageBoxButtons.YesNo, CustomMessageBoxIcon.Question);
				if (result == DialogResult.Yes)
					RestartAsAdmin();
				return;
			}

			GameSettingsForm gameSettingsForm = new GameSettingsForm(_mainForm, _player, _roundManager,
				GameSettingsForm.GameType.NetworkGame, this);
			gameSettingsForm.ShowDialog();
		}
		private bool IsRunningAsAdministrator()
		{
			WindowsIdentity identity = WindowsIdentity.GetCurrent();
			WindowsPrincipal principal = new WindowsPrincipal(identity);
			return principal.IsInRole(WindowsBuiltInRole.Administrator);
		}
		static void RestartAsAdmin()
		{
			var startInfo = new ProcessStartInfo($"{Process.GetCurrentProcess().ProcessName}.exe") { Verb = "runas" };
			Process.Start(startInfo);
			Environment.Exit(0);
		}

		private void StartNetworkGameForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_buttonEventHandlers.UnsubscribeAll();
			if (NeedToOpenMainForm)
				_mainForm.Show();
		}
	}
}