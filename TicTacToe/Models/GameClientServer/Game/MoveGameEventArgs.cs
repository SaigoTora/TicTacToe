using System;

namespace TicTacToe.Models.GameClientServer.Game
{
	internal class MoveGameEventArgs : EventArgs
	{
		internal readonly MoveInfo MoveInfo;

		internal MoveGameEventArgs(MoveInfo moveInfo)
		{
			MoveInfo = moveInfo;
		}
	}
}