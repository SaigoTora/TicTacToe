using System;
using System.Drawing;

namespace TicTacToe.Models.PlayerItem
{
	[Serializable]
	internal class ColorItem : Item
	{
		[NonSerialized]
		private readonly Color _color;
		internal Color Color => _color;

		internal ColorItem(string name, int price, Color color)
			: base(name, price)
		{
			_color = color;
		}

		public override object Clone()
		{
			ColorItem newColorItem = new ColorItem(Name, Price, Color)
			{ _dateTimePurchase = _dateTimePurchase };

			return newColorItem;
		}
	}
}