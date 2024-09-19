using System;
using System.Collections.Generic;

using TicTacToe.Models.PlayerItem;

namespace TicTacToe.Models.PlayerInfo
{
	[Serializable]
	internal class CountableItemsInventory : IInventory<CountableItem>
	{
		private readonly List<CountableItem> _inventory = new List<CountableItem>();

		public List<CountableItem> GetItems()
		{
			List<CountableItem> resultList = new List<CountableItem>();

			foreach (CountableItem item in _inventory)
				resultList.Add(item);

			return resultList;
		}
		public void AddItem(CountableItem item)
		{
			CountableItem foundItem = _inventory.Find(i => i.Type == item.Type);
			if (foundItem == null)
				_inventory.Add(item);
			else
			{
				foundItem.IncreaseCount(item.Count);
				foundItem.SetDateTimePurchase(item.DateTimePurchase);
			}
		}

		internal CountableItem GetItem(GameAssistType type)
			=> (CountableItem)_inventory.Find(i => i.Type == type).Clone();
		internal void UseItem(GameAssistType type)
		{
			CountableItem foundItem = _inventory.Find(i => i.Type == type);
			foundItem.UseItem();
		}
		internal void SetFullItems()
		{
			CountableItem item;
			int count;

			for (int i = 0; i < _inventory.Count; i++)
			{
				count = _inventory[i].Count;
				item = (CountableItem)ItemManager.GetFullItem(_inventory[i]);
				item.IncreaseCount(count);
				_inventory[i] = item;
			}
		}
	}
}