using System;

namespace TicTacToe.Models.GameClientServer.Lobby
{
	internal class NetworkPlayerEventArgs : EventArgs
	{
		internal readonly NetworkPlayer Player;
		internal readonly string IPAddress;

		internal NetworkPlayerEventArgs(NetworkPlayer player)
			=> Player = player;
		internal NetworkPlayerEventArgs(NetworkPlayer player, string ipAddress) : this(player)
			=> IPAddress = ipAddress;

		internal bool HasIPAddress()
			=> !string.IsNullOrEmpty(IPAddress);
	}
}