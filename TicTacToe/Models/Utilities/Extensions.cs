using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace TicTacToe.Models.Utilities
{
	public static class Extensions
	{
		#region ImageExtensions
		/// <summary>
		/// Compares this instance with an Image object.
		/// </summary>
		/// <param name="image1">This instance.</param>
		/// <param name="image2">Image compared to this instance.</param>
		/// <returns>If the images are equal, the method will return true, otherwise - false.</returns>
		public static bool CompareTo(this Image image1, Image image2)
		{
			if (image1 == null || image2 == null)
				return false;

			if (image1.Width != image2.Width || image1.Height != image2.Height)
				return false;

			byte[] img1Bytes = ImageToByteArray(image1);
			byte[] img2Bytes = ImageToByteArray(image2);

			for (int i = 0; i < img1Bytes.Length; i++)
				if (img1Bytes[i] != img2Bytes[i])
					return false;

			return true;
		}
		private static byte[] ImageToByteArray(Image image)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				image.Save(ms, ImageFormat.Png);
				return ms.ToArray();
			}
		}
		#endregion

		#region StringExtensions
		/// <summary>
		/// The method leaves in the string only the first occurrence of characters that follow in a row.
		/// </summary>
		/// <param name="str">This instance.</param>
		/// <param name="ch">Duplicate symbol.</param>
		/// <returns>Returns a new string without duplicate ch characters.</returns>
		public static string DeleteDuplicateChars(this string str, char ch)
		{
			StringBuilder result = new StringBuilder();

			for (int i = 0; i < str.Length; i++)
			{
				result.Append(str[i]);
				if (str[i] == ch)
					while (i + 1 < str.Length && str[i + 1] == ch)
						i++;
			}

			return result.ToString();
		}
		#endregion
	}
}