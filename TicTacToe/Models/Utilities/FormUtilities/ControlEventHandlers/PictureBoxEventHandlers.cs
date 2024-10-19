using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe.Models.Utilities.FormUtilities.ControlEventHandlers
{
	internal class PictureBoxEventHandlers : ControlEventHandlers<PictureBox>
	{
		private const byte PICTURE_SIZE_PERCENT_SCALER = 10;

		private readonly Dictionary<PictureBox, (Color defaultColor, Color hoverColor)> _colorPictures
			= new Dictionary<PictureBox, (Color, Color)>();

		#region PictureBox hover
		internal void SubscribeToHover(params PictureBox[] pictureBoxes)
		{
			foreach (PictureBox pictureBox in pictureBoxes)
			{
				if (controls.Contains(pictureBox))
					throw new ArgumentException($"The PictureBox '{pictureBox.Name}' is already subscribed.");

				pictureBox.MouseEnter += PictureBox_MouseEnter;
				pictureBox.MouseLeave += PictureBox_MouseLeave;
				controls.Add(pictureBox);
			}
		}
		internal void SubscribeToHover(Color hoverColor, params PictureBox[] pictureBoxes)
		{
			foreach (PictureBox pictureBox in pictureBoxes)
			{
				if (controls.Contains(pictureBox))
					throw new ArgumentException($"The PictureBox '{pictureBox.Name}' is already subscribed.");

				pictureBox.MouseEnter += PictureBoxColor_MouseEnter;
				pictureBox.MouseLeave += PictureBoxColor_MouseLeave;
				_colorPictures.Add(pictureBox, (pictureBox.BackColor, hoverColor));
			}
		}

		private void PictureBox_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is PictureBox picture) || isControlIncreased)
				return;

			ResizeControl(picture, PICTURE_SIZE_PERCENT_SCALER, true);
			isControlIncreased = true;
		}
		private void PictureBox_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is PictureBox picture) || !isControlIncreased)
				return;

			ResizeControl(picture, PICTURE_SIZE_PERCENT_SCALER, false);
			isControlIncreased = false;
		}

		private void PictureBoxColor_MouseEnter(object sender, EventArgs e)
		{
			if (sender is PictureBox picture)
				picture.BackColor = _colorPictures[picture].hoverColor;
		}
		private void PictureBoxColor_MouseLeave(object sender, EventArgs e)
		{
			if (sender is PictureBox picture)
				picture.BackColor = _colorPictures[picture].defaultColor;
		}
		#endregion

		protected override void DefaultUnsubscribe(PictureBox pictureBox)
		{
			pictureBox.MouseEnter -= PictureBox_MouseEnter;
			pictureBox.MouseLeave -= PictureBox_MouseLeave;
		}
		internal override void Unsubscribe(PictureBox pictureBox)
		{
			DefaultUnsubscribe(pictureBox);
			controls.Remove(pictureBox);
		}

		private void DefaultUnsubscribeHoverColor(PictureBox pictureBox)
		{
			pictureBox.MouseEnter -= PictureBoxColor_MouseEnter;
			pictureBox.MouseLeave -= PictureBoxColor_MouseLeave;
		}

		internal override void UnsubscribeAll()
		{
			foreach (PictureBox pictureBox in controls)
				DefaultUnsubscribe(pictureBox);

			foreach (PictureBox pictureBox in _colorPictures.Keys)
				DefaultUnsubscribeHoverColor(pictureBox);

			controls.Clear();
		}
	}
}