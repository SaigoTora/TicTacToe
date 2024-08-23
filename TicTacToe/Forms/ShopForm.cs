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
			FillListsOfItems();

			ImageCreator menuBackCreator = new ImageCreator(_player, flpBackMenu, _fontPrice, DefaultSuceesBuy, 100);
			AvatarCreator avatarCreator = new AvatarCreator(_player, flpAvatar, _fontPrice, DefaultSuceesBuy, 100);
			ColorCreator gameBackCreator = new ColorCreator(_player, flpBackGame, _fontPrice, DefaultSuceesBuy, 100);

			CreateNotBoughtItems(_imageItems, menuBackCreator);
			CreateNotBoughtItems(_avatarItems, avatarCreator);
			CreateNotBoughtItems(_colorItems, gameBackCreator);
		}
		private void FillListsOfItems()
		{
			Item[] allItems = ItemManager.GetAllItems();
			for (int i = 0; i < allItems.Length; i++)
				switch (allItems[i])
				{
					case Avatar avatar:
						{
							_avatarItems.Add(avatar);
							break;
						}
					case ImageItem imageItem:
						{
							_imageItems.Add(imageItem);
							break;
						}
					case ColorItem colorItem:
						{
							_colorItems.Add(colorItem);
							break;
						}
					default:
						{
							throw new InvalidOperationException
								($"Unknown item type: {allItems[i].GetType().Name}");
						}
				}
		}

		private void CreateNotBoughtItems<T>(List<T> shopItems, ItemCreator<T> creator) where T : Item
		{
			List<Item> playerItems = _player.GetPlayerItems();

			foreach (T shopItem in shopItems)
				for (int i = 0; i < playerItems.Count; i++)
				{
					if (shopItem.Equals(playerItems[i]))
					{// If the user already has the store item
						playerItems.RemoveAt(i);
						break;
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