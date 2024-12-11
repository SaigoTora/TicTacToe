using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

using TicTacToe.Models.PlayerItem;

namespace TicTacToe.Models.PlayerInfo
{
	[Serializable]
	internal class PlayerVisualSettings
	{
		internal WindowSize WindowSize = WindowSize.Large;
		internal GameView GameView = GameView.Score;
		[JsonProperty]
		internal Avatar Avatar;
		internal ImageItem BackgroundMenu;
		internal ColorItem BackgroundGame;

		internal PlayerVisualSettings()
		{
			Avatar = ItemManager.GetDefaultAvatar();
			BackgroundMenu = ItemManager.GetDefaultImageItem();
			BackgroundGame = ItemManager.GetDefaultColorItem();
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