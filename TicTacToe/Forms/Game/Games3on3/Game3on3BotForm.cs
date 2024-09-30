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

			pictureBoxOpponentAvatar.Image = GetBotAvatar(bot.Difficulty);
			labelOpponentName.Text = bot.Name;

			SetPlayerNamesSize(labelPlayerName, labelOpponentName);

			if (opponentCellType == CellType.Cross)
				_ = BotMoveAsync();
			else
			{
				ChangeGameViewVisibility(true);
				StartTimerToMove();
			}
		}
		private async void PictureCell_Click(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			await PictureBoxCell_DefaultClick(pictureBox, e != EventArgs.Empty);
		}
	}
}