using System;

using TicTacToeLibrary;

namespace TicTacToe.Models.GameInfo.Settings
{
	internal static class FieldParser
	{
		internal static Field Parse(FieldSize size)
		{
			switch (size)
			{
				case FieldSize.Size3on3: return new Field(3, 3);
				case FieldSize.Size5on5: return new Field(5, 4);
				case FieldSize.Size7on7: return new Field(7, 4);
				default: throw new InvalidOperationException($"Unknown field size: {size}");
			}
		}
	}
}