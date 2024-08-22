using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.PlayerItemCreator;
using TicTacToe.Models.Utilities;

namespace TicTacToe.Forms
{
	internal partial class ProfileForm : BaseForm
	{
		private const int SELECTED_ITEM_INDENT = 15;
		private const string SELECTED_PICTURE_TAG = "Selected";

		private static readonly (Color Default, Color DuringRenaming) _buttonRenameColor = (Color.White, Color.Yellow);
		private readonly Player _player;

		private readonly List<PictureBox> _menuBackList = new List<PictureBox>();
		private readonly List<PictureBox> _gameBackList = new List<PictureBox>();
		private readonly List<PictureBox> _avatarList = new List<PictureBox>();
		private readonly CustomTitleBar _customTitleBar;

		private bool _isSelectedMenuBackCreated = false;
		private bool _isSelectedGameBackCreated = false;
		private bool _isSelectedAvatarCreated = false;

		private readonly List<(Label label, FlowLayoutPanel flp)> _preferences;
		private int _preferenceIndex = 0;

		internal ProfileForm(Player player)
		{
			_customTitleBar = new CustomTitleBar(this, $"{player.Name}");
			IsResizable = true;
			InitializeComponent();

			_customTitleBar.MoveFormElementsDown();
			_player = player;

			_preferences = new List<(Label, FlowLayoutPanel)>
				{
					(labelBackgroundMenu, flpBackgroundMenu),
					(labelAvatar, flpAvatar),
					(labelBackgroundGame, flpBackgroundGame)
				};
		}

		private void ProfileForm_Load(object sender, EventArgs e)
		{
			const int ITEM_SIZE = 100;

			buttonPreferencesLeft.IconChar = FontAwesome.Sharp.IconChar.CircleArrowLeft;
			pictureBoxPlayerAvatar.Image = _player.Preferences.Avatar;
			textBoxPlayerName.MaxLength = PlayerValidator.MAX_NAME_LENGTH;
			textBoxPlayerName.Text = _player.Name;
			textBoxPlayerName.BackColor = BackColor;
			buttonRename.IconColor = _buttonRenameColor.Default;
			tabControl.TabButtonSelectedState.FillColor = BackColor;
			tabControl.TabMenuBackColor = BackColor;
			tabPagePreferences.BackColor = BackColor;

			ImageCreator creatorMenuBack = new ImageCreator(_player, flpBackgroundMenu, SelectMenuBack, ITEM_SIZE);
			AvatarCreator creatorAvatar = new AvatarCreator(_player, flpAvatar, SelectAvatar, ITEM_SIZE);
			ColorCreator creatorGameBack = new ColorCreator(_player, flpBackgroundGame, SelectGameBack, ITEM_SIZE);

			CreatePlayerItems(creatorMenuBack, creatorAvatar, creatorGameBack);
		}

		#region CreateItems
		private void CreatePlayerItems(ImageCreator menuBackCreator,
			AvatarCreator avatarCreator, ColorCreator gameBackCreator)
		{
			foreach (Item item in _player.GetPlayerItems())
				switch (item)
				{
					case Avatar avatar:
						{
							CreateAvatar(avatarCreator, avatar);
							break;
						}
					case ImageItem imageItem:
						{
							CreateMenuBack(menuBackCreator, imageItem);
							break;
						}
					case ColorItem colorItem:
						{
							CreateGameBack(gameBackCreator, colorItem);
							break;
						}
					default:
						{
							throw new InvalidOperationException
								($"Unknown item type: {item.GetType().Name}");
						}
				}
		}
		private void CreateAvatar(AvatarCreator avatarCreator, Avatar avatar)
		{
			PictureBox pictureBox = avatarCreator.CreateItemToSelect(avatar);
			_avatarList.Add(pictureBox);

			if (!_isSelectedAvatarCreated && avatar.Image.CompareTo(_player.Preferences.Avatar))
			{
				SelectAvatar(pictureBox, EventArgs.Empty);
				_isSelectedAvatarCreated = true;
			}
		}
		private void CreateMenuBack(ImageCreator menuBackCreator, ImageItem imageItem)
		{
			PictureBox pictureBox = menuBackCreator.CreateItemToSelect(imageItem);
			_menuBackList.Add(pictureBox);

			if (!_isSelectedMenuBackCreated && imageItem.Image.CompareTo(_player.Preferences.BackgroundMenu))
			{
				SelectMenuBack(pictureBox, EventArgs.Empty);
				_isSelectedMenuBackCreated = true;
			}
		}
		private void CreateGameBack(ColorCreator gameBackCreator, ColorItem colorItem)
		{
			PictureBox pictureBox = gameBackCreator.CreateItemToSelect(colorItem);
			_gameBackList.Add(pictureBox);

			if (!_isSelectedGameBackCreated && colorItem.Color == _player.Preferences.BackgroundGame)
			{
				SelectGameBack(pictureBox, EventArgs.Empty);
				_isSelectedGameBackCreated = true;
			}
		}
		#endregion

		#region SelectAndDeselectItems
		private void SelectAvatar(object sender, EventArgs e)
		{
			if (!(sender is PictureBox selectedPicture))
				return;

			DeselectPreviousItem(_avatarList);
			DefaultSelect(selectedPicture);
			pictureBoxPlayerAvatar.Image = selectedPicture.Image;
		}
		private void SelectMenuBack(object sender, EventArgs e)
		{
			if (!(sender is PictureBox selectedPicture))
				return;

			DeselectPreviousItem(_menuBackList);
			DefaultSelect(selectedPicture);
		}
		private void SelectGameBack(object sender, EventArgs e)
		{
			if (!(sender is PictureBox selectedPicture))
				return;

			DeselectPreviousItem(_gameBackList);
			DefaultSelect(selectedPicture);
		}

		private void DeselectPreviousItem(List<PictureBox> list)
		{
			foreach (PictureBox picture in list)
				if (picture.Tag != null && picture.Tag.ToString() == SELECTED_PICTURE_TAG)
				{
					DefaultDeselect(picture);
					break;
				}
		}

		private void DefaultSelect(PictureBox pictureBox)
		{
			pictureBox.Tag = SELECTED_PICTURE_TAG;
			pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - SELECTED_ITEM_INDENT);
			pictureBox.Enabled = false;
			CreateSelectionLabel(pictureBox.Parent);
		}
		private void DefaultDeselect(PictureBox pictureBox)
		{
			pictureBox.Tag = string.Empty;
			pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + SELECTED_ITEM_INDENT);
			pictureBox.Enabled = true;
			DeleteSelectionLabel(pictureBox.Parent);
		}
		private void CreateSelectionLabel(Control parent)
		{
			Color foreColor = Color.Yellow;

			new Label()
			{
				Parent = parent,
				Text = "Selected",
				BackColor = Color.Transparent,
				ForeColor = foreColor,
				Dock = DockStyle.Bottom,
				TextAlign = ContentAlignment.MiddleCenter,
				Font = new Font("Trebuchet MS", 10F, FontStyle.Bold)
			};

		}
		private void DeleteSelectionLabel(Control parent)
		{
			foreach (Control child in parent.Controls)
				if (child is Label label)
					label.Dispose();
		}
		#endregion

		#region ChangeName
		private void ButtonChangeName_Click(object sender, EventArgs e)
		{
			if (textBoxPlayerName.ReadOnly)
			{
				buttonRename.IconColor = _buttonRenameColor.DuringRenaming;
				textBoxPlayerName.ReadOnly = false;
				textBoxPlayerName.Focus();
				textBoxPlayerName.SelectAll();
			}
			else if (_player.Name == textBoxPlayerName.Text)
			{
				buttonRename.IconColor = _buttonRenameColor.Default;
				textBoxPlayerName.ReadOnly = true;
				ActiveControl = null;
			}
		}

		private bool IsPlayerDataValid()
		{
			PlayerValidator validator = new PlayerValidator();

			Player player = new Player(textBoxPlayerName.Text, _player.Coins, _player.Preferences);
			ValidationResult result = validator.Validate(player);
			if (!result.IsValid)
			{
				MessageBox.Show(result.Errors[0].ErrorMessage, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			else
				return true;
		}
		private void TryToChangeName()
		{
			if (textBoxPlayerName.ReadOnly)
				return;

			if (IsPlayerDataValid())
			{
				ActiveControl = null;
				textBoxPlayerName.ReadOnly = true;
				buttonRename.IconColor = _buttonRenameColor.Default;
				if (_player.Name != textBoxPlayerName.Text)
				{
					_player.ChangeName(textBoxPlayerName.Text);
					_customTitleBar.ChangeFormCaption(textBoxPlayerName.Text);
					MessageBox.Show("Your nickname has been successfully changed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
				textBoxPlayerName.Focus();
		}
		private void TextBoxPlayerName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				TryToChangeName();
		}
		private void TextBoxPlayerName_Leave(object sender, EventArgs e)
			=> TryToChangeName();
		#endregion

		#region ChangePreferenceNavigation
		private void SetPreferenceVisibility(int index)
		{
			for (int i = 0; i < _preferences.Count; i++)
			{
				_preferences[i].label.Visible = (i == index);
				_preferences[i].flp.Visible = (i == index);
			}
		}
		private void ButtonPreferencesLeft_Click(object sender, EventArgs e)
		{
			ActiveControl = null;

			_preferenceIndex--;

			if (_preferenceIndex < 0)
				_preferenceIndex = _preferences.Count - 1;

			SetPreferenceVisibility(_preferenceIndex);
		}
		private void ButtonPreferencesRight_Click(object sender, EventArgs e)
		{
			ActiveControl = null;

			_preferenceIndex++;

			if (_preferenceIndex >= _preferences.Count)
				_preferenceIndex = 0;

			SetPreferenceVisibility(_preferenceIndex);
		}
		#endregion

		private void Shop_FormClosed(object sender, FormClosedEventArgs e)
		{
			Serializator.Serialize(_player, Program.SerializePath, Program.EncryptKey);
		}
	}
}