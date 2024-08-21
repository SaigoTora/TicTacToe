using System;

namespace TicTacToeLibrary
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

		public Cell Move(Field field, CellType botCellType)
		{
			if (botCellType == CellType.None)
				throw new ArgumentException($"{nameof(botCellType)} cannot be equal {botCellType}");

			CellType[,] cells = field.GetAllCells();
			if (Difficulty != Difficulty.Impossible)
			{
				Cell? attackCell = AttackMove(cells, botCellType, field.WinningCellsCount);
				if (attackCell.HasValue)
					return attackCell.Value;
			}

			int randomPercent = _random.Next(1, 101);
			if (Difficulty == Difficulty.Easy && randomPercent <= EASY_BOT_DEFENSE_PERCENTAGE
				|| Difficulty == Difficulty.Medium && randomPercent <= MEDIUM_BOT_DEFENSE_PERCENTAGE
				|| Difficulty == Difficulty.Hard)
			{
				Cell? defenseCell = DefenseMove(cells, botCellType, field.WinningCellsCount);
				if (defenseCell.HasValue)
					return defenseCell.Value;
			}

			randomPercent = _random.Next(1, 101);
			if (Difficulty == Difficulty.Medium && randomPercent <= MEDIUM_BOT_PERFECT_MOVE_PERCENTAGE
				|| Difficulty == Difficulty.Hard && randomPercent <= HARD_BOT_PERFECT_MOVE_PERCENTAGE
				|| Difficulty == Difficulty.Impossible && randomPercent <= IMPOSSIBLE_BOT_PERFECT_MOVE_PERCENTAGE)
				return PerfectMoveFinder.FindCell(field, botCellType);

			return field.GetRandomEmptyCell();
		}
		private Cell? DefenseMove(CellType[,] cells, CellType botCellType, int winningCellsCount)
		{// Defense against a player's winning move
			CellType playerCellType = botCellType == CellType.Cross ? CellType.Zero : CellType.Cross;

			for (int i = 0; i < cells.GetLength(0); i++)
				for (int j = 0; j < cells.GetLength(1); j++)
					if (cells[i, j] == CellType.None && NearToFull(cells, i, j, playerCellType, winningCellsCount))
						return new Cell(i, j);

			return null;
		}
		private Cell? AttackMove(CellType[,] cells, CellType botCellType, int winningCellsCount)
		{// Attack (last move to win)
			for (int i = 0; i < cells.GetLength(0); i++)
				for (int j = 0; j < cells.GetLength(1); j++)
					if (cells[i, j] == CellType.None && NearToFull(cells, i, j, botCellType, winningCellsCount))
						return new Cell(i, j);

			return null;
		}
		private bool NearToFull(CellType[,] cells, int row, int column, CellType cellType, int winningCellsCount)
		{// Method that returns true if it finds n cells of type cellType in a row, where n = winningCellsCount - 1
			int rowCount = cells.GetLength(0);
			int columnCount = cells.GetLength(1);

			// Local function for counting matches
			int CheckDirection(int rowStep, int colStep)
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

			// Horizontal check (left and right)
			int countNeededCells = CheckDirection(0, -1) + CheckDirection(0, 1);
			if (countNeededCells >= winningCellsCount - 1) return true;

			// Vertical check (down and up)
			countNeededCells = CheckDirection(-1, 0) + CheckDirection(1, 0);
			if (countNeededCells >= winningCellsCount - 1) return true;

			// Diagonal check (left up and right down)
			countNeededCells = CheckDirection(-1, -1) + CheckDirection(1, 1);
			if (countNeededCells >= winningCellsCount - 1) return true;

			// Diagonal check (right up and left down)
			countNeededCells = CheckDirection(-1, 1) + CheckDirection(1, -1);
			if (countNeededCells >= winningCellsCount - 1) return true;

			return false;
		}
	}
}