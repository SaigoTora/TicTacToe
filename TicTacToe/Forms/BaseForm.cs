using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;
using TicTacToe.Models.PlayerInfo;
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

		private readonly (int Small, int Medium) sizePercentage = (69, 87);
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

		protected void SetFormSize(WindowSize windowSize)
			=> SetControlSize(windowSize, this);
		protected void SetControlSize(WindowSize windowSize, Control control)
		{
			float reduceFontSize = GetFontSizeReduction(windowSize);

			switch (windowSize)
			{
				case WindowSize.Small:
					{
						ReduceControlElements(control, sizePercentage.Small, reduceFontSize);
						break;
					}
				case WindowSize.Medium:
					{
						ReduceControlElements(control, sizePercentage.Medium, reduceFontSize);
						break;
					}
				case WindowSize.Large:
					break;
				default:
					throw new InvalidOperationException($"Unknown window size: {windowSize}");
			}
		}
		protected float GetFontSizeReduction(WindowSize windowSize)
		{
			(float reduceFontSizeSmall, float reduceFontSizeMedium, float reduceFontSizeLarge) =
				(4, 3, 0);

			switch (windowSize)
			{
				case WindowSize.Small:
					return reduceFontSizeSmall;
				case WindowSize.Medium:
					return reduceFontSizeMedium;
				case WindowSize.Large:
					return reduceFontSizeLarge;
				default:
					throw new InvalidOperationException($"Unknown window size: {windowSize}");
			}
		}

		private void ReduceControlElements(Control control, int percentage, float reduceFontSize)
		{
			if (control.Name == customTitleBar.MainPanel.Name)
				return;

			if (!(control is Guna2TabControl))
				ReduceControl(control, percentage, reduceFontSize);

			if (control.Controls.Count > 0)
				foreach (Control childControl in control.Controls)
					ReduceControlElements(childControl, percentage, reduceFontSize);
		}
		private void ReduceControl(Control control, int percentage, float reduceFontSize)
		{
			control.Size = new Size(GetNumberByPercentage(control.Width, percentage, true),
				GetNumberByPercentage(control.Height, percentage, true));

			if (control is BaseForm form)
				form.Location = new Point(
					(Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
					(Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2
				);
			else
				control.Location = new Point(GetNumberByPercentage(control.Location.X, percentage, false),
					GetNumberByPercentage(control.Location.Y, percentage, false));

			if (control is Label || control is RichTextBox || control is TextBox
				|| control is Guna2ComboBox)
				control.Font = ReduceFontSize(control.Font, reduceFontSize);
			if (control is IconButton iconButton)
			{
				iconButton.IconSize = GetNumberByPercentage(iconButton.IconSize, percentage, true);
				iconButton.Font = ReduceFontSize(iconButton.Font, reduceFontSize + reduceFontSize);
			}
			if (control is Guna2GradientButton button)
			{
				button.BorderRadius = GetNumberByPercentage(button.BorderRadius, percentage, false);
				button.Font = new Font(button.Font.FontFamily, GetNumberByPercentage((int)button.Font.Size, percentage, true));
			}
			if (control is Guna2CircleProgressBar progressBar)
				progressBar.ImageSize = new Size(GetNumberByPercentage(progressBar.ImageSize.Width, percentage, true),
				GetNumberByPercentage(progressBar.ImageSize.Height, percentage, true));
		}
		private Font ReduceFontSize(Font font, float reduceFontSize)
			=> new Font(font.FontFamily, font.Size - reduceFontSize);
		private int GetNumberByPercentage(int number, int percentage, bool roundUp)
		{
			double result = (double)number * percentage / 100;
			return roundUp ? (int)Math.Ceiling(result) : (int)Math.Floor(result);
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