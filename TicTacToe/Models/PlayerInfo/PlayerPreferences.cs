using System;
using System.Runtime.Serialization;
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
			Avatar = ItemManager.GetDefaultAvatar();
			BackgroundMenu = ItemManager.GetDefaultImageItem();
			BackgroundGame = ItemManager.GetDefaultColorItem();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			Avatar = (Avatar)ItemManager.FindItem(Avatar);
			BackgroundMenu = (ImageItem)ItemManager.FindItem(BackgroundMenu);
			BackgroundGame = (ColorItem)ItemManager.FindItem(BackgroundGame);
		}
	}
}