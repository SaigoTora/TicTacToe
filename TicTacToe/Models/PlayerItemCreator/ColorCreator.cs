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
		internal ColorCreator(Player player, Panel mainPanel, Font priceFont, int itemSize)
			: base(player, mainPanel, priceFont, itemSize)
		{ }

		/// <summary>
		/// Constructor for creating items to choose from.
		/// </summary>
		internal ColorCreator(Player player, Panel mainPanel, int itemSize)
			: base(player, mainPanel, itemSize)
		{ }

		internal override void CreateItemToBuy(ColorItem item)
		{
			PictureBox pictureBox = new PictureBox
			{
				BackColor = item.Color,
				BorderStyle = BorderStyle.FixedSingle
			};

			Label label = CreateLabelPrice(item);
			CreateItemToBuy(item, pictureBox, label);

			SubscribeControlToBuy(pictureBox, item);
		}
		internal override PictureBox CreateItemToSelect(ColorItem item)
		{
			PictureBox pictureBox = new PictureBox
			{
				BackColor = item.Color,
				BorderStyle = BorderStyle.FixedSingle
			};

			CreateItemToSelect(item, pictureBox);
			SubscribeToSelect(pictureBox, item);

			return pictureBox;
		}
	}
}