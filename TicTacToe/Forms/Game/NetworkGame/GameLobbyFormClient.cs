using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
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
	internal partial class GameLobbyClientForm : BaseForm
	{
		private static readonly (Color Ready, Color Cancel) _buttonFillColor
			= (Color.SandyBrown, Color.FromArgb(127, 24, 13));
		private static readonly (Color Ready, Color Cancel) _buttonFillColor2
			= (Color.FromArgb(236, 124, 38), Color.Maroon);

		private const int LOBBY_UPDATE_INTERVAL = 2000;

		private readonly MainForm _mainForm;
		private readonly Player _player;

		private readonly GameClient _gameClient;
		private ChatManager _lobbyChat = new ChatManager();
		private readonly Dictionary<long, Guna2Panel> _idToGamePanels = new Dictionary<long, Guna2Panel>();

		private readonly System.Threading.Timer _updateTimer;
		private readonly NetworkPlayerCreator _playerCreator;
		private readonly PlayerLobbyStatus _playerStatus = new PlayerLobbyStatus();
		private readonly SynchronizationContext _syncContext;
		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private bool _wasUpdateExceptionThrown, _isGameStarted;
		internal GameLobbyClientForm(MainForm mainForm, Player player, GameClient gameClient)
		{
			const int PANEL_WIDTH = 244, PANEL_HEIGHT = 76;

			InitializeComponent();
			customTitleBar = new CustomTitleBar(this, "Lobby", Properties.Resources.lobby, maximizeBox: false);

			_mainForm = mainForm;
			_player = player;
			_syncContext = SynchronizationContext.Current;

			_gameClient = gameClient;
			DisplayMessage(new Models.GameClientServer.Chat.Message(string.Empty, "Welcome to the chat!"), false);
			_updateTimer = new System.Threading.Timer(UpdateTimerCallBack, null, 0, LOBBY_UPDATE_INTERVAL);

			_playerCreator = new NetworkPlayerCreator(new Size(PANEL_WIDTH, PANEL_HEIGHT));
		}
		private void GameLobbyClientForm_Load(object sender, EventArgs e)
		{
			labelCoins.Text = $"{_player.Coins:N0}".Replace(',', ' ');
			richTextBoxChat.BackColor = BackColor;

			_buttonEventHandlers.SubscribeToHover(buttonReady);
			buttonReady.FillColor = _buttonFillColor.Ready;
			buttonReady.FillColor2 = _buttonFillColor2.Ready;
		}

		#region Client Form Settings
		private void SetClientForm(NetworkLobbyInfo lobbyInfo)
		{
			_syncContext.Post(_ =>
			{
				if (lobbyInfo.HasGameStarted)
				{
					_isGameStarted = true;
					_updateTimer.Dispose();
					ShowGameForm(lobbyInfo);

					return;
				}

				DisplayClientFieldSize(lobbyInfo.Settings.FieldSize);
				labelNumberOfRounds.Text = "Number of rounds:  " + lobbyInfo.Settings.NumberOfRounds;
				labelGameMode.Text = "Game mode:  " + lobbyInfo.Settings.GameMode.ToString();
				DisplayClientCoinsBet(lobbyInfo.Settings.CoinsBet);
				DisplayEnableButtons(lobbyInfo.Settings.IsTimerEnabled,
					lobbyInfo.Settings.IsGameAssistsEnabled);
				DisplayPlayers(lobbyInfo);
			}, null);
		}
		private void ShowGameForm(NetworkLobbyInfo lobbyInfo)
		{
			BaseGameForm gameForm;
			RoundManager roundManager = new RoundManager(lobbyInfo.Settings.NumberOfRounds);
			GameMode gameMode = lobbyInfo.Settings.GameMode;

			switch (lobbyInfo.Settings.FieldSize)
			{
				case FieldSize.Size3on3:
					{
						gameForm = new Game3on3NetworkForm(_mainForm, _player, _gameClient,
							lobbyInfo.Settings.CoinsBet, roundManager, gameMode, CellType.Zero,
							lobbyInfo.Settings.IsTimerEnabled, lobbyInfo.Settings.IsGameAssistsEnabled,
							lobbyInfo.Settings.OpponentAvatar.Image, lobbyInfo.Settings.OpponentName);
						break;
					}
				case FieldSize.Size5on5:
					{
						gameForm = new Game5on5NetworkForm(_mainForm, _player, _gameClient,
							lobbyInfo.Settings.CoinsBet, roundManager, gameMode, CellType.Zero,
							lobbyInfo.Settings.IsTimerEnabled, lobbyInfo.Settings.IsGameAssistsEnabled,
							lobbyInfo.Settings.OpponentAvatar.Image, lobbyInfo.Settings.OpponentName);
						break;
					}
				case FieldSize.Size7on7:
					{
						gameForm = new Game7on7NetworkForm(_mainForm, _player, _gameClient,
							lobbyInfo.Settings.CoinsBet, roundManager, gameMode, CellType.Zero,
							lobbyInfo.Settings.IsTimerEnabled, lobbyInfo.Settings.IsGameAssistsEnabled,
							lobbyInfo.Settings.OpponentAvatar.Image, lobbyInfo.Settings.OpponentName);
						break;
					}
				default:
					throw new InvalidOperationException
						($"Unknown field size: {_player.SinglePCGameSettings.FieldSize}");
			}

			if (!panelChat.IsDisposed)
				panelChat?.Dispose();
			Close();
			gameForm.Show();
		}
		private void DisplayClientFieldSize(FieldSize fieldSize)
		{
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
			labelFieldSize.Text = "Field size:  " + field;
		}
		private void DisplayClientCoinsBet(int coinsBet)
		{
			string coinsBetText = coinsBet == 0 ?
				"Free" :
				$"{coinsBet:N0}".Replace(',', ' ');
			labelValueCoinsBet.Text = coinsBetText;
		}
		private void DisplayEnableButtons(bool isTimerEnabled, bool isGameAssistsEnabled)
		{
			if (isTimerEnabled)
				SetActiveEnableButtonStyle(buttonTimerEnabled);
			else
				SetDefaultEnableButtonStyle(buttonTimerEnabled);
			if (isGameAssistsEnabled)
				SetActiveEnableButtonStyle(buttonGameAssistsEnabled);
			else
				SetDefaultEnableButtonStyle(buttonGameAssistsEnabled);
		}
		private void DisplayPlayers(NetworkLobbyInfo info)
		{
			long serverPlayerId = DisplayServerPlayer(info.Settings.OpponentName, info.Settings.OpponentAvatar);
			foreach (long id in _idToGamePanels.Keys)
			{
				if (id == serverPlayerId)
					continue;

				if (info.Players.Exists((p) => p.Id == id))
					_playerCreator.ChangePlayerPanel(_idToGamePanels[id], info.GetPlayer(id));
				else
				{
					_playerCreator.Dispose(_idToGamePanels[id]);
					_idToGamePanels.Remove(id);
				}
			}
			foreach (var player in info.Players)
				if (!_idToGamePanels.ContainsKey(player.Id))
					CreatePlayer(player);
		}
		private long DisplayServerPlayer(string name, Avatar avatar)
		{
			PlayerVisualSettings serverVisualSettings = new PlayerVisualSettings
			{ Avatar = avatar };
			NetworkPlayer serverPlayer = new NetworkPlayer(name, serverVisualSettings);
			serverPlayer.SetReady(true);

			if (_idToGamePanels.ContainsKey(serverPlayer.Id))
				_playerCreator.ChangePlayerPanel(_idToGamePanels[serverPlayer.Id], serverPlayer);
			else
				CreatePlayer(serverPlayer);

			return serverPlayer.Id;
		}
		#endregion

		#region Chat
		private async void ButtonSendMessage_Click(object sender, EventArgs e)
		{
			textBoxMessage.Text = textBoxMessage.Text.Trim('\n', ' ');
			if (!string.IsNullOrEmpty(textBoxMessage.Text))
			{
				var message = new Models.GameClientServer.Chat.Message(_player.Name, textBoxMessage.Text);
				try
				{
					_lobbyChat = await _gameClient.SendMessageAsync(message);
					DisplayMessage(message, true);
					textBoxMessage.Text = string.Empty;
					textBoxMessage.Multiline = false;
				}
				catch (System.Net.Http.HttpRequestException)
				{
					if (!_wasUpdateExceptionThrown)
						HandleClientRequestError();
				}
			}
		}
		private void DisplayMessage(Models.GameClientServer.Chat.Message message, bool isOwnMessage)
		{
			if (_lobbyChat != null && _lobbyChat.CheckMessageLimit())
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

		private void CreatePlayer(NetworkPlayer player)
		{
			Guna2Panel panel = _playerCreator.CreatePlayerPanel(player, false);
			flpPlayers.Controls.Add(panel);

			_idToGamePanels.Add(player.Id, panel);
		}

		private async void UpdateTimerCallBack(object state)
			=> await UpdateLobbyForClientAsync();
		private async Task UpdateLobbyForClientAsync()
		{
			try
			{
				NetworkLobbyInfo lobbyInfo = await _gameClient.UpdateGameLobbyAsync(_playerStatus);
				if (lobbyInfo != null)
				{
					if (!lobbyInfo.Players.Exists((p) => p.Id == _gameClient.PlayerId))
					{
						_syncContext.Post(_ =>
						{
							Close();
							CustomMessageBox.Show("You have been kicked out of the lobby.", "Kick",
								CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information);
						}, null);
					}
					else
						SetClientForm(lobbyInfo);
				}
				ChatManager newLobbyChat = await _gameClient.UpdateLobbyChatAsync();
				_syncContext.Post(_ =>
				{
					UpdateChat(newLobbyChat);
				}, null);
			}
			catch (System.Net.Http.HttpRequestException)
			{
				if (!_wasUpdateExceptionThrown)
					HandleClientRequestError();
			}
		}
		private void UpdateChat(ChatManager newLobbyChat)
		{
			int indexLastMessage = _lobbyChat.GetCount() - 1;
			int startIndex = 0;

			if (indexLastMessage >= 0)
			{
				var LastMessageOld = _lobbyChat.GetMessage(indexLastMessage);
				var LastMessageNew = newLobbyChat.GetMessage(newLobbyChat.GetCount() - 1);

				if (LastMessageOld == LastMessageNew)
					return;

				startIndex = newLobbyChat.FindIndexByMessage(LastMessageOld) + 1;
			}

			Models.GameClientServer.Chat.Message message;
			for (int i = startIndex; i < newLobbyChat.GetCount(); i++)
			{
				message = newLobbyChat.GetMessage(i);
				_lobbyChat.AddMessage(message);
				DisplayMessage(message, false);
			}
		}
		private void HandleClientRequestError()
		{
			_wasUpdateExceptionThrown = true;
			_updateTimer?.Dispose();
			_syncContext.Post(_ =>
			{
				Close();
				CustomMessageBox.Show($"Failed to connect because the player " +
				"who created the lobby has finished waiting for players.", "Error",
				CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
			}, null);
		}
		private async void ButtonReady_Click(object sender, EventArgs e)
		{
			buttonReady.Enabled = false;
			_playerStatus.ChangeReady(!_playerStatus.IsReady);
			if (_playerStatus.IsReady)
			{
				buttonReady.Text = "Cancel";
				buttonReady.FillColor = _buttonFillColor.Cancel;
				buttonReady.FillColor2 = _buttonFillColor2.Cancel;
			}
			else
			{
				buttonReady.Text = "Ready";
				buttonReady.FillColor = _buttonFillColor.Ready;
				buttonReady.FillColor2 = _buttonFillColor2.Ready;
			}
			await UpdateLobbyForClientAsync();
			buttonReady.Enabled = true;
		}

		private void ClearPlayers()
		{
			_playerCreator.Dispose();
			_idToGamePanels.Clear();
		}
		private void GameLobbyClientForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_buttonEventHandlers.UnsubscribeAll();
			_updateTimer?.Dispose();

			ClearPlayers();
			if (!_wasUpdateExceptionThrown && !_isGameStarted)
				_gameClient?.LeaveGameLobbyAsync();
			if (!_isGameStarted)
				_mainForm.Show();
		}
	}
}