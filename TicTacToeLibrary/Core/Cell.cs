namespace TicTacToeLibrary.Core
{
	public struct Cell
	{
		public int row;
		public int column;

		public Cell(int row, int column)
		{
			this.row = row;
			this.column = column;
		}

		public override bool Equals(object obj)
		{
			return obj is Cell cell &&
				   row == cell.row &&
				   column == cell.column;
		}

		public override int GetHashCode()
			=> base.GetHashCode();
	}
}