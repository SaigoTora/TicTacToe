using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TicTacToe.Models.PlayerItem
{
	internal static class ItemManager
	{
		private static readonly List<ImageItem> _defaultImageItems = new List<ImageItem>();
		private static readonly List<Avatar> _defaultAvatars = new List<Avatar>();
		private static readonly List<ColorItem> _defaultColorItems = new List<ColorItem>();
		private static readonly Dictionary<string, Item> _dictionary = new Dictionary<string, Item>();

		static ItemManager()
		{
			FillImageItems();
			FillAvatars();
			FillColorItems();
		}

		#region FillDictionary
		private static void FillImageItems()
		{
			AddItemToDictionary(new ImageItem("imageItem1", 0, "Menu background image.", Properties.Resources.background1), true);
			AddItemToDictionary(new ImageItem("imageItem2", 100, "Menu background image.", Properties.Resources.background5));
			AddItemToDictionary(new ImageItem("imageItem3", 100, "Menu background image.", Properties.Resources.background9));
			AddItemToDictionary(new ImageItem("imageItem4", 150, "Menu background image.", Properties.Resources.background2, Properties.Resources.mystery1));
			AddItemToDictionary(new ImageItem("imageItem5", 150, "Menu background image.", Properties.Resources.background3, Properties.Resources.mystery1));
			AddItemToDictionary(new ImageItem("imageItem6", 150, "Menu background image.", Properties.Resources.background6, Properties.Resources.mystery1));
			AddItemToDictionary(new ImageItem("imageItem7", 150, "Menu background image.", Properties.Resources.background7, Properties.Resources.mystery1));
			AddItemToDictionary(new ImageItem("imageItem8", 200, "Menu background image.", Properties.Resources.background4, Properties.Resources.mystery1));
			AddItemToDictionary(new ImageItem("imageItem9", 200, "Menu background image.", Properties.Resources.background8, Properties.Resources.mystery1));
			AddItemToDictionary(new ImageItem("imageItem10", 200, "Menu background image.", Properties.Resources.background10, Properties.Resources.mystery1));
		}
		private static void FillAvatars()
		{
			AddItemToDictionary(new Avatar("avatarItem1", 0, "Player avatar image.", Properties.Resources.manAvatar1, AvatarRarity.Common), true);
			AddItemToDictionary(new Avatar("avatarItem2", 0, "Player avatar image.", Properties.Resources.womanAvatar1, AvatarRarity.Common), true);
			AddItemToDictionary(new Avatar("avatarItem3", 25, "Player avatar image.", Properties.Resources.manAvatar2, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("avatarItem4", 25, "Player avatar image.", Properties.Resources.womanAvatar2, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("avatarItem5", 25, "Player avatar image.", Properties.Resources.manAvatar3, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("avatarItem6", 25, "Player avatar image.", Properties.Resources.womanAvatar3, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("avatarItem7", 25, "Player avatar image.", Properties.Resources.manAvatar4, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("avatarItem8", 25, "Player avatar image.", Properties.Resources.womanAvatar4, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("avatarItem9", 25, "Player avatar image.", Properties.Resources.manAvatar5, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("avatarItem10", 25, "Player avatar image.", Properties.Resources.womanAvatar5, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("avatarItem11", 100, "Player avatar image.", Properties.Resources.legendaryAvatar1,
				Properties.Resources.mystery1, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("avatarItem12", 100, "Player avatar image.", Properties.Resources.legendaryAvatar2,
				Properties.Resources.mystery1, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("avatarItem13", 100, "Player avatar image.", Properties.Resources.legendaryAvatar3,
				Properties.Resources.mystery1, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("avatarItem14", 100, "Player avatar image.", Properties.Resources.legendaryAvatar4,
				Properties.Resources.mystery1, AvatarRarity.Legendary));
		}
		private static void FillColorItems()
		{
			AddItemToDictionary(new ColorItem("colorItem1", 0, "Game background color.", Color.FromArgb(235, 235, 235)), true);
			AddItemToDictionary(new ColorItem("colorItem2", 35, "Game background color.", Color.DimGray));
			AddItemToDictionary(new ColorItem("colorItem3", 35, "Game background color.", Color.RosyBrown));
			AddItemToDictionary(new ColorItem("colorItem4", 35, "Game background color.", Color.NavajoWhite));
			AddItemToDictionary(new ColorItem("colorItem5", 35, "Game background color.", Color.Khaki));
			AddItemToDictionary(new ColorItem("colorItem6", 35, "Game background color.", Color.DarkSeaGreen));
			AddItemToDictionary(new ColorItem("colorItem7", 35, "Game background color.", Color.Turquoise));
			AddItemToDictionary(new ColorItem("colorItem8", 35, "Game background color.", Color.SteelBlue));
			AddItemToDictionary(new ColorItem("colorItem9", 35, "Game background color.", Color.MediumPurple));
			AddItemToDictionary(new ColorItem("colorItem10", 35, "Game background color.", Color.PaleVioletRed));
		}
		#endregion

		internal static Item[] GetAllItems()
			=> _dictionary.Values.Select(item => (Item)item.Clone()).ToArray();
		internal static Item FindItem(Item item)
		{
			DateTime dateTimePurchase = item.DateTimePurchase;
			Item resultItem = (Item)_dictionary[GetKey(item)].Clone();
			resultItem.SetDateTimePurchase(dateTimePurchase);

			return resultItem;
		}

		private static void AddItemToDictionary(Item item, bool isDefault = false)
		{
			if (_dictionary.ContainsKey(GetKey(item)))
				throw new ArgumentException($"An item with the key '{GetKey(item)}' already exists in the dictionary.", nameof(item));

			_dictionary.Add(GetKey(item), item);

			if (isDefault)
				switch (item)
				{
					case Avatar avatar:
						{
							_defaultAvatars.Add(avatar);
							break;
						}
					case ImageItem imageItem:
						{
							_defaultImageItems.Add(imageItem);
							break;
						}
					case ColorItem colorItem:
						{
							_defaultColorItems.Add(colorItem);
							break;
						}
					default:
						{
							throw new InvalidOperationException
								($"Unknown item type: {item.GetType().Name}");
						}
				}
		}
		private static string GetKey(Item item)
			=> $"{item.GetType().Name}.{item.Name}";

		#region DefaultItems
		internal static List<Item> GetDefaultItems()
		{
			List<Item> result = new List<Item>();

			result.AddRange(_defaultImageItems);
			result.AddRange(_defaultAvatars);
			result.AddRange(_defaultColorItems);

			return result;
		}
		internal static ImageItem GetDefaultImageItem(int index = 0)
			=> (ImageItem)_defaultImageItems[index].Clone();
		internal static Avatar GetDefaultAvatar(int index = 0)
			=> (Avatar)_defaultAvatars[index].Clone();
		internal static ColorItem GetDefaultColorItem(int index = 0)
			=> (ColorItem)_defaultColorItems[index].Clone();
		#endregion
	}
}