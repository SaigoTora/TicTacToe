using System;
using System.Windows.Forms;

using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.Utilities.FormUtilities;

namespace TicTacToe.Forms
{
	internal partial class PurchaseResultForm : BaseForm
	{
		private readonly CustomTitleBar _customTitleBar;
		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();

		internal PurchaseResultForm(Item item)
		{
			InitializeComponent();
			_customTitleBar = new CustomTitleBar(this, "Item successfully purchased", minimizeBox: false, maximizeBox: false);
			base.guna2BorderlessForm.SetDrag(this);
			base.guna2BorderlessForm.SetDrag(pictureBoxItem);
			base.guna2BorderlessForm.SetDrag(labelName);
			base.guna2BorderlessForm.SetDrag(pictureBoxCoin);
			base.guna2BorderlessForm.SetDrag(labelPrice);
			base.guna2BorderlessForm.SetDrag(labelDescription);
			base.guna2BorderlessForm.TransparentWhileDrag = false;

			SetItemValues(item);
			SetPicture(item);

			_buttonEventHandlers.SubscribeToHoverButtons(buttonOK);
		}
		private void SetItemValues(Item item)
		{
			labelName.Text = item.Name;
			labelPrice.Text = $"{item.Price:N0}".Replace(',', ' ');
			labelDescription.Text = item.Description;
		}
		private void SetPicture(Item item)
		{
			switch (item)
			{
				case Avatar avatar:
					pictureBoxItem.Image = avatar.Image;
					break;
				case ImageItem imageItem:
					pictureBoxItem.Image = imageItem.Image;
					break;
				case ColorItem colorItem:
					pictureBoxItem.BackColor = colorItem.Color;
					break;
				default:
					{
						throw new InvalidOperationException
							($"Unknown item type: {item.GetType().Name}");
					}
			}
		}

		private void ButtonOK_Click(object sender, EventArgs e)
			=> Close();
		private void PurchaseResultForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_buttonEventHandlers.UnsubscribeAll();
			_customTitleBar.Dispose();
		}
	}
}