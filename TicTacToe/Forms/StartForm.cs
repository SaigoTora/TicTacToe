using System;
using System.Drawing;
using System.Windows.Forms;
using FluentValidation.Results;

using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities;

namespace TicTacToe.Forms
{
	internal partial class StartForm : BaseForm
	{
		private static readonly string DEFAULT_PLAYER_NAME = Environment.UserName;
		private readonly (Color placeholderColor, Color textColor) _foreColorTextBoxName = (Color.Gray, Color.White);

		private static readonly Color _selectedAvatarColor = Color.FromArgb(71, 167, 106);
		private readonly CustomTitleBar _customTitleBar;

		private Player _player;
		private bool _isPlayerMan = true;

		internal StartForm()
		{
			InitializeComponent();

			_customTitleBar = new CustomTitleBar(this, "Tic Tac Toe", Properties.Resources.ticTacToe, true, false);
			_player = new Player();
		}

		private void StartForm_Load(object sender, EventArgs e)
		{
			textBoxName.MaxLength = PlayerValidator.MAX_NAME_LENGTH;
			TextBoxName_Leave(textBoxName, e);
			PictureBoxAvatar_Click(pictureBoxMan, e);

			FormEventHandlers.SubscribeToHoverPictureBoxes(pictureBoxMan, pictureBoxWoman);
			FormEventHandlers.SubscribeToHoverButtons(buttonReady);
		}

		private bool IsPlayerDataValid()
		{
			PlayerValidator validator = new PlayerValidator();

			ValidationResult result = validator.Validate(_player);
			if (!result.IsValid)
			{
				MessageBox.Show(result.Errors[0].ErrorMessage, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
			textBoxName.Text = textBoxName.Text.Trim(' ').DeleteDuplicateChars(' ');
			_player = new Player(textBoxName.Text, _player.Coins, _player.Preferences);

			if (IsPlayerDataValid())
			{
				PlayerPreferences preferences = new PlayerPreferences();

				if (_isPlayerMan)
					preferences.Avatar = pictureBoxMan.Image;
				else
					preferences.Avatar = pictureBoxWoman.Image;

				_player = new Player(_player.Name, _player.Coins, preferences);

				MainForm mainForm = new MainForm(_player);
				mainForm.FormClosed += (s, args) => { Close(); };

				Visible = false;
				mainForm.Show();
			}
		}

		private void LabelName_Click(object sender, EventArgs e)
		{
			textBoxName.Focus();
			textBoxName.SelectAll();
		}
		private void LabelName_MouseEnter(object sender, EventArgs e)
			=> labelName.Font = new Font(labelName.Font, FontStyle.Underline);
		private void LabelName_MouseLeave(object sender, EventArgs e)
			=> labelName.Font = new Font(labelName.Font, FontStyle.Regular);

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

		private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
			=> _customTitleBar.Dispose();
	}
}