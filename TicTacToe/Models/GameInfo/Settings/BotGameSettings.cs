using System;

using TicTacToeLibrary.AI;

namespace TicTacToe.Models.GameInfo.Settings
{
	[Serializable]
	internal class BotGameSettings : GameSettings
	{
		internal Difficulty BotDifficulty = Difficulty.Easy;

		internal BotGameSettings() : base()
		{ }
		internal BotGameSettings(Difficulty botDifficulty, int numberOfRounds, FieldSize fieldSize,
			bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(numberOfRounds, fieldSize, isTimerEnabled, isGameAssistsEnabled)
		{
			BotDifficulty = botDifficulty;
		}
	}
}