using System;

using TicTacToeLibrary.Core;
using TicTacToeLibrary.GameLogic;

namespace TicTacToeLibrary.AI
{
	public class Bot
	{
		private const string BOT_NAME_PREFIX = "BOT";
		private const int EASY_BOT_DEFENSE_PERCENTAGE = 35;
		private const int MEDIUM_BOT_DEFENSE_PERCENTAGE = 70;
		private const int MEDIUM_BOT_PERFECT_MOVE_PERCENTAGE = 35;
		private const int HARD_BOT_PERFECT_MOVE_PERCENTAGE = 70;
		private const int IMPOSSIBLE_BOT_PERFECT_MOVE_PERCENTAGE = 95;


		private static readonly Random _random = new Random();

		private readonly string[] _easyBotName = { "Boot", "Beginner", "Tube", "Harmless", "Rookie",
			"GameJoy", "Nooblet", "Cheerful", "Newbie", "Slipper", "Lightheart", "Novice", "Joyful", "Noob" };
		private readonly string[] _mediumBotName = {"Tactician", "Master", "Veteran", "Strategist",
			"Average", "Gentleman", "Brainy", "Advanced", "Skillful", "Planner", "Thinker", "Sneaky", "Smart" };
		private readonly string[] _hardBotName = { "Machine", "CyberBeast", "Champion", "Titan",
			"Emperor", "Powerful", "Unstoppable", "Guru", "Greatest", "Legendary", "Grinder", "King", "Strong", "Expert" };
		private readonly string[] _impossibleBotName = { "Invincible", "Godlike", "Overlord", "Immortal", "Omniscient",
			"Ultimate", "Eternal", "Infinity", "Unbeatable", "Absolute" };
		public string Name { get; private set; }
		public Difficulty Difficulty { get; private set; }

		public Bot(Difficulty difficulty)
		{
			Difficulty = difficulty;

			SelectRandomNameForBot();
		}
		private void SelectRandomNameForBot()
		{
			Name = BOT_NAME_PREFIX + " ";
			switch (Difficulty)
			{
				case Difficulty.Easy:
					{
						Name += _easyBotName[_random.Next(_easyBotName.Length)];
						break;
					}
				case Difficulty.Medium:
					{
						Name += _mediumBotName[_random.Next(_mediumBotName.Length)];
						break;
					}
				case Difficulty.Hard:
					{
						Name += _hardBotName[_random.Next(_hardBotName.Length)];
						break;
					}
				case Difficulty.Impossible:
					{
						Name += _impossibleBotName[_random.Next(_impossibleBotName.Length)];
						break;
					}
				default: break;
			}
		}

		public Cell Move(Field field, CellType botCellType, GameMode gameMode)
		{
			if (botCellType == CellType.None)
				throw new ArgumentException($"{nameof(botCellType)} cannot be equal {botCellType}");

			if (Difficulty != Difficulty.Impossible)
			{
				Cell? attackCell = AttackMove(field, botCellType, field.WinningCellsCount, gameMode);
				if (attackCell.HasValue)
					return attackCell.Value;
			}

			int randomPercent = _random.Next(1, 101);
			if (Difficulty == Difficulty.Easy && randomPercent <= EASY_BOT_DEFENSE_PERCENTAGE
				|| Difficulty == Difficulty.Medium && randomPercent <= MEDIUM_BOT_DEFENSE_PERCENTAGE
				|| Difficulty == Difficulty.Hard)
			{
				Cell? defenseCell = DefenseMove(field, botCellType, field.WinningCellsCount, gameMode);
				if (defenseCell.HasValue)
					return defenseCell.Value;
			}

			randomPercent = _random.Next(1, 101);
			if (Difficulty == Difficulty.Medium && randomPercent <= MEDIUM_BOT_PERFECT_MOVE_PERCENTAGE
				|| Difficulty == Difficulty.Hard && randomPercent <= HARD_BOT_PERFECT_MOVE_PERCENTAGE
				|| Difficulty == Difficulty.Impossible && randomPercent <= IMPOSSIBLE_BOT_PERFECT_MOVE_PERCENTAGE)
				return PerfectMoveFinder.FindCell(field, botCellType, gameMode);

			return field.GetRandomEmptyCell();
		}
		private Cell? DefenseMove(Field field, CellType botCellType,
			int winningCellsCount, GameMode gameMode)
		{// Defense against a player's winning move
			CellType[,] cells = field.GetAllCells();
			CellType playerCellType = botCellType == CellType.Cross ? CellType.Zero : CellType.Cross;

			for (int i = 0; i < cells.GetLength(0); i++)
				for (int j = 0; j < cells.GetLength(1); j++)
					if (field.IsCellValidForGameMode(new Cell(i, j), gameMode)
						&& NearToFull(cells, i, j, playerCellType, winningCellsCount))
						return new Cell(i, j);

			return null;
		}
		private Cell? AttackMove(Field field, CellType botCellType,
			int winningCellsCount, GameMode gameMode)
		{// Attack (last move to win)
			CellType[,] cells = field.GetAllCells();

			for (int i = 0; i < cells.GetLength(0); i++)
				for (int j = 0; j < cells.GetLength(1); j++)
					if (field.IsCellValidForGameMode(new Cell(i, j), gameMode)
						&& NearToFull(cells, i, j, botCellType, winningCellsCount))
						return new Cell(i, j);

			return null;
		}
		private bool NearToFull(CellType[,] cells, int row, int column, CellType cellType, int winningCellsCount)
		{
			int rowCount = cells.GetLength(0);
			int columnCount = cells.GetLength(1);

			// Horizontal check (left and right)
			if (IsDirectionFull(cells, row, column, cellType, winningCellsCount,
				rowCount, columnCount, 0, -1, 0, 1))
				return true;

			// Vertical check (down and up)
			if (IsDirectionFull(cells, row, column, cellType, winningCellsCount,
				rowCount, columnCount, -1, 0, 1, 0))
				return true;

			// Diagonal check (left up and right down)
			if (IsDirectionFull(cells, row, column, cellType, winningCellsCount,
				rowCount, columnCount, -1, -1, 1, 1))
				return true;

			// Diagonal check (right up and left down)
			if (IsDirectionFull(cells, row, column, cellType, winningCellsCount,
				rowCount, columnCount, -1, 1, 1, -1))
				return true;

			return false;
		}
		private bool IsDirectionFull(CellType[,] cells, int row, int column,
			CellType cellType, int winningCellsCount, int rowCount, int columnCount,
			int rowStep1, int colStep1, int rowStep2, int colStep2)
		{
			int countNeededCells = CountMatches(cells, row, column, cellType,
									rowCount, columnCount, rowStep1, colStep1)
								 + CountMatches(cells, row, column, cellType,
										rowCount, columnCount, rowStep2, colStep2);

			return countNeededCells >= winningCellsCount - 1;
		}
		private int CountMatches(CellType[,] cells, int row, int column,
			CellType cellType, int rowCount, int columnCount,
			int rowStep, int colStep)
		{
			int count = 0;
			int i = row + rowStep;
			int j = column + colStep;

			while (i >= 0 && i < rowCount && j >= 0 && j < columnCount
				&& cells[i, j] == cellType)
			{
				count++;
				i += rowStep;
				j += colStep;
			}

			return count;
		}
	}
}