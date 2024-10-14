using System;
using System.Net;

using TicTacToe.Models.GameInfo.Settings;

namespace TicTacToe.Models.GameClientServer
{
	internal class LobbyPreviewEventArgs : EventArgs
	{
		internal readonly IPAddress IPAddress;
		internal readonly int Port;
		internal readonly NetworkGameSettings NetworkGameSettings;

		public LobbyPreviewEventArgs(IPAddress iPAddress, int port,
			NetworkGameSettings networkGameSettings)
		{
			IPAddress = iPAddress;
			Port = port;
			NetworkGameSettings = networkGameSettings;
		}
	}
}