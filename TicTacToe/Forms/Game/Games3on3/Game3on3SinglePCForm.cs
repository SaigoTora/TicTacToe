using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToeLibrary;

namespace TicTacToe.Forms.Game.Games3on3
{
	internal partial class Game3on3SinglePCForm : BaseGame3on3Form
	{
		private CellType _currentCellType;

		internal Game3on3SinglePCForm(MainForm mainForm, Player player, RoundManager roundManager,
					CellType playerCellType, bool isTimerEnabled, Image opponentAvatar, string opponentName)
					: base(mainForm, player, new CoinReward(), roundManager, playerCellType, isTimerEnabled, false)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, $"Round {roundManager.CurrentNumberOfRounds} / {roundManager.MaxNumberOfRounds}",
				maximizeBox: false, canFormBeClosed: false);
			pictureBoxOpponentAvatar.Image = opponentAvatar;
			labelOpponentName.Text = opponentName;
		}

		private void Game3on3SinglePCForm_Load(object sender, EventArgs e)
		{
			Game3on3SinglePCForm nextGameForm = new Game3on3SinglePCForm(mainForm, player, roundManager,
			   opponentCellType, isTimerEnabled, pictureBoxOpponentAvatar.Image, labelOpponentName.Text);
			InitializeBaseGame(PictureCell_Click, nextGameForm);
			ManagePictureCellsEventHover(PictureCell_MouseEnter, PictureCell_MouseLeave, true);

			SetPlayerNamesSize(labelPlayerName, labelOpponentName);

			_currentCellType = playerCellType;
			if (opponentCellType == CellType.Cross)
				_currentCellType = CellType.Cross;

			SetupMoveTransition(_currentCellType,true);
		}

		private async void PictureCell_Click(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			await PictureBoxCell_DefaultClick(pictureBox, _currentCellType, e != EventArgs.Empty, false);
			_currentCellType = _currentCellType == CellType.Cross ? CellType.Zero : CellType.Cross;
			SetupMoveTransition(_currentCellType, true);
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

		private void Game3on3SinglePCForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			ManagePictureCellsEventHover(PictureCell_MouseEnter, PictureCell_MouseLeave, false);
		}
	}
}