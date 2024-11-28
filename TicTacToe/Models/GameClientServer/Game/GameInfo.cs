using Newtonsoft.Json;
using System;

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

		private GameInfo() { }
		internal GameInfo(FieldSize fieldSize)
			=> Field = FieldParser.Parse(fieldSize);

		internal void Move(Cell cell, CellType cellType)
		{
			Field.FillCell(cell, cellType);
			ChangeWhoseMove(cellType);
		}
		private void ChangeWhoseMove(CellType cellType)
		{
			if (cellType == CellType.Cross)
				WhoseMove = CellType.Zero;
			else if (cellType == CellType.Zero)
				WhoseMove = CellType.Cross;
		}
	}
}