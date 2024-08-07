using TicTacToeLibrary;

namespace TicTacToeTests
{
	internal static class TestHelper
	{
		internal static bool CompareCells(Cell firstCell, Cell secondCell)
			=> firstCell.row == secondCell.row && firstCell.column == secondCell.column;

		internal static Field CreateAndSetField(CellType[,] cells, int winningCellsCount)
		{
			Field field = new(cells.GetLength(0), winningCellsCount);

			for (int i = 0; i < cells.GetLength(0); i++)
				for (int j = 0; j < cells.GetLength(1); j++)
					field.FillCell(new Cell(i, j), cells[i, j]);

			return field;
		}

		internal static bool CompareCellArrays(Cell[] cellArray1, Cell[] cellArray2)
		{
			if (cellArray1 == null || cellArray2 == null)
				return cellArray1 == cellArray2;

			if (cellArray1.Length != cellArray2.Length)
				return false;

			for (int i = 0; i < cellArray1.Length; i++)
				if (!CompareCells(cellArray1[i], cellArray2[i]))
					return false;

			return true;
		}
	}
}