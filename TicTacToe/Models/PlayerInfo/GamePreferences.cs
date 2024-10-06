using System;
using System.Runtime.Serialization;

using TicTacToe.Models.PlayerItem;
using TicTacToeLibrary;

namespace TicTacToe.Models.PlayerInfo
{
	internal enum FieldSize : byte
	{
		Size3on3,
		Size5on5,
		Size7on7
	}
	[Serializable]
	internal class GamePreferences
	{
		internal Difficulty BotDifficulty = Difficulty.Easy;
		internal int NumberOfRounds = 2;
		internal FieldSize FieldSize = FieldSize.Size3on3;
		internal string OpponentName;
		internal Avatar OpponentAvatar;
		internal bool IsTimerEnabled;
		internal bool IsGameAssistsEnabled;

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			if (OpponentAvatar != null && OpponentAvatar.Name != null)
				OpponentAvatar = (Avatar)ItemManager.GetFullItem(OpponentAvatar);
		}
	}
}