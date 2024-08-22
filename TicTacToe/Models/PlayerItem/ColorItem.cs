using System;
using System.Drawing;

namespace TicTacToe.Models.PlayerItem
{
	[Serializable]
	internal class ColorItem : Item
	{
		internal Color Color { get; private set; }

		internal ColorItem(string name, int price, Color color)
			: base(name, price)
		{
			Color = color;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is ColorItem item))
				return false;

			return Color == item.Color;
		}
		public override int GetHashCode() => base.GetHashCode();
	}
}