﻿using System;
using System.Runtime.Serialization;

using TicTacToe.Models.CustomExceptions;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.PlayerInfo.Inventory;
using TicTacToeLibrary;

namespace TicTacToe.Models.PlayerInfo
{
	[Serializable]
	internal class Player
	{
		internal string Name { get; private set; }
		internal int Coins { get; private set; }
		internal PlayerPreferences Preferences { get; private set; }
		internal ItemsInventory ItemsInventory { get; private set; } = new ItemsInventory();
		internal CountableItemsInventory CountableItemsInventory { get; private set; } = new CountableItemsInventory();

		private int deductedCoins;
		internal Player(string name, int coins, PlayerPreferences preferences)
		{
			Name = name;
			Coins = coins;
			Preferences = preferences;
			ItemsInventory.SetDefaultInventory();
		}
		internal Player()
		{
			Preferences = new PlayerPreferences();
			ItemsInventory.SetDefaultInventory();
		}

		internal bool HaveEnoughCoins(int coins) => Coins >= coins;
		internal void ChangeName(string newName) => Name = newName;

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
			item.SetDateTimePurchaseNow();
			AddItemToInventory(item);
		}
		internal void SelectItem(Item item)
		{
			switch (item)
			{
				case Avatar avatar:
					Preferences.Avatar = avatar;
					break;
				case ImageItem imageItem:
					Preferences.BackgroundMenu = imageItem;
					break;
				case ColorItem colorItem:
					Preferences.BackgroundGame = colorItem;
					break;
				default:
					throw new InvalidOperationException
						($"Unknown item type: {item.GetType().Name}");
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
			deductedCoins = CoinsCalculator.GetRequiredCoins(botDifficulty);

			if (Coins - deductedCoins < 0)
			{
				if (botDifficulty == Difficulty.Easy)
				{// if there are not enough coins for easy difficulty, then subtract all the coins
					deductedCoins = Coins;
					Coins = 0;
				}
				else
					throw new NotEnoughCoinsToStartGameException(deductedCoins, botDifficulty);
			}
			else
				Coins -= deductedCoins;
		}
		internal void ReturnCoins()
		{
			Coins += deductedCoins;
			deductedCoins = 0;
		}

		private void AddItemToInventory(Item item)
		{
			if (item is CountableItem countableItem)
				CountableItemsInventory.AddItem(countableItem);
			else
				ItemsInventory.AddItem(item);
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			ItemsInventory.SetFullItems();
			CountableItemsInventory.SetFullItems();
		}
	}
}