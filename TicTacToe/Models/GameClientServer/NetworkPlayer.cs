using Newtonsoft.Json;
using System;

using TicTacToe.Models.PlayerInfo;

namespace TicTacToe.Models.GameClientServer
{
	[Serializable]
	internal class NetworkPlayer : Player
	{
		[JsonProperty]
		internal long Id { get; private set; }
		private static long _id = 1;
		[JsonProperty]
		internal bool IsReady { get; private set; }

		private NetworkPlayer() { }
		internal NetworkPlayer(string name, PlayerVisualSettings visualSettings, bool isReady)
			: base(name)
		{
			VisualSettings = visualSettings;
			IsReady = isReady;
		}
		internal NetworkPlayer(string name, PlayerVisualSettings visualSettings)
			: this(name, visualSettings, false)
		{ VisualSettings = visualSettings; }

		internal void AssignId()
			=> Id = _id++;
		internal void SetReady(bool ready)
			=> IsReady = ready;
	}
}