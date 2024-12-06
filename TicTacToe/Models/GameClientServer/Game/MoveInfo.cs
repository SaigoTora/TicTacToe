using Newtonsoft.Json;
using System;

using TicTacToeLibrary.Core;

namespace TicTacToe.Models.GameClientServer.Game
{
	[Serializable]
	internal class MoveInfo
	{
		[JsonProperty]
		internal Cell Cell { get; private set; }
		[JsonProperty]
		internal CellType CellType { get; private set; }
		[JsonProperty]
		internal bool IsMoveCancelled { get; private set; }

		private MoveInfo() { }
		internal MoveInfo(bool isMoveCancelled)
			=> IsMoveCancelled = isMoveCancelled;
		internal MoveInfo(Cell cell, CellType cellType)
		{
			Cell = cell;
			CellType = cellType;
		}
	}
}