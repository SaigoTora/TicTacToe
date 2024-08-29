using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.Utilities;

namespace TicTacToe.Forms
{
	enum CustomMessageBoxButtons : byte
	{
		OK,
		YesNo
	}

	enum CustomMessageBoxIcon : byte
	{
		None,
		Error,
		Warning,
		OK,
		Question
	}

	internal partial class CustomMessageBox : BaseForm
	{
		private readonly CustomTitleBar _customTitleBar;
		private DialogResult _dialogResult = DialogResult.None;

		private CustomMessageBox(string text, string caption, CustomMessageBoxButtons buttons, CustomMessageBoxIcon icon, int MaxWidth)
		{
			InitializeComponent();
			_customTitleBar = new CustomTitleBar(this, caption, minimizeBox: false, maximizeBox: false);
			base.guna2BorderlessForm.SetDrag(iconPicture);
			base.guna2BorderlessForm.SetDrag(labelText);
			base.guna2BorderlessForm.SetDrag(flpButtons);
			base.guna2BorderlessForm.TransparentWhileDrag = false;

			labelText.Text = text;
			button1.Visible = true;
			button2.Visible = true;
			AdjustFormSize(MaxWidth);
			SetButtons(buttons);
			SetIcon(icon);

			FormEventHandlers.SubscribeToHoverButtons(button1, button2);
		}
		private void SetButtons(CustomMessageBoxButtons buttons)
		{
			(Color OK, Color Yes, Color No) buttonFillColor =
				(Color.SeaGreen, Color.FromArgb(71, 167, 106), Color.FromArgb(107, 24, 13));
			(Color OK, Color Yes, Color No) buttonFillColor2 =
				(Color.FromArgb(0, 107, 60), Color.FromArgb(0, 107, 60), Color.Maroon);

			switch (buttons)
			{
				case CustomMessageBoxButtons.OK:
					ActiveControl = button1;
					button2.Visible = false;
					SetupButton(button1, "OK", DialogResult.OK, buttonFillColor.OK, buttonFillColor2.OK);
					break;
				case CustomMessageBoxButtons.YesNo:
					ActiveControl = button2;
					SetupButton(button1, "Yes", DialogResult.Yes, buttonFillColor.Yes, buttonFillColor2.Yes);
					SetupButton(button2, "No", DialogResult.No, buttonFillColor.No, buttonFillColor2.No);
					break;
				default:
					throw new ArgumentException($"Unknown buttons: {buttons}", nameof(buttons));
			}
		}
		private void SetupButton(Guna2GradientButton iconButton, string text, DialogResult dialogResult, Color FillColor, Color FillColor2)
		{
			iconButton.Text = text;
			iconButton.FillColor = FillColor;
			iconButton.FillColor2 = FillColor2;
			iconButton.DialogResult = dialogResult;
		}
		private void SetIcon(CustomMessageBoxIcon icon)
		{
			(IconChar Error, IconChar Warning, IconChar OK, IconChar Question) iconChar =
				(IconChar.XmarkCircle, IconChar.Warning, IconChar.CheckCircle, IconChar.QuestionCircle);
			(Color Error, Color Warning, Color OK, Color Question) iconColor =
				(Color.Red, Color.Yellow, Color.Green, Color.SteelBlue);

			switch (icon)
			{
				case CustomMessageBoxIcon.None:
					iconPicture.Visible = false;
					break;
				case CustomMessageBoxIcon.Error:
					SetupIcon(iconChar.Error, iconColor.Error);
					break;
				case CustomMessageBoxIcon.Warning:
					SetupIcon(iconChar.Warning, iconColor.Warning);
					break;
				case CustomMessageBoxIcon.OK:
					SetupIcon(iconChar.OK, iconColor.OK);
					break;
				case CustomMessageBoxIcon.Question:
					SetupIcon(iconChar.Question, iconColor.Question);
					break;
				default:
					throw new ArgumentException($"Unknown icon: {icon}", nameof(icon));
			}
		}
		private void SetupIcon(IconChar iconChar, Color iconColor)
		{
			iconPicture.IconChar = iconChar;
			iconPicture.IconColor = iconColor;
		}
		private void AdjustFormSize(int maxWidth)
		{
			const int PaddingHeight = 100;
			const int PaddingWidth = 40;

			Size textSize = TextRenderer.MeasureText(labelText.Text, labelText.Font, new Size(maxWidth, 0), TextFormatFlags.WordBreak);

			int lines = (int)Math.Ceiling((double)textSize.Width / maxWidth);
			int additionalHeight = lines * textSize.Height;

			int newWidth = Math.Min(textSize.Width + PaddingWidth, maxWidth);
			int newHeight = textSize.Height + PaddingHeight + additionalHeight;
			newHeight = Math.Max(newHeight, MinimumSize.Height);

			newWidth = newWidth < Width ? Width : newWidth;
			Size = new Size(newWidth, newHeight);
		}

		internal static DialogResult Show(string text, string caption = "",
			CustomMessageBoxButtons buttons = CustomMessageBoxButtons.OK,
			CustomMessageBoxIcon icon = CustomMessageBoxIcon.None, int maxWidth = 400)
		{
			CustomMessageBox messageBox = new CustomMessageBox(text, caption, buttons, icon, maxWidth);
			messageBox.ShowDialog();

			return messageBox._dialogResult;
		}

		private void Button_Click(object sender, EventArgs e)
		{
			if (sender is Guna2GradientButton button)
				_dialogResult = button.DialogResult;

			Close();
		}

		private void CustomMessageBox_FormClosed(object sender, FormClosedEventArgs e)
		{
			FormEventHandlers.UnsubscribeFromHoverButtons(button1, button2);
			_customTitleBar.Dispose();
		}
	}
}