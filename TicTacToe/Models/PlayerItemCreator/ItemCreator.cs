using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using TicTacToe.Models.CustomExceptions;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.Utilities;

namespace TicTacToe.Models.PlayerItemCreator
{
	internal abstract class ItemCreator<T> : IDisposable where T : Item
	{// Abstract creator
		internal Func<Item, bool> ConfirmPurchase;
		internal event EventHandler<ItemEventArgs> Select;
		internal event EventHandler<ItemBuyEventArgs> Buy;

		private readonly (Color Default, Color NotEnoughCoins) priceForeColor = (Color.Khaki, Color.FromArgb(191, 34, 51));
		private readonly Player _player;
		private readonly Panel _mainPanel;
		private readonly Font _priceFont;
		private readonly Dictionary<Control, Item> _controlItemMap = new Dictionary<Control, Item>();
		private readonly List<(Item, PictureBox, Label)> _createdItems = new List<(Item, PictureBox, Label)>();
		private readonly int _itemSize;


		/// <summary>
		/// Constructor for creating items for purchase.
		/// </summary>
		/// <param name="player">Instance of the Player class.</param>
		/// <param name="mainPanel">The panel where all created items will be stored.</param>
		/// <param name="priceFont">Font for item price.</param>
		/// <param name="successBuy">Successful purchase event handler.</param>
		/// <param name="itemSize">Size for each item.</param>
		internal ItemCreator(Player player, Panel mainPanel, Font priceFont, int itemSize)
		{
			_player = player;
			_mainPanel = mainPanel;
			_priceFont = priceFont;
			_itemSize = itemSize;
		}

		/// <summary>
		/// Constructor for creating items to choose from.
		/// </summary>
		/// <param name="player">Instance of the Player class.</param>
		/// <param name="mainPanel">The panel where all created items will be stored.</param>
		/// <param name="selectItem">Item selection event handler.</param>
		/// <param name="itemSize">Size for each item.</param>
		internal ItemCreator(Player player, Panel mainPanel, int itemSize)
		{
			_player = player;
			_mainPanel = mainPanel;
			_itemSize = itemSize;
		}

		#region AbstractMethods
		/// <summary>
		/// The method creates an item that the player can purchase.
		/// </summary>
		/// <param name="item">The item to be created with type T. Where T : Item.</param>
		internal abstract void CreateItemToBuy(T item);

		/// <summary>
		/// The method creates an item that the player can select.
		/// </summary>
		/// <param name="item">The item to be created with type T. Where T : Item.</param>
		/// <returns>Returns a PictureBox object that represents the item.</returns>
		internal abstract PictureBox CreateItemToSelect(T item);
		#endregion

		private Panel CreateItem(PictureBox pictureBox, int padding, int bottomPadding)
		{
			if (pictureBox == null)
				throw new ArgumentNullException();

			const int BOTTOM_MARGIN = 10;
			CreatePicture(pictureBox, padding);
			Panel currentPanel = new Panel
			{
				Size = new Size(_itemSize + padding + padding,
				_itemSize + padding + bottomPadding),
				Margin = new Padding(0, 0, 0, BOTTOM_MARGIN)
			};

			currentPanel.Controls.Add(pictureBox);

			_mainPanel.Controls.Add(currentPanel);
			FormEventHandlers.SubscribeToHoverPictureBoxes(pictureBox);

			return currentPanel;
		}

		/// <summary>
		/// The method creates an item for purchase.
		/// </summary>
		/// <param name="item">The item being purchased.</param>
		/// <param name="pictureBox">Displaying the contents of an item.</param>
		/// <param name="labelPrice">Displaying the price of an item.</param>
		/// <param name="percentPicturePadding">The padding between the image and the panel in percent.</param>
		/// <exception cref="ArgumentOutOfRangeException">If percentPicturePadding is less than 0 or greater than 100, an exception will be thrown.</exception>
		/// <exception cref="ArgumentNullException">If labelPrice is null, an exception will be thrown.</exception>
		protected void CreateItemToBuy(Item item, PictureBox pictureBox, Label labelPrice, int percentPicturePadding = 12)
		{
			if (percentPicturePadding < 0 || percentPicturePadding > 100)
				throw new ArgumentOutOfRangeException();

			if (labelPrice == null)
				throw new ArgumentNullException();

			const double PADDING_SCALER = 0.5;
			int padding = percentPicturePadding * _itemSize / 100;
			int bottomPadding = labelPrice.Font.Height + (int)(padding * PADDING_SCALER);

			Panel currentPanel = CreateItem(pictureBox, padding, bottomPadding);

			UpdatePurchaseIndicators(item, pictureBox, labelPrice);
			_createdItems.Add((item, pictureBox, labelPrice));
			currentPanel.Controls.Add(labelPrice);
		}
		/// <summary>
		/// The method creates a selectable item.
		/// </summary>
		/// <param name="pictureBox">Displaying the contents of an item.</param>
		/// <param name="percentPicturePadding">The padding between the image and the panel in percent.</param>
		/// <exception cref="ArgumentOutOfRangeException">If percentPicturePadding is less than 0 or greater than 100, an exception will be thrown.</exception>
		protected void CreateItemToSelect(PictureBox pictureBox, int percentPicturePadding = 12)
		{
			if (percentPicturePadding < 0 || percentPicturePadding > 100)
				throw new ArgumentOutOfRangeException();

			int padding = percentPicturePadding * _itemSize / 100;

			CreateItem(pictureBox, padding, padding);
			_createdItems.Add((null, pictureBox, null));
		}
		protected Label CreateLabelPrice(T item, ContentAlignment textAlign = ContentAlignment.MiddleCenter)
		{
			Label priceLabel = new Label
			{
				Text = item.Price.ToString(),
				Font = _priceFont,
				Dock = DockStyle.Bottom,
				TextAlign = textAlign,
				ForeColor = priceForeColor.Default
			};
			priceLabel.Size = new Size(0, priceLabel.Font.Height);

			return priceLabel;
		}

		private void CreatePicture(PictureBox pictureBox, int padding)
		{
			pictureBox.Location = new Point(padding, padding);
			pictureBox.Size = new Size(_itemSize, _itemSize);
			pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox.Cursor = Cursors.Hand;
		}
		internal void UpdatePurchaseIndicatorsForAllItems()
		{
			foreach (var item in _createdItems)
				UpdatePurchaseIndicators(item.Item1, item.Item2, item.Item3);
		}
		private void UpdatePurchaseIndicators(Item item, PictureBox pictureBox, Label labelPrice)
		{
			if (_player.HaveEnoughCoins(item.Price))
			{
				pictureBox.Cursor = Cursors.Hand;
				labelPrice.ForeColor = priceForeColor.Default;
			}
			else
			{
				pictureBox.Cursor = Cursors.No;
				labelPrice.ForeColor = priceForeColor.NotEnoughCoins;
			}
		}

		#region ClickEventHandlers
		protected void SubscribeControlToBuy(Control control, Item item)
		{
			_controlItemMap[control] = item;
			control.Click += ControlBuy_Click;
		}
		private void ControlBuy_Click(object sender, EventArgs e)
		{
			if (!(sender is Control control))
				return;

			Item item = _controlItemMap[control];
			if (_player.HaveEnoughCoins(item.Price) && ConfirmPurchase != null && !ConfirmPurchase(item))
				return;

			bool success = true;
			try
			{
				_player.BuyItem(item);
				if (control is PictureBox pictureBox)
					FormEventHandlers.UnsubscribeFromHoverPictureBoxes(pictureBox);
				control.Click -= ControlBuy_Click;
				control.Parent.Dispose();
				UpdatePurchaseIndicatorsForAllItems();
			}
			catch (NotEnoughCoinsToBuyException)
			{ success = false; }
			finally
			{ OnBuy(new ItemBuyEventArgs(item, control, success)); }
		}
		protected void OnBuy(ItemBuyEventArgs e)
		{
			var temp = System.Threading.Volatile.Read(ref Buy);
			temp?.Invoke(this, e);
		}

		protected void SubscribeToSelect(Control control, Item item)
		{
			_controlItemMap[control] = item;
			control.Click += ControlSelect_Click;
		}
		private void ControlSelect_Click(object sender, EventArgs e)
		{
			if (!(sender is Control control))
				return;

			Item item = _controlItemMap[control];

			_player.SelectItem(item);
			OnSelect(new ItemEventArgs(item, control));
		}
		protected void OnSelect(ItemEventArgs e)
		{
			var temp = System.Threading.Volatile.Read(ref Select);
			temp?.Invoke(this, e);
		}
		#endregion

		public void Dispose()
		{
			IEnumerable<PictureBox> pictureBoxes = _createdItems.Select(item => item.Item2);
			FormEventHandlers.UnsubscribeFromHoverPictureBoxes(pictureBoxes);

			foreach (var item in _controlItemMap)
				if (item.Key != null)
				{
					item.Key.Click -= ControlBuy_Click;
					item.Key.Click -= ControlSelect_Click;
					item.Key.Parent?.Dispose();
				}

			_controlItemMap?.Clear();
		}
	}
}