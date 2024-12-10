using FluentValidation.Results;
using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.Utilities;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToe.Models.Utilities.FormUtilities.ControlEventHandlers;

namespace TicTacToe.Forms
{
	internal partial class StartForm : BaseForm
	{
		private static readonly string DEFAULT_PLAYER_NAME = Environment.UserName;
		private static readonly (Color placeholderColor, Color textColor) _foreColorTextBoxName = (Color.Gray, Color.White);

		private static readonly Color _selectedAvatarColor = Color.FromArgb(71, 167, 106);
		private readonly PictureBoxEventHandlers _pictureBoxEventHandlers = new PictureBoxEventHandlers();
		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();

		private Player _player;
		private bool _isPlayerMan = true;

		internal StartForm()
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Tic Tac Toe", maximizeBox: false);
			_player = new Player();
		}

		private void StartForm_Load(object sender, EventArgs e)
		{
			textBoxName.MaxLength = PlayerValidator.MAX_NAME_LENGTH;
			TextBoxName_Leave(textBoxName, e);
			PictureBoxAvatar_Click(pictureBoxMan, e);

			_pictureBoxEventHandlers.SubscribeToHover(pictureBoxMan, pictureBoxWoman);
			_buttonEventHandlers.SubscribeToHover(buttonReady);
			_labelEventHandlers.SubscribeToHoverUnderline(labelName);
		}

		private bool IsPlayerDataValid()
		{
			PlayerValidator validator = new PlayerValidator();

			ValidationResult result = validator.Validate(_player);
			if (!result.IsValid)
			{
				CustomMessageBox.Show(result.Errors[0].ErrorMessage.Replace("&", "&&"), "Invalid input",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error, 420);
				return false;
			}
			else
				return true;
		}

		private void PictureBoxAvatar_Click(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			pictureBox.BackColor = _selectedAvatarColor;
			pictureBox.Enabled = false;
			if (pictureBox == pictureBoxMan)
			{
				pictureBoxWoman.BackColor = Color.Transparent;
				pictureBoxWoman.Enabled = true;
				_isPlayerMan = true;
			}
			else
			{
				pictureBoxMan.BackColor = Color.Transparent;
				pictureBoxMan.Enabled = true;
				_isPlayerMan = false;
			}
		}
		private void ButtonReady_Click(object sender, EventArgs e)
		{
			const int FIRST_TIME_COIN_REWARD = 100;

			textBoxName.Text = textBoxName.Text.Trim(' ').DeleteDuplicateChars(' ');
			_player = new Player(textBoxName.Text);

			if (IsPlayerDataValid())
			{
				if (_isPlayerMan)
					_player.VisualSettings.Avatar = ItemManager.GetDefaultAvatar(0);
				else
					_player.VisualSettings.Avatar = ItemManager.GetDefaultAvatar(1);
				_player.AddCoins(FIRST_TIME_COIN_REWARD);

				MainForm mainForm = new MainForm(_player);
				mainForm.FormClosed += (s, args) => { Close(); };

				Visible = false;
				CustomMessageBox.Show($"Congratulations! You've received {FIRST_TIME_COIN_REWARD} " +
					$"coins for your first login.",
					"Coin Reward", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information);
				mainForm.Show();
			}
		}

		private void LabelName_Click(object sender, EventArgs e)
		{
			textBoxName.Focus();
			textBoxName.SelectAll();
		}

		private void TextBoxName_Enter(object sender, EventArgs e)
		{
			if (textBoxName.Text == DEFAULT_PLAYER_NAME)
			{
				textBoxName.Text = string.Empty;
				textBoxName.ForeColor = _foreColorTextBoxName.textColor;
			}
		}
		private void TextBoxName_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBoxName.Text))
			{
				textBoxName.Text = DEFAULT_PLAYER_NAME;
				textBoxName.ForeColor = _foreColorTextBoxName.placeholderColor;
			}
		}

		private void StartForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				Close();
		}
		private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_pictureBoxEventHandlers.UnsubscribeAll();
			_buttonEventHandlers.UnsubscribeAll();
			_labelEventHandlers.UnsubscribeAll();
		}
	}
}