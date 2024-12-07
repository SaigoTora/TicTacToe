using TicTacToeLibrary.Core;
using TicTacToeLibrary.GameLogic;

namespace TicTacToeLibrary.AI
{
	public static class PerfectMoveFinder
	{
		public static Cell FindCell(Field field, CellType currentCellType, GameMode gameMode, int maxDepthLevel = 5)
		{
			Node node = new Node(field, currentCellType, maxDepthLevel, gameMode);
			return node.FindMaxRating();
		}
	}
}