using TicTacToe.Models.PlayerInfo;
using TicTacToeLibrary;

namespace TicTacToe.Models.GameInfo
{
	internal static class PointsCalculator
	{
		private const int EASY_REQUIRED_POINTS = 0;
		private const int MEDIUM_REQUIRED_POINTS = 5;
		private const int HARD_REQUIRED_POINTS = 10;

		private const int EASY_WIN_POINTS = 2;
		private const int EASY_DRAW_POINTS = 0;
		private const int EASY_LOSS_POINTS = -4;

		private const int MEDIUM_WIN_POINTS = 8;
		private const int MEDIUM_DRAW_POINTS = 1;
		private const int MEDIUM_LOSS_POINTS = -5;

		private const int HARD_WIN_POINTS = 15;
		private const int HARD_DRAW_POINTS = 2;
		private const int HARD_LOSS_POINTS = -10;

		internal static int CalculatePoints(Difficulty botDifficult, PlayerType gameWinner)
		{
			switch (botDifficult)
			{
				case Difficulty.Easy:
					{
						if (gameWinner == PlayerType.Human)
							return EASY_WIN_POINTS;
						else if (gameWinner == PlayerType.None)
							return EASY_DRAW_POINTS;
						else if (gameWinner == PlayerType.Bot)
							return EASY_LOSS_POINTS;
						break;
					}
				case Difficulty.Medium:
					{
						if (gameWinner == PlayerType.Human)
							return MEDIUM_WIN_POINTS;
						else if (gameWinner == PlayerType.None)
							return MEDIUM_DRAW_POINTS;
						else if (gameWinner == PlayerType.Bot)
							return MEDIUM_LOSS_POINTS;
						break;
					}
				case Difficulty.Hard:
					{
						if (gameWinner == PlayerType.Human)
							return HARD_WIN_POINTS;
						else if (gameWinner == PlayerType.None)
							return HARD_DRAW_POINTS;
						else if (gameWinner == PlayerType.Bot)
							return HARD_LOSS_POINTS;
						break;
					}
				default: break;
			}
			return 0;
		}
		internal static int GetRequiredPoints(Difficulty botDifficult)
		{
			switch (botDifficult)
			{
				case Difficulty.Easy:
					return EASY_REQUIRED_POINTS;
				case Difficulty.Medium:
					return MEDIUM_REQUIRED_POINTS;
				case Difficulty.Hard:
					return HARD_REQUIRED_POINTS;
				default:
					break;
			}

			return 0;
		}
	}
}