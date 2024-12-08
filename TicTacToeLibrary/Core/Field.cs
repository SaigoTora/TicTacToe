using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using TicTacToeLibrary.GameLogic;

namespace TicTacToeLibrary.Core
{
	[Serializable]
	public class Field : ICloneable
	{
		private const int MIN_CELLS_TO_CHECK_END_GAME = 4;
		[JsonIgnore]
		public readonly int WinningCellsCount;
		[JsonIgnore]
		public CellType Winner { get; private set; } = CellType.None;
		[JsonIgnore]
		public Cell[] WinningCells { get; private set; }
		[JsonProperty("Cells")]
		private readonly CellType[,] _cells;

		[JsonConstructor]
		private Field() { }
		public Field(int fieldSize, int winningCellsCount)
		{
			if (fieldSize < winningCellsCount)
				throw new ArgumentOutOfRangeException("The cell count must be greater than or equal to the winning cells count.");

			_cells = new CellType[fieldSize, fieldSize];
			WinningCellsCount = winningCellsCount;
		}

		public CellType[,] GetAllCells()
		{
			CellType[,] newCells = new CellType[_cells.GetLength(0), _cells.GetLength(1)];
			for (int i = 0; i < _cells.GetLength(0); i++)
				for (int j = 0; j < _cells.GetLength(1); j++)
					newCells[i, j] = _cells[i, j];

			return _cells;
		}
		public int GetFieldSize() => _cells.GetLength(0);
		public CellType GetCell(Cell cell)
			=> _cells[cell.row, cell.column];
		public void FillCell(Cell cell, CellType cellType)
			=> _cells[cell.row, cell.column] = cellType;
		public bool IsCellValidForGameMode(Cell cell, GameMode gameMode)
		{
			bool isCellEmpty = _cells[cell.row, cell.column] == CellType.None;

			switch (gameMode)
			{
				case GameMode.Classic:
				case GameMode.Swap:
					return isCellEmpty;
				case GameMode.Tetris:
					return isCellEmpty && (cell.row == _cells.GetLength(0) - 1
						|| _cells[cell.row + 1, cell.column] != CellType.None);
				case GameMode.ReverseTetris:
					return isCellEmpty && (cell.row == 0
						|| _cells[cell.row - 1, cell.column] != CellType.None);
				default:
					throw new InvalidOperationException($"Unknown game mode: {gameMode}");
			}
		}

		public object Clone()
		{
			Field newField = new Field(_cells.GetLength(0), WinningCellsCount);
			for (int i = 0; i < _cells.GetLength(0); i++)
				for (int j = 0; j < _cells.GetLength(1); j++)
					newField.FillCell(new Cell(i, j), _cells[i, j]);

			newField.Winner = Winner;
			if (WinningCells != null)
				newField.WinningCells = (Cell[])WinningCells.Clone();

			return newField;
		}
		public Cell? GetFirstCellMismatch(CellType[,] cells)
		{// The method returns the first mismatch between the cell arrays.
			if (_cells.GetLength(0) != cells.GetLength(0) || _cells.GetLength(1) != cells.GetLength(1))
				throw new ArgumentException("The field sizes must be the same.");

			for (int i = 0; i < cells.GetLength(0); i++)
				for (int j = 0; j < cells.GetLength(1); j++)
					if (_cells[i, j] != cells[i, j])
						return new Cell(i, j);

			return null;
		}

		public Cell GetRandomEmptyCell()
		{// The method returns a random cell with type cellType.None
			List<Cell> listEmptyCells = new List<Cell>();

			for (int i = 0; i < _cells.GetLength(0); i++)
				for (int j = 0; j < _cells.GetLength(1); j++)
					if (_cells[i, j] == CellType.None)
						listEmptyCells.Add(new Cell(i, j));

			if (listEmptyCells.Count == 0)
				throw new InvalidOperationException("All cells on the field are filled!");

			Random random = new Random();
			return listEmptyCells[random.Next(0, listEmptyCells.Count)];
		}
		public int CountFilledCells()
		{
			int result = 0;

			for (int i = 0; i < _cells.GetLength(0); i++)
				for (int j = 0; j < _cells.GetLength(1); j++)
					if (_cells[i, j] != CellType.None)
						result++;

			return result;
		}
		public bool IsGameEnd(bool needToSetWinnerCells = true)
		{
			Winner = CellType.None;
			if (CountFilledCells() <= MIN_CELLS_TO_CHECK_END_GAME)
				return false;

			if (HorizontalAndVerticalCheck(needToSetWinnerCells)
				|| DiagonalCheck(needToSetWinnerCells))
				return true;

			// If all cells are filled
			if (CountFilledCells() == _cells.Length)
				return true;

			return false;
		}


		private bool HorizontalAndVerticalCheck(bool needToSetWinnerCells)
		{
			int fieldSize = _cells.GetLength(0);

			for (int i = 0; i < fieldSize; i++)// Horizontal
				if (CheckLine(i, 0, 0, 1, needToSetWinnerCells))
					return true;

			for (int j = 0; j < fieldSize; j++)// Vertical
				if (CheckLine(0, j, 1, 0, needToSetWinnerCells))
					return true;

			return false;
		}
		private bool DiagonalCheck(bool needToSetWinnerCells)
		{
			int fieldSize = _cells.GetLength(0);

			for (int i = 0; i < fieldSize; i++)// Diagonal (top left - bottom right)
				if (CheckLine(0, i, 1, 1, needToSetWinnerCells)
					|| CheckLine(i, 0, 1, 1, needToSetWinnerCells))
					return true;

			for (int i = fieldSize - 1; i >= 0; i--)// Diagonal (top right - bottom left)
				if (CheckLine(0, i, 1, -1, needToSetWinnerCells)
					|| CheckLine(fieldSize - i - 1, fieldSize - 1, 1, -1, needToSetWinnerCells))
					return true;

			return false;
		}
		private bool CheckLine(int startRow, int startCol, int rowStep, int colStep, bool needToSetWinnerCells)
		{
			if (rowStep == 0 && colStep == 0)
				throw new ArgumentException($"{nameof(rowStep)} and {nameof(colStep)} " +
					$"cannot be zero at the same time.");

			int currentRow, currentCol, nextRow, nextCol;
			int matchCount = 1;

			for (int j = 0; ; j++)
			{
				currentRow = startRow + j * rowStep;
				currentCol = startCol + j * colStep;
				nextRow = startRow + (j + 1) * rowStep;
				nextCol = startCol + (j + 1) * colStep;

				if (nextRow >= _cells.GetLength(0) || nextCol >= _cells.GetLength(1)
					|| nextRow < 0 || nextCol < 0)// Condition for exiting the loop
					return false;

				if (_cells[currentRow, currentCol] != CellType.None &&
					_cells[currentRow, currentCol] == _cells[nextRow, nextCol])
					matchCount++;
				else
					matchCount = 1;

				if (matchCount == WinningCellsCount)
				{// If the required number of identical cells in a row was found
					Winner = _cells[nextRow, nextCol];
					if (needToSetWinnerCells)
						SetWinningCells(startRow, startCol, rowStep, colStep, j + 1);
					return true;
				}
			}
		}
		private void SetWinningCells(int startRow, int startCol, int rowStep, int colStep, int end)
		{
			WinningCells = new Cell[WinningCellsCount];
			int currentRow, currentCol;
			int winningCellIndex = 0;

			for (int k = end - WinningCellsCount + 1; k <= end; k++)
			{
				currentRow = startRow + k * rowStep;
				currentCol = startCol + k * colStep;
				WinningCells[winningCellIndex++] = new Cell(currentRow, currentCol);
			}
		}
	}
}