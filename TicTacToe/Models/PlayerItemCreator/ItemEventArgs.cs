using System;
using System.Windows.Forms;
using TicTacToe.Models.PlayerItem;

namespace TicTacToe.Models.PlayerItemCreator
{
	internal class ItemEventArgs : EventArgs
	{
		internal readonly Item Item;
		internal readonly Control ClickableControl;

		internal ItemEventArgs(Item item, Control clickableControl)
		{
			Item = item;
			ClickableControl = clickableControl;
		}
	}
}