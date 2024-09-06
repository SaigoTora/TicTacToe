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
			AddItemToDictionary(new ImageItem("imageItem4", 150, "Menu background image.", Properties.Resources.background2, Properties.Resources.mystery));
			AddItemToDictionary(new ImageItem("imageItem5", 150, "Menu background image.", Properties.Resources.background3, Properties.Resources.mystery));
			AddItemToDictionary(new ImageItem("imageItem6", 150, "Menu background image.", Properties.Resources.background6, Properties.Resources.mystery));
			AddItemToDictionary(new ImageItem("imageItem7", 150, "Menu background image.", Properties.Resources.background7, Properties.Resources.mystery));
			AddItemToDictionary(new ImageItem("imageItem8", 200, "Menu background image.", Properties.Resources.background4, Properties.Resources.mystery));
			AddItemToDictionary(new ImageItem("imageItem9", 200, "Menu background image.", Properties.Resources.background8, Properties.Resources.mystery));
			AddItemToDictionary(new ImageItem("imageItem10", 200, "Menu background image.", Properties.Resources.background10, Properties.Resources.mystery));
		}
		private static void FillAvatars()
		{
			AddItemToDictionary(new Avatar("Silhouette Man", 0, "An elegant silhouette for a man, minimalist and stylish.", Properties.Resources.manAvatar1, AvatarRarity.Common), true);
			AddItemToDictionary(new Avatar("Silhouette Woman", 0, "A slender silhouette of a woman, reflecting grace and sophistication.", Properties.Resources.womanAvatar1, AvatarRarity.Common), true);
			AddItemToDictionary(new Avatar("Liam", 25, "A classic Liam avatar with clean lines and simple shapes.", Properties.Resources.manAvatar2, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Sofia", 25, "A sleek and modern design for Sofia.", Properties.Resources.womanAvatar2, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Alex", 25, "An energetic avatar for Alex that symbolizes determination.", Properties.Resources.manAvatar3, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Ella", 25, "An adorable avatar for Ella that reflects her personality.", Properties.Resources.womanAvatar3, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Ben", 25, "Ben's avatar has a dynamic and energetic vibe.", Properties.Resources.manAvatar4, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Mia", 25, "A cute and friendly icon for Mia that creates a warm impression.", Properties.Resources.womanAvatar4, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Max", 25, "A modern and confident avatar for Max.", Properties.Resources.manAvatar5, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Lisa", 25, "An elegant and stylish avatar for Lisa.", Properties.Resources.womanAvatar5, AvatarRarity.Common));

			AddItemToDictionary(new Avatar("Bunny", 30, "A charming bunny with soft ears.", Properties.Resources.bunny, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Kitty", 35, "A cute kitten with a playful look.", Properties.Resources.cat, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Buddy", 35, "A loyal friend and protector.", Properties.Resources.dog1, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Foxy", 35, "A dexterous and cunning fox with a bright coloring.", Properties.Resources.fox1, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Gallop", 35, "A graceful horse in motion, symbolizing freedom.", Properties.Resources.horse, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Tiger", 35, "A powerful tiger with characteristic stripes.", Properties.Resources.tiger, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Penguin", 45, "An adorable penguin with a distinctive suit.", Properties.Resources.penguin, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Owl", 45, "A wise owl with large expressive eyes.", Properties.Resources.owl, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Gorilla", 45, "A powerful and impressive gorilla with a sturdy build.", Properties.Resources.gorilla, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Rover", 50, "A friendly dog ​​with a smart expression.", Properties.Resources.dog2, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Bear", 50, "A kind bear with a friendly look.", Properties.Resources.bear, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Amber", 50, "A colorful fox with a warm coloring and a playful personality.", Properties.Resources.fox2, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Piggy", 50, "A cheerful pig with rosy cheeks.", Properties.Resources.pig, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Koala", 50, "An adorable koala enjoying a rest in a tree.", Properties.Resources.koala, AvatarRarity.Common));

			AddItemToDictionary(new Avatar("Skeleton", 60, "A mystical image of a man in a skeleton mask.", Properties.Resources.skeleton, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Devil Mask", 60, "A mysterious character in a devil mask with horns.", Properties.Resources.devil1, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Ghost", 65, "A ghostly silhouette with a mysterious look.", Properties.Resources.ghost, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Mummy", 65, "A bandaged corpse with an ancient look.", Properties.Resources.mummy, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Witch", 65, "A classic witch with an ominous look.", Properties.Resources.witch1, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Alien", 70, "A mysterious alien with big ears.", Properties.Resources.alien, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Frankenstein", 70, "A sinister Frankenstein with stitches and green skin.", Properties.Resources.frankenstein, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Green Witch", 75, "A witch with a green tint, reminiscent of potions and magic.", Properties.Resources.witch2, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Devil", 75, "A fiery red devil with a burning gaze and horns.", Properties.Resources.devil2, AvatarRarity.Rare));

			AddItemToDictionary(new Avatar("Champion Bear", 75, "A bear wearing a gold medal, ready to win.", Properties.Resources.bearChampion, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Bella", 90, "An adorable dog with a friendly look.", Properties.Resources.cuteDog1, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Rusty", 90, "A fun and playful dog ready for adventure.", Properties.Resources.cuteDog2, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Lion with Glasses", 100, "A majestic lion wearing stylish glasses.", Properties.Resources.lion, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Cute Bird", 100, "A bird wearing glasses and a hat, looking fashionable and cozy.", Properties.Resources.bird, AvatarRarity.Rare));

			AddItemToDictionary(new Avatar("Panda Sheriff", 125, "Panda with a cowboy hat, ready for adventure in the Wild West.", Properties.Resources.panda,
				Properties.Resources.mysteryAvatar, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("Bender", 125, "Bender in Futurama style with a cigar and beer, looking ready to party.", Properties.Resources.bender,
				Properties.Resources.mysteryAvatar, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("Winston", 125, "A monkey in a business suit, expressing confidence and seriousness.", Properties.Resources.monkey,
				Properties.Resources.mysteryAvatar, AvatarRarity.Legendary));

			AddItemToDictionary(new Avatar("King Bugs", 150, "The great Bugs Bunny with a glittering crown, ruling the world of comedy with majesty and grace.",
				Properties.Resources.bugsBunny, Properties.Resources.mysteryAvatar, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("Pikachu", 150, "Pikachu with an elegant cap, the embodiment of style and enthusiasm, ready to light the way to adventure.",
				Properties.Resources.pikachu, Properties.Resources.mysteryAvatar, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("Homer", 200, "Homer Simpson in a tuxedo, symbolizing unrivaled chic and majestic severity.", Properties.Resources.homer,
				Properties.Resources.mysteryAvatar, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("Tom Rinnegan", 200, "Tom, gifted with the power of the Rinnegan, with all the signs of greatness and fighting prowess, " +
				"ready to conquer new horizons.", Properties.Resources.tom, Properties.Resources.mysteryAvatar, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("Fury Avatar", 250, "A fearsome Avatar with glowing eyes, radiating indescribable power and majesty, " +
				"capable of changing destinies and leaving a mark on history.", Properties.Resources.rageAvatar, Properties.Resources.mysteryAvatar, AvatarRarity.Legendary));
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