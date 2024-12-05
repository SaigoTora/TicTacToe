using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Forms;

namespace TicTacToe.Models.Utilities.FormUtilities
{
	internal class CustomTitleBar : IDisposable
	{
		private const string TAG_TO_MOVE_PARENT_CONTROL_DOWN = "needToMoveParentDown";
		private const int DEFAULT_PANEL_HEIGHT = 35;

		private static readonly Font _formNameFont = new Font("Segoe UI", 10F);
		private static readonly Color _defaultPanelColor = Color.FromArgb(31, 31, 31);
		private static readonly Color _pressedPanelColor = Color.FromArgb(35, 35, 35);
		private static readonly Color _defaultButtonColor = Color.FromArgb(200, 200, 200);
		private static readonly Color _defaultNameColor = Color.FromArgb(255, 255, 255);
		private static readonly Color _hoverButtonExitColor = Color.FromArgb(232, 17, 35);
		private readonly (bool Minimize, bool Maximize) _scalingForm;
		private readonly bool _canFormBeClosed;
		private readonly BaseForm _form;
		private IconButton _buttonClose;

		internal Panel MainPanel { get; private set; } = new Panel();

		private int _formBorderRadius;

		private readonly Label _labelCaption;
		private bool _isFormDragging;
		private Point _dragCursorPoint, _dragFormPoint;

		internal CustomTitleBar(BaseForm form, string formName, System.Drawing.Icon icon = null,
			bool minimizeBox = true, bool maximizeBox = true, bool canFormBeClosed = true)
		{
			_scalingForm.Minimize = minimizeBox;
			_scalingForm.Maximize = maximizeBox;
			_canFormBeClosed = canFormBeClosed;
			InitializeComponents();

			if (!string.IsNullOrWhiteSpace(formName))
			{
				form.Text = formName;
				_labelCaption = CreateFormCaption(formName);
				MainPanel.Controls.Add(_labelCaption);
			}
			if (icon != null)
			{
				MainPanel.Controls.Add(CreateFormIcon(icon));
				form.Icon = icon;
			}

			_form = form;
			_form.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
			_form.Load += Form_Load;
			_form.Controls.Add(MainPanel);
		}

		#region Initialization
		private void Form_Load(object sender, EventArgs e)
		{
			_formBorderRadius = _form.guna2BorderlessForm.BorderRadius;
			if (_form.WindowState == FormWindowState.Maximized)
				_form.guna2BorderlessForm.BorderRadius = 0;

			MoveFormElementsDown(_form);
			_form.Height += DEFAULT_PANEL_HEIGHT;
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

			if (_canFormBeClosed)
			{
				_buttonClose = CreateIconButton(IconChar.TimesCircle);
				_buttonClose.Click += ButtonClose_Click;
				_buttonClose.MouseEnter += ButtonClose_MouseEnter;
				_buttonClose.MouseLeave += ButtonClose_MouseLeave;
				MainPanel.Controls.Add(_buttonClose);
			}
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
		private void MoveFormElementsDown(Control control)
		{
			Point movedLocation = new Point(control.Location.X, control.Location.Y + DEFAULT_PANEL_HEIGHT);
			if (control.HasChildren && !(control is NumericUpDown))
			{
				foreach (Control item in control.Controls)
					MoveFormElementsDown(item);

				if (control.Tag != null && control.Tag.ToString().ToLower().
					Contains(TAG_TO_MOVE_PARENT_CONTROL_DOWN.ToLower()))
					control.Location = movedLocation;
			}

			else if (!control.Anchor.HasFlag(AnchorStyles.Bottom))
				control.Location = movedLocation;
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
		private Label CreateFormCaption(string name)
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
		#endregion

		internal void ChangeFormCaption(string newCaption) => _labelCaption.Text = newCaption;
		public void Dispose()
		{
			_form.Load -= Form_Load;
			ToggleEventHandlers(MainPanel, false);
			foreach (Control control in MainPanel.Controls)
			{
				if (control is IconButton iconButton)
				{
					iconButton.Click -= ButtonMinimize_Click;
					iconButton.Click -= ButtonMaximize_Click;
					iconButton.Click -= ButtonClose_Click;
				}
				else if (control is PictureBox pictureBox)
					ToggleEventHandlers(pictureBox, false);
				else if (control is Label label)
					ToggleEventHandlers(label, false);
			}
			if (_buttonClose != null)
			{
				_buttonClose.MouseEnter -= ButtonClose_MouseEnter;
				_buttonClose.MouseLeave -= ButtonClose_MouseLeave;
			}
			MainPanel.Dispose();
		}

		private void ToggleWindowState()
		{
			if (_form.WindowState == FormWindowState.Maximized)
			{
				_form.guna2BorderlessForm.BorderRadius = _formBorderRadius;
				_form.WindowState = FormWindowState.Normal;
				_form.StartPosition = FormStartPosition.CenterScreen;
			}
			else
			{
				_form.guna2BorderlessForm.BorderRadius = 0;
				_form.WindowState = FormWindowState.Maximized;
			}
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

		#region Event handlers
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

		private void ButtonClose_MouseEnter(object sender, EventArgs e)
		{
			if (sender is IconButton button)
				button.BackColor = _hoverButtonExitColor;
		}
		private void ButtonClose_MouseLeave(object sender, EventArgs e)
		{
			if (sender is IconButton button)
				button.BackColor = Color.Transparent;
		}
		private void ButtonClose_Click(object sender, EventArgs e)
			=> _form.Close();

		private void Control_DoubleClick(object sender, EventArgs e)
		{ if (_scalingForm.Maximize) ToggleWindowState(); }
		private void Control_MouseDown(object sender, MouseEventArgs e)
		{
			if (_form.WindowState == FormWindowState.Maximized)
			{
				ToggleWindowState();
				int screenWidth = Screen.PrimaryScreen.Bounds.Width;

				// Transfer the cursor coordinate from the screen range to the form range
				int offsetX = (int)(Cursor.Position.X / (double)screenWidth * _form.Width);
				_form.Location = new Point(Cursor.Position.X - offsetX, Cursor.Position.Y);
			}


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