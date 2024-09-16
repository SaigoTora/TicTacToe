using System;
using System.Collections.Generic;

using TicTacToe.Models.PlayerItem;

namespace TicTacToe.Models.PlayerInfo
{
	[Serializable]
	internal class ItemsInventory : IInventory<Item>
	{
		private List<Item> _inventory = new List<Item>();

		public List<Item> GetItems()
		{
			List<Item> resultList = new List<Item>();

			foreach (Item item in _inventory)
				resultList.Add(item);

			return resultList;
		}
		public void AddItem(Item item)
		{
			if (_inventory == null)
				_inventory = new List<Item>();

			_inventory.Add(item);
		}
		internal void SetDefaultInventory()
		{
			_inventory = new List<Item>();
			List<Item> defaultItems = ItemManager.GetDefaultItems();
			foreach (Item item in defaultItems)
			{
				item.SetDateTimePurchaseNow();
				_inventory.Add(item);
			}
		}
		internal void SetFullItems()
		{
			for (int i = 0; i < _inventory.Count; i++)
				_inventory[i] = ItemManager.GetFullItem(_inventory[i]);
		}
	}
}