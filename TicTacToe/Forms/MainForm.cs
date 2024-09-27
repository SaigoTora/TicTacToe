using FontAwesome.Sharp;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using TicTacToe.Forms.ItemManagement.Profile;
using TicTacToe.Forms.ItemManagement.Shop;
using TicTacToe.Forms.Game;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToe.Properties;
using TicTacToeLibrary;

namespace TicTacToe.Forms
{
	internal partial class MainForm : BaseForm
	{
		private static readonly (Color Default, Color Hover) _backColorLabelName = (Color.FromArgb(125, 35, 35, 35), Color.CornflowerBlue);
		private static readonly (Color Default, Color Selected) _foreColorDifficulty = (Color.Black, Color.White);
		private static readonly (Color Default, Color Selected) _iconColorDifficulty = (Color.Black, Color.Lime);
		private static readonly (IconChar Default, IconChar Selected) _iconCharDifficulty = (IconChar.Circle, IconChar.CircleCheck);

		private static readonly (Color Easy, Color Medium, Color Hard, Color Impossible) _difficultyButtonFillColor =
			(Color.FromArgb(71, 167, 106), Color.SandyBrown, Color.FromArgb(171, 52, 58), Color.FromArgb(71, 67, 137));
		private static readonly (Color Easy, Color Medium, Color Hard, Color Impossible) _difficultyButtonFillColor2 =
			(Color.FromArgb(30, 129, 69), Color.FromArgb(236, 124, 38), Color.FromArgb(155, 17, 30), Color.FromArgb(83, 55, 122));
		private readonly int _panelSettingsWidth;
		private readonly CustomTitleBar _customTitleBar;
		private readonly PictureBoxEventHandlers _pictureBoxEventHandlers = new PictureBoxEventHandlers();
		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();

		private readonly Player _player;
		private Difficulty _selectedDifficulty;
		private bool _isSettingsVisible = true;

		public MainForm(Player player)
		{
			_customTitleBar = new CustomTitleBar(this, "Tic Tac Toe", Resources.ticTacToe);
			IsResizable = true;
			InitializeComponent();

			_panelSettingsWidth = panelSettingsMain.Width;
			_player = player;
		}
		private void MainForm_Load(object sender, EventArgs e)
		{
			SetDefaultColorsForDifficultyButtons();
			ButtonDifficulty_Click(buttonEasy, e);
			DisplayPlayerData();

			_pictureBoxEventHandlers.SubscribeToHover(pictureBoxAvatar);
			_buttonEventHandlers.SubscribeToHover(buttonPlay, buttonProfile,
				buttonShop, buttonExit);
			_labelEventHandlers.SubscribeToHoverUnderline(labelAuthor);
		}

		private void DisplayPlayerData()
		{
			labelCoins.Text = $"{_player.Coins:N0}".Replace(',', ' ');
			labelPlayerName.Text = _player.Name;
			pictureBoxAvatar.Image = _player.Preferences.Avatar.Image;
			BackgroundImage = _player.Preferences.BackgroundMenu.Image;
		}
		private async Task ChangeSizePanelSettingsAsync(bool needToOpen)
		{
			const int DELAY = 2;
			int step = 5;

			if (!needToOpen)
				step *= -1;

			int targetWidth = needToOpen ? _panelSettingsWidth : buttonShowSettings.Width;

			while ((needToOpen && panelSettingsMain.Width < targetWidth) ||
				   (!needToOpen && panelSettingsMain.Width > targetWidth))
			{
				panelSettingsMain.Width += step;
				await Task.Delay(DELAY);
			}
		}

		#region Difficulty labels
		private void ButtonDifficulty_Click(object sender, EventArgs e)
		{
			if (!(sender is IconButton button))
				return;

			ActiveControl = null;
			button.IconChar = _iconCharDifficulty.Selected;
			button.IconColor = _iconColorDifficulty.Selected;
			button.ForeColor = _foreColorDifficulty.Selected;

			if (button == buttonEasy)
			{
				SetDifficultySettings(Difficulty.Easy, _difficultyButtonFillColor.Easy,
					_difficultyButtonFillColor2.Easy);
				SetDefaultColorsForDifficultyButtons(buttonMedium, buttonHard, buttonImpossible);
			}
			else if (button == buttonMedium)
			{
				SetDifficultySettings(Difficulty.Medium, _difficultyButtonFillColor.Medium,
					_difficultyButtonFillColor2.Medium);
				SetDefaultColorsForDifficultyButtons(buttonEasy, buttonHard, buttonImpossible);
			}
			else if (button == buttonHard)
			{
				SetDifficultySettings(Difficulty.Hard, _difficultyButtonFillColor.Hard,
					_difficultyButtonFillColor2.Hard);
				SetDefaultColorsForDifficultyButtons(buttonEasy, buttonMedium, buttonImpossible);
			}
			else if (button == buttonImpossible)
			{
				SetDifficultySettings(Difficulty.Impossible, _difficultyButtonFillColor.Impossible,
					_difficultyButtonFillColor2.Impossible);
				SetDefaultColorsForDifficultyButtons(buttonEasy, buttonMedium, buttonHard);
			}
		}
		private void SetDifficultySettings(Difficulty difficulty, Color buttonPlayFillColor, Color buttonPlayFillColor2)
		{
			_selectedDifficulty = difficulty;
			buttonPlay.FillColor = buttonPlayFillColor;
			buttonPlay.FillColor2 = buttonPlayFillColor2;
		}
		private void SetDefaultColorsForDifficultyButtons(params IconButton[] buttons)
		{
			foreach (IconButton button in buttons)
			{
				button.IconChar = _iconCharDifficulty.Default;
				button.IconColor = _iconColorDifficulty.Default;
				button.ForeColor = _foreColorDifficulty.Default;
			}
		}

		private void ButtonDifficulty_MouseEnter(object sender, EventArgs e)
		{
			if (sender is IconButton iconButton)
				iconButton.ForeColor = _foreColorDifficulty.Selected;
		}
		private void ButtonDifficulty_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is IconButton iconButton))
				return;

			if (_selectedDifficulty == Difficulty.Easy && iconButton == buttonEasy
				|| _selectedDifficulty == Difficulty.Medium && iconButton == buttonMedium
				|| _selectedDifficulty == Difficulty.Hard && iconButton == buttonHard
				|| _selectedDifficulty == Difficulty.Impossible && iconButton == buttonImpossible)
				return;

			iconButton.ForeColor = _foreColorDifficulty.Default;
		}
		#endregion

		#region Buttons click event handlers
		private void ButtonPlay_Click(object sender, EventArgs e)
		{
			Bot bot = new Bot(_selectedDifficulty);
			RoundManager roundManager = new RoundManager((int)numericUpDownNumberOfRounds.Value);

			BaseGame3on3Form gameForm = new BaseGame3on3Form(this, _player, bot, roundManager, CellType.Zero);
			if (!gameForm.IsDisposed)// If a player have enough coints to play
			{
				Hide();
				gameForm.Show();
			}
		}
		private void ButtonProfile_Click(object sender, EventArgs e)
		{
			ProfileForm profileForm = new ProfileForm(_player);
			profileForm.FormClosed += (s, args) => { Visible = true; };
			Visible = false;
			if (WindowState == FormWindowState.Maximized)
				profileForm.WindowState = FormWindowState.Maximized;
			profileForm.Show();
		}
		private void ButtonShop_Click(object sender, EventArgs e)
		{
			ShopForm shopForm = new ShopForm(_player);
			shopForm.FormClosed += (s, args) => { Visible = true; };
			Visible = false;
			if (WindowState == FormWindowState.Maximized)
				shopForm.WindowState = FormWindowState.Maximized;
			shopForm.Show();
		}
		private void ButtonExit_Click(object sender, EventArgs e)
		{
			DialogResult result = CustomMessageBox.Show("Are you sure you want to exit the game?",
				"Exit", CustomMessageBoxButtons.YesNo, CustomMessageBoxIcon.Question);

			if (result == DialogResult.Yes)
				Application.Exit();
		}
		#endregion

		#region Other event handlers
		private async void ButtonShowSettings_Click(object sender, EventArgs e)
		{
			if (!(sender is IconButton iconButton))
				return;

			ActiveControl = null;
			iconButton.Enabled = false;
			if (_isSettingsVisible)
			{
				await ChangeSizePanelSettingsAsync(false);
				_isSettingsVisible = false;
				panelSettings.Visible = false;
				iconButton.Flip = FlipOrientation.Normal;
			}
			else
			{
				panelSettings.Visible = true;
				await ChangeSizePanelSettingsAsync(true);
				_isSettingsVisible = true;
				iconButton.Flip = FlipOrientation.Horizontal;
			}
			iconButton.Enabled = true;
		}

		private void LabelName_MouseEnter(object sender, EventArgs e)
		{
			if (sender is Label label)
				label.BackColor = _backColorLabelName.Hover;
		}
		private void LabelName_MouseLeave(object sender, EventArgs e)
		{
			if (sender is Label label)
				label.BackColor = _backColorLabelName.Default;
		}

		private void LabelAuthor_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "https://github.com/SaigoTora",
					UseShellExecute = true
				});
			}
			catch (Exception ex)
			{
				CustomMessageBox.Show($"Failed to open link:\n{ex.Message}", "Error", icon: CustomMessageBoxIcon.Error);
			}

		}
		private void Menu_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible)
				DisplayPlayerData();
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_pictureBoxEventHandlers.UnsubscribeAll();
			_buttonEventHandlers.UnsubscribeAll();
			_labelEventHandlers.UnsubscribeAll();
			_customTitleBar.Dispose();

			Serializator.Serialize(_player, Program.SerializePath, Program.EncryptKey);
		}
		#endregion
	}
}