using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TicTacToe.Models.GameClientServer.Chat
{
	[Serializable]
	internal class Message
	{
		[JsonProperty]
		internal string Sender { get; private set; }
		[JsonProperty]
		internal string Text { get; private set; }
		[JsonProperty]
		internal DateTime Time { get; private set; }

		private Message() { }
		internal Message(string sender, string text)
		{
			Sender = sender;
			Text = text;
			Time = DateTime.UtcNow;
		}

		public static bool operator ==(Message left, Message right)
		{
			if (ReferenceEquals(left, right))
				return true;
			if (left is null || right is null)
				return false;

			return left.Sender == right.Sender
				&& left.Text == right.Text
				&& left.Time == right.Time;
		}
		public static bool operator !=(Message left, Message right)
			=> !(left == right);
		public override bool Equals(object obj)
		{
			if (obj is Message other)
				return this == other;

			return false;
		}
		public override int GetHashCode()
		{
			int hashCode = -2073091882;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Sender);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Text);
			hashCode = hashCode * -1521134295 + Time.GetHashCode();
			return hashCode;
		}
	}
}