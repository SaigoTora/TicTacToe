using System.Windows.Forms;
using TicTacToe.Models.PlayerItem;

namespace TicTacToe.Models.PlayerItemCreator
{
	internal class ItemBuyEventArgs : ItemEventArgs
	{
		internal readonly bool Success;

		internal ItemBuyEventArgs(Item item, Control control, bool haveEnoughCoins) : base(item, control)
		{
			Success = haveEnoughCoins;
		}
	}
}