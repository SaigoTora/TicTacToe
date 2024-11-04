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
using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToe.Models.Utilities.FormUtilities.ControlEventHandlers;

namespace TicTacToe.Forms.Game.NetworkGame
{
	internal partial class StartNetworkGameForm : BaseForm
	{
		private const int LOBBY_PREVIEW_PANEL_HEIGHT = 125;
		private const int LOBBY_PREVIEW_LABEL_MARGIN_LEFT = 35;

		private (Color Default, Color Selected, Color Hovered) _lobbyPreviewPanelColor =
			(Color.FromArgb(50, 50, 50), Color.FromArgb(200, 75, 105, 75), Color.FromArgb(200, 65, 65, 65));

		internal bool NeedToShowMainForm = true;

		private readonly MainForm _mainForm;
		private readonly Player _player;

		private readonly GameClient _gameClient;
		private readonly LocalNetworkScanner _localNetworkScanner;
		private readonly Dictionary<Guna2Panel, string> _gamePanelsToIP = new Dictionary<Guna2Panel, string>();

		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private string _selectedfullIPAddress;
		private int _lobbyPreviewNumber;

		internal StartNetworkGameForm(MainForm mainForm, Player player)
		{
			InitializeComponent();

			_mainForm = mainForm;
			_player = player;

			_gameClient = new GameClient();
			int port = int.Parse(ConfigurationManager.AppSettings["port"]);
			_localNetworkScanner = new LocalNetworkScanner(_gameClient, port, CreateLobbyPreview);

			customTitleBar = new CustomTitleBar(this, "Start Local Game", minimizeBox: false, maximizeBox: false);
		}
		private async void StartNetworkGameForm_Load(object sender, EventArgs e)
		{
			_buttonEventHandlers.SubscribeToHover(buttonCreateGame, buttonJoin);
			await ScanLocalNetworkAsync();
		}

		#region Lobby Previews
		private void CreateLobbyPreview(object sender, LobbyPreviewEventArgs e)
		{
			Guna2Panel panel = CreateLobbyPreviewPanel();
			Label labelOpponentName = CreateOpponentNameLabel($"#{Interlocked.Increment(ref _lobbyPreviewNumber)}  {e.NetworkGameSettings.OpponentName}");
			Label labelDescription = CreateDescriptionLabel(e.NetworkGameSettings.Description);
			PictureBox pictureBoxCoin = CreateCoinPictureBox();
			Label labelCoinsBet = CreateCoinsBetLabel(e.NetworkGameSettings.CoinsBet,
				pictureBoxCoin.Width + pictureBoxCoin.Location.X);
			Label labelPlayers = CreatePlayersLabel(e.NetworkGameSettings.CurrentPlayerCount, e.NetworkGameSettings.MaxPlayerCount);

			panel.Controls.Add(labelOpponentName);
			panel.Controls.Add(labelDescription);
			panel.Controls.Add(pictureBoxCoin);
			panel.Controls.Add(labelCoinsBet);
			panel.Controls.Add(labelPlayers);

			ManageLobbyPreviewHover(panel, true);
			foreach (Control child in panel.Controls)
			{
				child.Click += LobbyPreview_Click;
				child.DoubleClick += LobbyPreview_DoubleClick;
			}

			_gamePanelsToIP.Add(panel, $"{e.IPAddress}:{e.Port}");
		}
		private Guna2Panel CreateLobbyPreviewPanel()
		{
			const int PANEL_WIDTH_MARGIN = 17;// Indentation to fit the slider
			const int PANEL_BOTTOM_MARGIN = 12;

			Guna2Panel panel = new Guna2Panel
			{
				Parent = flpLobbyPreviews,
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
		private Label CreateOpponentNameLabel(string name)
		{
			const int LABEL_MARGIN_TOP = 6;

			Label label = new Label
			{
				AutoSize = true,
				ForeColor = Color.White,
				BackColor = Color.Transparent,
				Text = name,
				Font = new Font("Trebuchet MS", 17F, FontStyle.Bold),
				Location = new Point(LOBBY_PREVIEW_LABEL_MARGIN_LEFT, LABEL_MARGIN_TOP)
			};

			return label;
		}
		private Label CreateDescriptionLabel(string description)
		{
			const int LABEL_WIDTH = 450;

			Label label = new Label
			{
				AutoSize = false,
				Size = new Size(LABEL_WIDTH, LOBBY_PREVIEW_PANEL_HEIGHT / 2),
				ForeColor = Color.Gainsboro,
				BackColor = Color.Transparent,
				Text = description,
				Font = new Font("Trebuchet MS", 10F, FontStyle.Regular),
			};
			label.Location = new Point(LOBBY_PREVIEW_LABEL_MARGIN_LEFT,
				(LOBBY_PREVIEW_PANEL_HEIGHT + label.Height) / 3);

			return label;
		}
		private PictureBox CreateCoinPictureBox()
		{
			const int PICTURE_SIZE = 45;
			const int PICTURE_MARGIN_LEFT = 500;

			PictureBox pictureBox = new PictureBox
			{
				Size = new Size(PICTURE_SIZE, PICTURE_SIZE),
				SizeMode = PictureBoxSizeMode.Zoom,
				BackColor = Color.Transparent,
				Image = Properties.Resources.coin,
				Location = new Point(PICTURE_MARGIN_LEFT, (LOBBY_PREVIEW_PANEL_HEIGHT - PICTURE_SIZE) / 2)
			};

			return pictureBox;
		}
		private Label CreateCoinsBetLabel(int coinsBet, int labelMarginLeft)
		{
			string coinsBetText = coinsBet == 0 ?
				"Free" :
				$"{coinsBet:N0}".Replace(',', ' ');
			Label label = new Label
			{
				AutoSize = true,
				ForeColor = Color.Khaki,
				BackColor = Color.Transparent,
				Text = coinsBetText,
				Font = new Font("Courier New", 18F, FontStyle.Bold),
			};
			label.Location = new Point(labelMarginLeft, (LOBBY_PREVIEW_PANEL_HEIGHT - label.Font.Height) / 2);

			if (_player.Coins < coinsBet)
				label.ForeColor = Color.FromArgb(191, 34, 51);

			return label;
		}
		private Label CreatePlayersLabel(int currentPlayerCount, int maxPlayerCount)
		{
			const int LABEL_MARGIN_LEFT = 650;
			const int LABEL_WIDTH = 90;

			Label label = new Label
			{
				AutoSize = false,
				TextAlign = ContentAlignment.MiddleRight,
				ForeColor = Color.White,
				BackColor = Color.Transparent,
				Text = $"{currentPlayerCount} / {maxPlayerCount}",
				Font = new Font("Trebuchet MS", 16F, FontStyle.Regular),
			};
			label.Size = new Size(LABEL_WIDTH, label.Font.Height);
			label.Location = new Point(LABEL_MARGIN_LEFT, (LOBBY_PREVIEW_PANEL_HEIGHT - label.Font.Height) / 2);
			if (currentPlayerCount >= maxPlayerCount)
				label.ForeColor = Color.FromArgb(191, 34, 51);

			return label;
		}

		private void LobbyPreview_Click(object sender, EventArgs e)
		{
			Guna2Panel panel = FindPanelOrNull(sender);
			if (panel == null)
				return;

			string newSelectedIP = _gamePanelsToIP[panel];
			if (_selectedfullIPAddress == newSelectedIP)
			{
				_selectedfullIPAddress = string.Empty;
				panel.FillColor = _lobbyPreviewPanelColor.Default;
				buttonJoin.Enabled = false;
			}
			else
			{
				_selectedfullIPAddress = newSelectedIP;
				foreach (Guna2Panel item in _gamePanelsToIP.Keys)
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

			_selectedfullIPAddress = _gamePanelsToIP[panel];
			ButtonJoin_Click(sender, e);
		}
		private void ManageLobbyPreviewHover(Guna2Panel panel, bool subscribe)
		{
			if (subscribe)
			{
				panel.MouseEnter += LobbyPreview_MouseEnter;
				panel.MouseLeave += LobbyPreview_MouseLeave;
				foreach (Control child in panel.Controls)
				{
					child.MouseEnter += LobbyPreview_MouseEnter;
					child.MouseLeave += LobbyPreview_MouseLeave;
				}
			}
			else
			{
				panel.MouseEnter -= LobbyPreview_MouseEnter;
				panel.MouseLeave -= LobbyPreview_MouseLeave;
				foreach (Control child in panel.Controls)
				{
					child.MouseEnter -= LobbyPreview_MouseEnter;
					child.MouseLeave -= LobbyPreview_MouseLeave;
				}
			}
		}
		private void LobbyPreview_MouseEnter(object sender, EventArgs e)
		{
			Guna2Panel panel = FindPanelOrNull(sender);
			if (panel == null) return;
			if (_gamePanelsToIP[panel] == _selectedfullIPAddress) return;

			panel.FillColor = _lobbyPreviewPanelColor.Hovered;
			foreach (Guna2Panel item in _gamePanelsToIP.Keys)
			{
				if (item == _gamePanelsToIP.FirstOrDefault(ip => ip.Value == _selectedfullIPAddress).Key)
					continue;
				else if (item != panel)
					item.FillColor = _lobbyPreviewPanelColor.Default;
			}
		}
		private void LobbyPreview_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is Guna2Panel panel)) return;
			if (_gamePanelsToIP[panel] == _selectedfullIPAddress) return;

			panel.FillColor = _lobbyPreviewPanelColor.Default;
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
			foreach (Guna2Panel panel in _gamePanelsToIP.Keys)
			{
				ManageLobbyPreviewHover(panel, false);
				foreach (Control child in panel.Controls)
				{
					child.Click -= LobbyPreview_Click;
					child.Click -= LobbyPreview_DoubleClick;
				}
				panel.Click -= LobbyPreview_Click;
				panel.Click -= LobbyPreview_DoubleClick;
				panel.Dispose();
			}
			_gamePanelsToIP.Clear();
		}
		#endregion

		private async void ButtonRefresh_Click(object sender, EventArgs e)
		{
			if (_selectedfullIPAddress != null && _selectedfullIPAddress != string.Empty)
			{// Click on the selected panel to remove the selection.
				Guna2Panel panel = _gamePanelsToIP.FirstOrDefault(ip => ip.Value == _selectedfullIPAddress).Key;
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

			NetworkGameSettingsForm gameSettingsForm = new NetworkGameSettingsForm(_mainForm, _player, this);
			gameSettingsForm.FormClosed += (s, args) =>
			{
				if (!IsDisposed)
					Show();
			};
			Hide();
			gameSettingsForm.Show();
		}
		private bool IsRunningAsAdministrator()
		{
			WindowsIdentity identity = WindowsIdentity.GetCurrent();
			WindowsPrincipal principal = new WindowsPrincipal(identity);
			return principal.IsInRole(WindowsBuiltInRole.Administrator);
		}
		private void RestartAsAdmin()
		{
			try
			{
				var startInfo = new ProcessStartInfo($"{Process.GetCurrentProcess().ProcessName}.exe") { Verb = "runas" };
				Serializator.Serialize(_player, Program.SerializePath, Program.EncryptKey);
				Process.Start(startInfo);
				Environment.Exit(0);
			}
			catch (System.ComponentModel.Win32Exception)
			{
				CustomMessageBox.Show("Without running the application as an administrator, " +
					"you will not be able to create a game on a local network.", "Error",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
			}
		}

		private async void ButtonJoin_Click(object sender, EventArgs e)
		{
			NetworkGameSettings gameSettings = await _gameClient.JoinGameLobbyAsync(_selectedfullIPAddress, _player);
			GameLobbyForm gameLobbyForm = new GameLobbyForm(_mainForm, _player, gameSettings, _gameClient);
			gameLobbyForm.Show();

			NeedToShowMainForm = false;
			Close();
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