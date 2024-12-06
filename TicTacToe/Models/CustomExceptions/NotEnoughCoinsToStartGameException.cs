using System;

using TicTacToeLibrary.AI;

namespace TicTacToe.Models.CustomExceptions
{
	internal class NotEnoughCoinsToStartGameException : Exception
	{
		internal int RequiredCoins { get; private set; }
		internal Difficulty Difficulty { get; private set; }

		internal NotEnoughCoinsToStartGameException(int requiredCoins)
			: base($"You don't have enough coins to start the game!\nYou must have at least {requiredCoins} coins.")
		{
			RequiredCoins = requiredCoins;
		}
		internal NotEnoughCoinsToStartGameException(int requiredCoins, Difficulty difficulty)
			: base($"You don't have enough coins to start the game on difficulty: {difficulty}!\nYou must have at least {requiredCoins} coins.")
		{
			RequiredCoins = requiredCoins;
			Difficulty = difficulty;
		}
	}
}