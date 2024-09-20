using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace TicTacToe.Models.Utilities
{
	public static class Extensions
	{
		#region Image extensions

		/// <summary>
		/// Changes the opacity level of an image.
		/// </summary>
		/// <param name="image">This instance.</param>
		/// <param name="opacity">Opacity level in the range from 0 to 1.</param>
		/// <returns>Returns a new Bitmap object with the specified opacity.</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static Bitmap ChangeOpacity(this Image image, float opacity)
		{
			if (image == null)
				throw new ArgumentNullException(nameof(image));

			Bitmap bmp = new Bitmap(image.Width, image.Height);
			using (Graphics graphics = Graphics.FromImage(bmp))
			{
				ColorMatrix matrix = new ColorMatrix
				{ Matrix33 = opacity };

				ImageAttributes attributes = new ImageAttributes();
				attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

				graphics.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0,
					image.Width, image.Height, GraphicsUnit.Pixel, attributes);
			}

			return bmp;
		}
		#endregion

		#region String extensions
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