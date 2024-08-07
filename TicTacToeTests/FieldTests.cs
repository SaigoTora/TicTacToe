using TicTacToeLibrary;

namespace TicTacToeTests;

public class FieldTests
{
	[SetUp]
	public void Setup()
	{ }

	#region GameIsNotOver
	[Test]
	public void TestIsGameEnd_D3_NoEnd1()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.Zero }
		};

		Field field = TestHelper.CreateAndSetField(cells, 3);

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
	public void TestIsGameEnd_D3_NoEnd2()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.Zero, CellType.Cross },
			{ CellType.Cross, CellType.Cross, CellType.Zero },
			{ CellType.Zero, CellType.None, CellType.Zero }
		};

		Field field = TestHelper.CreateAndSetField(cells, 3);

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
	public void TestIsGameEnd_D5_NoEnd1()
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

		Field field = TestHelper.CreateAndSetField(cells, 4);

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
	public void TestIsGameEnd_D5_NoEnd2()
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

		Field field = TestHelper.CreateAndSetField(cells, 4);

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
	public void TestIsGameEnd_D3_WinnerNone1()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.Zero, CellType.Cross },
			{ CellType.Zero, CellType.Zero, CellType.Cross },
			{ CellType.Cross, CellType.Cross, CellType.Zero }
		};

		Field field = TestHelper.CreateAndSetField(cells, 3);

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
	public void TestIsGameEnd_D3_WinnerNone2()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.Cross, CellType.Zero },
			{ CellType.Zero, CellType.Cross, CellType.Cross },
			{ CellType.Cross, CellType.Zero, CellType.Zero }
		};

		Field field = TestHelper.CreateAndSetField(cells, 3);

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
	public void TestIsGameEnd_D5_WinnerNone1()
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

		Field field = TestHelper.CreateAndSetField(cells, 4);

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
	public void TestIsGameEnd_D5_WinnerNone2()
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

		Field field = TestHelper.CreateAndSetField(cells, 4);

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
	public void TestIsGameEnd_D3_WinnerCross1()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Zero, CellType.None, CellType.Zero },
			{ CellType.Cross, CellType.Cross, CellType.Cross },
			{ CellType.None, CellType.None, CellType.None }
		};

		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Cross;
		Cell[] expectedWinningCells = [new Cell(1, 0), new Cell(1, 1), new Cell(1, 2)];
		bool resultWinningCells = TestHelper.CompareCellArrays(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}
	[Test]
	public void TestIsGameEnd_D3_WinnerCross2()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.Zero, CellType.Cross },
			{ CellType.Zero, CellType.Cross, CellType.Zero },
			{ CellType.Cross, CellType.Zero, CellType.None }
		};

		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Cross;
		Cell[] expectedWinningCells = [new Cell(0, 2), new Cell(1, 1), new Cell(2, 0)];
		bool resultWinningCells = TestHelper.CompareCellArrays(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}

	[Test]
	public void TestIsGameEnd_D5_WinnerCross1()
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

		Field field = TestHelper.CreateAndSetField(cells, 4);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Cross;
		Cell[] expectedWinningCells = [new Cell(1, 1), new Cell(2, 1), new Cell(3, 1), new Cell(4, 1)];
		bool resultWinningCells = TestHelper.CompareCellArrays(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}
	[Test]
	public void TestIsGameEnd_D5_WinnerCross2()
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

		Field field = TestHelper.CreateAndSetField(cells, 4);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Cross;
		Cell[] expectedWinningCells = [new Cell(1, 1), new Cell(2, 2), new Cell(3, 3), new Cell(4, 4)];
		bool resultWinningCells = TestHelper.CompareCellArrays(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}
	#endregion

	#region GameEndedWithVictoryZero
	[Test]
	public void TestIsGameEnd_D3_WinnerZero1()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Zero, CellType.Cross, CellType.Cross },
			{ CellType.None, CellType.Zero, CellType.None },
			{ CellType.None, CellType.Cross, CellType.Zero }
		};

		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Zero;
		Cell[] expectedWinningCells = [new Cell(0, 0), new Cell(1, 1), new Cell(2, 2)];
		bool resultWinningCells = TestHelper.CompareCellArrays(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}
	[Test]
	public void TestIsGameEnd_D3_WinnerZero2()
	{
		// Arrange
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Zero, CellType.Cross, CellType.None },
			{ CellType.Zero, CellType.None, CellType.Cross },
			{ CellType.Zero, CellType.Cross, CellType.None }
		};

		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Zero;
		Cell[] expectedWinningCells = [new Cell(0, 0), new Cell(1, 0), new Cell(2, 0)];
		bool resultWinningCells = TestHelper.CompareCellArrays(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}

	[Test]
	public void TestIsGameEnd_D5_WinnerZero1()
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

		Field field = TestHelper.CreateAndSetField(cells, 4);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Zero;
		Cell[] expectedWinningCells = [new Cell(1, 4), new Cell(2, 3), new Cell(3, 2), new Cell(4, 1)];
		bool resultWinningCells = TestHelper.CompareCellArrays(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}
	[Test]
	public void TestIsGameEnd_D5_WinnerZero2()
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

		Field field = TestHelper.CreateAndSetField(cells, 4);

		// Act
		bool isGameEnd = field.IsGameEnd();
		CellType winner = field.Winner;
		Cell[] winningCells = field.WinningCells;

		// Assert
		bool expectedGameEnd = true;
		CellType expectedWinner = CellType.Zero;
		Cell[] expectedWinningCells = [new Cell(4, 0), new Cell(4, 1), new Cell(4, 2), new Cell(4, 3)];
		bool resultWinningCells = TestHelper.CompareCellArrays(winningCells, expectedWinningCells);

		Assert.That(isGameEnd == expectedGameEnd && winner == expectedWinner && resultWinningCells);
	}
	#endregion
}