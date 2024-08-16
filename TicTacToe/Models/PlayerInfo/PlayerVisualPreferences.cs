using System;
using System.Drawing;
using TicTacToe.Properties;

namespace TicTacToe.Models.PlayerInfo
{
	[Serializable]
	internal class PlayerVisualPreferences
	{
		internal Image Avatar;
		internal Image BackgroundMenu;
		internal Color BackgroundGame;

		internal PlayerVisualPreferences()
		{
			Avatar = Resources.manAvatar1;
			BackgroundMenu = Resources.background1;
			BackgroundGame = Color.White;
		}
	}
}