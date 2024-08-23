using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;

namespace TicTacToe.Models.PlayerItemCreator
{
	internal class AvatarCreator : ItemCreator<Avatar>
	{
		/// <summary>
		/// Constructor for creating items for purchase.
		/// </summary>
		internal AvatarCreator(Player player, Panel mainPanel, Font priceFont, EventHandler successBuy, int itemSize)
			: base(player, mainPanel, priceFont, successBuy, itemSize)
		{ }

		/// <summary>
		/// Constructor for creating items to choose from.
		/// </summary>
		internal AvatarCreator(Player player, Panel mainPanel, EventHandler selectItem, int itemSize)
			: base(player, mainPanel, selectItem, itemSize)
		{ }

		internal override void CreateItemToBuy(Avatar item)
		{
			PictureBox pictureBox = new PictureBox
			{
				Image = item.PreviewImage
			};

			Label label = CreateLabelPrice(item, Color.Khaki);
			Panel currentPanel = CreateItem(pictureBox, label);

			SubscribeControlToBuy(currentPanel, pictureBox, item);
		}
		internal override PictureBox CreateItemToSelect(Avatar item)
		{
			PictureBox pictureBox = new PictureBox
			{
				Image = item.Image,
				Cursor = Cursors.Hand
			};

			CreateItem(pictureBox);
			SubscribeToSelect(pictureBox, item);

			return pictureBox;
		}
	}
}