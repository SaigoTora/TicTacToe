using System;
using System.Drawing;

using TicTacToe.Models.Utilities;

namespace TicTacToe.Models.PlayerItem
{
	[Serializable]
	internal class ImageItem : Item
	{
		internal Image Image { get; private set; }
		[NonSerialized]
		private readonly Image _previewImage;

		internal ImageItem(string name, int price, Image image, Image previewImage)
			: base(name, price)
		{
			Image = image;
			_previewImage = previewImage;
		}
		internal ImageItem(string name, int price, Image image)
			: this(name, price, image, image)
		{ }

		internal Image GetPreviewImage() => _previewImage;

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is ImageItem item))
				return false;

			return Image.CompareTo(item.Image);
		}
		public override int GetHashCode() => base.GetHashCode();
	}
}