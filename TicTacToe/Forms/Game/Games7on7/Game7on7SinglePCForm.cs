using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToeLibrary.Core;

namespace TicTacToe.Forms.Game.Games7on7
{
	internal partial class Game7on7SinglePCForm : BaseGame7on7Form
	{
		private CellType _currentCellType;

		internal Game7on7SinglePCForm(MainForm mainForm, Player player, RoundManager roundManager,
					CellType playerCellType, bool isTimerEnabled, Image opponentAvatar, string opponentName)
					: base(mainForm, player, new CoinReward(), roundManager, playerCellType, isTimerEnabled, false)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, GetFormCaption(),
				maximizeBox: false, canFormBeClosed: false);
			pictureBoxOpponentAvatar.Image = opponentAvatar;
			labelOpponentName.Text = opponentName;
		}

		private void Game7on7SinglePCForm_Load(object sender, EventArgs e)
		{
			Game7on7SinglePCForm nextGameForm = new Game7on7SinglePCForm(mainForm, player, roundManager,
			   opponentCellType, isTimerEnabled, pictureBoxOpponentAvatar.Image, labelOpponentName.Text);
			InitializeBaseGame(PictureCell_Click, nextGameForm);
			ManagePictureCellsEventHover(PictureCell_MouseEnter, PictureCell_MouseLeave, true);

			_currentCellType = playerCellType;
			if (opponentCellType == CellType.Cross)
				_currentCellType = CellType.Cross;

			SetupMoveTransition(_currentCellType, true);
		}

		private async void PictureCell_Click(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			SetPictureBoxesEnabled(false);
			await PictureBoxCell_DefaultClick(pictureBox, _currentCellType, e != EventArgs.Empty, false);
			_currentCellType = _currentCellType == CellType.Cross ? CellType.Zero : CellType.Cross;
			SetupMoveTransition(_currentCellType, true);
			SetPictureBoxesEnabled(true);
		}
		private void PictureCell_MouseEnter(object sender, EventArgs e)
		{
			if (sender is PictureBox pictureBox)
				PictureBoxCell_DefaultMouseEnter(pictureBox, _currentCellType);
		}
		private void PictureCell_MouseLeave(object sender, EventArgs e)
		{
			if (sender is PictureBox pictureBox)
				PictureBoxCell_DefaultMouseLeave(pictureBox);
		}

		private void Game7on7SinglePCForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			ManagePictureCellsEventHover(PictureCell_MouseEnter, PictureCell_MouseLeave, false);
		}
	}
}