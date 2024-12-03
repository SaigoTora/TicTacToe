using System;

namespace TicTacToe.Models.GameClientServer.Chat
{
	internal class ChatMessageEventArgs : EventArgs
	{
		internal readonly Message Message;

		internal ChatMessageEventArgs(Message message)
			=> Message = message;
	}
}