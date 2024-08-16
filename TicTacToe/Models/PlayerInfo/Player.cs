using System;
using System.Collections.Generic;
using System.Drawing;

using TicTacToe.Models.CustomExceptions;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToeLibrary;

namespace TicTacToe.Models.PlayerInfo
{
	[Serializable]
	internal class Player
	{
		internal string Name { get; private set; }
		internal int Coins { get; private set; }
		internal PlayerVisualPreferences Preferences { get; private set; }

		private List<Item> _inventory = new List<Item>();

		internal Player(string name, int coins, PlayerVisualPreferences preferences)
		{
			Name = name;
			Coins = coins;
			Preferences = preferences;
			SetDefaultInventory();
		}
		internal Player()
		{
			Preferences = new PlayerVisualPreferences();
			SetDefaultInventory();
		}

		internal List<Item> GetPlayerItems()
		{
			List<Item> resultList = new List<Item>();

			foreach (Item item in _inventory)
				resultList.Add(item);

			return resultList;
		}

		/// <summary>
		/// The method takes away coins from the user and adds the item to the inventory.
		/// </summary>
		/// <param name="item">Item being purchased.</param>
		/// <exception cref="NotEnoughCoinsToBuyException">If the user doesn't have enough coins to make a purchase, 
		/// an exception will be thrown.</exception>
		internal void BuyItem(Item item)
		{
			if (item.Price > Coins)
				throw new NotEnoughCoinsToBuyException(item);

			Coins -= item.Price;
			AddItemToInventory(item);
		}
		internal void SelectItem(Item item)
		{
			switch (item)
			{
				case Avatar avatar:
					{
						Preferences.Avatar = avatar.Image;
						break;
					}
				case ImageItem imageItem:
					{
						Preferences.BackgroundMenu = imageItem.Image;
						break;
					}
				case ColorItem colorItem:
					{
						Preferences.BackgroundGame = colorItem.Color;
						break;
					}
				default:
					{
						throw new InvalidOperationException
							($"Unknown item type: {item.GetType().Name}");
					}
			}
		}

		internal void UpdateCoins(Difficulty botDifficulty, PlayerType gameWinner)
		{
			Coins += CoinsCalculator.CalculateCoins(botDifficulty, gameWinner);

			if (Coins < 0)
				Coins = 0;
		}

		/// <summary>
		/// The method takes coins from the player depending on the difficulty of the bot.
		/// </summary>
		/// <param name="botDifficulty">Bot difficulty level.</param>
		/// <exception cref="NotEnoughCoinsToStartGameException">If the user doesn't have enough coins, an exception will be thrown.</exception>
		internal void DeductCoins(Difficulty botDifficulty)
		{
			int deductedCoins = CoinsCalculator.GetRequiredCoins(botDifficulty);

			if (Coins - deductedCoins < 0)
				throw new NotEnoughCoinsToStartGameException(deductedCoins, botDifficulty);
			Coins -= deductedCoins;
		}
		internal void ReturnCoins(Difficulty botDifficult)
			=> Coins += CoinsCalculator.GetRequiredCoins(botDifficult);

		private void AddItemToInventory(Item item)
		{
			if (_inventory == null)
				_inventory = new List<Item>();

			_inventory.Add(item);
		}
		private void SetDefaultInventory()
		{
			_inventory = new List<Item>();
			ImageItem imageItem = new ImageItem(0, Properties.Resources.background1);
			Avatar profilePhotoItemMan = new Avatar(0, Properties.Resources.manAvatar1, AvatarRarity.Common);
			Avatar profilePhotoItemWoman = new Avatar(0, Properties.Resources.womanAvatar1, AvatarRarity.Common);
			ColorItem colorItem = new ColorItem(0, Color.White);

			_inventory.Add(imageItem);
			_inventory.Add(profilePhotoItemMan);
			_inventory.Add(profilePhotoItemWoman);
			_inventory.Add(colorItem);
		}
	}
}