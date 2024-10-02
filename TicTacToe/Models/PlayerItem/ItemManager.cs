using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using res = TicTacToe.Properties.Resources;


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
			FillCountableItems();
		}

		#region Filling in the dictionary
		private static void FillImageItems()
		{
			AddItemToDictionary(new ImageItem("Classic Gray", 0, "A standard gray background, perfect for minimalist and neutral designs.",
				res.background1), true);
			AddItemToDictionary(new ImageItem("Dark Waves", 50, "Black wavy lines create a minimalist and stylish background.",
				res.background17));
			AddItemToDictionary(new ImageItem("Leafy Blues", 50, "Blue patterns reminiscent of leaves create a natural and fresh feel.",
				res.background11));
			AddItemToDictionary(new ImageItem("Blue Wave", 50, "Patterns and waves that transition from white to blue create a sense of movement and calm.",
				res.background8));
			AddItemToDictionary(new ImageItem("Sea Breeze", 75, "Yellow background with images of sea creatures (mollusks, crabs) in a chaotic order, reflecting the summer sea theme.",
				res.background5));
			AddItemToDictionary(new ImageItem("Abstract Green", 75, "An abstract green background with lines, perfect for dynamic and creative designs.",
				res.background6));
			AddItemToDictionary(new ImageItem("Golden Clouds", 75, "Yellow clouds with an orange background and dots, reminiscent of warmth and a day full of light.",
				res.background3));
			AddItemToDictionary(new ImageItem("Frosty Blizzard", 75, "A blue blizzard background that gives a feeling of cold and winter calm.",
				res.background7));
			AddItemToDictionary(new ImageItem("Neon Grid", 100, "Yellow lines on a black background with dots create a dynamic and modern look.",
				res.background16));
			AddItemToDictionary(new ImageItem("Crimson Blood", 100, "A vibrant red background reminiscent of blood, creating a dramatic and energetic mood.",
				res.background2));
			AddItemToDictionary(new ImageItem("3D Violet Grid", 100, "Violet rectangles create a 3D space for an immersive effect.",
				res.background9));
			AddItemToDictionary(new ImageItem("Yellow Doodles", 100, "Yellow background with small details like dots, crosses and circles, adding a playful and dynamic feel.",
				res.background12));
			AddItemToDictionary(new ImageItem("Green Waves", 100, "Green lines form waves on a dark green background, creating a cybernetic feel.",
				res.background19));
			AddItemToDictionary(new ImageItem("Pastel Spheres", 100, "Light pink 3D spheres that create a soft and dimensional effect.",
				res.background14));
			AddItemToDictionary(new ImageItem("Neon Cubes", 100, "Blue and pink cubes on a purple background, adding volume and a 3D effect.",
				res.background18));
			AddItemToDictionary(new ImageItem("Hexagon Hive", 100, "Black hexagons placed in the center create a dynamic and futuristic background.",
				res.background10));

			AddItemToDictionary(new ImageItem("Twilight Lake", 150, "Purple landscape with a lake at sunset, birds and mountains, creating a dreamy atmosphere.",
				res.background4, res.mystery));
			AddItemToDictionary(new ImageItem("Candy Dots", 150, "Light blue and pink circles and dots add a candy-colored background.",
				res.background15, res.mystery));
			AddItemToDictionary(new ImageItem("Split Arrows", 150, "Blue and pink signs on the edges (> <) on a dark blue background, symbolizing movement and direction.",
				res.background21, res.mystery));
			AddItemToDictionary(new ImageItem("Chilly Mountains", 150, "Mountain landscape with lake and trees, where you can feel the cold and freshness.",
				res.background26, res.mystery));
			AddItemToDictionary(new ImageItem("Desert Sunrise", 200, "Desert landscape with sun and cacti, reminiscent of a hot and sunny day.",
				res.background23, res.mystery));
			AddItemToDictionary(new ImageItem("Midnight Island", 200, "Island landscape with trees and moon against the midnight sky, creating a calm atmosphere.",
				res.background24, res.mystery));
			AddItemToDictionary(new ImageItem("Geometric Teal", 200, "A teal background of squares and rectangles that reflects strong geometric shapes.",
				res.background13, res.mystery));
			AddItemToDictionary(new ImageItem("Starry Tree", 200, "Island landscape with a lonely tree and stars, immersing in the silence of the night.",
				res.background25, res.mystery));
			AddItemToDictionary(new ImageItem("Golden Leaves", 250, "Golden and green leaf patterns on a dark green background, adding natural elegance.",
				res.background20, res.mystery));
			AddItemToDictionary(new ImageItem("Neon Smoke", 250, "Gray smoke enveloping a neon circle creates a mysterious and futuristic effect.",
				res.background22, res.mystery));
			AddItemToDictionary(new ImageItem("Cartoon Studio", 250, "A cartoon workspace with a mirror, chair and accessories creates a cozy and creative backdrop.",
				res.background27, res.mystery));
		}
		private static void FillAvatars()
		{
			AddItemToDictionary(new Avatar("Silhouette Man", 0, "An elegant silhouette for a man, minimalist and stylish.", res.manAvatar1, AvatarRarity.Common), true);
			AddItemToDictionary(new Avatar("Silhouette Woman", 0, "A slender silhouette of a woman, reflecting grace and sophistication.", res.womanAvatar1, AvatarRarity.Common), true);
			AddItemToDictionary(new Avatar("Liam", 25, "A classic Liam avatar with clean lines and simple shapes.", res.manAvatar2, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Sofia", 25, "A sleek and modern design for Sofia.", res.womanAvatar2, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Alex", 25, "An energetic avatar for Alex that symbolizes determination.", res.manAvatar3, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Ella", 25, "An adorable avatar for Ella that reflects her personality.", res.womanAvatar3, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Ben", 25, "Ben's avatar has a dynamic and energetic vibe.", res.manAvatar4, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Mia", 25, "A cute and friendly icon for Mia that creates a warm impression.", res.womanAvatar4, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Max", 25, "A modern and confident avatar for Max.", res.manAvatar5, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Lisa", 25, "An elegant and stylish avatar for Lisa.", res.womanAvatar5, AvatarRarity.Common));

			AddItemToDictionary(new Avatar("Bunny", 30, "A charming bunny with soft ears.", res.bunny, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Kitty", 35, "A cute kitten with a playful look.", res.cat, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Buddy", 35, "A loyal friend and protector.", res.dog1, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Foxy", 35, "A dexterous and cunning fox with a bright coloring.", res.fox1, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Gallop", 35, "A graceful horse in motion, symbolizing freedom.", res.horse, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Tiger", 35, "A powerful tiger with characteristic stripes.", res.tiger, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Penguin", 45, "An adorable penguin with a distinctive suit.", res.penguin, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Owl", 45, "A wise owl with large expressive eyes.", res.owl, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Gorilla", 45, "A powerful and impressive gorilla with a sturdy build.", res.gorilla, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Rover", 50, "A friendly dog ​​with a smart expression.", res.dog2, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Bear", 50, "A kind bear with a friendly look.", res.bear, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Amber", 50, "A colorful fox with a warm coloring and a playful personality.", res.fox2, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Piggy", 50, "A cheerful pig with rosy cheeks.", res.pig, AvatarRarity.Common));
			AddItemToDictionary(new Avatar("Koala", 50, "An adorable koala enjoying a rest in a tree.", res.koala, AvatarRarity.Common));

			AddItemToDictionary(new Avatar("Skeleton", 60, "A mystical image of a man in a skeleton mask.", res.skeleton, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Devil Mask", 60, "A mysterious character in a devil mask with horns.", res.devil1, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Ghost", 65, "A ghostly silhouette with a mysterious look.", res.ghost, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Mummy", 65, "A bandaged corpse with an ancient look.", res.mummy, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Witch", 65, "A classic witch with an ominous look.", res.witch1, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Alien", 70, "A mysterious alien with big ears.", res.alien, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Frankenstein", 70, "A sinister Frankenstein with stitches and green skin.", res.frankenstein, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Green Witch", 75, "A witch with a green tint, reminiscent of potions and magic.", res.witch2, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Devil", 75, "A fiery red devil with a burning gaze and horns.", res.devil2, AvatarRarity.Rare));

			AddItemToDictionary(new Avatar("Champion Bear", 75, "A bear wearing a gold medal, ready to win.", res.bearChampion, AvatarRarity.Rare));
			AddItemToDictionary(new Avatar("Bella", 90, "An adorable dog with a friendly look.", res.cuteDog1, res.mysteryAvatar, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("Rusty", 90, "A fun and playful dog ready for adventure.", res.cuteDog2, res.mysteryAvatar, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("Lion with Glasses", 100, "A majestic lion wearing stylish glasses.", res.lion, res.mysteryAvatar, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("Cute Bird", 100, "A bird wearing glasses and a hat, looking fashionable and cozy.", res.bird, res.mysteryAvatar, AvatarRarity.Legendary));

			AddItemToDictionary(new Avatar("Panda Sheriff", 125, "Panda with a cowboy hat, ready for adventure in the Wild West.", res.panda,
				res.mysteryAvatar, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("Bender", 125, "Bender in Futurama style with a cigar and beer, looking ready to party.", res.bender,
				res.mysteryAvatar, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("Winston", 125, "A monkey in a business suit, expressing confidence and seriousness.", res.monkey,
				res.mysteryAvatar, AvatarRarity.Legendary));

			AddItemToDictionary(new Avatar("King Bugs", 150, "The great Bugs Bunny with a glittering crown, ruling the world of comedy with majesty and grace.",
				res.bugsBunny, res.mysteryAvatar, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("Pikachu", 150, "Pikachu with an elegant cap, the embodiment of style and enthusiasm, ready to light the way to adventure.",
				res.pikachu, res.mysteryAvatar, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("Homer", 200, "Homer Simpson in a tuxedo, symbolizing unrivaled chic and majestic severity.", res.homer,
				res.mysteryAvatar, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("Tom Rinnegan", 200, "Tom, gifted with the power of the Rinnegan, with all the signs of greatness and fighting prowess, " +
				"ready to conquer new horizons.", res.tom, res.mysteryAvatar, AvatarRarity.Legendary));
			AddItemToDictionary(new Avatar("Fury Avatar", 250, "A fearsome Avatar with glowing eyes, radiating indescribable power and majesty, " +
				"capable of changing destinies and leaving a mark on history.", res.rageAvatar, res.mysteryAvatar, AvatarRarity.Legendary));
		}
		private static void FillColorItems()
		{
			AddItemToDictionary(new ColorItem("Arctic White", 25, "A crisp, clean white that brings to mind the cold purity of the Arctic.",
				Color.FromArgb(235, 235, 235)), true);
			AddItemToDictionary(new ColorItem("Desert Sand", 25, "A light, neutral beige reminiscent of sandy landscapes, offering a calming backdrop.",
				Color.NavajoWhite));
			AddItemToDictionary(new ColorItem("Soft Khaki", 25, "A gentle, muted yellow-brown that adds a touch of warmth without overpowering the senses.",
				Color.Khaki));
			AddItemToDictionary(new ColorItem("Coral Pink", 25, "A soft and inviting pink with coral undertones, ideal for a gentle touch.",
				Color.FromArgb(255, 127, 80)));
			AddItemToDictionary(new ColorItem("Burnt Sienna", 25, "A rich, warm brown with reddish undertones, reminiscent of earthy tones.",
				Color.FromArgb(233, 116, 81)));
			AddItemToDictionary(new ColorItem("Sunset Orange", 25, "A warm and fiery orange reminiscent of a breathtaking sunset.",
				Color.FromArgb(255, 69, 0)));
			AddItemToDictionary(new ColorItem("Dusty Rose", 25, "A soft, warm pink with a vintage feel, ideal for a cozy and inviting background.",
				Color.RosyBrown));
			AddItemToDictionary(new ColorItem("Royal Red", 25, "A regal and bold red, fit for royalty and commanding attention.",
				Color.FromArgb(139, 0, 0)));
			AddItemToDictionary(new ColorItem("Rose Blush", 25, "A delicate, pale red with violet undertones, creating a soft and romantic ambiance.",
				Color.PaleVioletRed));
			AddItemToDictionary(new ColorItem("Seafoam Green", 25, "A tranquil green with hints of blue, evoking the calm of the sea and refreshing the visual field.",
				Color.DarkSeaGreen));
			AddItemToDictionary(new ColorItem("Emerald Green", 25, "A lush, vibrant green that evokes the beauty of emerald gemstones.",
				Color.FromArgb(0, 128, 0)));
			AddItemToDictionary(new ColorItem("Ocean Teal", 35, "A calming teal that reflects the serene colors of the ocean.",
				Color.FromArgb(0, 128, 128)));
			AddItemToDictionary(new ColorItem("Bright Cyan", 35, "A vivid and bright cyan that pops with a refreshing, cool tone.",
				Color.FromArgb(0, 255, 255)));
			AddItemToDictionary(new ColorItem("Lagoon Blue", 35, "A vibrant turquoise that brings to mind tropical waters, ideal for lively and engaging designs.",
				Color.Turquoise));
			AddItemToDictionary(new ColorItem("Iron Blue", 35, "A deep, rich blue with a steel-like quality, giving a sense of strength and stability.",
				Color.SteelBlue));
			AddItemToDictionary(new ColorItem("Midnight Blue", 35, "A dark blue with hints of navy, ideal for creating a nighttime atmosphere.",
				Color.FromArgb(25, 25, 112)));
			AddItemToDictionary(new ColorItem("Deep Space Blue", 50, "A dark and mysterious shade reminiscent of the vastness of space.",
				Color.FromArgb(10, 25, 47)));
			AddItemToDictionary(new ColorItem("Cosmic Purple", 50, "A rich, deep purple with cosmic vibes, perfect for a galactic theme.",
				Color.FromArgb(35, 0, 80)));
			AddItemToDictionary(new ColorItem("Mystic Purple", 50, "A medium purple with a mystical quality, perfect for adding a touch of magic and intrigue.",
				Color.MediumPurple));
			AddItemToDictionary(new ColorItem("Electric Purple", 50, "A vibrant and electrifying purple with a futuristic touch.",
				Color.FromArgb(153, 50, 204)));
			AddItemToDictionary(new ColorItem("Steel Gray", 50, "A strong, industrial gray with a hint of blue, perfect for a sleek look.",
				Color.FromArgb(70, 130, 180)));
			AddItemToDictionary(new ColorItem("Shadow Gray", 50, "A subdued gray with a touch of elegance, perfect for creating a refined atmosphere.",
				Color.DimGray));
			AddItemToDictionary(new ColorItem("Charcoal Gray", 50, "A deep, dark gray with subtle hints of black, providing a sophisticated and sleek backdrop.",
				Color.FromArgb(54, 69, 79)));
			AddItemToDictionary(new ColorItem("Near Black", 50, "An extremely dark gray, nearly black, offering a deep and intense background color.",
				Color.FromArgb(10, 10, 10)));

		}
		private static void FillCountableItems()
		{
			AddItemToDictionary(new CountableItem("Undo move", 4, "Undoes your last move.", res.undoMove, GameAssistType.UndoMove));
			AddItemToDictionary(new CountableItem("Surrender", 5, "Allows ending the game in a draw during play.", res.surrender, GameAssistType.Surrender));
			AddItemToDictionary(new CountableItem("Hint", 6, "Gives a hint for the next move.", res.hint, GameAssistType.Hint));
		}
		#endregion

		internal static Item[] GetAllItems()
			=> _dictionary.Values.Select(item => (Item)item.Clone()).ToArray();
		internal static Item GetFullItem(Item item)
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
					case CountableItem _:
						break;
					case Avatar avatar:
						_defaultAvatars.Add(avatar);
						break;
					case ImageItem imageItem:
						_defaultImageItems.Add(imageItem);
						break;
					case ColorItem colorItem:
						_defaultColorItems.Add(colorItem);
						break;
					default:
						throw new InvalidOperationException
							($"Unknown item type: {item.GetType().Name}");
				}
		}
		private static string GetKey(Item item)
			=> $"{item.GetType().Name}.{item.Name}";

		#region Default items
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