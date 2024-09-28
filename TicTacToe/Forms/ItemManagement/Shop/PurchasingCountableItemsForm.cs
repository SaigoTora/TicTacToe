using System;
using System.Windows.Forms;

using TicTacToe.Models.CustomExceptions;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.Utilities.FormUtilities;

namespace TicTacToe.Forms.ItemManagement.Shop
{
	internal partial class PurchasingCountableItemsForm : BaseForm
	{
		private readonly Player _player;
		private readonly CountableItem _item;
		private readonly Action _successPurchase;

		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();

		internal PurchasingCountableItemsForm(CountableItem item, Player player, Action successPurchase)
		{
			InitializeComponent();
			customTitleBar = new CustomTitleBar(this, "Selecting the number of items", minimizeBox: false, maximizeBox: false);
			base.guna2BorderlessForm.SetDrag(new Control[] { this, pictureBoxItem, labelName,
				pictureBoxCoin, labelPrice, labelNumberOfItems, labelDescription });
			base.guna2BorderlessForm.TransparentWhileDrag = false;

			SetItemValues(item);

			_player = player;
			_item = item;
			_successPurchase = successPurchase;
			numericUpDownNumberOfItems.BackColor = BackColor;
			numericUpDownNumberOfItems.Maximum = Math.Min(numericUpDownNumberOfItems.Maximum, _player.Coins / _item.Price);
			ActiveControl = buttonBack;
			_buttonEventHandlers.SubscribeToHover(buttonBuy, buttonBack);
		}
		private void SetItemValues(CountableItem item)
		{
			pictureBoxItem.Image = item.Image;
			labelName.Text = item.Name;
			labelPrice.Text = $"{item.Price:N0}".Replace(',', ' ');
			labelDescription.Text = item.Description;
		}

		private void ButtonExit_Click(object sender, EventArgs e)
			=> Close();
		private void ButtonBuy_Click(object sender, EventArgs e)
		{
			try
			{
				int itemCount = (int)numericUpDownNumberOfItems.Value;
				Item newItem = new CountableItem(_item.Name, _item.Price * itemCount, _item.Description, _item.Image, _item.Type, itemCount);
				_player.BuyItem(newItem);

				_successPurchase();
				string itemText = itemCount == 1 ? "item" : "items";
				CustomMessageBox.Show($"You have successfully purchased {itemCount} {itemText}: \"{_item.Name}\"!",
					"Item successfully purchased", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.OK);
				Close();
			}
			catch (NotEnoughCoinsToBuyException)
			{
				CustomMessageBox.Show($"You don't have enough coins to buy this item!\nThis item costs {_item.Price} coins.",
					"Not enough coins", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
			}
		}
		private void NumericUpDownNumberOfItems_ValueChanged(object sender, EventArgs e)
			=> labelPrice.Text = (_item.Price * numericUpDownNumberOfItems.Value).ToString();

		private void PurchaseResultForm_FormClosed(object sender, FormClosedEventArgs e)
			=> _buttonEventHandlers.UnsubscribeAll();
	}
}