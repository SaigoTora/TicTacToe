using TicTacToeLibrary;

namespace TicTacToeTests;

public class BotTests
{
	private static bool CompareCells(Cell firstCell, Cell secondCell)
		=> firstCell.row == secondCell.row && firstCell.column == secondCell.column;

	#region AttackMove
	#region EasyBot
	[Test]
	public void TestAttackEasyD3_1()
	{
		// Arrange
		Difficulty difficult = Difficulty.Easy;
		CellType botCellType = CellType.Cross;
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.Cross, CellType.None },
			{ CellType.None, CellType.Zero, CellType.Zero },
			{ CellType.None, CellType.None, CellType.None }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(0, 2);
		Assert.That(CompareCells(result, expect));
	}
	[Test]
	public void TestAttackEasyD3_2()
	{
		// Arrange
		Difficulty difficult = Difficulty.Easy;
		CellType botCellType = CellType.Zero;
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.Zero, CellType.Cross },
			{ CellType.None, CellType.None, CellType.Cross },
			{ CellType.None, CellType.Zero, CellType.None }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 1);
		Assert.That(CompareCells(result, expect));
	}

	[Test]
	public void TestAttackEasyD5_1()
	{
		// Arrange
		Difficulty difficult = Difficulty.Easy;
		CellType botCellType = CellType.Cross;
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.Zero },
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.None },
			{ CellType.Cross, CellType.Cross, CellType.None, CellType.Cross, CellType.Zero },
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.Zero }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(3, 2);
		Assert.That(CompareCells(result, expect));
	}
	[Test]
	public void TestAttackEasyD5_2()
	{
		// Arrange
		Difficulty difficult = Difficulty.Easy;
		CellType botCellType = CellType.Zero;
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.Cross, CellType.Cross, CellType.Cross, CellType.None, CellType.None },
			{ CellType.Cross, CellType.None, CellType.None, CellType.None, CellType.Zero },
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.Zero, CellType.None, CellType.None },
			{ CellType.None, CellType.Zero, CellType.None, CellType.None, CellType.None }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(2, 3);
		Assert.That(CompareCells(result, expect));
	}
	#endregion

	#region MediumBot
	[Test]
	public void TestAttackMediumyD3_1()
	{
		// Arrange
		Difficulty difficult = Difficulty.Medium;
		CellType botCellType = CellType.Zero;
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.None, CellType.Cross },
			{ CellType.None, CellType.Zero, CellType.Zero },
			{ CellType.Cross, CellType.None, CellType.None }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 0);
		Assert.That(CompareCells(result, expect));
	}
	[Test]
	public void TestAttackMediumyD3_2()
	{
		// Arrange
		Difficulty difficult = Difficulty.Medium;
		CellType botCellType = CellType.Cross;
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.Zero, CellType.None },
			{ CellType.None, CellType.None, CellType.Zero },
			{ CellType.None, CellType.None, CellType.Cross }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 1);
		Assert.That(CompareCells(result, expect));
	}

	[Test]
	public void TestAttackMediumyD5_1()
	{
		// Arrange
		Difficulty difficult = Difficulty.Medium;
		CellType botCellType = CellType.Zero;
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.Cross, CellType.Cross, CellType.None, CellType.None, CellType.None },
			{ CellType.Cross, CellType.None, CellType.Zero, CellType.None, CellType.None },
			{ CellType.Cross, CellType.None, CellType.Zero, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.Zero, CellType.None, CellType.None }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(3, 2);
		Assert.That(CompareCells(result, expect));
	}
	#endregion

	#region HardBot
	[Test]
	public void TestAttackHardD3_1()
	{
		// Arrange
		Difficulty difficult = Difficulty.Hard;
		CellType botCellType = CellType.Cross;
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.None, CellType.None, CellType.Cross },
			{ CellType.Zero, CellType.None, CellType.Cross },
			{ CellType.Zero, CellType.None, CellType.None }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(2, 2);
		Assert.That(CompareCells(result, expect));
	}
	[Test]
	public void TestAttackHardD3_2()
	{
		// Arrange
		Difficulty difficult = Difficulty.Hard;
		CellType botCellType = CellType.Zero;
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.None, CellType.Zero },
			{ CellType.Cross, CellType.None, CellType.None },
			{ CellType.Zero, CellType.Cross, CellType.None }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 1);
		Assert.That(CompareCells(result, expect));
	}

	[Test]
	public void TestAttackHardD5_1()
	{
		// Arrange
		Difficulty difficult = Difficulty.Hard;
		CellType botCellType = CellType.Cross;
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.None, CellType.Zero, CellType.Zero, CellType.None, CellType.Zero },
			{ CellType.None, CellType.Cross, CellType.None, CellType.Zero, CellType.None },
			{ CellType.Cross, CellType.None, CellType.None, CellType.None, CellType.None },
			{ CellType.Zero, CellType.None, CellType.None, CellType.Cross, CellType.None },
			{ CellType.Cross, CellType.None, CellType.None, CellType.None, CellType.Cross }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(2, 2);
		Assert.That(CompareCells(result, expect));
	}
	#endregion
	#endregion

	#region DefenseMove
	[Test]
	public void TestDefenseHardD3_1()
	{
		// Arrange
		Difficulty difficult = Difficulty.Hard;
		CellType botCellType = CellType.Cross;
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.Cross },
			{ CellType.Zero, CellType.None, CellType.Zero }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(2, 1);
		Assert.That(CompareCells(result, expect));
	}
	[Test]
	public void TestDefenseHardD3_2()
	{
		// Arrange
		Difficulty difficult = Difficulty.Hard;
		CellType botCellType = CellType.Zero;
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.None },
			{ CellType.Cross, CellType.None, CellType.Zero }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 0);
		Assert.That(CompareCells(result, expect));
	}
	[Test]
	public void TestDefenseHardD3_3()
	{
		// Arrange
		Difficulty difficult = Difficulty.Hard;
		CellType botCellType = CellType.Cross;
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Zero, CellType.None, CellType.Cross },
			{ CellType.None, CellType.Zero, CellType.None },
			{ CellType.Cross, CellType.None, CellType.None }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(2, 2);
		Assert.That(CompareCells(result, expect));
	}
	[Test]
	public void TestDefenseHardD3_4()
	{
		// Arrange
		Difficulty difficult = Difficulty.Hard;
		CellType botCellType = CellType.Zero;
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.None, CellType.None, CellType.None },
			{ CellType.Cross, CellType.Cross, CellType.Zero },
			{ CellType.None, CellType.Zero, CellType.Cross }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(0, 0);
		Assert.That(CompareCells(result, expect));
	}
	[Test]
	public void TestDefenseHardD3_5()
	{
		// Arrange
		Difficulty difficult = Difficulty.Hard;
		CellType botCellType = CellType.Cross;
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.None, CellType.None, CellType.Zero },
			{ CellType.Cross, CellType.Zero, CellType.Cross },
			{ CellType.None, CellType.None, CellType.None }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(2, 0);
		Assert.That(CompareCells(result, expect));
	}
	[Test]
	public void TestDefenseHardD3_6()
	{
		// Arrange
		Difficulty difficult = Difficulty.Hard;
		CellType botCellType = CellType.Zero;
		CellType[,] cells = new CellType[3, 3]
		{
			{ CellType.Cross, CellType.None, CellType.None },
			{ CellType.Zero, CellType.Cross, CellType.None },
			{ CellType.Cross, CellType.None, CellType.Zero }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(0, 2);
		Assert.That(CompareCells(result, expect));
	}

	[Test]
	public void TestDefenseHardD5_1()
	{
		// Arrange
		Difficulty difficult = Difficulty.Hard;
		CellType botCellType = CellType.Cross;
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.Cross, CellType.None, CellType.None, CellType.None, CellType.None },
			{ CellType.Cross, CellType.Zero, CellType.None, CellType.Zero, CellType.Zero},
			{ CellType.None, CellType.Cross, CellType.None, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.None},
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.None}
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 2);
		Assert.That(CompareCells(result, expect));
	}
	[Test]
	public void TestDefenseHardD5_2()
	{
		// Arrange
		Difficulty difficult = Difficulty.Hard;
		CellType botCellType = CellType.Zero;
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.None, CellType.None, CellType.None, CellType.Zero, CellType.Cross },
			{ CellType.None, CellType.None, CellType.Zero, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.Cross },
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.Cross },
			{ CellType.None, CellType.None, CellType.None, CellType.Cross, CellType.Zero }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 4);
		Assert.That(CompareCells(result, expect));
	}
	[Test]
	public void TestDefenseHardD5_3()
	{
		// Arrange
		Difficulty difficult = Difficulty.Hard;
		CellType botCellType = CellType.Cross;
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.None, CellType.Cross, CellType.Cross, CellType.None, CellType.Zero },
			{ CellType.None, CellType.Zero, CellType.None, CellType.Cross, CellType.None},
			{ CellType.None, CellType.None, CellType.Zero, CellType.None, CellType.None },
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.Cross},
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.Zero}
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(3, 3);
		Assert.That(CompareCells(result, expect));
	}
	[Test]
	public void TestDefenseHardD5_4()
	{
		// Arrange
		Difficulty difficult = Difficulty.Hard;
		CellType botCellType = CellType.Zero;
		CellType[,] cells = new CellType[5, 5]
		{
			{ CellType.None, CellType.None, CellType.None, CellType.Cross, CellType.None },
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.None },
			{ CellType.None, CellType.Cross, CellType.None, CellType.None, CellType.None },
			{ CellType.Cross, CellType.None, CellType.None, CellType.None, CellType.Zero },
			{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.Zero }
		};

		Bot bot = new(difficult);
		Field field = FieldTests.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 2);
		Assert.That(CompareCells(result, expect));
	}
	#endregion
}