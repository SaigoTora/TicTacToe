using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.GameClientServer.Core;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToeLibrary.Core;
using TicTacToeLibrary.GameLogic;

namespace TicTacToe.Forms.Game.Games3on3
{
	internal partial class Game3on3NetworkForm : BaseGame3on3Form
	{
		internal Game3on3NetworkForm(MainForm mainForm, Player player, GameServer gameServer, int coinsBet,
			RoundManager roundManager, GameMode gameMode, CellType playerCellType,
			bool isTimerEnabled, bool isGameAssistsEnabled, Image opponentAvatar, string opponentName)
			: base(mainForm, player, gameServer, coinsBet, roundManager, gameMode, playerCellType,
				  isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			DefaultInitialize(opponentAvatar, opponentName);
		}
		internal Game3on3NetworkForm(MainForm mainForm, Player player, GameClient gameClient, int coinsBet,
			RoundManager roundManager, GameMode gameMode, CellType playerCellType,
			bool isTimerEnabled, bool isGameAssistsEnabled, Image opponentAvatar, string opponentName)
			: base(mainForm, player, gameClient, coinsBet, roundManager, gameMode, playerCellType,
				  isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			DefaultInitialize(opponentAvatar, opponentName);
		}
		private void DefaultInitialize(Image opponentAvatar, string opponentName)
		{
			customTitleBar = new CustomTitleBar(this, GetFormCaption(),
				maximizeBox: false, canFormBeClosed: false);
			pictureBoxOpponentAvatar.Image = opponentAvatar;
			labelOpponentName.Text = opponentName;
		}

		private void Game3on3NetworkForm_Load(object sender, EventArgs e)
		{
			Game3on3NetworkForm nextGameForm = null;
			if (gameServer != null)
				nextGameForm = new Game3on3NetworkForm(mainForm, player, gameServer, coinReward.CoinsForWin,
					roundManager, gameMode, opponentCellType,
					isTimerEnabled, isGameAssistsEnabled,
					pictureBoxOpponentAvatar.Image, labelOpponentName.Text);
			else if (gameClient != null)
				nextGameForm = new Game3on3NetworkForm(mainForm, player, gameClient, coinReward.CoinsForWin,
					roundManager, gameMode, opponentCellType,
					isTimerEnabled, isGameAssistsEnabled,
					pictureBoxOpponentAvatar.Image, labelOpponentName.Text);

			InitializeBaseGame(PictureCell_Click, nextGameForm);
			ManagePictureCellsEventHover(PictureCell_MouseEnter, PictureCell_MouseLeave, true);

			SetPlayerNamesSize(labelPlayerName, labelOpponentName);

			if (playerCellType == CellType.Cross)
				SetupMoveTransition(playerCellType, true);
			else
			{
				SetPictureBoxesEnabled(false);
				SetupMoveTransition(opponentCellType, false);
			}
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

		private void Game3on3NetworkForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			ManagePictureCellsEventHover(PictureCell_MouseEnter, PictureCell_MouseLeave, false);
		}
	}
}