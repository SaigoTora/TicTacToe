using System;
using TicTacToeLibrary;

namespace TicTacToe.Models.GameInfo
{
	internal class CoinReward
	{
		internal int CoinsForWin { get; }
		internal int CoinsForDraw { get; }
		internal int CoinsForLoss { get; }

		internal CoinReward(int coinsForWin, int coinsForDraw, int coinsForLoss)
		{
			CoinsForWin = coinsForWin;
			CoinsForDraw = coinsForDraw;
			CoinsForLoss = coinsForLoss;
		}
		internal CoinReward(Difficulty botDifficulty)
		{
			CoinsForWin = CoinsCalculator.CalculateCoins(botDifficulty, GameResult.Win);
			CoinsForDraw = CoinsCalculator.CalculateCoins(botDifficulty, GameResult.Draw);
			CoinsForLoss = CoinsCalculator.CalculateCoins(botDifficulty, GameResult.Loss);
		}
		internal CoinReward()
		{ CoinsForWin = 0; CoinsForDraw = 0; CoinsForLoss = 0; }

		internal int GetCoins(GameResult gameResult)
		{
			switch (gameResult)
			{
				case GameResult.Loss:
					return CoinsForLoss;
				case GameResult.Draw:
					return CoinsForDraw;
				case GameResult.Win:
					return CoinsForWin;
				default:
					throw new InvalidOperationException
						($"Unknown game result: {gameResult.GetType().Name}");
			}
		}
	}
}