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

		internal NetworkGameSettings() : base()
		{ }
		internal NetworkGameSettings(string description, int coinsBet, string opponentName, Avatar opponentAvatar,
			int numberOfRounds, FieldSize fieldSize, bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(opponentName, opponentAvatar, numberOfRounds, fieldSize, isTimerEnabled, isGameAssistsEnabled)
		{
			Description = description;
			CoinsBet = coinsBet;
		}
	}
}