using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using TicTacToe.Models.GameInfo.Settings;
using TicTacToeLibrary.Core;
using TicTacToeLibrary.GameLogic;

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
		private readonly GameMode _gameMode;

		private GameInfo() { }
		internal GameInfo(FieldSize fieldSize, GameMode gameMode)
		{
			Field = FieldParser.Parse(fieldSize);
			_sequenceCells = new Stack<Cell>(Field.GetAllCells().Length);
			_gameMode = gameMode;
		}

		internal void Move(Cell cell, CellType cellType)
		{
			Field.FillCell(cell, cellType);
			_sequenceCells.Push(cell);
			if (_gameMode == GameMode.Swap && Field.CountFilledCells() % 2 == 0)
				return;
			else
				ChangeWhoseMove(cellType);
		}
		internal void ChangeWhoseMove(CellType cellType)
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
		{
			WhoseMove = CellType.None;
			Field = new Field(Field.GetFieldSize(), Field.WinningCellsCount);
		}
	}
}