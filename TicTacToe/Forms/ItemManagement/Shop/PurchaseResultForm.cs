using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.Utilities.FormUtilities;

namespace TicTacToe.Forms.ItemManagement.Shop
{
	internal partial class PurchaseResultForm : BaseForm
	{
		private readonly Player _player;
		private readonly Item _item;

		private readonly CustomTitleBar _customTitleBar;
		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();

		internal PurchaseResultForm(Item item, Player player)
		{
			InitializeComponent();
			_customTitleBar = new CustomTitleBar(this, "Item successfully purchased", minimizeBox: false, maximizeBox: false);
			base.guna2BorderlessForm.SetDrag(new Control[] { this, pictureBoxItem, labelName,
			pictureBoxCoin, labelPrice, labelDescription });
			base.guna2BorderlessForm.TransparentWhileDrag = false;

			SetItemValues(item);
			InitializeFromItem(item);

			_player = player;
			_item = item;
			ActiveControl = buttonOK;
			_buttonEventHandlers.SubscribeToHover(buttonOK, buttonSelect);
		}
		private void SetItemValues(Item item)
		{
			labelName.Text = item.Name;
			labelPrice.Text = $"{item.Price:N0}".Replace(',', ' ');
			labelDescription.Text = item.Description;
		}
		private void InitializeFromItem(Item item)
		{
			switch (item)
			{
				case Avatar avatar:
					pictureBoxItem.Image = avatar.Image;
					SetBackgroundColor(avatar);
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
		private void SetBackgroundColor(Avatar avatar)
		{
			(Color Common, Color Rare, Color Legendary) backColor =
				(Color.FromArgb(30, 35, 30), Color.FromArgb(30, 30, 40), Color.FromArgb(25, 20, 35));

			switch (avatar.Rarity)
			{
				case AvatarRarity.Common:
					BackColor = backColor.Common;
					break;
				case AvatarRarity.Rare:
					BackColor = backColor.Rare;
					break;
				case AvatarRarity.Legendary:
					BackColor = backColor.Legendary;
					break;
				default:
					break;
			}
		}

		private void ButtonSelect_Click(object sender, EventArgs e)
		{
			_player.SelectItem(_item);
			Close();
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