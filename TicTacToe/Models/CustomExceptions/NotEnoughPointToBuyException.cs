using System;

using TicTacToe.Models.PlayerItem;

namespace TicTacToe.Models.CustomExceptions
{
	internal class NotEnoughPointToBuyException : Exception
	{
		internal Item Item { get; private set; }

		internal NotEnoughPointToBuyException(Item item)
			: base($"You don't have enough points to buy this item!\nThis item costs {item.Price} points.")
		{
			Item = item;
		}
	}
}