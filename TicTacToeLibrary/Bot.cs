using System;
using System.Collections.Generic;

namespace TicTacToeLibrary
{
	public class Bot
	{
		private const string BOT_NAME_PREFIX = "BOT";
		private const int MEDIUM_BOT_DEFENSE_PERCENTAGE = 50;

		private readonly string[] _easyBotName = { "Boot", "Beginner", "Tube", "Harmless", "Rookie",
			"GameJoy", "Nooblet", "Cheerful", "Newbie", "Slipper", "Lightheart", "Novice", "Joyful", "Noob" };
		private readonly string[] _mediumBotName = {"Tactician", "Master", "Veteran", "Strategist",
			"Average", "Gentleman", "Brainy", "Advanced", "Skillful", "Planner", "Thinker", "Sneaky", "Smart" };
		private readonly string[] _hardBotName = { "Machine", "CyberBeast", "Champion", "Titan",
			"Emperor", "Powerful", "Unstoppable", "Guru", "Greatest", "Legendary", "Grinder", "King", "Strong", "Expert" };

		public string Name { get; private set; }
		public Difficulty Difficulty { get; private set; }

		public Bot(Difficulty difficulty)
		{
			Difficulty = difficulty;

			SelectRandomNameForBot();
		}
		private void SelectRandomNameForBot()
		{
			Random rnd = new Random();
			Name = BOT_NAME_PREFIX + " ";
			switch (Difficulty)
			{
				case Difficulty.Easy:
					{
						Name += _easyBotName[rnd.Next(_easyBotName.Length)];
						break;
					}
				case Difficulty.Medium:
					{
						Name += _mediumBotName[rnd.Next(_mediumBotName.Length)];
						break;
					}
				case Difficulty.Hard:
					{
						Name += _hardBotName[rnd.Next(_hardBotName.Length)];
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

			Cell? attackCell = AttackMove(cells, botCellType, field.WinningCellsCount);
			if (attackCell.HasValue)
				return attackCell.Value;

			int randomPercent = new Random().Next(1, 101);
			if (Difficulty == Difficulty.Medium && randomPercent <= MEDIUM_BOT_DEFENSE_PERCENTAGE
				|| Difficulty == Difficulty.Hard)
			{
				Cell? defenseCell = DefenseMove(cells, botCellType, field.WinningCellsCount);
				if (defenseCell.HasValue)
					return defenseCell.Value;
			}

			return GetRandomEmptyCell(cells);
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

		private Cell GetRandomEmptyCell(CellType[,] cells)
		{// The method returns a random cell with type cellType.None
			List<Cell> listEmptyCells = new List<Cell>();

			for (int i = 0; i < cells.GetLength(0); i++)
				for (int j = 0; j < cells.GetLength(1); j++)
					if (cells[i, j] == CellType.None)
						listEmptyCells.Add(new Cell(i, j));

			Random random = new Random();
			return listEmptyCells[random.Next(0, listEmptyCells.Count)];
		}
	}
}