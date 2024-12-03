using System.Collections.Generic;

namespace TicTacToe.Models.GameClientServer.Chat
{
	internal class ChatManager
	{
		private const int MAX_MESSAGES = 3;

		private readonly List<Message> messages = new List<Message>();

		internal ChatManager()
		{

		}
		internal void AddMessage(Message message)
		{
			if (messages.Count >= MAX_MESSAGES)
				messages.RemoveAt(0);

			messages.Add(message);
		}
	}
}