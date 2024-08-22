using System;
using System.Drawing;
using TicTacToe.Models.PlayerItem;

namespace TicTacToe.Models.PlayerInfo
{
	[Serializable]
	internal class PlayerPreferences
	{
		internal Avatar Avatar;
		internal ImageItem BackgroundMenu;
		internal ColorItem BackgroundGame;

		internal PlayerPreferences()
		{
			Avatar = new Avatar("avatarItem1", 0, Properties.Resources.manAvatar1, AvatarRarity.Common);
			BackgroundMenu = new ImageItem("imageItem1", 0, Properties.Resources.background1);
			BackgroundGame = new ColorItem("colorItem1", 0, Color.FromArgb(235, 235, 235));
		}
	}
}