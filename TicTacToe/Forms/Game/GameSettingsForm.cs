using FluentValidation.Results;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using TicTacToe.Forms.Game.Games3on3;
using TicTacToe.Forms.Game.Games5on5;
using TicTacToe.Forms.Game.Games7on7;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.PlayerItemCreator;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToeLibrary;

namespace TicTacToe.Forms.Game
{
	internal partial class GameSettingsForm : BaseForm
	{
		enum FieldSize : byte
		{
			Size3on3,
			Size5on5,
			Size7on7
		}

		private const int SELECTED_AVATAR_INDENT = 10;
		private const string SELECTED_AVATAR_TEXT = "Selected";
		private const string SELECTED_AVATAR_TAG = "ItemSelected";

		private static readonly (Color Default, Color Selected) _foreColorEnableButtons = (Color.Transparent, Color.Khaki);
		private static readonly (Color Default, Color Selected) _ColorFieldSize = (Color.Transparent, Color.Green);
		private static readonly (Color Default, Color DuringRenaming) _buttonChangeNameColor = (Color.White, Color.Yellow);

		private readonly MainForm _mainForm;
		private readonly Player _player;
		private readonly RoundManager _roundManager;

		private AvatarCreator _avatarCreator;
		private readonly List<PictureBox> _avatarPictureBoxes = new List<PictureBox>();
		private Image opponentAvatarImage;

		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();

		private readonly Player _tempPlayer;
		private FieldSize _fieldSize;
		private bool _isTimerEnabled;
		private bool _isGameAssistsEnabled;

		internal GameSettingsForm(MainForm mainForm, Player player, RoundManager roundManager, bool isGameAssistsEnabled = true)
		{
			customTitleBar = new CustomTitleBar(this, "Game settings", minimizeBox: false, maximizeBox: false);
			InitializeComponent();
			_mainForm = mainForm;
			_player = player;
			_roundManager = roundManager;
			_tempPlayer = new Player(textBoxOpponentName.Text, 0, new PlayerPreferences());

			if (!isGameAssistsEnabled)
				buttonGameAssistsEnabled.Visible = false;

			InitializeCreator();
			_buttonEventHandlers.SubscribeToHover(buttonPlay);
			_labelEventHandlers.SubscribeToHoverUnderline(label3on3, label5on5, label7on7);
		}
		private void GameSettingsForm_Load(object sender, EventArgs e)
		{
			textBoxOpponentName.MaxLength = PlayerValidator.MAX_NAME_LENGTH;
			textBoxOpponentName.BackColor = BackColor;
			CreateAvatars();

			LabelFieldSize_Click(label3on3, e);
		}

		private void ButtonPlay_Click(object sender, EventArgs e)
		{
			BaseGameForm gameForm = default;
			if (_fieldSize == FieldSize.Size3on3)
				gameForm = new Game3on3TwoPlayersForm(_mainForm, _player, _roundManager,
					CellType.Cross, _isTimerEnabled, opponentAvatarImage, textBoxOpponentName.Text);
			else if (_fieldSize == FieldSize.Size5on5)
				gameForm = new Game5on5TwoPlayersForm(_mainForm, _player, _roundManager,
					CellType.Cross, _isTimerEnabled, opponentAvatarImage, textBoxOpponentName.Text);
			else if (_fieldSize == FieldSize.Size7on7)
				gameForm = new Game7on7TwoPlayersForm(_mainForm, _player, _roundManager,
					CellType.Cross, _isTimerEnabled, opponentAvatarImage, textBoxOpponentName.Text);

			if (!gameForm.IsDisposed)// If a player have enough coints to play
			{
				_mainForm.Hide();
				gameForm.Show();
			}
			Close();
		}

		#region Field Size
		private void LabelFieldSize_Click(object sender, EventArgs e)
		{
			if (!(sender is Label label))
				return;

			label.BackColor = _ColorFieldSize.Selected;
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
		}
		private void SetDefaultFieldSizeLabels(params Label[] labels)
		{
			foreach (Label label in labels)
			{
				label.BackColor = _ColorFieldSize.Default;
				label.Enabled = true;
			}
		}
		#endregion

		#region Enable Buttons
		private void ButtonTimerEnabled_Click(object sender, EventArgs e)
		{
			if (!(sender is IconButton button))
				return;

			ActiveControl = null;
			if (!_isTimerEnabled)
				SetActiveEnableButtonStyle(button);
			else
				SetDefaultEnableButtonStyle(button);

			_isTimerEnabled = !_isTimerEnabled;
		}
		private void ButtonGameAssistsEnabled_Click(object sender, EventArgs e)
		{
			if (!(sender is IconButton button))
				return;

			ActiveControl = null;
			if (!_isGameAssistsEnabled)
				SetActiveEnableButtonStyle(button);
			else
				SetDefaultEnableButtonStyle(button);

			_isGameAssistsEnabled = !_isGameAssistsEnabled;
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
			iconButton.ForeColor = _foreColorEnableButtons.Selected;
		}
		private void EnableButton_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is IconButton iconButton))
				return;

			iconButton.ForeColor = _foreColorEnableButtons.Default;
		}
		#endregion

		#region Change Second Player Name
		private void ButtonChangeOpponentName_Click(object sender, EventArgs e)
		{
			if (textBoxOpponentName.ReadOnly)
			{
				buttonChangeOpponentName.IconColor = _buttonChangeNameColor.DuringRenaming;
				textBoxOpponentName.ReadOnly = false;
				textBoxOpponentName.Focus();
				textBoxOpponentName.SelectAll();
			}
			else if (_tempPlayer.Name == textBoxOpponentName.Text)
			{
				buttonChangeOpponentName.IconColor = _buttonChangeNameColor.Default;
				textBoxOpponentName.ReadOnly = true;
				ActiveControl = null;
			}
		}

		private bool IsPlayerDataValid()
		{
			PlayerValidator validator = new PlayerValidator();

			Player newPlayer = new Player(textBoxOpponentName.Text, _tempPlayer.Coins, _tempPlayer.Preferences);
			ValidationResult result = validator.Validate(newPlayer);
			if (!result.IsValid)
			{
				CustomMessageBox.Show(result.Errors[0].ErrorMessage, "Invalid input", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				return false;
			}
			else
				return true;
		}
		private void TryToChangeName()
		{
			if (textBoxOpponentName.ReadOnly)
				return;

			if (IsPlayerDataValid())
			{
				textBoxOpponentName.ReadOnly = true;
				ActiveControl = null;
				buttonChangeOpponentName.IconColor = _buttonChangeNameColor.Default;
				if (_tempPlayer.Name != textBoxOpponentName.Text)
				{
					CustomMessageBox.Show("The second player's nickname has been successfully changed.", "Success",
						CustomMessageBoxButtons.OK, CustomMessageBoxIcon.OK);
				}
			}
			else
				textBoxOpponentName.Focus();
		}

		private void TextBoxOpponentName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				TryToChangeName();
		}
		private void TextBoxOpponentName_Leave(object sender, EventArgs e)
			=> TryToChangeName();
		#endregion

		#region Change Second Player Avatar
		private void InitializeCreator()
		{
			const int ITEM_SIZE = 100;

			_avatarCreator = new AvatarCreator(_player, flpAvatar, ITEM_SIZE);
			ManageItemCreatorEvents(true);
		}
		private void ManageItemCreatorEvents(bool subscribe)
		{
			if (subscribe)
				_avatarCreator.Click += SelectAvatar;
			else
				_avatarCreator.Click -= SelectAvatar;
		}

		private void CreateAvatars()
		{
			foreach (Item item in _player.ItemsInventory.GetItems())
				if (item is Avatar avatar && item.Name != _player.Preferences.Avatar.Name)
				{
					PictureBox pictureBox = _avatarCreator.CreateItemToSelect(avatar);

					if (_avatarPictureBoxes.Count == 0)
						SelectAvatar(this, new ItemEventArgs(avatar, pictureBox));
					_avatarPictureBoxes.Add(pictureBox);
				}
		}
		private void SelectAvatar(object sender, ItemEventArgs e)
		{
			if (!(e.ClickableControl is PictureBox selectedPicture))
				return;

			DeselectPreviousItem(_avatarPictureBoxes);
			DefaultSelect(selectedPicture);
			opponentAvatarImage = selectedPicture.Image;
		}
		private void DeselectPreviousItem(List<PictureBox> list)
		{
			foreach (PictureBox picture in list)
				if (picture.Tag != null && picture.Tag.ToString() == SELECTED_AVATAR_TAG)
				{
					DefaultDeselect(picture);
					break;
				}
		}
		private void DefaultSelect(PictureBox pictureBox)
		{
			pictureBox.Tag = SELECTED_AVATAR_TAG;
			pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - SELECTED_AVATAR_INDENT);
			pictureBox.Enabled = false;
			CreateSelectionLabel(pictureBox.Parent);
		}
		private void DefaultDeselect(PictureBox pictureBox)
		{
			pictureBox.Tag = string.Empty;
			pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + SELECTED_AVATAR_INDENT);
			pictureBox.Enabled = true;
			DeleteSelectionLabel(pictureBox.Parent);
		}
		private void CreateSelectionLabel(Control parent)
		{
			Color foreColor = Color.Yellow;

			new Label
			{
				Parent = parent,
				Text = SELECTED_AVATAR_TEXT,
				ForeColor = foreColor,
				Dock = DockStyle.Bottom,
				TextAlign = ContentAlignment.MiddleCenter,
				Font = new Font("Trebuchet MS", 10F, FontStyle.Bold),
				Size = new Size(0, SELECTED_AVATAR_INDENT * 2)
			};
		}
		private void DeleteSelectionLabel(Control parent)
		{
			var labelToRemove = parent.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text == SELECTED_AVATAR_TEXT);
			labelToRemove?.Dispose();
		}
		#endregion

		private void GameSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_buttonEventHandlers.UnsubscribeAll();
			_labelEventHandlers.UnsubscribeAll();
			ManageItemCreatorEvents(false);

			_avatarCreator?.Dispose();
		}
	}
}