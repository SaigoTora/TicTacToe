using System.Collections.Generic;

namespace TicTacToe.Models.PlayerInfo.Inventory
{
	internal interface IInventory<T>
	{
		List<T> GetItems();
		void AddItem(T item);
	}
}