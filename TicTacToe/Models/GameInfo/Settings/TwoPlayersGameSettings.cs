using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

using TicTacToe.Models.PlayerItem;
using TicTacToeLibrary.GameLogic;

namespace TicTacToe.Models.GameInfo.Settings
{
	[Serializable]
	internal class TwoPlayersGameSettings : GameSettings
	{
		[JsonProperty]
		internal string OpponentName;
		[JsonProperty]
		internal Avatar OpponentAvatar;

		internal TwoPlayersGameSettings() : base()
		{ }
		internal TwoPlayersGameSettings(string opponentName, Avatar opponentAvatar, int numberOfRounds,
			FieldSize fieldSize, GameMode gameMode, bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(numberOfRounds, fieldSize, gameMode, isTimerEnabled, isGameAssistsEnabled)
		{
			OpponentName = opponentName;
			OpponentAvatar = opponentAvatar;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			if (OpponentAvatar != null && OpponentAvatar.Name != null
				&& OpponentAvatar.Name != string.Empty)
				OpponentAvatar = (Avatar)ItemManager.GetFullItem(OpponentAvatar);
		}
	}
}