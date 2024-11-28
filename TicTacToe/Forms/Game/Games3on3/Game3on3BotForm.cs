using System;
using System.Windows.Forms;

using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToeLibrary;

namespace TicTacToe.Forms.Game.Games3on3
{
	internal partial class Game3on3BotForm : BaseGame3on3Form
	{
		internal Game3on3BotForm(MainForm mainForm, Player player, Bot bot, RoundManager roundManager,
			CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(mainForm, player, bot, roundManager, playerCellType, isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, $"Round {roundManager.CurrentNumberOfRounds} / {roundManager.MaxNumberOfRounds}",
				maximizeBox: false, canFormBeClosed: false);
			TryToDeductCoins(bot.Difficulty);
		}
		private void Game3on3BotForm_Load(object sender, EventArgs e)
		{
			Game3on3BotForm nextGameForm = new Game3on3BotForm(mainForm, player, bot, roundManager,
			   opponentCellType, isTimerEnabled, isGameAssistsEnabled);
			InitializeBaseGame(PictureCell_Click, nextGameForm);
			ManagePictureCellsEventHover(PictureCell_MouseEnter, PictureCell_MouseLeave, true);

			pictureBoxOpponentAvatar.Image = GetBotAvatar(bot.Difficulty);
			labelOpponentName.Text = bot.Name;
			SetPlayerNamesSize(labelPlayerName, labelOpponentName);

			if (opponentCellType == CellType.Cross)
				_ = BotMoveAsync();
			else
				SetupMoveTransition(playerCellType, true);
		}

		private async void PictureCell_Click(object sender, EventArgs e)
		{
			if (sender is PictureBox pictureBox)
				await PictureBoxCell_DefaultClick(pictureBox, playerCellType, e != EventArgs.Empty);
		}
		private void PictureCell_MouseEnter(object sender, EventArgs e)
		{
			if (sender is PictureBox pictureBox)
				PictureBoxCell_DefaultMouseEnter(pictureBox, playerCellType);
		}
		private void PictureCell_MouseLeave(object sender, EventArgs e)
		{
			if (sender is PictureBox pictureBox)
				PictureBoxCell_DefaultMouseLeave(pictureBox);
		}

		private void Game3on3BotForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			ManagePictureCellsEventHover(PictureCell_MouseEnter, PictureCell_MouseLeave, false);
		}
	}
}