﻿using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToe.Properties;

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
		Information,
		OK,
		Question
	}

	internal partial class CustomMessageBox : BaseForm
	{
		private DialogResult _dialogResult = DialogResult.None;

		private CustomMessageBox(string text, string caption, CustomMessageBoxButtons buttons,
			CustomMessageBoxIcon icon, int width)
		{
			InitializeComponent();
			customTitleBar = new CustomTitleBar(this, caption, minimizeBox: false, maximizeBox: false);
			base.guna2BorderlessForm.SetDrag(new Control[] { this, iconPicture, labelText, flpButtons });
			base.guna2BorderlessForm.TransparentWhileDrag = false;

			labelText.Text = text;
			button1.Visible = true;
			button2.Visible = true;
			SetButtons(buttons);
			SetIcon(icon);
			AdjustFormSize(width);
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
		private void SetupButton(Guna2GradientButton iconButton, string text,
			DialogResult dialogResult, Color FillColor, Color FillColor2)
		{
			iconButton.Text = text;
			iconButton.FillColor = FillColor;
			iconButton.FillColor2 = FillColor2;
			iconButton.DialogResult = dialogResult;
		}
		private void SetIcon(CustomMessageBoxIcon icon)
		{
			(IconChar Error, IconChar Warning, IconChar Information, IconChar OK, IconChar Question) iconChar =
				(IconChar.XmarkCircle, IconChar.Warning, IconChar.InfoCircle, IconChar.CheckCircle, IconChar.QuestionCircle);
			(Color Error, Color Warning, Color Information, Color OK, Color Question) iconColor =
				(Color.Red, Color.Yellow, Color.FromArgb(0, 149, 182), Color.Green, Color.SteelBlue);

			switch (icon)
			{
				case CustomMessageBoxIcon.None:
					{
						iconPicture.Visible = false;
						ShowIcon = false;
					}
					break;
				case CustomMessageBoxIcon.Error:
					SetupIcon(iconChar.Error, iconColor.Error, Resources.error);
					break;
				case CustomMessageBoxIcon.Warning:
					SetupIcon(iconChar.Warning, iconColor.Warning, Resources.warning);
					break;
				case CustomMessageBoxIcon.Information:
					SetupIcon(iconChar.Information, iconColor.Information, Resources.information);
					break;
				case CustomMessageBoxIcon.OK:
					SetupIcon(iconChar.OK, iconColor.OK, Resources.success);
					break;
				case CustomMessageBoxIcon.Question:
					SetupIcon(iconChar.Question, iconColor.Question, Resources.question);
					break;
				default:
					throw new ArgumentException($"Unknown icon: {icon}", nameof(icon));
			}
		}
		private void SetupIcon(IconChar iconChar, Color iconColor, System.Drawing.Icon formIcon)
		{
			iconPicture.IconChar = iconChar;
			iconPicture.IconColor = iconColor;
			Icon = formIcon;
		}
		private void AdjustFormSize(int width)
		{
			const int PADDING_HEIGHT = 100;

			Size textSize = TextRenderer.MeasureText(labelText.Text, labelText.Font,
				new Size(width, 0), TextFormatFlags.WordBreak);

			int requiredHeight = textSize.Height + PADDING_HEIGHT;
			requiredHeight = Math.Max(requiredHeight, MinimumSize.Height);

			ClientSize = new Size(Math.Max(width, this.Width), requiredHeight);
		}

		internal static DialogResult Show(string text, string caption = "",
			CustomMessageBoxButtons buttons = CustomMessageBoxButtons.OK,
			CustomMessageBoxIcon icon = CustomMessageBoxIcon.None, int width = 400)
		{
			CustomMessageBox messageBox = new CustomMessageBox(text, caption, buttons, icon, width);
			messageBox.ShowDialog();

			return messageBox._dialogResult;
		}

		private void Button_Click(object sender, EventArgs e)
		{
			if (sender is Guna2GradientButton button)
				_dialogResult = button.DialogResult;

			Close();
		}
	}
}