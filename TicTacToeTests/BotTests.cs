using TicTacToeLibrary;

namespace TicTacToeTests;

public class BotTests
{
	[SetUp]
	public void Setup()
	{ }

	#region AttackMove
	#region EasyBot
	[Test]
	public void TestMove_CrossEasyD3_Attack1()
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
		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(0, 2);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	[Test]
	public void TestMove_ZeroEasyD3_Attack2()
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
		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 1);
		Assert.That(TestHelper.CompareCells(result, expect));
	}

	[Test]
	public void TestMove_CrossEasyD5_Attack1()
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
		Field field = TestHelper.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(3, 2);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	[Test]
	public void TestMove_ZeroEasyD5_Attack2()
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
		Field field = TestHelper.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(2, 3);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	#endregion

	#region MediumBot
	[Test]
	public void TestMove_ZeroMediumyD3_Attack1()
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
		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 0);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	[Test]
	public void TestMove_CrossMediumyD3_Attack2()
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
		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 1);
		Assert.That(TestHelper.CompareCells(result, expect));
	}

	[Test]
	public void TestMove_ZeroMediumyD5_Attack1()
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
		Field field = TestHelper.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(3, 2);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	#endregion

	#region HardBot
	[Test]
	public void TestMove_AttackHardD3_1()
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
		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(2, 2);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	[Test]
	public void TestMove_AttackHardD3_2()
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
		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 1);
		Assert.That(TestHelper.CompareCells(result, expect));
	}

	[Test]
	public void TestMove_AttackHardD5_1()
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
		Field field = TestHelper.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(2, 2);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	#endregion
	#endregion

	#region DefenseMove
	[Test]
	public void TestMove_CrossHardD3_Defense1()
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
		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(2, 1);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	[Test]
	public void TestMove_ZeroHardD3_Defense2()
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
		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 0);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	[Test]
	public void TestMove_CrossHardD3_Defense3()
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
		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(2, 2);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	[Test]
	public void TestMove_ZeroHardD3_Defense4()
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
		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(0, 0);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	[Test]
	public void TestMove_CrossHardD3_Defense5()
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
		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(2, 0);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	[Test]
	public void TestMove_ZeroHardD3_Defense6()
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
		Field field = TestHelper.CreateAndSetField(cells, 3);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(0, 2);
		Assert.That(TestHelper.CompareCells(result, expect));
	}

	[Test]
	public void TestMove_CrossHardD5_Defense1()
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
		Field field = TestHelper.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 2);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	[Test]
	public void TestMove_ZeroHardD5_Defense2()
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
		Field field = TestHelper.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 4);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	[Test]
	public void TestMove_CrossHardD5_Defense3()
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
		Field field = TestHelper.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(3, 3);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	[Test]
	public void TestMove_ZeroHardD5_Defense4()
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
		Field field = TestHelper.CreateAndSetField(cells, 4);

		// Act
		Cell result = bot.Move(field, botCellType);

		// Assert
		Cell expect = new(1, 2);
		Assert.That(TestHelper.CompareCells(result, expect));
	}
	#endregion
}