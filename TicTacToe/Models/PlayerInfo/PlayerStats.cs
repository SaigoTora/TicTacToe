using System;

using TicTacToe.Models.GameInfo;

namespace TicTacToe.Models.PlayerInfo
{
	[Serializable]
	internal class PlayerStats
	{
		internal long Wins { get; private set; }
		internal long Draws { get; private set; }
		internal long Losses { get; private set; }
		internal long TotalGames => Wins + Draws + Losses;
		internal double WinRate => TotalGames > 0 ? (double)Wins / TotalGames * 100 : 0.0;

		internal void AddGameResult(GameResult gameResult)
		{
			switch (gameResult)
			{
				case GameResult.Loss:
					Losses++;
					break;
				case GameResult.Draw:
					Draws++;
					break;
				case GameResult.Win:
					Wins++;
					break;
				default:
					throw new InvalidOperationException
						($"Unknown game result: {gameResult.GetType().Name}");
			}
		}
	}
}