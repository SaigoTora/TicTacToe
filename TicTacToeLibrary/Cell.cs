namespace TicTacToeLibrary
{
	public struct Cell
	{
		public int row;
		public int column;

		public Cell(int row, int column)
		{// Конструктор
			this.row = row;
			this.column = column;
		}
	}
}