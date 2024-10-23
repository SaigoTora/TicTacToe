using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Forms.Game.NetworkGame;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToe.Models.Utilities.FormUtilities.ControlEventHandlers;

namespace TicTacToe.Forms.Game.Settings
{
	internal partial class NetworkGameSettingsForm : BaseForm
	{
		private static readonly (Color Default, Color Selected) _enableButtonsForeColor = (Color.Transparent, Color.Khaki);
		private static readonly (Color Default, Color Selected) _fieldSizeColor = (Color.Transparent, Color.Green);
		private static readonly (Color Default, Color Reached) _descriptionLengthColor = (Color.LightGray, Color.Moccasin);

		private readonly MainForm _mainForm;
		private readonly StartNetworkGameForm _previousForm;
		private readonly Player _player;
		private readonly RoundManager _roundManager;

		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();

		private FieldSize _fieldSize;
		private bool _isTimerEnabled;
		private bool _isGameAssistsEnabled;

		internal NetworkGameSettingsForm(MainForm mainForm, Player player, RoundManager roundManager,
			StartNetworkGameForm previousForm)
		{
			customTitleBar = new CustomTitleBar(this, "Local Game Settings", minimizeBox: false, maximizeBox: false);
			InitializeComponent();
			_mainForm = mainForm;
			_previousForm = previousForm;
			_player = player;
			_roundManager = roundManager;

			_buttonEventHandlers.SubscribeToHover(buttonPlay);
			_labelEventHandlers.SubscribeToHoverUnderline(label3on3, label5on5, label7on7);
		}
		private void NetworkGameSettingsForm_Load(object sender, EventArgs e)
		{
			numericUpDownCoinsBet.BackColor = BackColor;
			richTextBoxDescription.BackColor = BackColor;

			Label labelFieldSize = GetLabelByFieldSize(_player.NetworkGameSettings.FieldSize);
			LabelFieldSize_Click(labelFieldSize, e);
			numericUpDownCoinsBet.Value = Math.Min(_player.NetworkGameSettings.CoinsBet, _player.Coins);
			richTextBoxDescription.Text = _player.NetworkGameSettings.Description;
			if (buttonTimerEnabled.Visible && _player.NetworkGameSettings.IsTimerEnabled)
				ButtonTimerEnabled_Click(this, EventArgs.Empty);
			if (buttonGameAssistsEnabled.Visible && _player.NetworkGameSettings.IsGameAssistsEnabled)
				ButtonGameAssistsEnabled_Click(this, EventArgs.Empty);
		}

		private void ButtonCreate_Click(object sender, EventArgs e)
		{
			GameLobbyForm gameLobbyForm = new GameLobbyForm(_mainForm, _player, _roundManager);

			_mainForm.Hide();
			gameLobbyForm.Show();

			if (_previousForm != null)
			{
				_previousForm.NeedToShowMainForm = false;
				_previousForm.Close();
			}
			Close();
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
				_fieldSize = FieldSize.Size3on3;
			}
			else if (label == label5on5)
			{
				SetDefaultFieldSizeLabels(label3on3, label7on7);
				_fieldSize = FieldSize.Size5on5;
			}
			else
			{
				SetDefaultFieldSizeLabels(label3on3, label5on5);
				_fieldSize = FieldSize.Size7on7;
			}
			_player.NetworkGameSettings.FieldSize = _fieldSize;
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
		{
			_player.NetworkGameSettings.Description = richTextBoxDescription.Text;
		}

		#region Enable Buttons
		private void ButtonTimerEnabled_Click(object sender, EventArgs e)
		{
			ActiveControl = null;
			if (!_isTimerEnabled)
				SetActiveEnableButtonStyle(buttonTimerEnabled);
			else
				SetDefaultEnableButtonStyle(buttonTimerEnabled);

			_isTimerEnabled = !_isTimerEnabled;
			_player.NetworkGameSettings.IsTimerEnabled = _isTimerEnabled;
		}
		private void ButtonGameAssistsEnabled_Click(object sender, EventArgs e)
		{
			ActiveControl = null;
			if (!_isGameAssistsEnabled)
				SetActiveEnableButtonStyle(buttonGameAssistsEnabled);
			else
				SetDefaultEnableButtonStyle(buttonGameAssistsEnabled);

			_isGameAssistsEnabled = !_isGameAssistsEnabled;
			_player.NetworkGameSettings.IsGameAssistsEnabled = _isGameAssistsEnabled;
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

			if (_isTimerEnabled && iconButton == buttonTimerEnabled
				|| _isGameAssistsEnabled && iconButton == buttonGameAssistsEnabled)
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

		private void NetworkGameSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_buttonEventHandlers.UnsubscribeAll();
			_labelEventHandlers.UnsubscribeAll();
		}
	}
}