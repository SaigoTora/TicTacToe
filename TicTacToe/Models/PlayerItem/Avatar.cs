using System;
using System.Drawing;

namespace TicTacToe.Models.PlayerItem
{
	[Serializable]
	internal class Avatar : ImageItem
	{
		public AvatarRarity Rarity { get; private set; }

		internal Avatar(string name, int price, Image image, AvatarRarity rarity) : base(name, price, image)
		{ Rarity = rarity; }
		internal Avatar(string name, int price, Image image, Image previewImage, AvatarRarity rarity) : base(name, price, image, previewImage)
		{ Rarity = rarity; }
	}
}