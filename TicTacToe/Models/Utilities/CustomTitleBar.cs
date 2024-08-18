using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace TicTacToe.Models.Utilities
{
	internal class CustomTitleBar
	{
		private const int DEFAULT_PANEL_HEIGHT = 35;

		private static readonly Font _formNameFont = new Font("Segoe UI", 10F);
		private static readonly Color _defaultPanelColor = Color.FromArgb(31, 31, 31);
		private static readonly Color _pressedPanelColor = Color.FromArgb(35, 35, 35);
		private static readonly Color _defaultButtonColor = Color.FromArgb(200, 200, 200);
		private static readonly Color _defaultNameColor = Color.FromArgb(255, 255, 255);
		private readonly (bool Minimize, bool Maximize) _scalingForm;
		private readonly Form _form;

		internal Panel MainPanel { get; private set; } = new Panel();

		private bool _isFormDragging;
		private Point _dragCursorPoint, _dragFormPoint;

		internal CustomTitleBar(Form form, string formName, System.Drawing.Icon icon = null, bool minimizeBox = true, bool maximizeBox = true)
		{
			_scalingForm.Minimize = minimizeBox;
			_scalingForm.Maximize = maximizeBox;
			InitializeComponents();

			if (!string.IsNullOrWhiteSpace(formName))
				MainPanel.Controls.Add(CreateFormName(formName));
			if (icon != null)
				MainPanel.Controls.Add(CreateFormIcon(icon));

			_form = form;
			_form.Controls.Add(MainPanel);
		}
		private void InitializeComponents()
		{
			InitializeMainPanel();

			if (_scalingForm.Minimize)
			{
				IconButton buttonMinimize = CreateIconButton(IconChar.WindowMinimize);
				buttonMinimize.Click += ButtonMinimize_Click;
				MainPanel.Controls.Add(buttonMinimize);
			}

			if (_scalingForm.Maximize)
			{
				IconButton buttonMaximize = CreateIconButton(IconChar.WindowRestore);
				buttonMaximize.Click += ButtonMaximize_Click;
				MainPanel.Controls.Add(buttonMaximize);
			}

			IconButton buttonClose = CreateIconButton(IconChar.TimesCircle);
			buttonClose.Click += ButtonExit_Click;
			MainPanel.Controls.Add(buttonClose);
		}
		private void InitializeMainPanel()
		{
			const int LEFT_PADDING = 6;

			MainPanel.BackColor = _defaultPanelColor;
			MainPanel.Dock = DockStyle.Top;
			MainPanel.Size = new Size(0, DEFAULT_PANEL_HEIGHT);
			MainPanel.Padding = new Padding(LEFT_PADDING, 0, 0, 0);

			ToggleEventHandlers(MainPanel, true);
		}

		internal void MoveFormElementsDown()
		{
			MoveFormElementsDown(_form);
			_form.Height = _form.Height + DEFAULT_PANEL_HEIGHT;
		}
		private void MoveFormElementsDown(Control control)
		{
			if (control.Controls.Count > 0 && !(control is NumericUpDown))
				foreach (Control item in control.Controls)
					MoveFormElementsDown(item);
			else if (!control.Anchor.HasFlag(AnchorStyles.Bottom))
				control.Location = new Point(control.Location.X, control.Location.Y + DEFAULT_PANEL_HEIGHT);
		}
		internal void Dispose()
		{
			ToggleEventHandlers(MainPanel, false);
			foreach (Control control in MainPanel.Controls)
			{
				if (control is IconButton iconButton)
				{
					iconButton.Click -= ButtonMinimize_Click;
					iconButton.Click -= ButtonMaximize_Click;
					iconButton.Click -= ButtonExit_Click;
				}
				else if (control is PictureBox pictureBox)
					ToggleEventHandlers(pictureBox, false);
				else if (control is Label label)
					ToggleEventHandlers(label, false);
			}
		}

		private IconButton CreateIconButton(IconChar iconChar)
		{
			const int PADDING = 15;
			const int SIZE = 25;

			IconButton iconButton = new IconButton
			{
				Anchor = AnchorStyles.Top | AnchorStyles.Right,
				Dock = DockStyle.Right,
				Size = new Size(DEFAULT_PANEL_HEIGHT + PADDING, 0),
				IconSize = SIZE,
				IconColor = _defaultButtonColor,
				FlatStyle = FlatStyle.Flat,
				Cursor = Cursors.Hand,
				TabStop = false,
				IconChar = iconChar
			};
			iconButton.FlatAppearance.BorderSize = 0;

			return iconButton;
		}
		private PictureBox CreateFormIcon(System.Drawing.Icon icon)
		{
			const int SIZE = 27;

			PictureBox iconPictureBox = new PictureBox()
			{
				Anchor = AnchorStyles.Top | AnchorStyles.Left,
				Dock = DockStyle.Left,
				Size = new Size(SIZE, 0),
				Image = icon.ToBitmap(),
				SizeMode = PictureBoxSizeMode.Zoom,
			};

			ToggleEventHandlers(iconPictureBox, true);

			return iconPictureBox;
		}
		private Label CreateFormName(string name)
		{
			const int MAX_NAME_LENGTH = 80;

			if (name.Length > MAX_NAME_LENGTH)
				name = name.Substring(0, MAX_NAME_LENGTH) + "...";
			Label labelName = new Label()
			{
				Anchor = AnchorStyles.Top | AnchorStyles.Left,
				Dock = DockStyle.Fill,
				ForeColor = _defaultNameColor,
				Text = name,
				TextAlign = ContentAlignment.MiddleLeft,
				Font = _formNameFont,
			};

			ToggleEventHandlers(labelName, true);

			return labelName;
		}

		private void ToggleWindowState()
		{
			if (_form.WindowState == FormWindowState.Maximized)
			{
				_form.WindowState = FormWindowState.Normal;
				_form.StartPosition = FormStartPosition.CenterScreen;
			}
			else
				_form.WindowState = FormWindowState.Maximized;
		}
		private void ToggleEventHandlers(Control control, bool subscribe)
		{
			if (subscribe)
			{
				control.DoubleClick += Control_DoubleClick;
				control.MouseDown += Control_MouseDown;
				control.MouseUp += Control_MouseUp;
				control.MouseMove += Control_MouseMove;
			}
			else
			{
				control.DoubleClick -= Control_DoubleClick;
				control.MouseDown -= Control_MouseDown;
				control.MouseUp -= Control_MouseUp;
				control.MouseMove -= Control_MouseMove;
			}
		}


		#region EventHandlers
		private void ButtonMaximize_Click(object sender, EventArgs e)
		{
			_form.ActiveControl = null;
			ToggleWindowState();
		}
		private void ButtonMinimize_Click(object sender, EventArgs e)
		{
			_form.ActiveControl = null;
			_form.WindowState = FormWindowState.Minimized;
		}
		private void ButtonExit_Click(object sender, EventArgs e)
			=> _form.Close();

		private void Control_DoubleClick(object sender, EventArgs e)
		{ if (_scalingForm.Maximize) ToggleWindowState(); }
		private void Control_MouseDown(object sender, EventArgs e)
		{
			_isFormDragging = true;
			_dragCursorPoint = Cursor.Position;
			_dragFormPoint = _form.Location;
			MainPanel.BackColor = _pressedPanelColor;
		}
		private void Control_MouseUp(object sender, EventArgs e)
		{
			_isFormDragging = false;
			MainPanel.BackColor = _defaultPanelColor;
		}
		private void Control_MouseMove(object sender, EventArgs e)
		{
			if (_isFormDragging)
			{
				Point difference = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
				_form.Location = Point.Add(_dragFormPoint, new Size(difference));
			}
		}
		#endregion
	}
}