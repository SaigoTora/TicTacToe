using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.PlayerItemCreator;
using TicTacToe.Models.Utilities;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToe.Models.Utilities.FormUtilities.ControlEventHandlers;

namespace TicTacToe.Forms.ItemManagement.Profile
{
	internal partial class ProfileForm : ItemManagementForm
	{
		private const float PREVIEW_OPACITY_LEVEL = 0.65f;
		private const int SELECTED_ITEM_INDENT = 12;
		private const string SELECTED_ITEM_TEXT = "Selected";
		private const string SELECTED_PICTURE_TAG = "ItemSelected";

		private static readonly (Color Default, Color DuringRenaming) _buttonChangeNameColor =
			(Color.White, Color.Yellow);
		private static readonly (Color AboveHalf, Color BelowHalf) _winRateColor =
			(Color.FromArgb(71, 167, 106), Color.Maroon);

		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();
		private readonly List<PictureBox> _menuBackPictureBoxes = new List<PictureBox>();
		private readonly List<PictureBox> _gameBackPictureBoxes = new List<PictureBox>();
		private readonly List<PictureBox> _avatarPictureBoxes = new List<PictureBox>();

		private bool _isSelectedMenuBackCreated = false;
		private bool _isSelectedGameBackCreated = false;
		private bool _isSelectedAvatarCreated = false;

		internal ProfileForm(Player player) : base(player)
		{
			IsResizable = true;
			customTitleBar = new CustomTitleBar(this, $"{player.Name}");
			InitializeComponent();

			InitializeCreators();
			preferences = new List<(Label, FlowLayoutPanel)>
			{
				(labelBackgroundMenu, flpBackgroundMenu),
				(labelAvatar, flpAvatar),
				(labelBackgroundGame, flpBackgroundGame)
			};
		}

		private void ProfileForm_Load(object sender, EventArgs e)
		{
			buttonChangeName.IconColor = _buttonChangeNameColor.Default;
			pictureBoxPlayerAvatar.Image = player.VisualSettings.Avatar.Image;

			textBoxPlayerName.MaxLength = PlayerValidator.MAX_NAME_LENGTH;
			textBoxPlayerName.Text = player.Name;
			textBoxPlayerName.BackColor = BackColor;

			tabControl.TabButtonSelectedState.FillColor = BackColor;
			tabControl.TabMenuBackColor = BackColor;
			tabPagePreferences.BackColor = BackColor;
			tabPageStats.BackColor = BackColor;

			FillStatistics();
			CreateItems();
			_labelEventHandlers.SubscribeToHoverUnderline(labelBotStats, labelNetworkStats);
			SubscribeToNavigationButtonEvents(buttonPreferencesLeft,
				buttonPreferencesRight);
		}
		private void InitializeCreators()
		{
			const int ITEM_SIZE = 100;
			const int GAME_ASSISTANTS_SIZE = 80;

			menuBackCreator = new ImageCreator(player, flpBackgroundMenu, ITEM_SIZE);
			avatarCreator = new AvatarCreator(player, flpAvatar, ITEM_SIZE);
			gameBackCreator = new ColorCreator(player, flpBackgroundGame, ITEM_SIZE);
			gameAssistantsCreator = new ImageCreator(player, flpGameAssistants, GAME_ASSISTANTS_SIZE);
			ManageItemCreatorEvents(true);
			MouseLeaveItem(this, ItemEventArgs.Empty);
		}
		private void ManageItemCreatorEvents(bool subscribe)
		{
			if (subscribe)
			{
				menuBackCreator.Click += SelectMenuBack;
				avatarCreator.Click += SelectAvatar;
				gameBackCreator.Click += SelectGameBack;

				menuBackCreator.MouseEnter += MouseEnterMenuBack;
				avatarCreator.MouseEnter += MouseEnterAvatar;
				gameBackCreator.MouseEnter += MouseEnterGameBack;
				gameAssistantsCreator.MouseEnter += MouseEnterGameAssistants;

				menuBackCreator.MouseLeave += MouseLeaveItem;
				avatarCreator.MouseLeave += MouseLeaveItem;
				gameBackCreator.MouseLeave += MouseLeaveItem;
				gameAssistantsCreator.MouseLeave += MouseLeaveItem;
			}
			else
			{
				menuBackCreator.Click -= SelectMenuBack;
				avatarCreator.Click -= SelectAvatar;
				gameBackCreator.Click -= SelectGameBack;

				menuBackCreator.MouseEnter -= MouseEnterMenuBack;
				avatarCreator.MouseEnter -= MouseEnterAvatar;
				gameBackCreator.MouseEnter -= MouseEnterGameBack;
				gameAssistantsCreator.MouseEnter -= MouseEnterGameAssistants;

				menuBackCreator.MouseLeave -= MouseLeaveItem;
				avatarCreator.MouseLeave -= MouseLeaveItem;
				gameBackCreator.MouseLeave -= MouseLeaveItem;
				gameAssistantsCreator.MouseLeave -= MouseLeaveItem;
			}
		}

		#region Statistics
		private void FillStatistics()
		{
			FillBotStatistics();
			FillNetworkStatistics();

			if (player.BotStats.TotalGames > 0 && player.NetworkStats.TotalGames > 0)
				pictureBoxLineBetweenStats.Visible = true;
		}
		private void FillBotStatistics()
		{
			if (player.BotStats.TotalGames <= 0)
			{
				panelBotStats.Visible = false;
				return;
			}

			labelBotTotalGames.Text = player.BotStats.TotalGames.ToString();
			labelBotWinRate.Text = player.BotStats.WinRate.ToString("F2") + " %";
			if (player.BotStats.WinRate > 50)
				labelBotWinRate.ForeColor = _winRateColor.AboveHalf;
			else if (player.BotStats.WinRate < 50)
				labelBotWinRate.ForeColor = _winRateColor.BelowHalf;

			FillWinsDrawsLosses(player.BotStats, labelBotWinsTitle, labelBotWins,
				labelBotDrawsTitle, labelBotDraws, labelBotLossesTitle, labelBotLosses);
		}
		private void FillNetworkStatistics()
		{
			if (player.NetworkStats.TotalGames <= 0)
			{
				panelNetworkStats.Visible = false;
				return;
			}

			labelNetworkTotalGames.Text = player.NetworkStats.TotalGames.ToString();
			labelNetworkWinRate.Text = player.NetworkStats.WinRate.ToString("F2") + " %";
			if (player.NetworkStats.WinRate > 50)
				labelNetworkWinRate.ForeColor = _winRateColor.AboveHalf;
			else if (player.NetworkStats.WinRate < 50)
				labelNetworkWinRate.ForeColor = _winRateColor.BelowHalf;

			FillWinsDrawsLosses(player.NetworkStats, labelNetworkWinsTitle, labelNetworkWins,
				labelNetworkDrawsTitle, labelNetworkDraws, labelNetworkLossesTitle, labelNetworkLosses);
		}
		private void FillWinsDrawsLosses(PlayerStats stats, Label winsTitle, Label wins,
			Label drawsTitle, Label draws, Label lossesTitle, Label losses)
		{
			if (stats.Wins > 0)
				wins.Text = stats.Wins.ToString();
			else
			{
				winsTitle.Visible = false;
				wins.Visible = false;
			}

			if (stats.Draws > 0)
				draws.Text = stats.Draws.ToString();
			else
			{
				drawsTitle.Visible = false;
				draws.Visible = false;
			}
			if (stats.Losses > 0)
				losses.Text = stats.Losses.ToString();
			else
			{
				lossesTitle.Visible = false;
				losses.Visible = false;
			}
		}

		private void LabelBotStats_Click(object sender, EventArgs e)
		{
			CustomMessageBox.Show("Statistics for games with a bot are calculated for each ROUND.",
				"Information", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information);
		}
		private void LabelNetworkStats_Click(object sender, EventArgs e)
		{
			CustomMessageBox.Show("Statistics for network games are calculated for each MATCH.",
				"Information", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information);
		}
		#endregion

		#region Create items
		private void CreateItems()
		{
			foreach (Item item in player.ItemsInventory.GetItems())
				switch (item)
				{
					case Avatar avatar:
						CreateAvatar(avatarCreator, avatar);
						break;
					case ImageItem imageItem:
						CreateMenuBack(menuBackCreator, imageItem);
						break;
					case ColorItem colorItem:
						CreateGameBack(gameBackCreator, colorItem);
						break;
					default:
						throw new InvalidOperationException($"Unknown item type: {item.GetType().Name}");
				}

			foreach (CountableItem item in player.CountableItemsInventory.GetItems())
				if (item.Count > 0)
					gameAssistantsCreator.CreateItemToSelect(item);
		}
		private void CreateMenuBack(ImageCreator menuBackCreator, ImageItem imageItem)
		{
			PictureBox pictureBox = menuBackCreator.CreateItemToSelect(imageItem);
			_menuBackPictureBoxes.Add(pictureBox);

			if (!_isSelectedMenuBackCreated && imageItem.Name == player.VisualSettings.BackgroundMenu.Name)
			{
				SelectMenuBack(this, new ItemEventArgs(imageItem, pictureBox));
				_isSelectedMenuBackCreated = true;
			}
		}
		private void CreateAvatar(AvatarCreator avatarCreator, Avatar avatar)
		{
			PictureBox pictureBox = avatarCreator.CreateItemToSelect(avatar);
			_avatarPictureBoxes.Add(pictureBox);

			if (!_isSelectedAvatarCreated && avatar.Name == player.VisualSettings.Avatar.Name)
			{
				SelectAvatar(this, new ItemEventArgs(avatar, pictureBox));
				_isSelectedAvatarCreated = true;
			}
		}
		private void CreateGameBack(ColorCreator gameBackCreator, ColorItem colorItem)
		{
			PictureBox pictureBox = gameBackCreator.CreateItemToSelect(colorItem);
			_gameBackPictureBoxes.Add(pictureBox);

			if (!_isSelectedGameBackCreated && colorItem.Name == player.VisualSettings.BackgroundGame.Name)
			{
				SelectGameBack(this, new ItemEventArgs(colorItem, pictureBox));
				_isSelectedGameBackCreated = true;
			}
		}
		#endregion

		#region Select and deselect items
		private void SelectAvatar(object sender, ItemEventArgs e)
		{
			if (!(e.ClickableControl is PictureBox selectedPicture))
				return;

			player.SelectItem(e.Item);
			DeselectPreviousItem(_avatarPictureBoxes);
			DefaultSelect(selectedPicture);
			pictureBoxPlayerAvatar.Image = selectedPicture.Image;
		}
		private void SelectMenuBack(object sender, ItemEventArgs e)
		{
			if (!(e.ClickableControl is PictureBox selectedPicture))
				return;

			player.SelectItem(e.Item);
			DeselectPreviousItem(_menuBackPictureBoxes);
			DefaultSelect(selectedPicture);
		}
		private void SelectGameBack(object sender, ItemEventArgs e)
		{
			if (!(e.ClickableControl is PictureBox selectedPicture))
				return;

			player.SelectItem(e.Item);
			DeselectPreviousItem(_gameBackPictureBoxes);
			DefaultSelect(selectedPicture);
		}

		private void DeselectPreviousItem(List<PictureBox> list)
		{
			foreach (PictureBox picture in list)
				if (picture.Tag != null && picture.Tag.ToString() == SELECTED_PICTURE_TAG)
				{
					DefaultDeselect(picture);
					break;
				}
		}

		private void DefaultSelect(PictureBox pictureBox)
		{
			pictureBox.Tag = SELECTED_PICTURE_TAG;
			pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - SELECTED_ITEM_INDENT);
			pictureBox.Enabled = false;
			CreateSelectionLabel(pictureBox.Parent);
		}
		private void DefaultDeselect(PictureBox pictureBox)
		{
			pictureBox.Tag = string.Empty;
			pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + SELECTED_ITEM_INDENT);
			pictureBox.Enabled = true;
			DeleteSelectionLabel(pictureBox.Parent);
		}
		private void CreateSelectionLabel(Control parent)
		{
			Color foreColor = Color.Yellow;

			new Label
			{
				Parent = parent,
				Text = SELECTED_ITEM_TEXT,
				ForeColor = foreColor,
				Dock = DockStyle.Bottom,
				TextAlign = ContentAlignment.MiddleCenter,
				Font = new Font("Trebuchet MS", 10F, FontStyle.Bold),
				Size = new Size(0, SELECTED_ITEM_INDENT * 2)
			};
		}
		private void DeleteSelectionLabel(Control parent)
		{
			var labelToRemove = parent.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text == SELECTED_ITEM_TEXT);
			labelToRemove?.Dispose();
		}
		#endregion

		#region Change name
		private void ButtonChangeName_Click(object sender, EventArgs e)
		{
			if (textBoxPlayerName.ReadOnly)
			{
				buttonChangeName.IconColor = _buttonChangeNameColor.DuringRenaming;
				textBoxPlayerName.ReadOnly = false;
				textBoxPlayerName.Focus();
				textBoxPlayerName.SelectAll();
			}
			else if (player.Name == textBoxPlayerName.Text)
			{
				buttonChangeName.IconColor = _buttonChangeNameColor.Default;
				textBoxPlayerName.ReadOnly = true;
				ActiveControl = null;
			}
		}

		private bool IsPlayerDataValid()
		{
			PlayerValidator validator = new PlayerValidator();

			Player newPlayer = new Player(textBoxPlayerName.Text);
			ValidationResult result = validator.Validate(newPlayer);
			if (!result.IsValid)
			{
				CustomMessageBox.Show(result.Errors[0].ErrorMessage, "Invalid input", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error, 420);
				return false;
			}
			else
				return true;
		}
		private void TryToChangeName()
		{
			if (textBoxPlayerName.ReadOnly)
				return;

			if (IsPlayerDataValid())
			{
				ActiveControl = null;
				textBoxPlayerName.ReadOnly = true;
				buttonChangeName.IconColor = _buttonChangeNameColor.Default;
				if (player.Name != textBoxPlayerName.Text)
				{
					player.ChangeName(textBoxPlayerName.Text);
					customTitleBar.ChangeFormCaption(textBoxPlayerName.Text);
					CustomMessageBox.Show("Your nickname has been successfully changed.", "Success", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.OK);
				}
			}
			else
				textBoxPlayerName.Focus();
		}
		private void TextBoxPlayerName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				TryToChangeName();
		}
		private void TextBoxPlayerName_Leave(object sender, EventArgs e)
			=> TryToChangeName();
		#endregion

		#region Hover items
		private void SetPreviewItem(Item item, bool needToSetPrice = true, bool needToSetDate = true)
		{
			labelItemName.Text = item.Name;
			if (needToSetPrice)
				SetPrice(item);
			if (needToSetDate)
				labelDateTimePurchase.Text = item.DateTimePurchase.ToString("dd.MM.yyyy HH:mm");
			labelDescription.Text = item.Description;
			panelPreviewItem.Visible = true;
		}
		private void SetPrice(Item item)
		{
			if (item.Price == 0)
			{
				labelPrice.Text = string.Empty;
				pictureBoxCoin.Visible = false;
			}
			else
			{
				labelPrice.Text = $"{item.Price:N0}".Replace(',', ' ');
				pictureBoxCoin.Visible = true;
			}
		}

		private void MouseEnterMenuBack(object sender, ItemEventArgs e)
		{
			if (!(e.Item is ImageItem imageItem))
				return;

			pictureBoxItem.Image = imageItem.Image.ChangeOpacity(PREVIEW_OPACITY_LEVEL);
			SetPreviewItem(imageItem);
		}
		private void MouseEnterAvatar(object sender, ItemEventArgs e)
		{
			if (!(e.Item is Avatar avatar))
				return;

			pictureBoxItem.Image = avatar.Image.ChangeOpacity(PREVIEW_OPACITY_LEVEL);
			SetPreviewItem(avatar);
		}
		private void MouseEnterGameBack(object sender, ItemEventArgs e)
		{
			if (!(e.Item is ColorItem colorItem))
				return;

			pictureBoxItem.BackColor = colorItem.Color;
			SetPreviewItem(colorItem);
		}
		private void MouseEnterGameAssistants(object sender, ItemEventArgs e)
		{
			if (!(e.Item is CountableItem countableItem))
				return;

			pictureBoxItem.Image = countableItem.Image;
			labelItemCount.Text = $"X {countableItem.Count:N0}".Replace(',', ' ');
			SetPreviewItem(countableItem, false, false);
		}
		private void MouseLeaveItem(object sender, ItemEventArgs e)
		{
			panelPreviewItem.Visible = false;
			pictureBoxItem.BackColor = Color.Transparent;
			pictureBoxItem.Image = null;
			pictureBoxCoin.Visible = false;
			labelItemName.Text = string.Empty;
			labelPrice.Text = string.Empty;
			labelItemCount.Text = string.Empty;
			labelDateTimePurchase.Text = string.Empty;
			labelDescription.Text = string.Empty;
		}
		#endregion

		private void ButtonResetProgress_Click(object sender, EventArgs e)
		{
			ActiveControl = null;

			DialogResult result = CustomMessageBox.Show("Are you sure you want to reset ALL your progress? " +
				"All your saves will be lost FOREVER.", "Reset Progress Confirmation",
				CustomMessageBoxButtons.YesNo, CustomMessageBoxIcon.Warning);
			if (result == DialogResult.Yes)
			{
				result = CustomMessageBox.Show("Are you really sure? This action will reset " +
					"your game progress and restart the application.", "Final Warning",
					CustomMessageBoxButtons.YesNo, CustomMessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					Visible = false;
					Serializator.DeleteSerializationFile(Program.SerializePath);
					Process.Start(Application.ExecutablePath);
					Environment.Exit(0);
				}
			}
		}

		private void ProfileForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				Close();
		}
		private void Profile_FormClosed(object sender, FormClosedEventArgs e)
		{
			ManageItemCreatorEvents(false);
			_labelEventHandlers.UnsubscribeAll();
			UnsubscribeFromNavigationButtonEvents(buttonPreferencesLeft,
				buttonPreferencesRight);

			Serializator.Serialize(player, Program.SerializePath, Program.EncryptKey);
		}
	}
}