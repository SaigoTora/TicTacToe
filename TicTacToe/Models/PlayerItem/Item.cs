using System;

namespace TicTacToe.Models.PlayerItem
{
	[Serializable]
	internal abstract class Item
	{
		internal int Price { get; private set; }

		protected Item(int price)
		{
			Price = price;
		}
	}
}