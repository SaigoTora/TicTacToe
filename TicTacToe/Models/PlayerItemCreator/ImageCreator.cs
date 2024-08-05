using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;

namespace TicTacToe.Models.PlayerItemCreator
{
	internal class ImageCreator : ItemCreator<ImageItem>
	{
		/// <summary>
		/// Constructor for creating items for purchase.
		/// </summary>
		internal ImageCreator(Player player, Panel mainPanel, Font priceFont, EventHandler successBuy, int itemSize)
			: base(player, mainPanel, priceFont, successBuy, itemSize)
		{ }

		/// <summary>
		/// Constructor for creating items to choose from.
		/// </summary>
		internal ImageCreator(Player player, Panel mainPanel, EventHandler selectItem, int itemSize)
			: base(player, mainPanel, selectItem, itemSize)
		{ }

		internal override void CreateItemToBuy(ImageItem item)
		{
			PictureBox pictureBox = new PictureBox
			{ Image = item.GetPreviewImage() };

			Label label = CreateLabelPrice(item, Color.Khaki);
			Panel currentPanel = CreateItem(pictureBox, label);

			SubscribeControlToBuy(currentPanel, pictureBox, item);
		}
		internal override PictureBox CreateItemToSelect(ImageItem item)
		{
			PictureBox pictureBox = new PictureBox
			{ Image = item.Image };

			CreateItem(pictureBox);
			SubscribeToSelect(pictureBox, item);

			return pictureBox;
		}
	}
}