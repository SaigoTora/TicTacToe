using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.CustomExceptions;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.Utilities;

namespace TicTacToe.Models.PlayerItemCreator
{
	internal abstract class ItemCreator<T> where T : Item
	{// Abstract creator
		private readonly Player _player;
		private readonly Panel _mainPanel;

		private readonly Font _priceFont;
		private readonly EventHandler _successBuy;
		private readonly EventHandler _selectItem;

		private readonly int _itemSize;

		private int _padding;
		private int _bottomPadding;


		/// <summary>
		/// Constructor for creating items for purchase.
		/// </summary>
		/// <param name="player">Instance of the Player class.</param>
		/// <param name="mainPanel">The panel where all created items will be stored.</param>
		/// <param name="priceFont">Font for item price.</param>
		/// <param name="successBuy">Successful purchase event handler.</param>
		/// <param name="itemSize">Size for each item.</param>
		internal ItemCreator(Player player, Panel mainPanel, Font priceFont, EventHandler successBuy, int itemSize)
		{
			_player = player;
			_mainPanel = mainPanel;
			_priceFont = priceFont;
			_successBuy = successBuy;
			_itemSize = itemSize;
		}

		/// <summary>
		/// Constructor for creating items to choose from.
		/// </summary>
		/// <param name="player">Instance of the Player class.</param>
		/// <param name="mainPanel">The panel where all created items will be stored.</param>
		/// <param name="selectItem">Item selection event handler.</param>
		/// <param name="itemSize">Size for each item.</param>
		internal ItemCreator(Player player, Panel mainPanel, EventHandler selectItem, int itemSize)
		{
			_player = player;
			_mainPanel = mainPanel;
			_selectItem = selectItem;
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

		/// <summary>
		/// The method creates an item.
		/// </summary>
		/// <param name="pictureBox">Displaying the contents of an item.</param>
		/// <param name="labelPrice">Displaying the price of an item.</param>
		/// <param name="percentPicturePadding">The padding between the image and the panel in percent.</param>
		/// <returns>Returns the created panel with information about the item.</returns>
		/// <exception cref="ArgumentNullException">If PictureBox is null, an exception will be thrown.</exception>
		protected Panel CreateItem(PictureBox pictureBox, Label labelPrice = null, int percentPicturePadding = 12)
		{
			if (pictureBox == null)
				throw new ArgumentNullException();

			_padding = percentPicturePadding * _itemSize / 100;
			_bottomPadding = 0;

			if (labelPrice == null)// Calculating the bottom padding
				_bottomPadding = _padding;
			else
				_bottomPadding = labelPrice.Font.Height + (int)(_padding * 0.25);

			pictureBox.Location = new Point(_padding, _padding);
			pictureBox.Size = new Size(_itemSize, _itemSize);
			pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

			Panel currentPanel = new Panel
			{
				Size = new Size(_itemSize + _padding + _padding,
				_itemSize + _padding + _bottomPadding)
			};

			currentPanel.Controls.Add(pictureBox);
			if (labelPrice != null)
				currentPanel.Controls.Add(labelPrice);

			_mainPanel.Controls.Add(currentPanel);
			FormEventHandlers.SubscribeToHoverPictureBoxes(pictureBox);

			return currentPanel;
		}
		protected Label CreateLabelPrice(T item, Color foreColor, ContentAlignment textAlign = ContentAlignment.MiddleCenter)
		{
			Label priceLabel = new Label
			{
				Text = item.Price.ToString(),
				Font = _priceFont,
				Dock = DockStyle.Bottom
			};
			priceLabel.Size = new Size(0, priceLabel.Font.Height);
			priceLabel.TextAlign = textAlign;
			priceLabel.ForeColor = foreColor;

			return priceLabel;
		}

		protected void SubscribeControlToBuy(Panel parentPanel, Control control, Item item)
		{
			control.Click += (s, e) =>
			{
				try
				{
					_player.BuyItem(item);
					_successBuy(control, e);
					parentPanel.Visible = false;
				}
				catch (NotEnoughCoinsToBuyException coinsException)
				{
					MessageBox.Show(coinsException.Message, "Not enough coins", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			};
		}
		protected void SubscribeToSelect(Control control, Item item)
		{
			control.Click += (s, e) =>
			{
				_player.SelectItem(item);
				_selectItem(control, e);
			};
		}
	}
}