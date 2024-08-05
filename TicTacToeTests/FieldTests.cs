using TicTacToeLibrary;

namespace TicTacToeTests;

public class FieldTests
{
	[SetUp]
	public void Setup()
	{
	}

	internal static Field CreateAndSetField(CellType[,] cells, int winningCellsCount)
	{
		Field field = new(cells.GetLength(0), winningCellsCount);

		for (int i = 0; i < cells.GetLength(0); i++)
			for (int j = 0; j < cells.GetLength(1); j++)
				field.FillCell(new Cell(i, j), cells[i, j]);

		return field;
	}
	private static bool CompareWinningCells(Cell[] winningCells, Cell[] expectedWinningCells)
	{
		if (winningCells == null || expectedWinningCells == null)
			return winningCells == expectedWinningCells;

		if (winningCells.Length != expectedWinningCells.Length)
			return false;

		for (int i = 0; i < winningCells.Length; i++)
			if (winningCells[i].row != expectedWinningCells[i].row
				|| winningCells[i].column != expectedWinningCells[i].column)
				return false;

		return true;
	}

	#region GameIsNotOver
	[Test]
	public void TestNoEndD3_1()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.Zero }
		};

		Field field = CreateAndSetField(cells, 3);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = false;
		CellType expectedWinner = CellType.None;

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && winningCells == null);
	}
	[Test]
	public void TestNoEndD3_2()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.Zero, CellType.Cross },
			{ CellType.Cross, CellType.Cross, CellType.Zero },
			{ CellType.Zero, CellType.None, CellType.Zero }
		};

		Field field = CreateAndSetField(cells, 3);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = false;
		CellType expectedWinner = CellType.None;

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && winningCells == null);
	}

	[Test]
	public void TestNoEndD5_1()
	{
		// Arrange
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.Cross, CellType.Cross, CellType.Cross, CellType.Zero, CellType.Zero },
			{ CellType.None, CellType.None, CellType.None, CellType.Zero, CellType.Cross},
			{ CellType.None, CellType.None, CellType.None, CellType.Zero, CellType.Zero },
			{ CellType.None, CellType.None, CellType.None, CellType.Cross, CellType.Zero},
			{ CellType.Zero, CellType.Zero, CellType.Zero, CellType.Cross, CellType.Cross}
		};

		Field field = CreateAndSetField(cells, 4);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = false;
		CellType expectedWinner = CellType.None;

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && winningCells == null);
	}
	[Test]
	public void TestNoEndD5_2()
	{
		// Arrange
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.None, CellType.Cross, CellType.None, CellType.Cross, CellType.Cross },
			{ CellType.None, CellType.None, CellType.Zero, CellType.Cross, CellType.Cross },
			{ CellType.None, CellType.None, CellType.Cross, CellType.None, CellType.Zero },
			{ CellType.Zero, CellType.Zero, CellType.Zero, CellType.Cross, CellType.None },
			{ CellType.Zero, CellType.None, CellType.None, CellType.Cross, CellType.Zero }
		};

		Field field = CreateAndSetField(cells, 4);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = false;
		CellType expectedWinner = CellType.None;

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && winningCells == null);
	}
	#endregion

	#region GameEndedInDraw
	[Test]
	public void TestWinnerNoneD3_1()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.Zero, CellType.Cross },
			{ CellType.Zero, CellType.Zero, CellType.Cross },
			{ CellType.Cross, CellType.Cross, CellType.Zero }
		};

		Field field = CreateAndSetField(cells, 3);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.None;

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && winningCells == null);
	}
	[Test]
	public void TestWinnerNoneD3_2()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.Cross, CellType.Zero },
			{ CellType.Zero, CellType.Cross, CellType.Cross },
			{ CellType.Cross, CellType.Zero, CellType.Zero }
		};

		Field field = CreateAndSetField(cells, 3);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.None;

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && winningCells == null);
	}

	[Test]
	public void TestWinnerNoneD5_1()
	{
		// Arrange
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.Cross, CellType.Cross, CellType.Cross, CellType.Zero, CellType.Zero },
			{ CellType.Zero, CellType.Cross, CellType.Zero, CellType.Cross, CellType.Cross },
			{ CellType.Cross, CellType.Zero, CellType.Cross, CellType.Zero, CellType.Zero },
			{ CellType.Cross, CellType.Cross, CellType.Cross, CellType.Zero, CellType.Zero },
			{ CellType.Zero, CellType.Cross, CellType.Zero, CellType.Cross, CellType.Zero }
		};

		Field field = CreateAndSetField(cells, 4);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.None;

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && winningCells == null);
	}
	[Test]
	public void TestWinnerNoneD5_2()
	{
		// Arrange
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.Cross, CellType.Zero, CellType.Zero, CellType.Cross, CellType.Zero },
			{ CellType.Cross, CellType.Cross, CellType.Zero, CellType.Zero, CellType.Cross },
			{ CellType.Cross, CellType.Zero, CellType.Zero, CellType.Cross, CellType.Cross },
			{ CellType.Zero, CellType.Cross, CellType.Cross, CellType.Cross, CellType.Zero },
			{ CellType.Zero, CellType.Zero, CellType.Zero, CellType.Cross, CellType.Cross }
		};

		Field field = CreateAndSetField(cells, 4);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.None;

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && winningCells == null);
	}
	#endregion

	#region GameEndedWithVictoryCross
	[Test]
	public void TestWinnerCrossD3_1()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Zero, CellType.None, CellType.Zero },
			{ CellType.Cross, CellType.Cross, CellType.Cross },
			{ CellType.None, CellType.None, CellType.None }
		};

		Field field = CreateAndSetField(cells, 3);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Cross;
		Cell[] expectedWinningCells = [new Cell(1, 0), new Cell(1, 1), new Cell(1, 2)];
		bool resultWinningCells = CompareWinningCells(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}
	[Test]
	public void TestWinnerCrossD3_2()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.Zero, CellType.Cross },
			{ CellType.Zero, CellType.Cross, CellType.Zero },
			{ CellType.Cross, CellType.Zero, CellType.None }
		};

		Field field = CreateAndSetField(cells, 3);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Cross;
		Cell[] expectedWinningCells = [new Cell(0, 2), new Cell(1, 1), new Cell(2, 0)];
		bool resultWinningCells = CompareWinningCells(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}

	[Test]
	public void TestWinnerCrossD5_1()
	{
		// Arrange
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.Zero, CellType.Zero, CellType.Zero, CellType.Cross, CellType.Cross },
			{ CellType.Cross, CellType.Cross, CellType.Zero, CellType.Cross, CellType.Cross },
			{ CellType.Zero, CellType.Cross, CellType.Zero, CellType.Zero, CellType.Zero },
			{ CellType.Zero, CellType.Cross, CellType.Cross, CellType.Zero, CellType.Cross },
			{ CellType.Zero, CellType.Cross, CellType.Cross, CellType.Zero, CellType.Cross }
		};

		Field field = CreateAndSetField(cells, 4);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Cross;
		Cell[] expectedWinningCells = [new Cell(1, 1), new Cell(2, 1), new Cell(3, 1), new Cell(4, 1)];
		bool resultWinningCells = CompareWinningCells(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}
	[Test]
	public void TestWinnerCrossD5_2()
	{
		// Arrange
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.Cross },
			{ CellType.None, CellType.Cross, CellType.Zero, CellType.Zero, CellType.None },
			{ CellType.None, CellType.Zero, CellType.Cross, CellType.Zero, CellType.None },
			{ CellType.None, CellType.Cross, CellType.Zero, CellType.Cross, CellType.None },
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.Cross}
		};

		Field field = CreateAndSetField(cells, 4);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Cross;
		Cell[] expectedWinningCells = [new Cell(1, 1), new Cell(2, 2), new Cell(3, 3), new Cell(4, 4)];
		bool resultWinningCells = CompareWinningCells(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}
	#endregion

	#region GameEndedWithVictoryZero
	[Test]
	public void TestWinnerZeroD3_1()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Zero, CellType.Cross, CellType.Cross },
			{ CellType.None, CellType.Zero, CellType.None },
			{ CellType.None, CellType.Cross, CellType.Zero }
		};

		Field field = CreateAndSetField(cells, 3);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Zero;
		Cell[] expectedWinningCells = [new Cell(0, 0), new Cell(1, 1), new Cell(2, 2)];
		bool resultWinningCells = CompareWinningCells(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}
	[Test]
	public void TestWinnerZeroD3_2()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Zero, CellType.Cross, CellType.None },
			{ CellType.Zero, CellType.None, CellType.Cross },
			{ CellType.Zero, CellType.Cross, CellType.None }
		};

		Field field = CreateAndSetField(cells, 3);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Zero;
		Cell[] expectedWinningCells = [new Cell(0, 0), new Cell(1, 0), new Cell(2, 0)];
		bool resultWinningCells = CompareWinningCells(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}

	[Test]
	public void TestWinnerZeroD5_1()
	{
		// Arrange
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.None, CellType.None, CellType.Cross, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.Cross, CellType.None, CellType.Zero },
			{ CellType.None, CellType.None, CellType.Cross, CellType.Zero, CellType.None },
			{ CellType.None, CellType.None, CellType.Zero, CellType.Cross, CellType.None },
			{ CellType.None, CellType.Zero, CellType.Cross, CellType.None, CellType.Zero }
		};

		Field field = CreateAndSetField(cells, 4);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Zero;
		Cell[] expectedWinningCells = [new Cell(1, 4), new Cell(2, 3), new Cell(3, 2), new Cell(4, 1)];
		bool resultWinningCells = CompareWinningCells(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}
	[Test]
	public void TestWinnerZeroD5_2()
	{
		// Arrange
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.Cross, CellType.None, CellType.Cross },
			{ CellType.None, CellType.Zero, CellType.None, CellType.Cross, CellType.Cross },
			{ CellType.Zero, CellType.Zero, CellType.Zero, CellType.Zero, CellType.Cross }
		};

		Field field = CreateAndSetField(cells, 4);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Zero;
		Cell[] expectedWinningCells = [new Cell(4, 0), new Cell(4, 1), new Cell(4, 2), new Cell(4, 3)];
		bool resultWinningCells = CompareWinningCells(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}
	#endregion
}