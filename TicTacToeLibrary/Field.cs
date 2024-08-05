using System;

namespace TicTacToeLibrary
{
	public class Field
	{
		private const int MIN_CELLS_TO_CHECK_END_GAME = 4;

		public readonly int WinningCellsCount;
		public CellType Winner { get; private set; } = CellType.None;
		public Cell[] WinningCells { get; private set; }

		private readonly CellType[,] _cells;

		public Field(int cellCount, int winningCellsCount)
		{
			if (cellCount < winningCellsCount)
				throw new ArgumentOutOfRangeException("The cell count must be greater than or equal to the winning cells count.");

			_cells = new CellType[cellCount, cellCount];
			WinningCellsCount = winningCellsCount;
		}

		public CellType[,] GetAllCells() => _cells;

		public void FillCell(Cell cell, CellType cellType)
			=> _cells[cell.row, cell.column] = cellType;

		public bool IsGameEnd(bool needToSetWinnerCells = true)
		{
			if (CountFilledCells() <= MIN_CELLS_TO_CHECK_END_GAME)
				return false;

			int rowCount = _cells.GetLength(0);
			int columnCount = _cells.GetLength(1);


			for (int i = 0; i < rowCount; i++)// Horizontal
				if (CheckLine(i, 0, 0, 1, needToSetWinnerCells))
					return true;

			for (int j = 0; j < columnCount; j++)// Vertical
				if (CheckLine(0, j, 1, 0, needToSetWinnerCells))
					return true;

			for (int i = 0; i < rowCount; i++)// Diagonal (top left - bottom right)
				if (CheckLine(0, i, 1, 1, needToSetWinnerCells)
					|| CheckLine(i, 0, 1, 1, needToSetWinnerCells))
					return true;

			for (int i = rowCount - 1; i >= 0; i--)// Diagonal (top right - bottom left)
				if (CheckLine(0, i, 1, -1, needToSetWinnerCells)
					|| CheckLine(rowCount - i - 1, rowCount - 1, 1, -1, needToSetWinnerCells))
					return true;


			// If there is at least one empty cell, the game is not over yet.
			for (int i = 0; i < rowCount; i++)
				for (int j = 0; j < columnCount; j++)
					if (_cells[i, j] == CellType.None)
						return false;

			return true;
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

		private int CountFilledCells()
		{
			int result = 0;

			for (int i = 0; i < _cells.GetLength(0); i++)
				for (int j = 0; j < _cells.GetLength(1); j++)
					if (_cells[i, j] != CellType.None)
						result++;

			return result;
		}
	}
}