using System;

namespace TicTacToe.Models.PlayerItem
{
	[Serializable]
	internal abstract class Item
	{
		internal string Name { get; private set; }
		internal int Price { get; private set; }

		private DateTime _dateTimePurchase;
		internal DateTime DateTimePurchase
		{ get => _dateTimePurchase.ToLocalTime(); }

		protected Item(string name, int price)
		{
			Name = name;
			Price = price;
		}

		internal void SetDateTimePurchaseNow()
			=> _dateTimePurchase = DateTime.UtcNow;

		public override bool Equals(object obj)
		{
			if (!GetType().Equals(obj.GetType()))
				return false;

			return obj is Item item &&
				   Name == item.Name &&
				   Price == item.Price;
		}
		public override int GetHashCode() => base.GetHashCode();
	}
}