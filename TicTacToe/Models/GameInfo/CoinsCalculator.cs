using TicTacToe.Models.PlayerInfo;
using TicTacToeLibrary;

namespace TicTacToe.Models.GameInfo
{
	internal static class CoinsCalculator
	{
		private const int EASY_REQUIRED_COINS = 2;
		private const int MEDIUM_REQUIRED_COINS = 5;
		private const int HARD_REQUIRED_COINS = 10;
		private const int IMPOSSIBLE_REQUIRED_COINS = 15;

		private const int EASY_WIN_COINS = 2;
		private const int EASY_DRAW_COINS = 0;
		private const int EASY_LOSS_COINS = -4;

		private const int MEDIUM_WIN_COINS = 8;
		private const int MEDIUM_DRAW_COINS = 1;
		private const int MEDIUM_LOSS_COINS = -5;

		private const int HARD_WIN_COINS = 15;
		private const int HARD_DRAW_COINS = 1;
		private const int HARD_LOSS_COINS = -10;

		private const int IMPOSSIBLE_WIN_COINS = 30;
		private const int IMPOSSIBLE_DRAW_COINS = 2;
		private const int IMPOSSIBLE_LOSS_COINS = -15;

		internal static int CalculateCoins(Difficulty botDifficult, PlayerType gameWinner)
		{
			switch (botDifficult)
			{
				case Difficulty.Easy:
					{
						if (gameWinner == PlayerType.Human)
							return EASY_WIN_COINS;
						else if (gameWinner == PlayerType.None)
							return EASY_DRAW_COINS;
						else if (gameWinner == PlayerType.Bot)
							return EASY_LOSS_COINS;
						break;
					}
				case Difficulty.Medium:
					{
						if (gameWinner == PlayerType.Human)
							return MEDIUM_WIN_COINS;
						else if (gameWinner == PlayerType.None)
							return MEDIUM_DRAW_COINS;
						else if (gameWinner == PlayerType.Bot)
							return MEDIUM_LOSS_COINS;
						break;
					}
				case Difficulty.Hard:
					{
						if (gameWinner == PlayerType.Human)
							return HARD_WIN_COINS;
						else if (gameWinner == PlayerType.None)
							return HARD_DRAW_COINS;
						else if (gameWinner == PlayerType.Bot)
							return HARD_LOSS_COINS;
						break;
					}
				case Difficulty.Impossible:
					{
						if (gameWinner == PlayerType.Human)
							return IMPOSSIBLE_WIN_COINS;
						else if (gameWinner == PlayerType.None)
							return IMPOSSIBLE_DRAW_COINS;
						else if (gameWinner == PlayerType.Bot)
							return IMPOSSIBLE_LOSS_COINS;
						break;
					}
				default: break;
			}
			return 0;
		}
		internal static int GetRequiredCoins(Difficulty botDifficult)
		{
			switch (botDifficult)
			{
				case Difficulty.Easy:
					return EASY_REQUIRED_COINS;
				case Difficulty.Medium:
					return MEDIUM_REQUIRED_COINS;
				case Difficulty.Hard:
					return HARD_REQUIRED_COINS;
				case Difficulty.Impossible:
					return IMPOSSIBLE_REQUIRED_COINS;
				default:
					break;
			}

			return 0;
		}
	}
}