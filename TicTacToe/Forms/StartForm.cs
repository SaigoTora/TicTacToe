﻿using FluentValidation.Results;
using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.Utilities;
using TicTacToe.Models.Utilities.FormUtilities;

namespace TicTacToe.Forms
{
	internal partial class StartForm : BaseForm
	{
		private static readonly string DEFAULT_PLAYER_NAME = Environment.UserName;
		private static readonly (Color placeholderColor, Color textColor) _foreColorTextBoxName = (Color.Gray, Color.White);

		private static readonly Color _selectedAvatarColor = Color.FromArgb(71, 167, 106);
		private readonly CustomTitleBar _customTitleBar;
		private readonly PictureBoxEventHandlers _pictureBoxEventHandlers = new PictureBoxEventHandlers();
		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();

		private Player _player;
		private bool _isPlayerMan = true;

		internal StartForm()
		{
			InitializeComponent();

			_customTitleBar = new CustomTitleBar(this, "Tic Tac Toe", Properties.Resources.ticTacToe, maximizeBox: false);
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
				CustomMessageBox.Show(result.Errors[0].ErrorMessage.Replace("&", "&&"), "Invalid input", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
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
					preferences.Avatar = ItemManager.GetDefaultAvatar(0);
				else
					preferences.Avatar = ItemManager.GetDefaultAvatar(1);

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
		{
			_pictureBoxEventHandlers.UnsubscribeAll();
			_buttonEventHandlers.UnsubscribeAll();
			_labelEventHandlers.UnsubscribeAll();
			_customTitleBar.Dispose();
		}
	}
}