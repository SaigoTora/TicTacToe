using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using TicTacToe.Models.GameClientServer;
using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToe.Models.Utilities.FormUtilities.ControlEventHandlers;

namespace TicTacToe.Forms.Game.NetworkGame
{
	internal partial class GameLobbyForm : BaseForm
	{
		private static readonly (Color Default, Color Selected) _fieldSizeColor = (Color.Transparent, Color.Green);
		private static readonly (Color Default, Color Selected) _enableButtonsForeColor = (Color.Transparent, Color.Khaki);

		private readonly MainForm _mainForm;
		private readonly Player _player;

		private readonly GameServer _gameServer;
		private readonly Dictionary<string, Guna2Panel> _ipToGamePanels = new Dictionary<string, Guna2Panel>();

		private readonly SynchronizationContext _syncContext;
		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();

		internal GameLobbyForm(MainForm mainForm, Player player)
		{
			customTitleBar = new CustomTitleBar(this, "Lobby");
			IsResizable = true;
			InitializeComponent();

			_mainForm = mainForm;
			_player = player;
			_syncContext = SynchronizationContext.Current;
			PlayerJoined(this, new LocalPlayerEventArgs(_player));

			int port = int.Parse(ConfigurationManager.AppSettings["port"]);
			_gameServer = new GameServer(_player, port);
			SetServerForm();
			_gameServer.Start();
			_gameServer.PlayerJoined += PlayerJoined;
		}
		internal GameLobbyForm(MainForm mainForm, Player player, NetworkGameSettings gameSettings)
		{
			customTitleBar = new CustomTitleBar(this, "Lobby");
			IsResizable = true;
			InitializeComponent();

			_mainForm = mainForm;
			_player = player;
			MakeEnabledButtonsNonInteractive();
			SetClientForm(gameSettings);
		}
		private void GameLobbyForm_Load(object sender, EventArgs e)
			=> labelCoins.Text = $"{_player.Coins:N0}".Replace(',', ' ');

		private void SetServerForm()
		{
			Label labelFieldSize = GetLabelByFieldSize(_player.NetworkGameSettings.FieldSize);
			LabelFieldSize_Click(labelFieldSize, EventArgs.Empty);
			numericUpDownNumberOfRounds.BackColor = BackColor;
			numericUpDownNumberOfRounds.Value = _player.NetworkGameSettings.NumberOfRounds;
			numericUpDownCoinsBet.BackColor = BackColor;
			numericUpDownCoinsBet.Value = _player.NetworkGameSettings.CoinsBet;
			numericUpDownCoinsBet.Maximum = Math.Min(_player.Coins, numericUpDownCoinsBet.Maximum);

			if (_player.NetworkGameSettings.IsTimerEnabled)
				SetActiveEnableButtonStyle(buttonTimerEnabled);
			if (_player.NetworkGameSettings.IsGameAssistsEnabled)
				SetActiveEnableButtonStyle(buttonGameAssistsEnabled);
			buttonStart.Visible = true;

			_buttonEventHandlers.SubscribeToHover(buttonStart);
			_labelEventHandlers.SubscribeToHoverUnderline(label3on3, label5on5, label7on7);
		}

		#region Client Form Settings
		private void MakeEnabledButtonsNonInteractive()
		{
			buttonTimerEnabled.Cursor = Cursors.Default;
			buttonGameAssistsEnabled.Cursor = Cursors.Default;
			buttonTimerEnabled.BackColor = BackColor;
			buttonGameAssistsEnabled.BackColor = BackColor;

			buttonTimerEnabled.Click -= ButtonTimerEnabled_Click;
			buttonGameAssistsEnabled.Click -= ButtonGameAssistsEnabled_Click;

			buttonTimerEnabled.MouseEnter -= EnabledButton_MouseEnter;
			buttonGameAssistsEnabled.MouseEnter -= EnabledButton_MouseEnter;

			buttonTimerEnabled.MouseLeave -= EnabledButton_MouseLeave;
			buttonGameAssistsEnabled.MouseLeave -= EnabledButton_MouseLeave;
		}

		private void SetClientForm(NetworkGameSettings gameSettings)
		{
			SetClientFieldSize(gameSettings.FieldSize);
			SetClientNumberOfRounds(gameSettings.NumberOfRounds);
			SetClientCoinsBet(gameSettings.CoinsBet);
			if (gameSettings.IsTimerEnabled)
				SetActiveEnableButtonStyle(buttonTimerEnabled);
			if (gameSettings.IsGameAssistsEnabled)
				SetActiveEnableButtonStyle(buttonGameAssistsEnabled);
			buttonReady.Visible = true;

			_buttonEventHandlers.SubscribeToHover(buttonReady);
		}
		private void SetClientFieldSize(FieldSize fieldSize)
		{
			label3on3.Visible = false;
			label5on5.Visible = false;
			label7on7.Visible = false;
			string field;

			switch (fieldSize)
			{
				case FieldSize.Size3on3:
					field = "3 x 3";
					break;
				case FieldSize.Size5on5:
					field = "5 x 5";
					break;
				case FieldSize.Size7on7:
					field = "7 x 7";
					break;
				default:
					throw new InvalidOperationException
						($"Unknown field size: {fieldSize}");
			}
			labelFieldSize.Text += "  " + field;
		}
		private void SetClientNumberOfRounds(int numberOfRounds)
		{
			numericUpDownNumberOfRounds.Visible = false;
			labelNumberOfRounds.Text += "  " + numberOfRounds;
		}
		private void SetClientCoinsBet(int coinsBet)
		{
			numericUpDownCoinsBet.Visible = false;
			string coinsBetText = coinsBet == 0 ?
				"Free" :
				$"{coinsBet:N0}".Replace(',', ' ');

			Label coinsLabel = new Label()
			{
				AutoSize = false,
				Size = numericUpDownCoinsBet.Size,
				Location = numericUpDownCoinsBet.Location,
				Text = coinsBetText,
				TextAlign = ContentAlignment.MiddleCenter,
				ForeColor = Color.Khaki,
				BackColor = Color.Transparent,
				Font = new Font("Courier New", 20F, FontStyle.Bold),
			};
			Controls.Add(coinsLabel);
		}
		#endregion

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
		private void NumericUpDownCoinsBet_ValueChanged(object sender, EventArgs e)
			=> _player.NetworkGameSettings.CoinsBet = (int)numericUpDownCoinsBet.Value;

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

		#region Create Joined Players
		private void PlayerJoined(object sender, LocalPlayerEventArgs e)
		{
			_syncContext.Post(_ =>
			{
				Guna2Panel panel = CreatePlayerPanel();

				string avatarName = e.Player.VisualSettings.Avatar.Name;
				Avatar avatar = new Avatar(avatarName, 0, string.Empty, null, AvatarRarity.Common);
				avatar = (Avatar)ItemManager.GetFullItem(avatar);
				PictureBox pictureBoxAvatar = CreatePlayerAvatarPictureBox(avatar);
				Label labelName = CreatePlayerNameLabel(e.Player.Name);
				IconPictureBox iconPictureBoxReady = CreatePlayerCheckReady(false);

				panel.Controls.Add(pictureBoxAvatar);
				panel.Controls.Add(labelName);
				panel.Controls.Add(iconPictureBoxReady);

				flpPlayers.Controls.Add(panel);

				if (e.HasIPAddress())
					_ipToGamePanels[e.IPAddress] = panel;
			}, null);
		}

		private Guna2Panel CreatePlayerPanel()
		{
			Guna2Panel panel = new Guna2Panel()
			{
				BackColor = Color.FromArgb(50, 50, 50),
				Size = new Size(244, 76),
			};

			return panel;
		}
		private PictureBox CreatePlayerAvatarPictureBox(Avatar avatar)
		{
			PictureBox pictureBox = new PictureBox()
			{
				Image = avatar.Image,
				BackColor = Color.Transparent,
				Location = new Point(3, 3),
				Size = new Size(70, 70),
				SizeMode = PictureBoxSizeMode.Zoom,
			};

			return pictureBox;
		}
		private Label CreatePlayerNameLabel(string name)
		{
			Label label = new Label()
			{
				Text = name,
				BackColor = Color.Transparent,
				FlatStyle = FlatStyle.Flat,
				Font = new Font("Trebuchet MS", 10F, FontStyle.Bold),
				ForeColor = Color.White,
				Location = new Point(74, 3),
				AutoSize = false,
				Size = new Size(167, 36),
				TextAlign = ContentAlignment.MiddleLeft,
			};

			return label;
		}
		private IconPictureBox CreatePlayerCheckReady(bool ready)
		{
			IconPictureBox iconPictureBox = new IconPictureBox()
			{
				Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
				BackColor = Color.Transparent,
				IconChar = IconChar.Circle,
				IconColor = Color.White,
				IconFont = IconFont.Auto,
				IconSize = 30,
				Location = new Point(213, 45),
				Size = new Size(30, 30),
			};

			return iconPictureBox;
		}
		#endregion

		private void ButtonReady_Click(object sender, EventArgs e)
		{

		}
		private void ButtonStart_Click(object sender, EventArgs e)
		{
			if (numericUpDownNumberOfRounds.Value % 2 != 0)
			{
				CustomMessageBox.Show("The number of rounds must be an even number.",
					"Error", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				return;
			}
		}
		private void GameLobbyForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_buttonEventHandlers.UnsubscribeAll();
			_labelEventHandlers.UnsubscribeAll();

			foreach (Guna2Panel panel in _ipToGamePanels.Values)
				panel.Dispose();
			_ipToGamePanels.Clear();

			if (_gameServer != null)
			{
				_gameServer.PlayerJoined -= PlayerJoined;
				_gameServer?.Stop();
			}

			_mainForm.Show();
		}
	}
}