using System;
using System.Drawing;

namespace TicTacToe.Models.PlayerItem
{
	[Serializable]
	internal class Avatar : ImageItem
	{
		public AvatarRarity Rarity { get; private set; }

		internal Avatar(int price, Image image, AvatarRarity rarity) : base(price, image)
		{ Rarity = rarity; }
		internal Avatar(int price, Image image, Image previewImage, AvatarRarity rarity) : base(price, image, previewImage)
		{ Rarity = rarity; }
	}
}