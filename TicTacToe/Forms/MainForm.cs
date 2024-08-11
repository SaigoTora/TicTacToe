using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities;
using TicTacToe.Properties;
using TicTacToeLibrary;

namespace TicTacToe.Forms
{
	internal partial class MainForm : Form
	{
		private const int DELAY_VISIBILITY_OF_SETTINGS = 150;

		private readonly Color _backColorSelectedLabelName = Color.CornflowerBlue;

		private readonly (Color Default, Color Selected) _backColorLabelDifficulty =
			(Color.LightSteelBlue, Color.Blue);

		private readonly (Color Default, Color Selected) _foreColorLabel =
			(Color.Black, Color.White);

		private readonly (Color Easy, Color Medium, Color Hard, Color Impossible) _difficultyButtonColor =
			(Color.FromArgb(0, 107, 60), Color.FromArgb(229, 158, 31), Color.FromArgb(127, 24, 13), Color.FromArgb(71, 67, 137));

		private readonly Player _player;
		private Difficulty _selectedDifficulty;
		private bool _isSettingsVisible = true;

		public MainForm(Player player)
		{
			InitializeComponent();

			_player = player;
		}
		private void MainForm_Load(object sender, EventArgs e)
		{
			SetDefaultColorsForDifficultyLabels();
			LabelDifficulty_Click(labelEasy, e);
			DisplayPlayerData();

			FormEventHandlers.SubscribeToHoverPictureBoxes(pictureBoxAvatar,
				pictureBoxShowSettings);
			//FormEventHandlers.SubscribeToHoverButtons(buttonPlay, buttonProfile,
			//	buttonShop, buttonExit);
		}

		private void DisplayPlayerData()
		{
			labelPoints.Text = _player.Points.ToString();
			labelPlayerName.Text = _player.Name;
			pictureBoxAvatar.Image = _player.Settings.Avatar;
			BackgroundImage = _player.Settings.BackgroundMenu;
		}
		private async Task ChangeVisibilityOfControlsWithDelay(bool visible, int millisecondsDelay, params Control[] controls)
		{
			for (int i = 0; i < controls.Length; i++)
			{
				controls[i].Visible = visible;
				if (i < controls.Length - 1)
					await Task.Delay(millisecondsDelay);
			}
		}

		#region DifficultyLabels
		private void LabelDifficulty_Click(object sender, EventArgs e)
		{
			if (!(sender is Label label))
				return;

			label.BackColor = _backColorLabelDifficulty.Selected;
			label.ForeColor = _foreColorLabel.Selected;

			if (label == labelEasy)
			{
				_selectedDifficulty = Difficulty.Easy;
				buttonPlay.BackColor = _difficultyButtonColor.Easy;
				SetDefaultColorsForDifficultyLabels(labelMedium, labelHard, labelImpossible);
			}
			else if (label == labelMedium)
			{
				_selectedDifficulty = Difficulty.Medium;
				buttonPlay.BackColor = _difficultyButtonColor.Medium;
				SetDefaultColorsForDifficultyLabels(labelEasy, labelHard, labelImpossible);
			}
			else if (label == labelHard)
			{
				_selectedDifficulty = Difficulty.Hard;
				buttonPlay.BackColor = _difficultyButtonColor.Hard;
				SetDefaultColorsForDifficultyLabels(labelEasy, labelMedium, labelImpossible);
			}
			else if (label == labelImpossible)
			{
				_selectedDifficulty = Difficulty.Impossible;
				buttonPlay.BackColor = _difficultyButtonColor.Impossible;
				SetDefaultColorsForDifficultyLabels(labelEasy, labelMedium, labelHard);
			}
		}
		private void SetDefaultColorsForDifficultyLabels(params Label[] labels)
		{
			foreach (Label label in labels)
			{
				label.BackColor = _backColorLabelDifficulty.Default;
				label.ForeColor = _foreColorLabel.Default;
			}
		}

		private void LabelDifficulty_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is Label label))
				return;

			label.ForeColor = _foreColorLabel.Selected;
		}
		private void LabelDifficulty_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is Label label))
				return;

			// If the mouse has left the difficulty level already selected
			if (label == labelEasy && _selectedDifficulty == Difficulty.Easy
				|| label == labelMedium && _selectedDifficulty == Difficulty.Medium
				|| label == labelHard && _selectedDifficulty == Difficulty.Hard)
				return;

			label.ForeColor = _foreColorLabel.Default;
		}
		#endregion

		#region ButtonsClick
		private void ButtonPlay_Click(object sender, EventArgs e)
		{
			Bot bot = new Bot(_selectedDifficulty);
			RoundManager roundManager = new RoundManager((int)numericUpDownNumberOfRounds.Value);

			GameForm gameForm = new GameForm(this, _player, bot, roundManager, true);
			if (!gameForm.IsDisposed)// If a player have enough points to play
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
			profileForm.Show();
		}
		private void ButtonShop_Click(object sender, EventArgs e)
		{
			ShopForm shopForm = new ShopForm(_player);
			shopForm.FormClosed += (s, args) => { Visible = true; };
			Visible = false;
			shopForm.Show();
		}
		#endregion

		#region OtherEventHandlers
		private async void PictureBoxShowSettings_Click(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			pictureBox.Enabled = false;
			if (_isSettingsVisible)
			{
				_isSettingsVisible = false;
				pictureBox.BackgroundImage = Resources.eyeClose;

				await ChangeVisibilityOfControlsWithDelay(false, DELAY_VISIBILITY_OF_SETTINGS,
					numericUpDownNumberOfRounds, labelNumberOfRounds, labelImpossible, labelHard,
					labelMedium, labelEasy, labelDifficult);
			}
			else
			{
				_isSettingsVisible = true;
				pictureBox.BackgroundImage = Resources.eyeOpen;

				await ChangeVisibilityOfControlsWithDelay(true, DELAY_VISIBILITY_OF_SETTINGS,
					labelDifficult, labelEasy, labelMedium, labelHard, labelImpossible,
					labelNumberOfRounds, numericUpDownNumberOfRounds);
			}
			pictureBox.Enabled = true;
		}

		private void LabelName_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is Label label))
				return;

			label.BackColor = _backColorSelectedLabelName;
			label.ForeColor = _foreColorLabel.Selected;
		}
		private void LabelName_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is Label label))
				return;

			label.BackColor = Color.Transparent;
			label.ForeColor = _foreColorLabel.Default;
		}

		private void Menu_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible)
				DisplayPlayerData();
		}

		private void ButtonExit_Click(object sender, EventArgs e) { Application.Exit(); }
		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Serializator.Serialize(_player, Program.SerializePath, Program.EncryptKey);
		}
		#endregion
	}
}