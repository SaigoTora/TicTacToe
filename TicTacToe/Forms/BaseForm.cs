using System;
using System.Windows.Forms;

namespace TicTacToe.Forms
{
	internal class BaseForm : Form
	{
		#region CollapseTheFormByClickingOnTheIcon
		const int WS_MINIMIZEBOX = 0x20000;
		const int CS_DBLCLKS = 0x8;

		protected override CreateParams CreateParams
		{// Property for collapsing an open form
			get
			{
				CreateParams cp = base.CreateParams;
				cp.Style |= WS_MINIMIZEBOX;
				cp.ClassStyle |= CS_DBLCLKS;
				return cp;
			}
		}
		#endregion

		#region ResizingForm
		protected bool IsResizable { get; set; } = false;

		private const int HTLEFT = 10;
		private const int HTRIGHT = 11;
		private const int HTTOP = 12;
		private const int HTTOPLEFT = 13;
		private const int HTTOPRIGHT = 14;
		private const int HTBOTTOM = 15;
		private const int HTBOTTOMLEFT = 16;
		private const int HTBOTTOMRIGHT = 17;

		private const int WM_NCHITTEST = 0x84;
		private const int RESIZE_HANDLE_SIZE = 10;

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);

			if (!IsResizable)
				return;

			if (m.Msg == WM_NCHITTEST)
			{
				var cursor = this.PointToClient(Cursor.Position);

				if (cursor.X >= this.ClientSize.Width - RESIZE_HANDLE_SIZE && cursor.Y >= this.ClientSize.Height - RESIZE_HANDLE_SIZE)
					m.Result = (IntPtr)HTBOTTOMRIGHT;
				else if (cursor.X <= RESIZE_HANDLE_SIZE && cursor.Y >= this.ClientSize.Height - RESIZE_HANDLE_SIZE)
					m.Result = (IntPtr)HTBOTTOMLEFT;
				else if (cursor.X <= RESIZE_HANDLE_SIZE && cursor.Y <= RESIZE_HANDLE_SIZE)
					m.Result = (IntPtr)HTTOPLEFT;
				else if (cursor.X >= ClientSize.Width - RESIZE_HANDLE_SIZE && cursor.Y <= RESIZE_HANDLE_SIZE)
					m.Result = (IntPtr)HTTOPRIGHT;
				else if (cursor.X <= RESIZE_HANDLE_SIZE)
					m.Result = (IntPtr)HTLEFT;
				else if (cursor.X >= ClientSize.Width - RESIZE_HANDLE_SIZE)
					m.Result = (IntPtr)HTRIGHT;
				else if (cursor.Y <= RESIZE_HANDLE_SIZE)
					m.Result = (IntPtr)HTTOP;
				else if (cursor.Y >= ClientSize.Height - RESIZE_HANDLE_SIZE)
					m.Result = (IntPtr)HTBOTTOM;
			}
		}
		#endregion
	}
}