using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToeLibrary;

namespace TicTacToe.Forms.Game
{
	internal partial class BaseGame3on3Form : BaseGameForm
	{
		private readonly CustomTitleBar _customTitleBar;

		internal BaseGame3on3Form(MainForm mainForm, Player player, Bot bot, RoundManager roundManager, CellType playerCellType)
			: base(mainForm, player, bot, roundManager, playerCellType)
		{
			InitializeComponent();

			_customTitleBar = new CustomTitleBar(this, $"Round {roundManager.CurrentNumberOfRounds} / {roundManager.MaxNumberOfRounds}",
				maximizeBox: false, canFormBeClosed: false);
			TryToDeductCoins(bot.Difficulty);
		}
		private void GameForm_Load(object sender, EventArgs e)
		{
			InitializeBaseGame();
			SetColorForControls(new[] { labelPlayerName, labelScore, labelBotName },
				new Control[]{ pictureBoxLine1, pictureBoxLine2, pictureBoxLine3, pictureBoxLine4,
					buttonChangeView });

			pictureBoxBotAvatar.Image = GetBotAvatar(bot.Difficulty);
			labelBotName.Text = bot.Name;
			SetPlayerNamesSize(labelPlayerName, labelBotName);

			if (opponentCellType == CellType.Cross)
				_ = BotMoveAsync();
			else
			{
				ChangeGameViewVisibility(true);
				StartTimerToMove();
			}
		}

		private void InitializeBaseGame()
		{
			const int TIMER_MOVE_DELAY = 900;

			PictureBox[,] pictureCells = new[,]{ { pictureBoxCell1, pictureBoxCell2, pictureBoxCell3 },
									{ pictureBoxCell4, pictureBoxCell5, pictureBoxCell6 },
									{ pictureBoxCell7, pictureBoxCell8, pictureBoxCell9 } };

			PlayerInfo playerInfo = new PlayerInfo(pictureBoxBotAvatar, labelPlayerName);
			TimerInfo timerInfo = new TimerInfo(progressBarTimer, progressBarCircleTimer, TIMER_MOVE_DELAY);
			GameAssistsInfo gameAssistsInfo = new GameAssistsInfo(pictureBoxUndoMove, pictureBoxHint,
				pictureBoxSurrender, buttonChangeView, flpGameAssistants);
			GameFormInfo gameFormInfo = new GameFormInfo(playerInfo, labelScore, pictureCells,
				PictureBoxCell_Click, timerInfo, gameAssistsInfo);
			InitializeGame(gameFormInfo);
		}
		private void SetPlayerNamesSize(params Label[] names)
		{
			foreach (var name in names)
				if (name.Text.Length > 15)
					name.Font = new Font(name.Font.FontFamily, 12);
		}

		protected override BaseGameForm GetNextGameForm()
			=> new BaseGame3on3Form(mainForm, player, bot, roundManager, opponentCellType);

		#region Actions of the game
		private async void PictureBoxCell_Click(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			await PictureBoxCell_DefaultClick(pictureBox, e != EventArgs.Empty);
		}

		private void PictureBoxCell_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			PictureBoxCell_DefaultMouseEnter(pictureBox);
		}
		private void PictureBoxCell_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			PictureBoxCell_DefaultMouseLeave(pictureBox);
		}
		#endregion

		private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_customTitleBar.Dispose();
		}
	}
}