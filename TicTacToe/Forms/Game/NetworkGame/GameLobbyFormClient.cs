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
		private readonly Dictionary<long, Guna2Panel> _idToGamePanels = new Dictionary<long, Guna2Panel>();

		private readonly System.Threading.Timer _updateTimer;
		private readonly PlayerLobbyStatus _playerStatus = new PlayerLobbyStatus();
		private readonly SynchronizationContext _syncContext;
		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private bool _wasUpdateExceptionThrown, _isGameStarted;
		internal GameLobbyClientForm(MainForm mainForm, Player player, GameClient gameClient)
		{
			InitializeComponent();
			customTitleBar = new CustomTitleBar(this, "Lobby", maximizeBox: false);

			_mainForm = mainForm;
			_player = player;
			_syncContext = SynchronizationContext.Current;

			_gameClient = gameClient;
			_updateTimer = new System.Threading.Timer(UpdateTimerCallBack, null, 0, LOBBY_UPDATE_INTERVAL);
		}
		private void GameLobbyClientForm_Load(object sender, EventArgs e)
		{
			labelCoins.Text = $"{_player.Coins:N0}".Replace(',', ' ');
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

			switch (lobbyInfo.Settings.FieldSize)
			{
				case FieldSize.Size3on3:
					{
						gameForm = new Game3on3NetworkForm(_mainForm, _player, _gameClient,
							roundManager, lobbyInfo.Settings.CoinsBet, CellType.Zero,
							lobbyInfo.Settings.IsTimerEnabled, lobbyInfo.Settings.IsGameAssistsEnabled,
							lobbyInfo.Settings.OpponentAvatar.Image, lobbyInfo.Settings.OpponentName);
						break;
					}
				case FieldSize.Size5on5:
					{
						gameForm = new Game5on5NetworkForm(_mainForm, _player, _gameClient,
							roundManager, lobbyInfo.Settings.CoinsBet, CellType.Zero,
							lobbyInfo.Settings.IsTimerEnabled, lobbyInfo.Settings.IsGameAssistsEnabled,
							lobbyInfo.Settings.OpponentAvatar.Image, lobbyInfo.Settings.OpponentName);
						break;
					}
				case FieldSize.Size7on7:
					{
						gameForm = new Game7on7NetworkForm(_mainForm, _player, _gameClient,
							roundManager, lobbyInfo.Settings.CoinsBet, CellType.Zero,
							lobbyInfo.Settings.IsTimerEnabled, lobbyInfo.Settings.IsGameAssistsEnabled,
							lobbyInfo.Settings.OpponentAvatar.Image, lobbyInfo.Settings.OpponentName);
						break;
					}
				default:
					throw new InvalidOperationException
						($"Unknown field size: {_player.SinglePCGameSettings.FieldSize}");
			}

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
					NetworkPlayerCreator.ChangePlayerPanel(_idToGamePanels[id], info.GetPlayer(id));
				else
				{
					_idToGamePanels[id].Dispose();
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
				NetworkPlayerCreator.ChangePlayerPanel(_idToGamePanels[serverPlayer.Id], serverPlayer);
			else
				CreatePlayer(serverPlayer);

			return serverPlayer.Id;
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
			const int PANEL_WIDTH = 244, PANEL_HEIGHT = 76;

			Guna2Panel panel = NetworkPlayerCreator.CreatePlayerPanel(player,
				new Size(PANEL_WIDTH, PANEL_HEIGHT));
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
					SetClientForm(lobbyInfo);
			}
			catch (System.Net.Http.HttpRequestException)
			{
				if (!_wasUpdateExceptionThrown)
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
			}
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
			foreach (Guna2Panel panel in _idToGamePanels.Values)
				panel.Dispose();
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