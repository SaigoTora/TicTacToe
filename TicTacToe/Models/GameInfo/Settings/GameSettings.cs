using Newtonsoft.Json;
using System;

namespace TicTacToe.Models.GameInfo.Settings
{
	[Serializable]
	internal class GameSettings
	{
		[JsonProperty]
		internal int NumberOfRounds = 2;
		[JsonProperty]
		internal FieldSize FieldSize = FieldSize.Size3on3;
		[JsonProperty]
		internal bool IsTimerEnabled;
		[JsonProperty]
		internal bool IsGameAssistsEnabled;

		internal GameSettings()
		{ }
		internal GameSettings(int numberOfRounds, FieldSize fieldSize,
			bool isTimerEnabled, bool isGameAssistsEnabled)
		{
			NumberOfRounds = numberOfRounds;
			FieldSize = fieldSize;
			IsTimerEnabled = isTimerEnabled;
			IsGameAssistsEnabled = isGameAssistsEnabled;
		}
	}
}