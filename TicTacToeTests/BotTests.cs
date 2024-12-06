using TicTacToeLibrary.AI;
using TicTacToeLibrary.Core;

namespace TicTacToeTests;

public class BotTests
{
	[SetUp]
	public void Setup()
	{ }

	#region Attack move
	#region Easy bot
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
		Cell expectedCell = new(0, 2);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(1, 1);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(3, 2);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(2, 3);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
	}
	#endregion

	#region Medium bot
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
		Cell expectedCell = new(1, 0);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(1, 1);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(3, 2);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
	}
	#endregion

	#region Hard bot
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
		Cell expectedCell = new(2, 2);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(1, 1);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(2, 2);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
	}
	#endregion
	#endregion

	#region Defense move
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
		Cell expectedCell = new(2, 1);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(1, 0);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(2, 2);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(0, 0);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(2, 0);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(0, 2);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(1, 2);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(1, 4);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(3, 3);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
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
		Cell expectedCell = new(1, 2);
		Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
			$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
	}
	#endregion
}