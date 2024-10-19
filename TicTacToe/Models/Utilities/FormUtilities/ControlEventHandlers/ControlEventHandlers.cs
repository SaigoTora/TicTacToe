using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe.Models.Utilities.FormUtilities.ControlEventHandlers
{
	internal abstract class ControlEventHandlers<T> where T : Control
	{
		protected readonly List<T> controls = new List<T>();
		protected bool isControlIncreased = false;
		protected int widthScaler, heightScaler;// Current values ​​for increase in width and height

		#region Abstract methods
		/// <summary>
		/// Unsubscribes the specified control from its event handlers.
		/// </summary>
		/// <param name="control">The control to unsubscribe.</param>
		protected abstract void DefaultUnsubscribe(T control);
		/// <summary>
		/// Fully unsubscribes the specified control and removes it from the list.
		/// </summary>
		/// <param name="control">The control to unsubscribe and remove.</param>
		internal abstract void Unsubscribe(T control);
		/// <summary>
		/// Unsubscribes all controls and clears the list.
		/// </summary>
		internal abstract void UnsubscribeAll();
		#endregion

		protected void ResizeControl(T control, byte percent, bool isIncreasing)
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
		protected void ResizeFont(T control, int value, bool isIncreasing)
		{
			if (!isIncreasing)
				value *= -1;

			control.Font = new Font(control.Font.FontFamily.Name, control.Font.Size + value, control.Font.Style);
		}
		private int GetValueUsingPercentage(int number, int percent)
		{
			if (percent < 0 || percent > 100)
				throw new ArgumentException("The percentage value must be between 0 and 100.");

			return percent * number / 100;
		}
	}
}