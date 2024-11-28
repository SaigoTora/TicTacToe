using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using TicTacToe.Models.GameInfo.Settings;
using TicTacToeLibrary;

namespace TicTacToe.Models.GameClientServer.Game
{
	[Serializable]
	internal class GameInfo
	{
		[JsonProperty]
		internal Field Field { get; private set; }
		[JsonProperty]
		internal CellType WhoseMove { get; private set; } = CellType.Cross;
		private readonly Stack<Cell> _sequenceCells;

		private GameInfo() { }
		internal GameInfo(FieldSize fieldSize)
		{
			Field = FieldParser.Parse(fieldSize);
			_sequenceCells = new Stack<Cell>(Field.GetAllCells().Length);
		}

		internal void Move(Cell cell, CellType cellType)
		{
			Field.FillCell(cell, cellType);
			_sequenceCells.Push(cell);
			ChangeWhoseMove(cellType);
		}
		private void ChangeWhoseMove(CellType cellType)
		{
			if (cellType == CellType.Cross)
				WhoseMove = CellType.Zero;
			else if (cellType == CellType.Zero)
				WhoseMove = CellType.Cross;
		}

		internal void CancelLastMove()
		{
			Cell cell = _sequenceCells.Pop();
			Field.FillCell(cell, CellType.None);
		}
		internal void ClearField()
			=> Field = new Field(Field.GetFieldSize(), Field.WinningCellsCount);
	}
}