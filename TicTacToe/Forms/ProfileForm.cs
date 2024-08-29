using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.PlayerItemCreator;
using TicTacToe.Models.Utilities;

namespace TicTacToe.Forms
{
	internal partial class ProfileForm : ItemManagementForm
	{
		private const int SELECTED_ITEM_INDENT = 12;
		private const string SELECTED_ITEM_TEXT = "Selected";
		private const string SELECTED_PICTURE_TAG = "ItemSelected";

		private static readonly (Color Default, Color DuringRenaming) _buttonChangeNameColor = (Color.White, Color.Yellow);

		private readonly CustomTitleBar _customTitleBar;

		private readonly List<PictureBox> _menuBackList = new List<PictureBox>();
		private readonly List<PictureBox> _gameBackList = new List<PictureBox>();
		private readonly List<PictureBox> _avatarList = new List<PictureBox>();

		private bool _isSelectedMenuBackCreated = false;
		private bool _isSelectedGameBackCreated = false;
		private bool _isSelectedAvatarCreated = false;

		internal ProfileForm(Player player) : base(player)
		{
			IsResizable = true;
			_customTitleBar = new CustomTitleBar(this, $"{player.Name}");
			InitializeComponent();

			InitializeCreators();
			preferences = new List<(Label, FlowLayoutPanel)>
			{
				(labelBackgroundMenu, flpBackgroundMenu),
				(labelAvatar, flpAvatar),
				(labelBackgroundGame, flpBackgroundGame)
			};
		}

		private void ProfileForm_Load(object sender, EventArgs e)
		{
			buttonChangeName.IconColor = _buttonChangeNameColor.Default;
			pictureBoxPlayerAvatar.Image = player.Preferences.Avatar.Image;

			textBoxPlayerName.MaxLength = PlayerValidator.MAX_NAME_LENGTH;
			textBoxPlayerName.Text = player.Name;
			textBoxPlayerName.BackColor = BackColor;

			tabControl.TabButtonSelectedState.FillColor = BackColor;
			tabControl.TabMenuBackColor = BackColor;
			tabPagePreferences.BackColor = BackColor;

			CreateItems();
			SubscribeToNavigationButtonEvents(buttonPreferencesLeft,
				buttonPreferencesRight);
		}
		private void InitializeCreators()
		{
			const int ITEM_SIZE = 100;

			menuBackCreator = new ImageCreator(player, flpBackgroundMenu, ITEM_SIZE);
			avatarCreator = new AvatarCreator(player, flpAvatar, ITEM_SIZE);
			gameBackCreator = new ColorCreator(player, flpBackgroundGame, ITEM_SIZE);

			menuBackCreator.Select += SelectMenuBack;
			avatarCreator.Select += SelectAvatar;
			gameBackCreator.Select += SelectGameBack;
		}

		#region CreateItems
		private void CreateItems()
		{
			foreach (Item item in player.GetPlayerItems())
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

			if (!_isSelectedAvatarCreated && avatar.Name == player.Preferences.Avatar.Name)
			{
				SelectAvatar(this, new ItemEventArgs(avatar, pictureBox));
				_isSelectedAvatarCreated = true;
			}
		}
		private void CreateMenuBack(ImageCreator menuBackCreator, ImageItem imageItem)
		{
			PictureBox pictureBox = menuBackCreator.CreateItemToSelect(imageItem);
			_menuBackList.Add(pictureBox);

			if (!_isSelectedMenuBackCreated && imageItem.Name == player.Preferences.BackgroundMenu.Name)
			{
				SelectMenuBack(this, new ItemEventArgs(imageItem, pictureBox));
				_isSelectedMenuBackCreated = true;
			}
		}
		private void CreateGameBack(ColorCreator gameBackCreator, ColorItem colorItem)
		{
			PictureBox pictureBox = gameBackCreator.CreateItemToSelect(colorItem);
			_gameBackList.Add(pictureBox);

			if (!_isSelectedGameBackCreated && colorItem.Name == player.Preferences.BackgroundGame.Name)
			{
				SelectGameBack(this, new ItemEventArgs(colorItem, pictureBox));
				_isSelectedGameBackCreated = true;
			}
		}
		#endregion

		#region SelectAndDeselectItems
		private void SelectAvatar(object sender, ItemEventArgs e)
		{
			if (!(e.ClickableControl is PictureBox selectedPicture))
				return;

			DeselectPreviousItem(_avatarList);
			DefaultSelect(selectedPicture);
			pictureBoxPlayerAvatar.Image = selectedPicture.Image;
		}
		private void SelectMenuBack(object sender, ItemEventArgs e)
		{
			if (!(e.ClickableControl is PictureBox selectedPicture))
				return;

			DeselectPreviousItem(_menuBackList);
			DefaultSelect(selectedPicture);
		}
		private void SelectGameBack(object sender, ItemEventArgs e)
		{
			if (!(e.ClickableControl is PictureBox selectedPicture))
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

			Label selectLabel = new Label()
			{
				Parent = parent,
				Text = SELECTED_ITEM_TEXT,
				ForeColor = foreColor,
				Dock = DockStyle.Bottom,
				TextAlign = ContentAlignment.MiddleCenter,
				Font = new Font("Trebuchet MS", 10F, FontStyle.Bold),
			};
			selectLabel.Size = new Size(0, SELECTED_ITEM_INDENT * 2);
		}
		private void DeleteSelectionLabel(Control parent)
		{
			var labelToRemove = parent.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text == SELECTED_ITEM_TEXT);
			labelToRemove?.Dispose();
		}
		#endregion

		#region ChangeName
		private void ButtonChangeName_Click(object sender, EventArgs e)
		{
			if (textBoxPlayerName.ReadOnly)
			{
				buttonChangeName.IconColor = _buttonChangeNameColor.DuringRenaming;
				textBoxPlayerName.ReadOnly = false;
				textBoxPlayerName.Focus();
				textBoxPlayerName.SelectAll();
			}
			else if (player.Name == textBoxPlayerName.Text)
			{
				buttonChangeName.IconColor = _buttonChangeNameColor.Default;
				textBoxPlayerName.ReadOnly = true;
				ActiveControl = null;
			}
		}

		private bool IsPlayerDataValid()
		{
			PlayerValidator validator = new PlayerValidator();

			Player newPlayer = new Player(textBoxPlayerName.Text, player.Coins, player.Preferences);
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
			if (textBoxPlayerName.ReadOnly)
				return;

			if (IsPlayerDataValid())
			{
				ActiveControl = null;
				textBoxPlayerName.ReadOnly = true;
				buttonChangeName.IconColor = _buttonChangeNameColor.Default;
				if (player.Name != textBoxPlayerName.Text)
				{
					player.ChangeName(textBoxPlayerName.Text);
					_customTitleBar.ChangeFormCaption(textBoxPlayerName.Text);
					CustomMessageBox.Show("Your nickname has been successfully changed.", "Success", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.OK);
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

		private void Shop_FormClosed(object sender, FormClosedEventArgs e)
		{
			UnsubscribeFromNavigationButtonEvents(buttonPreferencesLeft,
				buttonPreferencesRight);
			_customTitleBar.Dispose();

			Serializator.Serialize(player, Program.SerializePath, Program.EncryptKey);
		}
	}
}