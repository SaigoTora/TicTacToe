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
		internal AvatarCreator(Player player, Panel mainPanel, Font priceFont, int itemSize)
			: base(player, mainPanel, priceFont, itemSize)
		{ }

		/// <summary>
		/// Constructor for creating items to choose from.
		/// </summary>
		internal AvatarCreator(Player player, Panel mainPanel, int itemSize)
			: base(player, mainPanel, itemSize)
		{ }

		internal override void CreateItemToBuy(Avatar item)
		{
			PictureBox pictureBox = new PictureBox
			{
				Image = item.PreviewImage
			};

			Label label = CreateLabelPrice(item);
			CreateItemToBuy(item, pictureBox, label);

			SubscribeControlToBuy(pictureBox, item);
		}
		internal override PictureBox CreateItemToSelect(Avatar item)
		{
			PictureBox pictureBox = new PictureBox
			{
				Image = item.Image,
			};

			CreateItemToSelect(pictureBox);
			SubscribeToSelect(pictureBox, item);

			return pictureBox;
		}
	}
}