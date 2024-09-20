using System;
using System.Drawing;

namespace TicTacToe.Models.PlayerItem
{
	internal enum GameAssistType : byte
	{
		UndoMove,
		Hint,
		Surrender
	}

	[Serializable]
	internal class CountableItem : ImageItem
	{
		private readonly GameAssistType _type;
		internal GameAssistType Type => _type;

		private int _count;
		internal int Count => _count;

		internal CountableItem(string name, int price, string description, Image image, GameAssistType type, int count = 0)
			: base(name, price, description, image)
		{
			_type = type;
			_count = count;
		}

		internal void IncreaseCount(int quantity)
			=> _count += quantity;
		internal void UseItem()
		{
			if (Count == 0)
				throw new InvalidOperationException($"You cannot use the item '{Name}' because its quantity is 0!");

			_count--;
		}

		public override object Clone()
		{
			Image newImage = (Image)Image.Clone();

			CountableItem newCountableItem = new CountableItem(Name, Price, Description, newImage, Type, Count)
			{ dateTimePurchase = dateTimePurchase };

			return newCountableItem;
		}
	}
}
