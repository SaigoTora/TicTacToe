using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using TicTacToe.Forms.Game.Games3on3;
using TicTacToe.Models.GameClientServer.Core;
using TicTacToe.Models.GameClientServer.Lobby;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToe.Models.Utilities.FormUtilities.ControlEventHandlers;
using TicTacToeLibrary;

namespace TicTacToe.Forms.Game.NetworkGame
{
	internal partial class GameLobbyServerForm : BaseForm
	{
		private static readonly (Color Default, Color Selected) _fieldSizeColor
			= (Color.Transparent, Color.Green);
		private static readonly (Color Default, Color Selected) _enableButtonsForeColor
			= (Color.Transparent, Color.Khaki);

		private readonly MainForm _mainForm;
		private readonly Player _player;

		private readonly GameServer _gameServer;
		private readonly Dictionary<string, Guna2Panel> _ipToGamePanels = new Dictionary<string, Guna2Panel>();

		private readonly SynchronizationContext _syncContext;
		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();

		private bool _isGameStarted;

		internal GameLobbyServerForm(MainForm mainForm, Player player)
		{
			InitializeComponent();
			customTitleBar = new CustomTitleBar(this, "Lobby", maximizeBox: false);

			_mainForm = mainForm;
			_player = player;
			_syncContext = SynchronizationContext.Current;

			int port = int.Parse(ConfigurationManager.AppSettings["port"]);
			_gameServer = new GameServer(_player, port);
		}
		private void GameLobbyServerForm_Load(object sender, EventArgs e)
		{
			labelCoins.Text = $"{_player.Coins:N0}".Replace(',', ' ');
			PlayerJoined(this, new NetworkPlayerEventArgs(
				new NetworkPlayer(_player.Name, _player.VisualSettings, true)));

			SetServerForm();
			_gameServer.Start();
			ManageServerEventHandlers(true);
		}

		private void SetServerForm()
		{
			Label labelFieldSize = GetLabelByFieldSize(_player.NetworkGameSettings.FieldSize);
			LabelFieldSize_Click(labelFieldSize, EventArgs.Empty);
			numericUpDownNumberOfRounds.BackColor = BackColor;
			numericUpDownNumberOfRounds.Value = _player.NetworkGameSettings.NumberOfRounds;
			string coinsBetText = _player.NetworkGameSettings.CoinsBet == 0 ?
				"Free" :
				$"{_player.NetworkGameSettings.CoinsBet:N0}".Replace(',', ' ');
			labelValueCoinsBet.Text = coinsBetText;

			if (_player.NetworkGameSettings.IsTimerEnabled)
				SetActiveEnableButtonStyle(buttonTimerEnabled);
			if (_player.NetworkGameSettings.IsGameAssistsEnabled)
				SetActiveEnableButtonStyle(buttonGameAssistsEnabled);

			_buttonEventHandlers.SubscribeToHover(buttonStart);
			_labelEventHandlers.SubscribeToHoverUnderline(label3on3, label5on5, label7on7);
		}
		private void ManageServerEventHandlers(bool subscribe)
		{
			if (subscribe)
			{
				_gameServer.PlayerJoined += PlayerJoined;
				_gameServer.PlayerStatusChanged += PlayerStatusChanged;
				_gameServer.PlayerLeftLobby += PlayerLeftLobby;
			}
			else
			{
				_gameServer.PlayerJoined -= PlayerJoined;
				_gameServer.PlayerStatusChanged -= PlayerStatusChanged;
				_gameServer.PlayerLeftLobby -= PlayerLeftLobby;
			}
		}

		#region Field Size
		private Label GetLabelByFieldSize(FieldSize fieldSize)
		{
			switch (fieldSize)
			{
				case FieldSize.Size3on3:
					return label3on3;
				case FieldSize.Size5on5:
					return label5on5;
				case FieldSize.Size7on7:
					return label7on7;
				default:
					throw new InvalidOperationException
						($"Unknown field size: {fieldSize}");
			}
		}
		private void LabelFieldSize_Click(object sender, EventArgs e)
		{
			if (!(sender is Label label))
				return;

			label.BackColor = _fieldSizeColor.Selected;
			label.Enabled = false;
			if (label == label3on3)
			{
				SetDefaultFieldSizeLabels(label5on5, label7on7);
				_player.NetworkGameSettings.FieldSize = FieldSize.Size3on3;
			}
			else if (label == label5on5)
			{
				SetDefaultFieldSizeLabels(label3on3, label7on7);
				_player.NetworkGameSettings.FieldSize = FieldSize.Size5on5;
			}
			else
			{
				SetDefaultFieldSizeLabels(label3on3, label5on5);
				_player.NetworkGameSettings.FieldSize = FieldSize.Size7on7;
			}
		}
		private void SetDefaultFieldSizeLabels(params Label[] labels)
		{
			foreach (Label label in labels)
			{
				label.BackColor = _fieldSizeColor.Default;
				label.Enabled = true;
			}
		}
		#endregion

		private void NumericUpDownNumberOfRounds_ValueChanged(object sender, EventArgs e)
			=> _player.NetworkGameSettings.NumberOfRounds =
			(int)numericUpDownNumberOfRounds.Value;

		#region Enable Buttons
		private void ButtonTimerEnabled_Click(object sender, EventArgs e)
		{
			ActiveControl = null;
			if (!_player.NetworkGameSettings.IsTimerEnabled)
				SetActiveEnableButtonStyle(buttonTimerEnabled);
			else
				SetDefaultEnableButtonStyle(buttonTimerEnabled);

			_player.NetworkGameSettings.IsTimerEnabled = !_player.NetworkGameSettings.IsTimerEnabled;
		}
		private void ButtonGameAssistsEnabled_Click(object sender, EventArgs e)
		{
			ActiveControl = null;
			if (!_player.NetworkGameSettings.IsGameAssistsEnabled)
				SetActiveEnableButtonStyle(buttonGameAssistsEnabled);
			else
				SetDefaultEnableButtonStyle(buttonGameAssistsEnabled);

			_player.NetworkGameSettings.IsGameAssistsEnabled = !_player.NetworkGameSettings.IsGameAssistsEnabled;
		}

		private void SetActiveEnableButtonStyle(IconButton button)
		{
			button.IconChar = IconChar.CircleCheck;
			button.IconColor = Color.Lime;
			button.ForeColor = Color.White;
		}
		private void SetDefaultEnableButtonStyle(IconButton button)
		{
			button.IconChar = IconChar.Circle;
			button.IconColor = Color.White;
			button.ForeColor = Color.White;
		}

		private void EnabledButton_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is IconButton iconButton))
				return;

			if (_player.NetworkGameSettings.IsTimerEnabled && iconButton == buttonTimerEnabled
				|| _player.NetworkGameSettings.IsGameAssistsEnabled && iconButton == buttonGameAssistsEnabled)
				return;

			iconButton.ForeColor = _enableButtonsForeColor.Selected;
		}
		private void EnabledButton_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is IconButton iconButton))
				return;

			iconButton.ForeColor = _enableButtonsForeColor.Default;
		}
		#endregion

		private void PlayerJoined(object sender, NetworkPlayerEventArgs e)
		{
			const int PANEL_WIDTH = 244, PANEL_HEIGHT = 76;

			_syncContext.Post(_ =>
			{
				string avatarName = e.Player.VisualSettings.Avatar.Name;
				Avatar avatar = new Avatar(avatarName, 0, string.Empty, null, AvatarRarity.Common);
				avatar = (Avatar)ItemManager.GetFullItem(avatar);
				e.Player.VisualSettings.Avatar = avatar;

				Guna2Panel panel = NetworkPlayerCreator.CreatePlayerPanel(e.Player,
					new Size(PANEL_WIDTH, PANEL_HEIGHT));
				flpPlayers.Controls.Add(panel);

				if (_gameServer.GetOpponents().Count + 1 == _gameServer.GetMaxPlayerCount())
					buttonStart.Enabled = true;

				if (e.HasIPAddress())
					_ipToGamePanels.Add(e.IPAddress, panel);
			}, null);
		}

		private void PlayerStatusChanged(object sender, NetworkPlayerEventArgs e)
		{
			_syncContext.Post(_ =>
			{
				if (!string.IsNullOrEmpty(e.IPAddress) && _ipToGamePanels.ContainsKey(e.IPAddress))
					NetworkPlayerCreator.ChangePlayerPanel(_ipToGamePanels[e.IPAddress], e.Player);
			}, null);
		}
		private void PlayerLeftLobby(object sender, NetworkPlayerEventArgs e)
		{
			if (!string.IsNullOrEmpty(e.IPAddress))
			{
				buttonStart.Enabled = false;

				_ipToGamePanels[e.IPAddress].Dispose();
				_ipToGamePanels.Remove(e.IPAddress);
			}
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			if (numericUpDownNumberOfRounds.Value % 2 != 0)
			{
				CustomMessageBox.Show("The number of rounds must be an even number.",
					"Error", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				return;
			}
			if (!_gameServer.AllPlayersReady())
			{
				CustomMessageBox.Show("All players must be ready before the start of the game.",
					"Error", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				return;
			}

			_isGameStarted = true;
			NetworkGameSettings settings = _player.NetworkGameSettings;
			RoundManager roundManager = new RoundManager(settings.NumberOfRounds);
			NetworkPlayer opponent = _gameServer.GetOpponents()[0];
			Game3on3NetworkForm gameForm = new Game3on3NetworkForm(_mainForm, _player, _gameServer,
				roundManager, settings.CoinsBet, CellType.Cross,
				settings.IsTimerEnabled, settings.IsGameAssistsEnabled,
				opponent.VisualSettings.Avatar.Image, opponent.Name);

			Close();
			gameForm.Show();
		}

		private void ClearPlayers()
		{
			foreach (Guna2Panel panel in _ipToGamePanels.Values)
				panel.Dispose();
			_ipToGamePanels.Clear();
		}
		private void GameLobbyServerForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_buttonEventHandlers.UnsubscribeAll();
			_labelEventHandlers.UnsubscribeAll();

			ClearPlayers();
			ManageServerEventHandlers(false);
			if (!_isGameStarted)
			{
				_gameServer.Stop();
				_mainForm.Show();
			}
		}
	}
}