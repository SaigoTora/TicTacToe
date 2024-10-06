using System;
using System.Runtime.Serialization;

using TicTacToe.Models.PlayerItem;

namespace TicTacToe.Models.PlayerInfo
{
	[Serializable]
	internal class PlayerPreferences
	{
		internal GameView GameView = GameView.Score;
		internal Avatar Avatar;
		internal ImageItem BackgroundMenu;
		internal ColorItem BackgroundGame;
		internal GamePreferences GamePreferences;

		internal PlayerPreferences()
		{
			Avatar = ItemManager.GetDefaultAvatar();
			BackgroundMenu = ItemManager.GetDefaultImageItem();
			BackgroundGame = ItemManager.GetDefaultColorItem();
			GamePreferences = new GamePreferences();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			Avatar = (Avatar)ItemManager.GetFullItem(Avatar);
			BackgroundMenu = (ImageItem)ItemManager.GetFullItem(BackgroundMenu);
			BackgroundGame = (ColorItem)ItemManager.GetFullItem(BackgroundGame);
		}
	}
}