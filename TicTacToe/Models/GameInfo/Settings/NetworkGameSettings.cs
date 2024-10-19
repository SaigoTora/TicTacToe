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
		internal int CoinBet;
		[JsonProperty]
		internal int CurrentPlayerCount;
		[JsonProperty]
		internal int MaxPlayerCount;

		internal NetworkGameSettings() : base()
		{ }
		internal NetworkGameSettings(string description, int coinBet, string opponentName, Avatar opponentAvatar,
			int numberOfRounds, FieldSize fieldSize, bool isTimerEnabled, bool isGameAssistsEnabled,
			int currentPlayerCount, int maxPlayerCount)
			: base(opponentName, opponentAvatar, numberOfRounds, fieldSize, isTimerEnabled, isGameAssistsEnabled)
		{
			Description = description;
			CoinBet = coinBet;
			CurrentPlayerCount = currentPlayerCount;
			MaxPlayerCount = maxPlayerCount;
		}
	}
}