using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;

namespace TicTacToe.Models.PlayerItemCreator
{
	internal class ColorCreator : ItemCreator<ColorItem>
	{
		/// <summary>
		/// Constructor for creating items for purchase.
		/// </summary>
		internal ColorCreator(Player player, Panel mainPanel, Font priceFont, EventHandler successBuy, int itemSize)
			: base(player, mainPanel, priceFont, successBuy, itemSize)
		{ }

		/// <summary>
		/// Constructor for creating items to choose from.
		/// </summary>
		internal ColorCreator(Player player, Panel mainPanel, EventHandler selectItem, int itemSize)
			: base(player, mainPanel, selectItem, itemSize)
		{ }

		internal override void CreateItemToBuy(ColorItem item)
		{
			PictureBox pictureBox = new PictureBox
			{
				BackColor = item.Color,
				BorderStyle = BorderStyle.FixedSingle
			};

			Label label = CreateLabelPrice(item, Color.Khaki);
			Panel currentPanel = CreateItem(pictureBox, label);

			SubscribeControlToBuy(currentPanel, pictureBox, item);
		}
		internal override PictureBox CreateItemToSelect(ColorItem item)
		{
			PictureBox pictureBox = new PictureBox
			{
				BackColor = item.Color,
				BorderStyle = BorderStyle.FixedSingle,
				Cursor = Cursors.Hand
			};

			CreateItem(pictureBox);
			SubscribeToSelect(pictureBox, item);

			return pictureBox;
		}
	}
}