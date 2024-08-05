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
	internal partial class ProfileForm : Form
	{
		private const int SELECTED_ITEM_INDENT = 15;
		private const string SELECTED_PICTURE_TAG = "Selected";

		private readonly Player _player;

		private readonly List<PictureBox> _menuBackList = new List<PictureBox>();
		private readonly List<PictureBox> _gameBackList = new List<PictureBox>();
		private readonly List<PictureBox> _avatarList = new List<PictureBox>();

		private bool _isSelectedMenuBackCreated = false;
		private bool _isSelectedGameBackCreated = false;
		private bool _isSelectedAvatarCreated = false;

		internal ProfileForm(Player player)
		{
			InitializeComponent();

			_player = player;
		}

		private void ProfileForm_Load(object sender, EventArgs e)
		{
			ImageCreator creatorMenuBack = new ImageCreator(_player, flpBackgroundMenu, SelectMenuBack, 100);
			AvatarCreator creatorAvatar = new AvatarCreator(_player, flpAvatar, SelectAvatar, 100);
			ColorCreator creatorGameBack = new ColorCreator(_player, flpBackgroundGame, SelectGameBack, 100);

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

			if (!_isSelectedAvatarCreated && avatar.Image.CompareTo(_player.Settings.Avatar))
			{
				SelectAvatar(pictureBox, EventArgs.Empty);
				_isSelectedAvatarCreated = true;
			}
		}
		private void CreateMenuBack(ImageCreator menuBackCreator, ImageItem imageItem)
		{
			PictureBox pictureBox = menuBackCreator.CreateItemToSelect(imageItem);
			_menuBackList.Add(pictureBox);

			if (!_isSelectedMenuBackCreated && imageItem.Image.CompareTo(_player.Settings.BackgroundMenu))
			{
				SelectMenuBack(pictureBox, EventArgs.Empty);
				_isSelectedMenuBackCreated = true;
			}
		}
		private void CreateGameBack(ColorCreator gameBackCreator, ColorItem colorItem)
		{
			PictureBox pictureBox = gameBackCreator.CreateItemToSelect(colorItem);
			_gameBackList.Add(pictureBox);

			if (!_isSelectedGameBackCreated && colorItem.Color == _player.Settings.BackgroundGame)
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
		}
		private void DefaultDeselect(PictureBox pictureBox)
		{
			pictureBox.Tag = string.Empty;
			pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + SELECTED_ITEM_INDENT);
			pictureBox.Enabled = true;
		}
		#endregion

		private void Shop_FormClosed(object sender, FormClosedEventArgs e)
		{
			Serializator.Serialize(_player, Program.SerializePath, Program.EncryptKey);
		}
	}
}