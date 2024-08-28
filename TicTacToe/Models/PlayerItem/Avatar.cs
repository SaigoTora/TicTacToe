using System;
using System.Drawing;

namespace TicTacToe.Models.PlayerItem
{
	[Serializable]
	internal class Avatar : ImageItem
	{
		[NonSerialized]
		private readonly AvatarRarity _rarity;
		internal AvatarRarity Rarity => _rarity;

		internal Avatar(string name, int price, Image image, AvatarRarity rarity)
			: base(name, price, image)
		{ _rarity = rarity; }
		internal Avatar(string name, int price, Image image, Image previewImage, AvatarRarity rarity)
			: base(name, price, image, previewImage)
		{ _rarity = rarity; }

		public override object Clone()
		{
			Image newImage = (Image)Image.Clone();
			Image newPreviewImage = (Image)PreviewImage.Clone();

			Avatar newAvatar = new Avatar(Name, Price, newImage, newPreviewImage, Rarity)
			{ dateTimePurchase = dateTimePurchase };

			return newAvatar;
		}
	}
}