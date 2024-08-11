using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace TicTacToe.Models.Utilities
{
	public static class FormEventHandlers
	{
		private const byte PICTURE_SIZE_PERCENT_SCALER = 10;

		private const byte BUTTON_SIZE_PERCENT_SCALER = 4;
		private const byte BUTTON_FONT_SCALER = 2;

		private static bool isControlIncreased = false;
		private static int widthScaler, heightScaler;// Current values ​​for increase in width and height

		#region PictureBoxHover
		public static void SubscribeToHoverPictureBoxes(params PictureBox[] pictureBoxes)
		{
			foreach (PictureBox pictureBox in pictureBoxes)
			{
				pictureBox.MouseEnter += PictureBox_MouseEnter;
				pictureBox.MouseLeave += PictureBox_MouseLeave;
			}
		}
		private static void PictureBox_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is PictureBox picture) || isControlIncreased)
				return;

			ResizeControl(picture, PICTURE_SIZE_PERCENT_SCALER, true);
			isControlIncreased = true;
		}
		private static void PictureBox_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is PictureBox picture))
				return;

			ResizeControl(picture, PICTURE_SIZE_PERCENT_SCALER, false);
			isControlIncreased = false;
		}
		#endregion

		#region ButtonHover
		public static void SubscribeToHoverButtons(params Guna2GradientButton[] buttons)
		{
			foreach (Guna2GradientButton button in buttons)
			{
				button.MouseEnter += Button_MouseEnter;
				button.MouseLeave += Button_MouseLeave;
			}
		}
		private static void Button_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is Guna2GradientButton button) || isControlIncreased)
				return;

			ResizeControl(button, BUTTON_SIZE_PERCENT_SCALER, true);
			ResizeFont(button, BUTTON_FONT_SCALER, true);
			isControlIncreased = true;
		}
		private static void Button_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is Guna2GradientButton button))
				return;

			ResizeControl(button, BUTTON_SIZE_PERCENT_SCALER, false);
			ResizeFont(button, BUTTON_FONT_SCALER, false);
			isControlIncreased = false;
		}
		#endregion

		private static void ResizeControl(Control control, byte percent, bool isIncreasing)
		{
			if (!isIncreasing)
			{
				widthScaler *= -1;
				heightScaler *= -1;
			}
			else
			{
				widthScaler = GetValueUsingPercentage(control.Width, percent);
				heightScaler = GetValueUsingPercentage(control.Height, percent);
			}

			control.Size = new Size(control.Width + widthScaler, control.Height + heightScaler);
			control.Location = new Point(control.Location.X - widthScaler / 2, control.Location.Y - heightScaler / 2);
		}
		private static void ResizeFont(Control control, int value, bool isIncreasing)
		{
			if (!isIncreasing)
				value *= -1;

			control.Font = new Font(control.Font.FontFamily.Name, control.Font.Size + value, control.Font.Style);
		}

		private static int GetValueUsingPercentage(int number, int percent)
		{
			if (percent < 0 || percent > 100)
				throw new ArgumentException("The percentage value must be between 0 and 100.");

			return percent * number / 100;
		}
	}
}