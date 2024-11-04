using System;
using TicTacToe.Models.PlayerInfo;

namespace TicTacToe.Models.GameClientServer
{
	internal class LocalPlayerEventArgs : EventArgs
	{
		internal readonly Player Player;
		internal readonly string IPAddress;

		internal LocalPlayerEventArgs(Player player)
			=> Player = player;
		internal LocalPlayerEventArgs(Player player, string ipAddress) : this(player)
			=> IPAddress = ipAddress;

		internal bool HasIPAddress()
			=> !string.IsNullOrEmpty(IPAddress);
	}
}