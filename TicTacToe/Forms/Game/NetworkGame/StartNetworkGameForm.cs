using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using TicTacToe.Forms.Game.Settings;
using TicTacToe.Models.GameClientServer;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToe.Models.Utilities.FormUtilities.ControlEventHandlers;

namespace TicTacToe.Forms.Game.NetworkGame
{
	internal partial class StartNetworkGameForm : BaseForm
	{
		private const int LOBBY_PREVIEW_PANEL_HEIGHT = 125;
		private const int LOBBY_PREVIEW_LABEL_MARGIN_LEFT = 35;

		private (Color Default, Color Selected) _lobbyPreviewPanelColor =
			(Color.FromArgb(50, 50, 50), Color.FromArgb(200, 229, 158, 31));

		internal bool NeedToShowMainForm = true;

		private readonly MainForm _mainForm;
		private readonly Player _player;
		private readonly RoundManager _roundManager;

		private readonly GameClient _gameClient;
		private readonly LocalNetworkScanner _localNetworkScanner;
		private readonly Dictionary<Guna2Panel, string> _dictionaryIP = new Dictionary<Guna2Panel, string>();

		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private string _selectedIP;
		private int _lobbyPreviewNumber;

		internal StartNetworkGameForm(MainForm mainForm, Player player, RoundManager roundManager)
		{
			InitializeComponent();

			_mainForm = mainForm;
			_player = player;
			_roundManager = roundManager;

			_gameClient = new GameClient();
			int port = int.Parse(ConfigurationManager.AppSettings["port"]);
			_localNetworkScanner = new LocalNetworkScanner(_gameClient, port, CreateLobbyPreview);

			customTitleBar = new CustomTitleBar(this, "Start Local Game", minimizeBox: false, maximizeBox: false);
		}
		private async void StartNetworkGameForm_Load(object sender, EventArgs e)
		{
			_buttonEventHandlers.SubscribeToHover(buttonCreateGame, buttonJoin);
			await ScanLocalNetworkAsync();

			CreateExampleData(new System.Net.IPAddress(new byte[] { 192, 168, 1, 12 }));
			CreateExampleData(new System.Net.IPAddress(new byte[] { 192, 168, 1, 14 }));
			CreateExampleData(new System.Net.IPAddress(new byte[] { 192, 168, 1, 16 }));
			CreateExampleData(new System.Net.IPAddress(new byte[] { 192, 168, 1, 18 }));
			CreateExampleData(new System.Net.IPAddress(new byte[] { 192, 168, 1, 20 }));
		}
		private void CreateExampleData(System.Net.IPAddress ip)
		{
			var lpea = new LobbyPreviewEventArgs(ip, 7755,
				new Models.GameInfo.Settings.NetworkGameSettings(new string('W', 108) + 'a', 1000, "WWWWWWWWWWWWWWWWWWWW", // Example Data
				new Models.PlayerItem.Avatar(), 99, Models.GameInfo.Settings.FieldSize.Size5on5, false, false, 1));
			CreateLobbyPreview(this, lpea);
		}

		#region Lobby Previews
		private void CreateLobbyPreview(object sender, LobbyPreviewEventArgs e)
		{
			Guna2Panel panel = CreatePanel();
			Label labelOpponentName = CreateLabelOpponentName($"#{Interlocked.Increment(ref _lobbyPreviewNumber)}  {e.NetworkGameSettings.OpponentName}");
			Label labelDescription = CreateLabelDescription(e.NetworkGameSettings.Description);
			PictureBox pictureBoxCoin = CreatePictureBoxCoin();
			Label labelCoinsBet = CreateLabelCoinsBet(e.NetworkGameSettings.CoinsBet,
				pictureBoxCoin.Width + pictureBoxCoin.Location.X);
			Label labelPlayers = CreateLabelPlayers(e.NetworkGameSettings.CurrentPlayerCount, e.NetworkGameSettings.MaxPlayerCount);

			panel.Controls.Add(labelOpponentName);
			panel.Controls.Add(labelDescription);
			panel.Controls.Add(pictureBoxCoin);
			panel.Controls.Add(labelCoinsBet);
			panel.Controls.Add(labelPlayers);
			flpLobbyPreviews.Controls.Add(panel);

			_dictionaryIP.Add(panel, $"{e.IPAddress}:{e.Port}");
		}
		private Guna2Panel CreatePanel()
		{
			const int PANEL_WIDTH_MARGIN = 17;// Indentation to fit the slider
			const int PANEL_BOTTOM_MARGIN = 12;

			Guna2Panel panel = new Guna2Panel
			{
				Size = new Size(flpLobbyPreviews.Width -
				flpLobbyPreviews.Margin.Right - flpLobbyPreviews.Margin.Left - PANEL_WIDTH_MARGIN,
				LOBBY_PREVIEW_PANEL_HEIGHT),
				AutoRoundedCorners = true,
				Cursor = Cursors.Hand,
				Margin = new Padding(0, 0, 0, PANEL_BOTTOM_MARGIN),
				FillColor = _lobbyPreviewPanelColor.Default
			};
			panel.Click += LobbyPreview_Click;
			panel.DoubleClick += LobbyPreview_DoubleClick;

			return panel;
		}
		private Label CreateLabelOpponentName(string name)
		{
			const int LABEL_MARGIN_TOP = 6;

			Label label = new Label
			{
				AutoSize = true,
				ForeColor = Color.White,
				Text = name,
				Font = new Font("Trebuchet MS", 17F, FontStyle.Bold),
				Location = new Point(LOBBY_PREVIEW_LABEL_MARGIN_LEFT, LABEL_MARGIN_TOP)
			};
			label.Click += LobbyPreview_Click;
			label.DoubleClick += LobbyPreview_DoubleClick;

			return label;
		}
		private Label CreateLabelDescription(string description)
		{
			const int LABEL_WIDTH = 450;
			const int LABEL_HEIGHT_SHIFT = -18;

			Label label = new Label
			{
				AutoSize = false,
				Size = new Size(LABEL_WIDTH, LOBBY_PREVIEW_PANEL_HEIGHT / 2),
				ForeColor = Color.Gainsboro,
				Text = description,
				Font = new Font("Trebuchet MS", 10F, FontStyle.Regular),
			};
			label.Location = new Point(LOBBY_PREVIEW_LABEL_MARGIN_LEFT,
				(LOBBY_PREVIEW_PANEL_HEIGHT + label.Height - LABEL_HEIGHT_SHIFT) / 3);
			label.Click += LobbyPreview_Click;
			label.DoubleClick += LobbyPreview_DoubleClick;

			return label;
		}
		private PictureBox CreatePictureBoxCoin()
		{
			const int PICTURE_SIZE = 45;
			const int PICTURE_MARGIN_LEFT = 500;

			PictureBox pictureBox = new PictureBox
			{
				Size = new Size(PICTURE_SIZE, PICTURE_SIZE),
				SizeMode = PictureBoxSizeMode.Zoom,
				Image = Properties.Resources.coin,
				Location = new Point(PICTURE_MARGIN_LEFT, (LOBBY_PREVIEW_PANEL_HEIGHT - PICTURE_SIZE) / 2)
			};
			pictureBox.Click += LobbyPreview_Click;
			pictureBox.DoubleClick += LobbyPreview_DoubleClick;

			return pictureBox;
		}
		private Label CreateLabelCoinsBet(int coinsBet, int labelMarginLeft)
		{
			string coinsBetText = coinsBet == 0 ?
				"Free" :
				$"{coinsBet:N0}".Replace(',', ' ');
			Label label = new Label
			{
				AutoSize = true,
				ForeColor = Color.Khaki,
				Text = coinsBetText,
				Font = new Font("Courier New", 18F, FontStyle.Bold),
			};
			label.Location = new Point(labelMarginLeft, (LOBBY_PREVIEW_PANEL_HEIGHT - label.Font.Height) / 2);

			if (_player.Coins < coinsBet)
				label.ForeColor = Color.FromArgb(191, 34, 51);
			label.Click += LobbyPreview_Click;
			label.DoubleClick += LobbyPreview_DoubleClick;

			return label;
		}
		private Label CreateLabelPlayers(int currentPlayerCount, int maxPlayerCount)
		{
			const int LABEL_MARGIN_LEFT = 650;
			const int LABEL_WIDTH = 90;

			Label label = new Label
			{
				AutoSize = false,
				TextAlign = ContentAlignment.MiddleRight,
				ForeColor = Color.White,
				Text = $"{currentPlayerCount} / {maxPlayerCount}",
				Font = new Font("Trebuchet MS", 16F, FontStyle.Regular),
			};
			label.Size = new Size(LABEL_WIDTH, label.Font.Height);
			label.Location = new Point(LABEL_MARGIN_LEFT, (LOBBY_PREVIEW_PANEL_HEIGHT - label.Font.Height) / 2);
			if (currentPlayerCount >= maxPlayerCount)
				label.ForeColor = Color.FromArgb(191, 34, 51);

			label.Click += LobbyPreview_Click;
			label.DoubleClick += LobbyPreview_DoubleClick;

			return label;
		}

		private void LobbyPreview_Click(object sender, EventArgs e)
		{
			Guna2Panel panel = FindPanelOrNull(sender);
			if (panel == null)
				return;

			string newSelectedIP = _dictionaryIP[panel];
			if (_selectedIP == newSelectedIP)
			{
				_selectedIP = string.Empty;
				panel.FillColor = _lobbyPreviewPanelColor.Default;
				buttonJoin.Enabled = false;
			}
			else
			{
				_selectedIP = newSelectedIP;
				foreach (Guna2Panel item in _dictionaryIP.Keys)
					item.FillColor = _lobbyPreviewPanelColor.Default;

				panel.FillColor = _lobbyPreviewPanelColor.Selected;
				buttonJoin.Enabled = true;
			}
		}
		private void LobbyPreview_DoubleClick(object sender, EventArgs e)
		{
			Guna2Panel panel = FindPanelOrNull(sender);
			if (panel == null)
				return;

			string newSelectedIP = _dictionaryIP[panel];
			_selectedIP = newSelectedIP;
			foreach (Guna2Panel item in _dictionaryIP.Keys)
				item.FillColor = _lobbyPreviewPanelColor.Default;

			panel.FillColor = _lobbyPreviewPanelColor.Selected;
			buttonJoin.Enabled = true;
			ButtonJoin_Click(sender, e);
		}
		private Guna2Panel FindPanelOrNull(object obj)
		{
			Guna2Panel panel = null;
			if (!(obj is Control control))
				return null;

			if (control is Guna2Panel panel2)
				panel = panel2;
			else if (control.Parent is Guna2Panel parentPanel)
				panel = parentPanel;

			return panel;
		}

		private void ClearLobbyPreviews()
		{
			foreach (Guna2Panel panel in _dictionaryIP.Keys)
			{
				foreach (Control child in panel.Controls)
				{
					child.Click -= LobbyPreview_Click;
					child.Click -= LobbyPreview_DoubleClick;
					child.Dispose();
				}
				panel.Click -= LobbyPreview_Click;
				panel.Click -= LobbyPreview_DoubleClick;
				panel.Dispose();
			}
		}
		#endregion

		private async void ButtonRefresh_Click(object sender, EventArgs e)
		{
			if (_selectedIP != null && _selectedIP != string.Empty)
			{
				Guna2Panel panel = _dictionaryIP.FirstOrDefault(ip => ip.Value == _selectedIP).Key;
				if (panel != null)
					LobbyPreview_Click(panel, EventArgs.Empty);
			}

			await ScanLocalNetworkAsync();
		}
		private async Task ScanLocalNetworkAsync()
		{
			_lobbyPreviewNumber = 0;
			ActiveControl = null;
			buttonRefresh.Visible = false;
			UseWaitCursor = true;
			ClearLobbyPreviews();
			await _localNetworkScanner.ScanLocalNetworkAsync();
			UseWaitCursor = false;
			buttonRefresh.Visible = true;
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

			NetworkGameSettingsForm gameSettingsForm = new NetworkGameSettingsForm(_mainForm, _player, _roundManager, this);
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

		private void ButtonJoin_Click(object sender, EventArgs e)
		{
			CustomMessageBox.Show(_selectedIP);
		}

		private void StartNetworkGameForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			ClearLobbyPreviews();

			_buttonEventHandlers.UnsubscribeAll();
			if (NeedToShowMainForm)
				_mainForm.Show();
		}
	}
}