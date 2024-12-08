using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using TicTacToe.Forms.Game.Games3on3;
using TicTacToe.Forms.Game.Games5on5;
using TicTacToe.Forms.Game.Games7on7;
using TicTacToe.Models.GameClientServer.Chat;
using TicTacToe.Models.GameClientServer.Core;
using TicTacToe.Models.GameClientServer.Lobby;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToe.Models.Utilities.FormUtilities.ControlEventHandlers;
using TicTacToeLibrary.Core;
using TicTacToeLibrary.GameLogic;

namespace TicTacToe.Forms.Game.NetworkGame
{
	internal partial class GameLobbyServerForm : BaseForm
	{
		private static readonly (Color Default, Color Selected) _fieldSizeColor
			= (Color.Transparent, Color.FromArgb(25, 100, 55));
		private static readonly (Color Default, Color Selected) _enableButtonsForeColor
			= (Color.Transparent, Color.Khaki);

		private readonly MainForm _mainForm;
		private readonly Player _player;

		private readonly GameServer _gameServer;
		private readonly Dictionary<string, Guna2Panel> _ipToGamePanels = new Dictionary<string, Guna2Panel>();

		private readonly NetworkPlayerCreator _playerCreator;
		private readonly SynchronizationContext _syncContext;
		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();

		private bool _isGameStarted;

		internal GameLobbyServerForm(MainForm mainForm, Player player)
		{
			const int PANEL_WIDTH = 244, PANEL_HEIGHT = 76;

			InitializeComponent();
			customTitleBar = new CustomTitleBar(this, "Lobby", Properties.Resources.lobby, maximizeBox: false);

			_mainForm = mainForm;
			_player = player;
			_syncContext = SynchronizationContext.Current;

			int port = int.Parse(ConfigurationManager.AppSettings["port"]);
			_gameServer = new GameServer(_player, port);

			_playerCreator = new NetworkPlayerCreator(new Size(PANEL_WIDTH, PANEL_HEIGHT), PlayerKickButton_Click);
		}
		private void GameLobbyServerForm_Load(object sender, EventArgs e)
		{
			labelCoins.Text = $"{_player.Coins:N0}".Replace(',', ' ');
			richTextBoxChat.SelectionIndent = 15;
			richTextBoxChat.BackColor = BackColor;

			DisplayMessage(new Models.GameClientServer.Chat.Message(string.Empty, "Welcome to the chat!"), false);
			PlayerJoined(this, new NetworkPlayerEventArgs(
				new NetworkPlayer(_player.Name, _player.VisualSettings, true)));

			SetServerForm();
			try
			{
				_gameServer.Start();
			}
			catch (System.Net.HttpListenerException)
			{
				CustomMessageBox.Show("Failed to start the game server! " +
					"It looks like a server is already running at this address.",
					"Server Error", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				Close();
			}
			ManageServerEventHandlers(true);
		}

		private void SetServerForm()
		{
			Label labelFieldSize = GetLabelByFieldSize(_player.NetworkGameSettings.FieldSize);
			LabelFieldSize_Click(labelFieldSize, EventArgs.Empty);
			comboBoxGameMode.SelectedIndex = (int)_player.NetworkGameSettings.GameMode;
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
				_gameServer.PlayerPostMessage += PlayerPostedMessage;
			}
			else
			{
				_gameServer.PlayerJoined -= PlayerJoined;
				_gameServer.PlayerStatusChanged -= PlayerStatusChanged;
				_gameServer.PlayerLeftLobby -= PlayerLeftLobby;
				_gameServer.PlayerPostMessage -= PlayerPostedMessage;
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

		private void ComboBoxGameMode_SelectedIndexChanged(object sender, EventArgs e)
			=> _player.NetworkGameSettings.GameMode = (GameMode)comboBoxGameMode.SelectedIndex;
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

		#region Server Event Handlers
		private void PlayerJoined(object sender, NetworkPlayerEventArgs e)
		{
			_syncContext.Post(_ =>
			{
				string avatarName = e.Player.VisualSettings.Avatar.Name;
				Avatar avatar = new Avatar(avatarName, 0, string.Empty, null, AvatarRarity.Common);
				avatar = (Avatar)ItemManager.GetFullItem(avatar);
				e.Player.VisualSettings.Avatar = avatar;

				Guna2Panel panel;
				if (e.HasIPAddress())
					panel = _playerCreator.CreatePlayerPanel(e.Player, true);
				else
					panel = _playerCreator.CreatePlayerPanel(e.Player, false);

				flpPlayers.Controls.Add(panel);
				ActiveControl = null;

				if (_gameServer.GetOpponents().Count + 1 == _gameServer.GetMaxPlayerCount())
					buttonStart.Enabled = true;

				if (e.HasIPAddress())
					_ipToGamePanels.Add(e.IPAddress, panel);
			}, null);
		}
		private void PlayerKickButton_Click(object sender, EventArgs e)
		{
			ActiveControl = null;

			if (sender is Control control && control.Parent is Guna2Panel parentPanel)
			{
				string ipAddress = _ipToGamePanels.FirstOrDefault((item) => item.Value == parentPanel).Key;
				NetworkPlayer kickedPlayer = _gameServer.GetPlayerByIp(ipAddress);

				if (ipAddress != null && CustomMessageBox.Show($"Are you sure you want to kick {kickedPlayer.Name} from the lobby?",
					"Kick", CustomMessageBoxButtons.YesNo, CustomMessageBoxIcon.Question) == DialogResult.Yes)
					_gameServer.DeletePlayerFromLobby(ipAddress);
			}

			ActiveControl = null;
		}
		private void PlayerStatusChanged(object sender, NetworkPlayerEventArgs e)
		{
			_syncContext.Post(_ =>
			{
				if (!string.IsNullOrEmpty(e.IPAddress) && _ipToGamePanels.ContainsKey(e.IPAddress))
					_playerCreator.ChangePlayerPanel(_ipToGamePanels[e.IPAddress], e.Player);
			}, null);
		}
		private void PlayerLeftLobby(object sender, NetworkPlayerEventArgs e)
		{
			if (!string.IsNullOrEmpty(e.IPAddress))
			{
				buttonStart.Enabled = false;

				_playerCreator.Dispose(_ipToGamePanels[e.IPAddress]);
				_ipToGamePanels.Remove(e.IPAddress);
			}
		}
		private void PlayerPostedMessage(object sender, ChatMessageEventArgs e)
			=> DisplayMessage(e.Message, false);
		#endregion

		#region Chat
		private void ButtonSendMessage_Click(object sender, EventArgs e)
		{
			textBoxMessage.Text = textBoxMessage.Text.Trim('\n', ' ');
			if (!string.IsNullOrEmpty(textBoxMessage.Text))
			{
				var message = new Models.GameClientServer.Chat.Message(_player.Name, textBoxMessage.Text);
				_gameServer.LobbyChat.AddMessage(message);
				DisplayMessage(message, true);
				textBoxMessage.Text = string.Empty;
				textBoxMessage.Multiline = false;
			}
		}
		private void DisplayMessage(Models.GameClientServer.Chat.Message message, bool isOwnMessage)
		{
			if (_gameServer.LobbyChat.CheckMessageLimit())
				RemoveFirstLineFromRichTextBox();

			richTextBoxChat.SelectionStart = richTextBoxChat.Text.Length;
			if (richTextBoxChat.Text.Length > 0)
				richTextBoxChat.SelectedText = "\n";
			DisplayTimeInMessage(message.Time.ToLocalTime());

			if (!string.IsNullOrEmpty(message.Sender))
				DisplaySenderInMessage(message.Sender, isOwnMessage);

			DisplayMessageText(message.Text);
			richTextBoxChat.ScrollToCaret();
		}
		private void RemoveFirstLineFromRichTextBox()
		{
			int firstLineEndIndex = richTextBoxChat.GetFirstCharIndexFromLine(1);

			if (firstLineEndIndex > 0)
			{
				richTextBoxChat.Select(firstLineEndIndex, richTextBoxChat.Text.Length - firstLineEndIndex);
				string remainingRtf = richTextBoxChat.SelectedRtf;

				richTextBoxChat.Rtf = remainingRtf; // Replace the current text with a new one
			}
		}
		private void DisplayTimeInMessage(DateTime dateTime)
		{
			richTextBoxChat.SelectionFont = new Font(richTextBoxChat.Font.FontFamily, 10, FontStyle.Regular);
			richTextBoxChat.SelectionColor = Color.Gray;
			richTextBoxChat.SelectedText = $"{dateTime:HH:mm}\t";
		}
		private void DisplaySenderInMessage(string sender, bool isOwnMessage)
		{
			richTextBoxChat.SelectionFont = new Font(richTextBoxChat.Font.FontFamily, 16, FontStyle.Bold);
			if (isOwnMessage)
				richTextBoxChat.SelectionColor = Color.FromArgb(255, 223, 0);
			else
				richTextBoxChat.SelectionColor = Color.White;

			richTextBoxChat.SelectedText = sender;

			richTextBoxChat.SelectionFont = new Font(richTextBoxChat.Font.FontFamily, 16, FontStyle.Regular);
			richTextBoxChat.SelectionColor = Color.White;
			richTextBoxChat.SelectedText = ":  ";
		}
		private void DisplayMessageText(string text)
		{
			richTextBoxChat.SelectionFont = new Font(richTextBoxChat.Font.FontFamily, 16, FontStyle.Regular);
			richTextBoxChat.SelectionColor = Color.LightGray;
			richTextBoxChat.SelectedText = text;
		}

		private void TextBoxMessage_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				ButtonSendMessage_Click(sender, e);
			}
		}
		private void TextBoxMessage_TextChanged(object sender, EventArgs e)
		{
			BeginInvoke(new Action(() =>
			{
				const int MULTILINE_HEIGHT = 75;
				const int SINGLELINE_HEIGHT = 50;
				const int MULTILINE_Y_POSITION = 313;
				const int SINGLELINE_Y_POSITION = 338;

				textBoxMessage.AutoScroll = false;
				Size textSize = TextRenderer.MeasureText(textBoxMessage.Text, textBoxMessage.Font);
				bool requiresMultiline = textSize.Width > textBoxMessage.Width || textSize.Height > SINGLELINE_HEIGHT;

				if (requiresMultiline)
				{
					textBoxMessage.Size = new Size(textBoxMessage.Width, MULTILINE_HEIGHT);
					textBoxMessage.Location = new Point(textBoxMessage.Location.X, MULTILINE_Y_POSITION);
					textBoxMessage.Multiline = true;
				}
				else
				{
					textBoxMessage.Size = new Size(textBoxMessage.Width, SINGLELINE_HEIGHT);
					textBoxMessage.Location = new Point(textBoxMessage.Location.X, SINGLELINE_Y_POSITION);
					textBoxMessage.Multiline = false;
				}
			}));
		}
		#endregion

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
			ShowGameForm(settings, new RoundManager(settings.NumberOfRounds),
				_gameServer.GetOpponents()[0]);
		}
		private void ShowGameForm(NetworkGameSettings settings, RoundManager roundManager,
			NetworkPlayer opponent)
		{
			BaseGameForm gameForm;

			switch (settings.FieldSize)
			{
				case FieldSize.Size3on3:
					{
						gameForm = new Game3on3NetworkForm(_mainForm, _player, _gameServer,
						settings.CoinsBet, roundManager, settings.GameMode, CellType.Cross,
						settings.IsTimerEnabled, settings.IsGameAssistsEnabled,
							opponent.VisualSettings.Avatar.Image, opponent.Name);
						break;
					}
				case FieldSize.Size5on5:
					{
						gameForm = new Game5on5NetworkForm(_mainForm, _player, _gameServer,
						settings.CoinsBet, roundManager, settings.GameMode, CellType.Cross,
						settings.IsTimerEnabled, settings.IsGameAssistsEnabled,
							opponent.VisualSettings.Avatar.Image, opponent.Name);
						break;
					}
				case FieldSize.Size7on7:
					{
						gameForm = new Game7on7NetworkForm(_mainForm, _player, _gameServer,
						settings.CoinsBet, roundManager, settings.GameMode, CellType.Cross,
						settings.IsTimerEnabled, settings.IsGameAssistsEnabled,
							opponent.VisualSettings.Avatar.Image, opponent.Name);
						break;
					}
				default:
					throw new InvalidOperationException
						($"Unknown field size: {_player.SinglePCGameSettings.FieldSize}");
			}
			Close();
			gameForm.Show();
		}

		private void ClearPlayers()
		{
			_playerCreator.Dispose();
			_ipToGamePanels.Clear();
		}
		private void GameLobbyServerForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				DialogResult result = CustomMessageBox.Show("Are you sure you want to leave this lobby?", "Exit",
					CustomMessageBoxButtons.YesNo, CustomMessageBoxIcon.Question);
				if (result == DialogResult.Yes)
					Close();
			}
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