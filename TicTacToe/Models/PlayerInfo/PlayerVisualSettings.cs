using System;
using System.Drawing;
using TicTacToe.Properties;

namespace TicTacToe.Models.PlayerInfo
{
	[Serializable]
	internal class PlayerVisualSettings
	{
		internal Image Avatar;
		internal Image BackgroundMenu;
		internal Color BackgroundGame;

		internal PlayerVisualSettings()
		{
			Avatar = Resources.manAvatar1;
			BackgroundMenu = Resources.background1;
			BackgroundGame = Color.White;
		}
	}
}