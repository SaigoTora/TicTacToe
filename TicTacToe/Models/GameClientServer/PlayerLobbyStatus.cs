﻿using Newtonsoft.Json;
using System;

namespace TicTacToe.Models.GameClientServer
{
	[Serializable]
	internal class PlayerLobbyStatus
	{
		[JsonProperty]
		internal bool IsReady { get; private set; }

		internal void ChangeReady(bool ready)
			=> IsReady = ready;
	}
}