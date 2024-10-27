using FontAwesome.Sharp;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.GameClientServer;
using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;
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

		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();

		internal GameLobbyForm(MainForm mainForm, Player player)
		{
			customTitleBar = new CustomTitleBar(this, "Lobby");
			IsResizable = true;
			InitializeComponent();

			_mainForm = mainForm;
			_player = player;
			int port = int.Parse(ConfigurationManager.AppSettings["port"]);
			_gameServer = new GameServer(_player, port);
		}
		private void GameLobbyForm_Load(object sender, EventArgs e)
		{
			labelCoins.Text = $"{_player.Coins:N0}".Replace(',', ' ');

			Label labelFieldSize = GetLabelByFieldSize(_player.NetworkGameSettings.FieldSize);
			LabelFieldSize_Click(labelFieldSize, e);
			numericUpDownNumberOfRounds.BackColor = BackColor;
			numericUpDownNumberOfRounds.Value = _player.NetworkGameSettings.NumberOfRounds;
			numericUpDownCoinsBet.BackColor = BackColor;
			numericUpDownCoinsBet.Value = _player.NetworkGameSettings.CoinsBet;
			numericUpDownCoinsBet.Maximum = Math.Min(_player.Coins, numericUpDownCoinsBet.Maximum);

			if (_player.NetworkGameSettings.IsTimerEnabled)
				SetActiveEnableButtonStyle(buttonTimerEnabled);
			if (_player.NetworkGameSettings.IsGameAssistsEnabled)
				SetActiveEnableButtonStyle(buttonGameAssistsEnabled);

			_buttonEventHandlers.SubscribeToHover(buttonStart);
			_labelEventHandlers.SubscribeToHoverUnderline(label3on3, label5on5, label7on7);
			_gameServer.Start();
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

		private void EnableButton_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is IconButton iconButton))
				return;

			if (_player.NetworkGameSettings.IsTimerEnabled && iconButton == buttonTimerEnabled
				|| _player.NetworkGameSettings.IsGameAssistsEnabled && iconButton == buttonGameAssistsEnabled)
				return;

			iconButton.ForeColor = _enableButtonsForeColor.Selected;
		}
		private void EnableButton_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is IconButton iconButton))
				return;

			iconButton.ForeColor = _enableButtonsForeColor.Default;
		}
		#endregion

		private void GameLobbyForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_buttonEventHandlers.UnsubscribeAll();
			_labelEventHandlers.UnsubscribeAll();

			_gameServer.Stop();
			_mainForm.Show();
		}
	}
}