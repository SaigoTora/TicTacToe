using System;
using System.Drawing;

namespace TicTacToe.Models.PlayerItem
{
	[Serializable]
	internal class ImageItem : Item
	{
		[NonSerialized]
		private readonly Image _image;
		internal Image Image => _image;

		[NonSerialized]
		private readonly Image _previewImage;
		internal Image PreviewImage => _previewImage;

		internal ImageItem(string name, int price, Image image, Image previewImage)
			: base(name, price)
		{
			_image = image;
			_previewImage = previewImage;
		}
		internal ImageItem(string name, int price, Image image)
			: this(name, price, image, image)
		{ }

		public override object Clone()
		{
			Image newImage = (Image)Image.Clone();
			Image newPreviewImage = (Image)PreviewImage.Clone();

			ImageItem newImageItem = new ImageItem(Name, Price, newImage, newPreviewImage)
			{ _dateTimePurchase = this._dateTimePurchase };

			return newImageItem;
		}
	}
}