using System;
using System.Windows.Forms;
using TicTacToe.Models.Utilities.FormUtilities;

namespace TicTacToe.Forms
{
	internal class BaseForm : Form
	{
		#region Collapse the form by clicking on the icon
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

		#region Resizing form
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
		internal Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm;
		private System.ComponentModel.IContainer components;
		private const int RESIZE_HANDLE_SIZE = 10;

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);

			if (!IsResizable)
				return;

			if (m.Msg == WM_NCHITTEST)
			{
				var cursor = PointToClient(Cursor.Position);

				if (cursor.X >= ClientSize.Width - RESIZE_HANDLE_SIZE && cursor.Y >= ClientSize.Height - RESIZE_HANDLE_SIZE)
					m.Result = (IntPtr)HTBOTTOMRIGHT;
				else if (cursor.X <= RESIZE_HANDLE_SIZE && cursor.Y >= ClientSize.Height - RESIZE_HANDLE_SIZE)
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

		protected CustomTitleBar customTitleBar;

		public BaseForm()
		{
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.guna2BorderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.SuspendLayout();
			// 
			// guna2BorderlessForm
			// 
			this.guna2BorderlessForm.BorderRadius = 30;
			this.guna2BorderlessForm.ContainerControl = this;
			this.guna2BorderlessForm.DockIndicatorTransparencyValue = 0.6D;
			this.guna2BorderlessForm.DragForm = false;
			this.guna2BorderlessForm.ResizeForm = false;
			this.guna2BorderlessForm.TransparentWhileDrag = true;
			// 
			// BaseForm
			// 
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "BaseForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaseForm_FormClosed);
			this.ResumeLayout(false);
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
				components.Dispose();

			guna2BorderlessForm?.Dispose();
			base.Dispose(disposing);
		}

		private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
		{ customTitleBar?.Dispose(); }
	}
}