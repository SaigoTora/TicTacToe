using TicTacToeLibrary.Core;

namespace TicTacToeLibrary.AI
{
	public static class PerfectMoveFinder
	{
		public static Cell FindCell(Field field, CellType currentCellType, int maxDepthLevel = 5)
		{
			Node node = new Node(field, currentCellType, maxDepthLevel);
			return node.FindMaxRating();
		}
	}
}