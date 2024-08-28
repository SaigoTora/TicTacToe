using System;
using System.Collections.Generic;

namespace TicTacToe.Models.PlayerItem
{
	[Serializable]
	internal abstract class Item : ICloneable
	{
		internal string Name { get; private set; }

		[NonSerialized]
		private readonly int _price;
		internal int Price => _price;

		protected DateTime dateTimePurchase;
		internal DateTime DateTimePurchase
			=> dateTimePurchase.ToLocalTime();

		protected Item(string name, int price)
		{
			Name = name;
			_price = price;
		}
		public abstract object Clone();

		internal void SetDateTimePurchaseNow()
			=> dateTimePurchase = DateTime.UtcNow;

		public override bool Equals(object obj)
		{
			if (obj is Item item)
				return Name == item.Name &&
					   Price == item.Price;

			return false;
		}
		public override int GetHashCode()
		{
			int hashCode = 1557183321;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + _price.GetHashCode();
			hashCode = hashCode * -1521134295 + dateTimePurchase.GetHashCode();

			return hashCode;
		}
	}
}