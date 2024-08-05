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
		internal int Points { get; private set; }
		internal PlayerVisualSettings Settings { get; private set; }

		private List<Item> _inventory = new List<Item>();

		internal Player(string Name, int Points, PlayerVisualSettings settings)
		{
			this.Name = Name;
			this.Points = Points;
			Settings = settings;
			SetDefaultInventory();
		}
		internal Player()
		{
			Settings = new PlayerVisualSettings();
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
		/// The method takes away points from the user and adds the item to the inventory.
		/// </summary>
		/// <param name="item">Item being purchased.</param>
		/// <exception cref="NotEnoughPointToBuyException">If the user doesn't have enough points to make a purchase, 
		/// an exception will be thrown.</exception>
		internal void BuyItem(Item item)
		{
			if (item.Price > Points)
				throw new NotEnoughPointToBuyException(item);

			Points -= item.Price;
			AddItemToInventory(item);
		}
		internal void SelectItem(Item item)
		{
			switch (item)
			{
				case Avatar avatar:
					{
						Settings.Avatar = avatar.Image;
						break;
					}
				case ImageItem imageItem:
					{
						Settings.BackgroundMenu = imageItem.Image;
						break;
					}
				case ColorItem colorItem:
					{
						Settings.BackgroundGame = colorItem.Color;
						break;
					}
				default:
					{
						throw new InvalidOperationException
							($"Unknown item type: {item.GetType().Name}");
					}
			}
		}

		internal void UpdatePoints(Difficulty botDifficulty, PlayerType gameWinner)
		{
			Points += PointsCalculator.CalculatePoints(botDifficulty, gameWinner);

			if (Points < 0)
				Points = 0;
		}

		/// <summary>
		/// The method takes points from the player depending on the difficulty of the bot.
		/// </summary>
		/// <param name="botDifficulty">Bot difficulty level.</param>
		/// <exception cref="NotEnoughPointToStartGameException">If the user doesn't have enough points, an exception will be thrown.</exception>
		internal void DeductPoints(Difficulty botDifficulty)
		{
			int deductedPoints = PointsCalculator.GetRequiredPoints(botDifficulty);

			if (Points - deductedPoints < 0)
				throw new NotEnoughPointToStartGameException(deductedPoints, botDifficulty);
			Points -= deductedPoints;
		}
		internal void ReturnPoints(Difficulty botDifficult)
		{
			Points += PointsCalculator.GetRequiredPoints(botDifficult);
		}

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