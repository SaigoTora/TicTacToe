using System;

using TicTacToe.Models.PlayerItem;

namespace TicTacToe.Models.CustomExceptions
{
	internal class NotEnoughCoinsToBuyException : Exception
	{
		internal Item Item { get; private set; }

		internal NotEnoughCoinsToBuyException(Item item)
			: base($"You don't have enough coins to buy this item!\nThis item costs {item.Price} coins.")
		{
			Item = item;
		}
	}
}