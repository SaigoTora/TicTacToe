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
		internal ImageCreator(Player player, Panel mainPanel, Font priceFont, int itemSize)
			: base(player, mainPanel, priceFont, itemSize)
		{ }

		/// <summary>
		/// Constructor for creating items to choose from.
		/// </summary>
		internal ImageCreator(Player player, Panel mainPanel, int itemSize)
			: base(player, mainPanel, itemSize)
		{ }

		internal override void CreateItemToBuy(ImageItem item)
		{
			PictureBox pictureBox = new PictureBox
			{
				Image = item.PreviewImage
			};

			Label label = CreateLabelPrice(item);
			CreateItemToBuy(item, pictureBox, label);

			SubscribeControlToClick(pictureBox, item);
		}
		internal override PictureBox CreateItemToSelect(ImageItem item)
		{
			PictureBox pictureBox = new PictureBox
			{
				Image = item.Image
			};

			CreateItemToSelect(item, pictureBox);

			SubscribeControlToClick(pictureBox, item);
			SubscribeControlToHover(pictureBox, item);

			return pictureBox;
		}
	}
}