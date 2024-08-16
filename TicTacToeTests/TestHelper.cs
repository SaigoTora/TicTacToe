using TicTacToeLibrary;

namespace TicTacToeTests
{
	internal static class TestHelper
	{
		internal static Field CreateAndSetField(CellType[,] cells, int winningCellsCount)
		{
			Field field = new(cells.GetLength(0), winningCellsCount);

			for (int i = 0; i < cells.GetLength(0); i++)
				for (int j = 0; j < cells.GetLength(1); j++)
					field.FillCell(new Cell(i, j), cells[i, j]);

			return field;
		}
	}
}