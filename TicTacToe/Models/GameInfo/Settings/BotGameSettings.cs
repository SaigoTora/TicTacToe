using System;

using TicTacToeLibrary.AI;
using TicTacToeLibrary.GameLogic;

namespace TicTacToe.Models.GameInfo.Settings
{
	[Serializable]
	internal class BotGameSettings : GameSettings
	{
		internal Difficulty BotDifficulty = Difficulty.Easy;

		internal BotGameSettings() : base()
		{ }
		internal BotGameSettings(Difficulty botDifficulty, int numberOfRounds, FieldSize fieldSize,
			GameMode gameMode, bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(numberOfRounds, fieldSize, gameMode, isTimerEnabled, isGameAssistsEnabled)
		{
			BotDifficulty = botDifficulty;
		}
	}
}