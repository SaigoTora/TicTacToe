using System;
using System.Drawing;
using System.Windows.Forms;
using FluentValidation.Results;

using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities;

namespace TicTacToe.Forms
{
	internal partial class StartForm : Form
	{
		private readonly Color _selectedAvatarColor = Color.FromArgb(189, 236, 182);

		private Player _player;
		private bool _isPlayerMan = true;

		internal StartForm()
		{
			InitializeComponent();

			_player = new Player();
		}

		private void StartForm_Load(object sender, EventArgs e)
		{
			textBoxName.Text = Environment.UserName;
			textBoxName.MaxLength = PlayerValidator.MAX_NAME_LENGTH;
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
				MessageBox.Show(result.Errors[0].ErrorMessage);
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
			_player = new Player(textBoxName.Text, _player.Points, _player.Settings);

			if (IsPlayerDataValid())
			{
				PlayerVisualSettings settings = new PlayerVisualSettings();

				if (_isPlayerMan)
					settings.Avatar = pictureBoxMan.Image;
				else
					settings.Avatar = pictureBoxWoman.Image;

				_player = new Player(_player.Name, _player.Points, settings);

				MainForm mainForm = new MainForm(_player);
				mainForm.FormClosed += (s, args) => { Close(); };
				Visible = false;
				mainForm.Show();
			}
		}
	}
}