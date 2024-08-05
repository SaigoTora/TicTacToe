using System;

using TicTacToeLibrary;

namespace TicTacToe.Models.CustomExceptions
{
	internal class NotEnoughPointToStartGameException : Exception
	{
		internal int RequiredPoints { get; private set; }
		internal Difficulty Difficulty { get; private set; }

		internal NotEnoughPointToStartGameException(int requiredPoints, Difficulty difficulty)
			: base($"You don't have enough points to start the game on difficulty: {difficulty}!\nYou must have at least {requiredPoints} points.")
		{
			RequiredPoints = requiredPoints;
			Difficulty = difficulty;
		}
	}
}