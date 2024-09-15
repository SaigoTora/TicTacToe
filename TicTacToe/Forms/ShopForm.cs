using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.CustomExceptions;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.PlayerItemCreator;
using TicTacToe.Models.Utilities;
using TicTacToe.Models.Utilities.FormUtilities;

namespace TicTacToe.Forms
{
	internal partial class ShopForm : ItemManagementForm
	{
		private readonly CustomTitleBar _customTitleBar;

		private readonly List<ImageItem> _imageItems = new List<ImageItem>();
		private readonly List<Avatar> _avatarItems = new List<Avatar>();
		private readonly List<ColorItem> _colorItems = new List<ColorItem>();

		internal ShopForm(Player player) : base(player)
		{
			IsResizable = true;
			_customTitleBar = new CustomTitleBar(this, "Tic Tac Toe", Properties.Resources.shop);
			InitializeComponent();

			InitializeCreators();
			preferences = new List<(Label, FlowLayoutPanel)>
			{
				(labelBackgroundMenu, flpBackgroundMenu),
				(labelAvatar, flpAvatar),
				(labelBackgroundGame, flpBackgroundGame)
			};
		}

		private void ShopForm_Load(object sender, EventArgs e)
		{
			tabControl.TabButtonSelectedState.FillColor = BackColor;
			tabControl.TabMenuBackColor = BackColor;
			tabPagePreferences.BackColor = BackColor;
			labelCoins.Text = $"{player.Coins:N0}".Replace(',', ' ');
			FillListsOfItems();

			CreateNotBoughtItems(_imageItems, menuBackCreator);
			CreateNotBoughtItems(_avatarItems, avatarCreator);
			CreateNotBoughtItems(_colorItems, gameBackCreator);

			SubscribeToNavigationButtonEvents(buttonPreferencesLeft,
				buttonPreferencesRight);
			TryToCreateEmptyLabels();
		}

		private void InitializeCreators()
		{
			const int ITEM_SIZE = 100;
			Font fontPrice = new Font("Courier New", 16F, FontStyle.Bold);

			menuBackCreator = new ImageCreator(player, flpBackgroundMenu, fontPrice, ITEM_SIZE);
			avatarCreator = new AvatarCreator(player, flpAvatar, fontPrice, ITEM_SIZE);
			gameBackCreator = new ColorCreator(player, flpBackgroundGame, fontPrice, ITEM_SIZE);

			ManageItemCreatorEvents(true);
		}
		private void ManageItemCreatorEvents(bool subscribe)
		{
			if (subscribe)
			{
				menuBackCreator.Click += MenuBack_Click;
				avatarCreator.Click += Avatar_Click;
				gameBackCreator.Click += GameBack_Click;
			}
			else
			{
				menuBackCreator.Click -= MenuBack_Click;
				avatarCreator.Click -= Avatar_Click;
				gameBackCreator.Click -= GameBack_Click;
			}
		}

		private void FillListsOfItems()
		{
			Item[] allItems = ItemManager.GetAllItems();
			for (int i = 0; i < allItems.Length; i++)
				switch (allItems[i])
				{
					case Avatar avatar:
						{
							_avatarItems.Add(avatar);
							break;
						}
					case ImageItem imageItem:
						{
							_imageItems.Add(imageItem);
							break;
						}
					case ColorItem colorItem:
						{
							_colorItems.Add(colorItem);
							break;
						}
					default:
						{
							throw new InvalidOperationException
								($"Unknown item type: {allItems[i].GetType().Name}");
						}
				}
		}
		private void CreateNotBoughtItems<T>(List<T> shopItems, ItemCreator<T> creator) where T : Item
		{
			List<Item> playerItems = player.GetPlayerItems();

			foreach (T shopItem in shopItems)
				for (int i = 0; i < playerItems.Count; i++)
				{
					if (shopItem.Equals(playerItems[i]))
					{// If the user already has the store item
						playerItems.RemoveAt(i);
						break;
					}
					if (i == playerItems.Count - 1)// If no matches were found,
						creator.CreateItemToBuy(shopItem);// then the item should be created
				}
		}

		private void Avatar_Click(object sender, ItemEventArgs e)
			=> DefaultBuy(avatarCreator, true, e);
		private void MenuBack_Click(object sender, ItemEventArgs e)
			=> DefaultBuy(menuBackCreator, true, e);
		private void GameBack_Click(object sender, ItemEventArgs e)
			=> DefaultBuy(gameBackCreator, true, e);

		private bool ConfirmPurchase(Item item)
		{
			DialogResult result = CustomMessageBox.Show($"Are you sure you want to buy this item for {item.Price} coins?", "Confirmation", CustomMessageBoxButtons.YesNo, CustomMessageBoxIcon.Question);

			if (result == DialogResult.Yes)
				return true;
			return false;
		}
		private void DefaultBuy<T>(ItemCreator<T> itemCreator, bool needToDisposeParent, ItemEventArgs e) where T : Item
		{
			if (player.HaveEnoughCoins(e.Item.Price) && !ConfirmPurchase(e.Item))
				return;

			try
			{
				player.BuyItem(e.Item);

				if (e.ClickableControl is PictureBox pictureBox)
					itemCreator.PictureBoxEventHandlers.Unsubscribe(pictureBox);
				itemCreator.UnSubscribeFromClick(e.ClickableControl);
				if (needToDisposeParent)
					e.ClickableControl.Parent.Dispose();
				UpdateAllCreators();

				labelCoins.Text = $"{player.Coins:N0}".Replace(',', ' ');
				TryToCreateEmptyLabels();

				PurchaseResultForm resultForm = new PurchaseResultForm(e.Item, player);
				resultForm.ShowDialog();
			}
			catch (NotEnoughCoinsToBuyException)
			{
				CustomMessageBox.Show($"You don't have enough coins to buy this item!\nThis item costs {e.Item.Price} coins.",
					"Not enough coins", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
			}
		}
		private void UpdateAllCreators()
		{
			menuBackCreator.UpdatePurchaseIndicatorsForAllItems();
			avatarCreator.UpdatePurchaseIndicatorsForAllItems();
			gameBackCreator.UpdatePurchaseIndicatorsForAllItems();
		}

		private Label InitializeLabelEmpty(string text)
		{
			const int TOP_MARGIN = 30;

			Label labelEmpty = new Label()
			{
				Text = text,
				AutoSize = true,
				Margin = new Padding(0, TOP_MARGIN, 0, 0),
				TextAlign = ContentAlignment.MiddleCenter,
				Font = new Font("Trebuchet MS", 16F),
				BackColor = Color.Transparent,
				ForeColor = Color.White,
			};

			return labelEmpty;
		}
		private void TryToCreateEmptyLabels()
		{
			const string EMPTY_TEXT_BACK_MENU = "Unbelievable! All the menu backgrounds have been bought.";
			const string EMPTY_TEXT_AVATAR = "No way! There are no more avatars in the store.";
			const string EMPTY_TEXT_BACK_GAME = "Wow, looks like you bought all the backgrounds for the game.";

			if (!flpBackgroundMenu.HasChildren)
				flpBackgroundMenu.Controls.Add(InitializeLabelEmpty(EMPTY_TEXT_BACK_MENU));
			if (!flpAvatar.HasChildren)
				flpAvatar.Controls.Add(InitializeLabelEmpty(EMPTY_TEXT_AVATAR));
			if (!flpBackgroundGame.HasChildren)
				flpBackgroundGame.Controls.Add(InitializeLabelEmpty(EMPTY_TEXT_BACK_GAME));
		}

		private void Shop_FormClosed(object sender, FormClosedEventArgs e)
		{
			ManageItemCreatorEvents(false);
			UnsubscribeFromNavigationButtonEvents(buttonPreferencesLeft,
				buttonPreferencesRight);
			_customTitleBar.Dispose();

			Serializator.Serialize(player, Program.SerializePath, Program.EncryptKey);
		}
	}
}