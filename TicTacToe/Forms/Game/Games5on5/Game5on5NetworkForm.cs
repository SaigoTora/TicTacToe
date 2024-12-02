using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.GameClientServer.Core;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToeLibrary;

namespace TicTacToe.Forms.Game.Games5on5
{
	internal partial class Game5on5NetworkForm : BaseGame5on5Form
	{
		internal Game5on5NetworkForm(MainForm mainForm, Player player, GameServer gameServer, RoundManager roundManager,
					int coinsBet, CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled,
					Image opponentAvatar, string opponentName)
					: base(mainForm, player, gameServer, roundManager, coinsBet, playerCellType, isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			DefaultInitialize(opponentAvatar, opponentName);
		}
		internal Game5on5NetworkForm(MainForm mainForm, Player player, GameClient gameClient, RoundManager roundManager,
			int coinsBet, CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled,
			Image opponentAvatar, string opponentName)
			: base(mainForm, player, gameClient, roundManager, coinsBet, playerCellType, isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			DefaultInitialize(opponentAvatar, opponentName);
		}
		private void DefaultInitialize(Image opponentAvatar, string opponentName)
		{
			customTitleBar = new CustomTitleBar(this, CreateFormCaption(),
				maximizeBox: false, canFormBeClosed: false);
			pictureBoxOpponentAvatar.Image = opponentAvatar;
			labelOpponentName.Text = opponentName;
		}

		private void Game5on5NetworkForm_Load(object sender, EventArgs e)
		{
			Game5on5NetworkForm nextGameForm = null;
			if (gameServer != null)
				nextGameForm = new Game5on5NetworkForm(mainForm, player, gameServer, roundManager,
					coinReward.CoinsForWin, opponentCellType, isTimerEnabled, isGameAssistsEnabled,
					pictureBoxOpponentAvatar.Image, labelOpponentName.Text);
			else if (gameClient != null)
				nextGameForm = new Game5on5NetworkForm(mainForm, player, gameClient, roundManager,
					coinReward.CoinsForWin, opponentCellType, isTimerEnabled, isGameAssistsEnabled,
					pictureBoxOpponentAvatar.Image, labelOpponentName.Text);

			InitializeBaseGame(PictureCell_Click, nextGameForm);
			ManagePictureCellsEventHover(PictureCell_MouseEnter, PictureCell_MouseLeave, true);

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

		private void Game5on5NetworkForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			ManagePictureCellsEventHover(PictureCell_MouseEnter, PictureCell_MouseLeave, false);
		}
	}
}