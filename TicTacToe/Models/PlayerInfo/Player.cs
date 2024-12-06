using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

using TicTacToe.Models.CustomExceptions;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo.Inventory;
using TicTacToe.Models.PlayerItem;
using TicTacToeLibrary.AI;

namespace TicTacToe.Models.PlayerInfo
{
	[Serializable]
	internal class Player
	{
		[JsonProperty]
		internal string Name { get; private set; }
		internal int Coins { get; private set; }
		internal int DeductedCoins => _deductedCoins;

		[JsonProperty]
		internal PlayerVisualSettings VisualSettings { get; private protected set; }
		internal BotGameSettings BotGameSettings { get; private set; }
		internal TwoPlayersGameSettings SinglePCGameSettings { get; private set; }
		internal NetworkGameSettings NetworkGameSettings { get; private set; }

		internal ItemsInventory ItemsInventory { get; private set; }
		internal CountableItemsInventory CountableItemsInventory { get; private set; }

		[NonSerialized]
		private int _deductedCoins;

		internal Player(string name)
			: this()
			=> Name = name;
		internal Player()
		{
			VisualSettings = new PlayerVisualSettings();
			BotGameSettings = new BotGameSettings();
			SinglePCGameSettings = new TwoPlayersGameSettings();
			NetworkGameSettings = new NetworkGameSettings();

			ItemsInventory = new ItemsInventory();
			CountableItemsInventory = new CountableItemsInventory();

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
					VisualSettings.Avatar = avatar;
					break;
				case ImageItem imageItem:
					VisualSettings.BackgroundMenu = imageItem;
					break;
				case ColorItem colorItem:
					VisualSettings.BackgroundGame = colorItem;
					break;
				default:
					throw new InvalidOperationException
						($"Unknown item type: {item.GetType().Name}");
			}
		}

		internal void UpdateCoins(CoinReward coinReward, GameResult gameResult)
		{
			Coins += coinReward.GetCoins(gameResult);

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
			if (_deductedCoins > 0)
				throw new InvalidOperationException("Coins have already been deducted. You cannot deduct them again!");

			_deductedCoins = CoinsCalculator.GetRequiredCoins(botDifficulty);

			if (Coins - _deductedCoins < 0)
			{
				if (botDifficulty == Difficulty.Easy)
				{// if there are not enough coins for easy difficulty, then subtract all the coins
					_deductedCoins = Coins;
					Coins = 0;
				}
				else
				{
					int requiredCoins = _deductedCoins;
					_deductedCoins = 0;
					throw new NotEnoughCoinsToStartGameException(requiredCoins, botDifficulty);
				}
			}
			else
				Coins -= _deductedCoins;
		}
		internal void DeductCoins(int coins)
		{
			if (_deductedCoins > 0)
				throw new InvalidOperationException("Coins have already been deducted. You cannot deduct them again!");

			_deductedCoins = coins;

			if (Coins - _deductedCoins < 0)
				throw new NotEnoughCoinsToStartGameException(_deductedCoins);
			else
				Coins -= _deductedCoins;
		}
		internal void ReturnCoins()
		{
			Coins += _deductedCoins;
			ResetReductedCoins();
		}
		internal void ResetReductedCoins()
			=> _deductedCoins = 0;

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