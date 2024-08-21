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
	internal partial class ShopForm : Form
	{
		private readonly Font _fontPrice = new Font("Courier New", 16F, FontStyle.Bold);

		private readonly Player _player;
		private readonly List<ImageItem> _imageItems = new List<ImageItem>();
		private readonly List<Avatar> _avatarItems = new List<Avatar>();
		private readonly List<ColorItem> _colorItems = new List<ColorItem>();

		internal ShopForm(Player player)
		{
			InitializeComponent();

			_player = player;
		}

		private void ShopForm_Load(object sender, EventArgs e)
		{
			labelCoins.Text = _player.Coins.ToString();

			SetImageItems();
			SetAvatarItems();
			SetColorItems();

			ImageCreator menuBackCreator = new ImageCreator(_player, flpBackMenu, _fontPrice, DefaultSuceesBuy, 100);
			AvatarCreator avatarCreator = new AvatarCreator(_player, flpAvatar, _fontPrice, DefaultSuceesBuy, 100);
			ColorCreator gameBackCreator = new ColorCreator(_player, flpBackGame, _fontPrice, DefaultSuceesBuy, 100);

			CreateNotBoughtItems(_imageItems, menuBackCreator);
			CreateNotBoughtItems(_avatarItems, avatarCreator);
			CreateNotBoughtItems(_colorItems, gameBackCreator);
		}

		#region ShopItems
		private void SetImageItems()
		{
			_imageItems.Add(new ImageItem(100, Properties.Resources.background5));
			_imageItems.Add(new ImageItem(100, Properties.Resources.background9));
			_imageItems.Add(new ImageItem(150, Properties.Resources.background2, Properties.Resources.mystery1));
			_imageItems.Add(new ImageItem(150, Properties.Resources.background3, Properties.Resources.mystery1));
			_imageItems.Add(new ImageItem(150, Properties.Resources.background6, Properties.Resources.mystery1));
			_imageItems.Add(new ImageItem(150, Properties.Resources.background7, Properties.Resources.mystery1));
			_imageItems.Add(new ImageItem(200, Properties.Resources.background4, Properties.Resources.mystery1));
			_imageItems.Add(new ImageItem(200, Properties.Resources.background8, Properties.Resources.mystery1));
			_imageItems.Add(new ImageItem(200, Properties.Resources.background10, Properties.Resources.mystery1));
		}
		private void SetAvatarItems()
		{
			_avatarItems.Add(new Avatar(0, Properties.Resources.womanAvatar1, AvatarRarity.Common));
			_avatarItems.Add(new Avatar(25, Properties.Resources.manAvatar2, AvatarRarity.Common));
			_avatarItems.Add(new Avatar(25, Properties.Resources.womanAvatar2, AvatarRarity.Common));
			_avatarItems.Add(new Avatar(25, Properties.Resources.manAvatar3, AvatarRarity.Common));
			_avatarItems.Add(new Avatar(25, Properties.Resources.womanAvatar3, AvatarRarity.Common));
			_avatarItems.Add(new Avatar(25, Properties.Resources.manAvatar4, AvatarRarity.Common));
			_avatarItems.Add(new Avatar(25, Properties.Resources.womanAvatar4, AvatarRarity.Common));
			_avatarItems.Add(new Avatar(25, Properties.Resources.manAvatar5, AvatarRarity.Common));
			_avatarItems.Add(new Avatar(25, Properties.Resources.womanAvatar5, AvatarRarity.Common));
			_avatarItems.Add(new Avatar(100, Properties.Resources.legendaryAvatar1, Properties.Resources.mystery1, AvatarRarity.Legendary));
			_avatarItems.Add(new Avatar(100, Properties.Resources.legendaryAvatar2, Properties.Resources.mystery1, AvatarRarity.Legendary));
			_avatarItems.Add(new Avatar(100, Properties.Resources.legendaryAvatar3, Properties.Resources.mystery1, AvatarRarity.Legendary));
			_avatarItems.Add(new Avatar(100, Properties.Resources.legendaryAvatar4, Properties.Resources.mystery1, AvatarRarity.Legendary));
		}
		private void SetColorItems()
		{
			_colorItems.Add(new ColorItem(35, Color.DimGray));
			_colorItems.Add(new ColorItem(35, Color.RosyBrown));
			_colorItems.Add(new ColorItem(35, Color.NavajoWhite));
			_colorItems.Add(new ColorItem(35, Color.Khaki));
			_colorItems.Add(new ColorItem(35, Color.DarkSeaGreen));
			_colorItems.Add(new ColorItem(35, Color.Turquoise));
			_colorItems.Add(new ColorItem(35, Color.SteelBlue));
			_colorItems.Add(new ColorItem(35, Color.MediumPurple));
			_colorItems.Add(new ColorItem(35, Color.PaleVioletRed));
		}
		#endregion

		private void CreateNotBoughtItems<T>(List<T> shopItems, ItemCreator<T> creator) where T : Item
		{
			List<Item> playerItems = _player.GetPlayerItems();

			foreach (T shopItem in shopItems)
				for (int i = 0; i < playerItems.Count; i++)
				{
					if (playerItems[i].GetType().Equals(typeof(T)))
					{// If the current player element is the correct type
						if (shopItem.Equals(playerItems[i]))
						{// If the user already has the store item
							playerItems.RemoveAt(i);
							break;
						}
					}
					if (i == playerItems.Count - 1)// If no matches were found,
						creator.CreateItemToBuy(shopItem);// then the item should be created
				}
		}

		private void DefaultSuceesBuy(object sender, EventArgs e)
		{
			labelCoins.Text = _player.Coins.ToString();
			MessageBox.Show("The product has been successfully purchased!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		private void Shop_FormClosed(object sender, FormClosedEventArgs e)
		{
			Serializator.Serialize(_player, Program.SerializePath, Program.EncryptKey);
		}
	}
}