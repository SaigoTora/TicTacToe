using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TicTacToe.Models.Utilities.FormUtilities
{
	internal class NoCaretRichTextBox : RichTextBox
	{
		[DllImport("user32.dll")]
		private static extern bool HideCaret(IntPtr hWnd);

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			HideCaret(Handle);// Hide the caret when receiving focus
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			HideCaret(Handle);// Hide the caret on click
		}

		protected override void OnSelectionChanged(EventArgs e)
		{
			base.OnSelectionChanged(e);
			HideCaret(Handle);// Hide the caret when selecting text
		}
	}
}