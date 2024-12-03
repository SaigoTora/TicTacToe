using System;

namespace TicTacToe.Models.GameClientServer.Chat
{
	[Serializable]
	internal class Message
	{
		internal string Sender { get; private set; }
		internal string Text { get; private set; }
		internal DateTime Time { get; private set; }

		internal Message(string sender, string text)
		{
			Sender = sender;
			Text = text;
			Time = DateTime.UtcNow;
		}
	}
}