using Newtonsoft.Json;
using System;

using TicTacToe.Models.PlayerItem;

namespace TicTacToe.Models.GameInfo.Settings
{
	[Serializable]
	internal class NetworkGameSettings : TwoPlayersGameSettings
	{
		[JsonProperty]
		internal string Description;
		[JsonProperty]
		internal int CoinsBet;
		[JsonProperty]
		internal int CurrentPlayerCount;
		[JsonProperty]
		internal int MaxPlayerCount = 2;

		internal NetworkGameSettings() : base()
		{ }
		internal NetworkGameSettings(string description, int coinsBet, string opponentName, Avatar opponentAvatar,
			int numberOfRounds, FieldSize fieldSize, bool isTimerEnabled, bool isGameAssistsEnabled,
			int currentPlayerCount)
			: base(opponentName, opponentAvatar, numberOfRounds, fieldSize, isTimerEnabled, isGameAssistsEnabled)
		{
			Description = description;
			CoinsBet = coinsBet;
			CurrentPlayerCount = currentPlayerCount;
		}
	}
}