using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Forms.Game.NetworkGame;
using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToe.Models.Utilities.FormUtilities.ControlEventHandlers;
using TicTacToeLibrary.GameLogic;

namespace TicTacToe.Forms.Game.Settings
{
	internal partial class NetworkGameSettingsForm : BaseForm
	{
		private static readonly (Color Default, Color Selected) _fieldSizeColor = (Color.Transparent, Color.FromArgb(25, 85, 55));
		private static readonly (Color Default, Color Reached) _descriptionLengthColor = (Color.LightGray, Color.Moccasin);
		private static readonly (Color Default, Color Selected) _enableButtonsForeColor = (Color.Transparent, Color.Khaki);

		private readonly MainForm _mainForm;
		private readonly StartNetworkGameForm _previousForm;
		private readonly Player _player;

		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();

		internal NetworkGameSettingsForm(MainForm mainForm, Player player, StartNetworkGameForm previousForm)
		{
			customTitleBar = new CustomTitleBar(this, "Local Game Settings", Properties.Resources.gameSettings,
				minimizeBox: false, maximizeBox: false);
			InitializeComponent();
			_mainForm = mainForm;
			_previousForm = previousForm;
			_player = player;

			_buttonEventHandlers.SubscribeToHover(buttonCreate);
			_labelEventHandlers.SubscribeToHoverUnderline(label3on3, label5on5, label7on7);
		}
		private void NetworkGameSettingsForm_Load(object sender, EventArgs e)
		{
			Label labelFieldSize = GetLabelByFieldSize(_player.NetworkGameSettings.FieldSize);
			LabelFieldSize_Click(labelFieldSize, e);
			comboBoxGameMode.SelectedIndex = (int)_player.NetworkGameSettings.GameMode;
			numericUpDownNumberOfRounds.BackColor = BackColor;
			numericUpDownNumberOfRounds.Value = _player.NetworkGameSettings.NumberOfRounds;
			numericUpDownCoinsBet.BackColor = BackColor;
			numericUpDownCoinsBet.Value = Math.Min(_player.NetworkGameSettings.CoinsBet, _player.Coins);
			numericUpDownCoinsBet.Maximum = Math.Min(_player.Coins, numericUpDownCoinsBet.Maximum);
			richTextBoxDescription.BackColor = BackColor;
			richTextBoxDescription.Text = _player.NetworkGameSettings.Description;

			if (_player.NetworkGameSettings.IsTimerEnabled)
				SetActiveEnableButtonStyle(buttonTimerEnabled);
			if (_player.NetworkGameSettings.IsGameAssistsEnabled)
				SetActiveEnableButtonStyle(buttonGameAssistsEnabled);
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
		private void NumericUpDownCoinsBet_ValueChanged(object sender, EventArgs e)
			=> _player.NetworkGameSettings.CoinsBet = (int)numericUpDownCoinsBet.Value;

		private void RichTextBoxDescription_TextChanged(object sender, EventArgs e)
		{
			if (richTextBoxDescription.Text.Length > 0)
			{
				if (richTextBoxDescription.Text.Length == richTextBoxDescription.MaxLength)
					labelDescriptionLength.ForeColor = _descriptionLengthColor.Reached;
				else
					labelDescriptionLength.ForeColor = _descriptionLengthColor.Default;

				labelDescriptionLength.Visible = true;
				labelDescriptionLength.Text = $"{richTextBoxDescription.Text.Length} /" +
					$" {richTextBoxDescription.MaxLength}";
			}
			else
				labelDescriptionLength.Visible = false;
		}
		private void RichTextBoxDescription_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				ActiveControl = null;
			}
		}
		private void RichTextBoxDescription_Leave(object sender, EventArgs e)
			=> _player.NetworkGameSettings.Description = richTextBoxDescription.Text;

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

		private void ButtonCreate_Click(object sender, EventArgs e)
		{
			if (numericUpDownNumberOfRounds.Value % 2 != 0)
			{
				CustomMessageBox.Show("The number of rounds must be an even number.",
					"Error", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				return;
			}

			GameLobbyServerForm gameLobbyForm = new GameLobbyServerForm(_mainForm, _player);
			gameLobbyForm.Show();

			if (_previousForm != null)
			{
				_previousForm.NeedToShowMainForm = false;
				_previousForm.Close();
			}
			Close();
		}

		private void NetworkGameSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_buttonEventHandlers.UnsubscribeAll();
			_labelEventHandlers.UnsubscribeAll();
		}
	}
}