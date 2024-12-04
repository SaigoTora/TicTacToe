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
using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.PlayerItemCreator;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToe.Models.Utilities.FormUtilities.ControlEventHandlers;
using TicTacToeLibrary;

namespace TicTacToe.Forms.Game.Settings
{
	internal partial class SinglePCGameSettingsForm : BaseForm
	{
		private const int SELECTED_AVATAR_INDENT = 10;
		private const string SELECTED_AVATAR_TEXT = "Selected";
		private const string SELECTED_AVATAR_TAG = "ItemSelected";

		private static readonly (Color Default, Color Selected) _fieldSizeColor = (Color.Transparent, Color.Green);
		private static readonly (Color Default, Color Selected) _enableButtonsForeColor = (Color.Transparent, Color.Khaki);
		private static readonly (Color Default, Color DuringRenaming) _buttonChangeNameColor = (Color.White, Color.Yellow);

		private readonly MainForm _mainForm;
		private readonly Player _player;

		private AvatarCreator _avatarCreator;
		private readonly List<PictureBox> _avatarPictureBoxes = new List<PictureBox>();
		private Image opponentAvatarImage;

		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();

		internal SinglePCGameSettingsForm(MainForm mainForm, Player player)
		{
			customTitleBar = new CustomTitleBar(this, "Game Settings", minimizeBox: false, maximizeBox: false);
			InitializeComponent();
			_mainForm = mainForm;
			_player = player;

			InitializeCreator();
			_buttonEventHandlers.SubscribeToHover(buttonPlay);
			_labelEventHandlers.SubscribeToHoverUnderline(label3on3, label5on5, label7on7);
		}
		private void SinglePCGameSettingsForm_Load(object sender, EventArgs e)
		{

			Label labelFieldSize = GetLabelByFieldSize(_player.SinglePCGameSettings.FieldSize);
			LabelFieldSize_Click(labelFieldSize, e);
			numericUpDownNumberOfRounds.BackColor = BackColor;
			numericUpDownNumberOfRounds.Value = _player.SinglePCGameSettings.NumberOfRounds;
			string opponentName = _player.SinglePCGameSettings.OpponentName;
			if (opponentName != null)
				textBoxOpponentName.Text = opponentName;
			textBoxOpponentName.MaxLength = PlayerValidator.MAX_NAME_LENGTH;
			textBoxOpponentName.BackColor = BackColor;
			CreateAvatars();

			if (_player.SinglePCGameSettings.IsTimerEnabled)
				SetActiveEnableButtonStyle(buttonTimerEnabled);
		}

		private void ButtonPlay_Click(object sender, EventArgs e)
		{
			ShowSinglePCGameForm();
			Close();
		}
		private void ShowSinglePCGameForm()
		{
			BaseGameForm gameForm;
			RoundManager roundManager = new RoundManager(_player.SinglePCGameSettings.NumberOfRounds);

			switch (_player.SinglePCGameSettings.FieldSize)
			{
				case FieldSize.Size3on3:
					gameForm = new Game3on3SinglePCForm(_mainForm, _player, roundManager,
						CellType.Cross, _player.SinglePCGameSettings.IsTimerEnabled, opponentAvatarImage, textBoxOpponentName.Text);
					break;
				case FieldSize.Size5on5:
					gameForm = new Game5on5SinglePCForm(_mainForm, _player, roundManager,
						CellType.Cross, _player.SinglePCGameSettings.IsTimerEnabled, opponentAvatarImage, textBoxOpponentName.Text);
					break;
				case FieldSize.Size7on7:
					gameForm = new Game7on7SinglePCForm(_mainForm, _player, roundManager,
						CellType.Cross, _player.SinglePCGameSettings.IsTimerEnabled, opponentAvatarImage, textBoxOpponentName.Text);
					break;
				default:
					throw new InvalidOperationException
						($"Unknown field size: {_player.SinglePCGameSettings.FieldSize}");
			}

			_mainForm.Hide();
			gameForm.Show();
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
				_player.SinglePCGameSettings.FieldSize = FieldSize.Size3on3;
			}
			else if (label == label5on5)
			{
				SetDefaultFieldSizeLabels(label3on3, label7on7);
				_player.SinglePCGameSettings.FieldSize = FieldSize.Size5on5;
			}
			else
			{
				SetDefaultFieldSizeLabels(label3on3, label5on5);
				_player.SinglePCGameSettings.FieldSize = FieldSize.Size7on7;
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
			=> _player.SinglePCGameSettings.NumberOfRounds =
			(int)numericUpDownNumberOfRounds.Value;

		#region Enable Buttons
		private void ButtonTimerEnabled_Click(object sender, EventArgs e)
		{
			ActiveControl = null;
			if (!_player.SinglePCGameSettings.IsTimerEnabled)
				SetActiveEnableButtonStyle(buttonTimerEnabled);
			else
				SetDefaultEnableButtonStyle(buttonTimerEnabled);

			_player.SinglePCGameSettings.IsTimerEnabled = !_player.SinglePCGameSettings.IsTimerEnabled;
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

			if (_player.SinglePCGameSettings.IsTimerEnabled && iconButton == buttonTimerEnabled)
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

		#region Second Player Name
		private void ButtonChangeOpponentName_Click(object sender, EventArgs e)
		{
			if (textBoxOpponentName.ReadOnly)
			{
				buttonChangeOpponentName.IconColor = _buttonChangeNameColor.DuringRenaming;
				textBoxOpponentName.ReadOnly = false;
				textBoxOpponentName.Focus();
				textBoxOpponentName.SelectAll();
			}
			else if (_player.SinglePCGameSettings.OpponentName == textBoxOpponentName.Text)
			{
				buttonChangeOpponentName.IconColor = _buttonChangeNameColor.Default;
				textBoxOpponentName.ReadOnly = true;
				ActiveControl = null;
			}
		}

		private bool IsPlayerDataValid()
		{
			PlayerValidator validator = new PlayerValidator();

			Player newPlayer = new Player(textBoxOpponentName.Text);
			ValidationResult result = validator.Validate(newPlayer);
			if (!result.IsValid)
			{
				CustomMessageBox.Show(result.Errors[0].ErrorMessage, "Invalid input", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error, 420);
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
				if (_player.SinglePCGameSettings.OpponentName != textBoxOpponentName.Text)
				{
					_player.SinglePCGameSettings.OpponentName = textBoxOpponentName.Text;
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

		#region Second Player Avatar
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
			Avatar opponentAvatar = _player.SinglePCGameSettings.OpponentAvatar;

			foreach (Item item in _player.ItemsInventory.GetItems())
				if (item is Avatar avatar && item.Name != _player.VisualSettings.Avatar.Name)
				{
					PictureBox pictureBox = _avatarCreator.CreateItemToSelect(avatar);

					if (_avatarPictureBoxes.Count == 0)
						if (opponentAvatar == null
							|| _player.VisualSettings.Avatar.Name == opponentAvatar.Name)
							SelectAvatar(this, new ItemEventArgs(avatar, pictureBox));
					if (opponentAvatar != null && opponentAvatar.Name != null
						&& item.Name == opponentAvatar.Name)
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
			_player.SinglePCGameSettings.OpponentAvatar =
				(Avatar)ItemManager.GetFullItem(e.Item);
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

		private void SinglePCGameSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_buttonEventHandlers.UnsubscribeAll();
			_labelEventHandlers.UnsubscribeAll();
			ManageItemCreatorEvents(false);

			_avatarCreator?.Dispose();
		}
	}
}