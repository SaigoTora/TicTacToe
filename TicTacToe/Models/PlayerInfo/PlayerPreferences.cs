using System;
using System.Drawing;
using TicTacToe.Properties;

namespace TicTacToe.Models.PlayerInfo
{
	[Serializable]
	internal class PlayerPreferences
	{
		internal Image Avatar;
		internal Image BackgroundMenu;
		internal Color BackgroundGame;

		internal PlayerPreferences()
		{
			Avatar = Resources.manAvatar1;
			BackgroundMenu = Resources.background1;
			BackgroundGame = Color.FromArgb(235, 235, 235);
		}
	}
}