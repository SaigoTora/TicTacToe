using System;
using System.Net;

namespace TicTacToe.Models.GameClientServer
{
	internal class LobbyPreviewEventArgs : EventArgs
	{
		internal readonly IPAddress IPAddress;
		internal readonly int Port;
		internal readonly NetworkLobbyInfo NetworkLobbyInfo;

		public LobbyPreviewEventArgs(IPAddress ipAddress, int port,
			NetworkLobbyInfo networkLobbyInfo)
		{
			IPAddress = ipAddress;
			Port = port;
			NetworkLobbyInfo = networkLobbyInfo;
		}
	}
}