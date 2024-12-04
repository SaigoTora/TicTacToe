using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TicTacToe.Models.GameClientServer.Chat
{
	[Serializable]
	internal class ChatManager
	{
		private const int MAX_MESSAGES = 1000;
		[JsonProperty("Messages")]
		private readonly List<Message> messages = new List<Message>();

		internal ChatManager() { }
		internal void AddMessage(Message message)
		{
			if (messages.Count >= MAX_MESSAGES)
				messages.RemoveAt(0);

			messages.Add(message);
		}
		internal int FindIndexByMessage(Message message)
		{
			for (int i = messages.Count - 1; i >= 0; i--)
				if (messages[i] == message)
					return i;

			return -1;
		}
		internal int GetCount() => messages.Count;
		internal Message GetMessage(int index) => messages[index];
		internal bool CheckMessageLimit()
			=> messages.Count >= MAX_MESSAGES;
	}
}