using TicTacToeLibrary;

namespace TicTacToeTests
{
	public class PerfectMoveFinderTests
	{
		[SetUp]
		public void Setup()
		{ }

		#region The move of the zero
		[Test]
		public void TestFindCell_ZeroD3_1()
		{
			// Arrange
			CellType[,] cells = new CellType[3, 3]
			{
				{ CellType.Cross, CellType.None, CellType.Zero },
				{ CellType.None, CellType.Cross, CellType.None },
				{ CellType.None, CellType.None, CellType.None }
			};

			// Act
			Field field = TestHelper.CreateAndSetField(cells, 3);
			Cell result = PerfectMoveFinder.FindCell(field, CellType.Zero);

			// Assert
			Cell expectedCell = new(2, 2);
			Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
				$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
		}
		[Test]
		public void TestFindCell_ZeroD3_2()
		{
			// Arrange
			CellType[,] cells = new CellType[3, 3]
			{
				{ CellType.None, CellType.Cross, CellType.Cross },
				{ CellType.Cross, CellType.Zero, CellType.Zero },
				{ CellType.None, CellType.None, CellType.None }
			};

			// Act
			Field field = TestHelper.CreateAndSetField(cells, 3);
			Cell result = PerfectMoveFinder.FindCell(field, CellType.Zero);

			// Assert
			Cell expectedCell = new(0, 0);
			Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
				$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
		}
		[Test]
		public void TestFindCell_ZeroD3_3()
		{
			// Arrange
			CellType[,] cells = new CellType[3, 3]
			{
				{ CellType.Cross, CellType.Cross, CellType.Zero },
				{ CellType.Cross, CellType.None, CellType.None },
				{ CellType.None, CellType.None, CellType.Zero }
			};

			// Act
			Field field = TestHelper.CreateAndSetField(cells, 3);
			Cell result = PerfectMoveFinder.FindCell(field, CellType.Zero);

			// Assert
			Cell expectedCell = new(1, 2);
			Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
				$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
		}
		[Test]
		public void TestFindCell_ZeroD3_4()
		{
			// Arrange
			CellType[,] cells = new CellType[3, 3]
			{
				{ CellType.None, CellType.Zero, CellType.Cross },
				{ CellType.None, CellType.Cross, CellType.Cross },
				{ CellType.Zero, CellType.Cross, CellType.Zero }
			};

			// Act
			Field field = TestHelper.CreateAndSetField(cells, 3);
			Cell result = PerfectMoveFinder.FindCell(field, CellType.Zero);

			// Assert
			Cell expectedCell = new(1, 0);
			Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
				$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
		}

		[Test]
		public void TestFindCell_MaxDepth3ZeroD5_1()
		{
			// Arrange
			CellType[,] cells = new CellType[5, 5]
			{
				{ CellType.Cross, CellType.None, CellType.None, CellType.Zero, CellType.Zero },
				{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.None },
				{ CellType.None, CellType.None, CellType.Cross, CellType.None, CellType.None },
				{ CellType.None, CellType.None, CellType.None, CellType.Cross, CellType.None },
				{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.None }
			};

			// Act
			Field field = TestHelper.CreateAndSetField(cells, 4);
			Cell result = PerfectMoveFinder.FindCell(field, CellType.Zero, 3);

			// Assert
			Cell expectedCell = new(1, 1);
			Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
				$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
		}
		[Test]
		public void TestFindCell_MaxDepth3ZeroD5_2()
		{
			// Arrange
			CellType[,] cells = new CellType[5, 5]
			{
				{ CellType.Zero, CellType.None, CellType.None, CellType.None, CellType.None },
				{ CellType.Cross, CellType.Cross, CellType.Cross, CellType.None, CellType.Cross },
				{ CellType.None, CellType.None, CellType.Cross, CellType.None, CellType.Zero },
				{ CellType.None, CellType.None, CellType.Cross, CellType.None, CellType.Zero },
				{ CellType.Zero, CellType.Zero, CellType.Zero, CellType.None, CellType.Cross }
			};

			// Act
			Field field = TestHelper.CreateAndSetField(cells, 4);
			Cell result = PerfectMoveFinder.FindCell(field, CellType.Zero, 3);

			// Assert
			Cell expectedCell = new(4, 3);
			Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
				$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
		}
		#endregion

		#region The move of the cross
		[Test]
		public void TestFindCell_CrossD3_1()
		{
			// Arrange
			CellType[,] cells = new CellType[3, 3]
			{
				{ CellType.None, CellType.Cross, CellType.None },
				{ CellType.Zero, CellType.Cross, CellType.Zero },
				{ CellType.None, CellType.None, CellType.None }
			};

			// Act
			Field field = TestHelper.CreateAndSetField(cells, 3);
			Cell result = PerfectMoveFinder.FindCell(field, CellType.Cross);

			// Assert
			Cell expectedCell = new(2, 1);
			Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
				$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
		}
		[Test]
		public void TestFindCell_CrossD3_2()
		{
			// Arrange
			CellType[,] cells = new CellType[3, 3]
			{
				{ CellType.Cross, CellType.Zero, CellType.Cross },
				{ CellType.None, CellType.Zero, CellType.Zero },
				{ CellType.None, CellType.Cross, CellType.None }
			};

			// Act
			Field field = TestHelper.CreateAndSetField(cells, 3);
			Cell result = PerfectMoveFinder.FindCell(field, CellType.Cross);

			// Assert
			Cell expectedCell = new(1, 0);
			Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
				$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
		}
		[Test]
		public void TestFindCell_CrossD3_3()
		{
			// Arrange
			CellType[,] cells = new CellType[3, 3]
			{
				{ CellType.Zero, CellType.Cross, CellType.Zero },
				{ CellType.Zero, CellType.Cross, CellType.Cross },
				{ CellType.Cross, CellType.Zero, CellType.None }
			};

			// Act
			Field field = TestHelper.CreateAndSetField(cells, 3);
			Cell result = PerfectMoveFinder.FindCell(field, CellType.Cross);

			// Assert
			Cell expectedCell = new(2, 2);
			Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
				$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
		}
		[Test]
		public void TestFindCell_CrossD3_4()
		{
			// Arrange
			CellType[,] cells = new CellType[3, 3]
			{
				{ CellType.Zero, CellType.Cross, CellType.Zero },
				{ CellType.Zero, CellType.None, CellType.Cross },
				{ CellType.Cross, CellType.None, CellType.None }
			};

			// Act
			Field field = TestHelper.CreateAndSetField(cells, 3);
			Cell result = PerfectMoveFinder.FindCell(field, CellType.Cross);

			// Assert
			Cell expectedCell = new(2, 1);
			Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
				$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
		}

		[Test]
		public void TestFindCell_MaxDepth3CrossD5_1()
		{
			// Arrange
			CellType[,] cells = new CellType[5, 5]
			{
				{ CellType.Cross, CellType.None, CellType.None, CellType.None, CellType.Zero },
				{ CellType.Cross, CellType.None, CellType.None, CellType.Zero, CellType.None },
				{ CellType.None, CellType.None, CellType.Zero, CellType.None, CellType.None },
				{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.Cross },
				{ CellType.Zero, CellType.None, CellType.None, CellType.None, CellType.Cross }
			};

			// Act
			Field field = TestHelper.CreateAndSetField(cells, 4);
			Cell result = PerfectMoveFinder.FindCell(field, CellType.Cross, 3);

			// Assert
			Cell expectedCell = new(3, 1);
			Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
				$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
		}
		[Test]
		public void TestFindCell_MaxDepth3CrossD5_2()
		{
			// Arrange
			CellType[,] cells = new CellType[5, 5]
			{
				{ CellType.Cross, CellType.None, CellType.None, CellType.None, CellType.Cross },
				{ CellType.None, CellType.Cross, CellType.None, CellType.Zero, CellType.None },
				{ CellType.None, CellType.None, CellType.Cross, CellType.None, CellType.None },
				{ CellType.None, CellType.None, CellType.None, CellType.None, CellType.None },
				{ CellType.Zero, CellType.Zero, CellType.None, CellType.Zero, CellType.None }
			};

			// Act
			Field field = TestHelper.CreateAndSetField(cells, 4);
			Cell result = PerfectMoveFinder.FindCell(field, CellType.Cross, 3);

			// Assert
			Cell expectedCell = new(3, 3);
			Assert.That(result, Is.EqualTo(expectedCell), $"The resulting cell({result.row};{result.column}) " +
				$"isn't equal to the expected one({expectedCell.row};{expectedCell.column}).");
		}
		#endregion
	}
}