using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using TicTacToe.Models.CustomExceptions;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToe.Properties;
using TicTacToeLibrary;

namespace TicTacToe.Forms
{
	internal partial class GameForm : BaseForm
	{
		private const int WINNING_CELL_SHOW_DELAY = 350;
		private const float PREVIEW_OPACITY_LEVEL = 0.35f;

		private static readonly (Color Cross, Color Zero) _backColorWinningCells = (Color.FromArgb(220, 173, 162),
			Color.FromArgb(162, 190, 220));

		private readonly MainForm _mainForm;
		private readonly Field _field = new Field(3, 3);
		private readonly Player _player;
		private readonly Bot _bot;
		private readonly RoundManager _roundManager;
		private readonly PictureBox[,] _pictureCells;
		private readonly CustomTitleBar _customTitleBar;
		private readonly PictureBoxEventHandlers _pictureBoxEventHandlers = new PictureBoxEventHandlers();

		private readonly bool _isBotMoveFirst = false;
		private readonly CellType _playerCellType;
		private readonly CellType _botCellType;

		private readonly (Bitmap Cross, Bitmap Zero) _bitmapPreviewCell;
		private readonly (string Cross, string Zero) _tagPreviewCell = ("Preview Cross", "Preview_Zero");

		private CancellationTokenSource _cancellationTokenSource;
		private bool _isFormClosingForNextRound = false;
		private bool _wasPressedButtonBack = false;

		internal GameForm(MainForm mainForm, Player player, Bot bot, RoundManager roundManager, bool isBotFirst)
		{
			InitializeComponent();

			_player = player;
			_bot = bot;
			_isBotMoveFirst = isBotFirst;
			_roundManager = roundManager;
			_mainForm = mainForm;

			_customTitleBar = new CustomTitleBar(this, $"Round {_roundManager.CurrentNumberOfRounds} / {_roundManager.MaxNumberOfRounds}",
				maximizeBox: false, canFormBeClosed: false);

			_botCellType = isBotFirst ? CellType.Cross : CellType.Zero;
			_playerCellType = isBotFirst ? CellType.Zero : CellType.Cross;

			try
			{ player.DeductCoins(bot.Difficulty); }
			catch (NotEnoughCoinsToStartGameException exception)
			{
				CustomMessageBox.Show(exception.Message, "Not enough coins", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				Close();
			}

			_pictureCells = new[,]{ { pictureBoxCell1, pictureBoxCell2, pictureBoxCell3 },
									{ pictureBoxCell4, pictureBoxCell5, pictureBoxCell6 },
									{ pictureBoxCell7, pictureBoxCell8, pictureBoxCell9 } };

			_bitmapPreviewCell.Cross = Resources.cross.ChangeOpacity(PREVIEW_OPACITY_LEVEL);
			_bitmapPreviewCell.Zero = Resources.zero.ChangeOpacity(PREVIEW_OPACITY_LEVEL);
		}

		private void GameForm_Load(object sender, EventArgs e)
		{
			BackColor = Color.FromArgb(20, 20, 20);
			BackColor = _player.Preferences.BackgroundGame.Color;
			SelectControlsColor();

			pictureBoxPlayerAvatar.Image = _player.Preferences.Avatar.Image;
			SetBotAvatar();

			labelPlayerName.Text = _player.Name;
			labelBotName.Text = _bot.Name;
			SetPlayerNameSize(labelPlayerName);
			SetPlayerNameSize(labelBotName);

			labelScore.Text = $"{_roundManager.NumberOfWinsFirstPlayer} : {_roundManager.NumberOfWinsSecondPlayer}";

			if (_isBotMoveFirst)
				_ = BotMove();
			else
				StartTimerToMove();
		}

		private void SetPlayerNameSize(Label label)
		{
			if (label.Text.Length > 15)
				label.Font = new Font(label.Font.FontFamily, 12);
		}
		private void SetBotAvatar()
		{
			if (_bot.Difficulty == Difficulty.Easy)
				pictureBoxBotAvatar.Image = Resources.botEasy;
			else if (_bot.Difficulty == Difficulty.Medium)
				pictureBoxBotAvatar.Image = Resources.botMedium;
			else if (_bot.Difficulty == Difficulty.Hard)
				pictureBoxBotAvatar.Image = Resources.botHard;
			else if (_bot.Difficulty == Difficulty.Impossible)
				pictureBoxBotAvatar.Image = Resources.botImpossible;
		}
		private void SelectControlsColor()
		{
			double avgBackColor = BackColor.R * 0.299 + BackColor.G * 0.587 + BackColor.B * 0.114;
			if (avgBackColor < byte.MaxValue / 2)
			{
				SetLabelsColor(Color.White);
				SetLinesColor(Color.FromArgb(200, 200, 200));
				progressBarTimer.Image = Resources.clockWhite;
			}
			else
			{
				SetLabelsColor(Color.Black);
				SetLinesColor(Color.FromArgb(20, 20, 20));
				progressBarTimer.Image = Resources.clockBlack;
			}

		}
		private void SetLabelsColor(Color labelColor)
		{
			labelPlayerName.ForeColor = labelColor;
			labelScore.ForeColor = labelColor;
			labelBotName.ForeColor = labelColor;
		}
		private void SetLinesColor(Color lineColor)
		{
			pictureBoxLine1.BackColor = lineColor;
			pictureBoxLine2.BackColor = lineColor;
			pictureBoxLine3.BackColor = lineColor;
			pictureBoxLine4.BackColor = lineColor;
		}

		private Cell FindIndexPictureBoxCell(PictureBox pictureBox)
		{
			Cell result = new Cell();

			for (int i = 0; i < _pictureCells.GetLength(0); i++)
				for (int j = 0; j < _pictureCells.GetLength(1); j++)
				{
					if (_pictureCells[i, j] == pictureBox)
					{
						result.row = i;
						result.column = j;
					}
				}

			return result;
		}

		private async void PictureBoxCell_Click(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			StopTimerToMove();
			await Task.Delay(10);// Add a delay to complete the current execution of the timer

			SetPictureBoxesEnabled(false);
			Cell cell = FindIndexPictureBoxCell(pictureBox);
			_field.FillCell(cell, _playerCellType);

			FillCellWithImage(cell, PlayerType.Human);

			if (_field.IsGameEnd())
				await FinishGame();
			else
				await BotMove();
		}
		private void FillCellWithImage(Cell cell, PlayerType playerType)
		{
			PictureBox pictureBox = _pictureCells[cell.row, cell.column];
			pictureBox.Tag = null;
			pictureBox.Cursor = Cursors.Default;

			if (_isBotMoveFirst && playerType == PlayerType.Human || !_isBotMoveFirst && playerType == PlayerType.Bot)
				pictureBox.Image = Resources.zero;
			else
				pictureBox.Image = Resources.cross;

			pictureBox.Click -= PictureBoxCell_Click;

			if (playerType == PlayerType.Human)// Subscribe to one-time event handler
				pictureBox.MouseLeave += EnableHoverAfterMouseLeave;
			else
				_pictureBoxEventHandlers.SubscribeToHoverPictureBoxes(pictureBox);
		}
		private void EnableHoverAfterMouseLeave(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			_pictureBoxEventHandlers.SubscribeToHoverPictureBoxes(pictureBox);
			pictureBox.MouseLeave -= EnableHoverAfterMouseLeave;
		}

		private async Task BotMove()
		{
			const int BOT_MOVE_DELAY = 600;

			SetPictureBoxesEnabled(false);

			Cell botMove = _bot.Move(_field, _botCellType);
			_field.FillCell(botMove, _botCellType);
			await Task.Delay(BOT_MOVE_DELAY);
			FillCellWithImage(botMove, PlayerType.Bot);

			if (_field.IsGameEnd())
				await FinishGame();

			SetPictureBoxesEnabled(true);
			StartTimerToMove();
		}
		private void SetPictureBoxesEnabled(bool enabled)
		{
			for (int i = 0; i < _pictureCells.GetLength(0); i++)
				for (int j = 0; j < _pictureCells.GetLength(1); j++)
					_pictureCells[i, j].Enabled = enabled;
		}

		private void StartTimerToMove()
		{
			progressBarTimer.Visible = true;
			_cancellationTokenSource?.Cancel();
			_cancellationTokenSource = new CancellationTokenSource();

			_ = TimerForMove(_cancellationTokenSource.Token);
		}
		private void StopTimerToMove()
		{
			progressBarTimer.Visible = false;
			_cancellationTokenSource?.Cancel();
		}
		private async Task TimerForMove(CancellationToken cancellationToken)
		{
			const int TIMER_DELAY = 900;

			progressBarTimer.Maximum = TIMER_DELAY;
			progressBarTimer.Value = TIMER_DELAY;
			for (int i = progressBarTimer.Maximum; i >= 0; i--)
			{
				if (cancellationToken.IsCancellationRequested || IsDisposed)
					return;

				progressBarTimer.Value = i;
				progressBarTimer.ProgressColor = GetColorForPercentage((double)i / TIMER_DELAY);
				await Task.Delay(1);
			}

			Cell selectedCell = SelectCellAfterInactivity();

			if (cancellationToken.IsCancellationRequested || IsDisposed)
				return;

			PictureBoxCell_Click(_pictureCells[selectedCell.row, selectedCell.column], EventArgs.Empty);
		}
		private Color GetColorForPercentage(double percentage)
		{
			int r, g, b;

			if (percentage > 0.5)
			{// Green to yellow
				r = (int)(255 * (1 - percentage) * 2);
				g = 255;
				b = 0;
			}
			else
			{// Yellow to red
				r = 255;
				g = (int)(255 * percentage * 2);
				b = 0;
			}

			return Color.FromArgb(r, g, b);
		}
		private Cell SelectCellAfterInactivity()
		{
			for (int i = 0; i < _pictureCells.GetLength(0); i++)
				for (int j = 0; j < _pictureCells.GetLength(1); j++)
					if (_isBotMoveFirst && _pictureCells[i, j].Tag?.ToString() == _tagPreviewCell.Zero
						|| !_isBotMoveFirst && _pictureCells[i, j].Tag?.ToString() == _tagPreviewCell.Cross)
						return new Cell(i, j);

			return _field.GetRandomEmptyCell();
		}

		private async Task FinishGame()
		{
			_player.ReturnCoins();
			SetPictureBoxesEnabled(false);

			await ShowWinningCells(_field.Winner);
			await Task.Delay(WINNING_CELL_SHOW_DELAY);
			OpenResultForm();

			_isFormClosingForNextRound = true;
			if (_roundManager.IsLastRound() || _wasPressedButtonBack)
				_mainForm.Show();
			else
			{
				_roundManager.AddRound();

				GameForm gameForm = new GameForm(_mainForm, _player, _bot, _roundManager, !_isBotMoveFirst);
				if (!gameForm.IsDisposed)// If a player have enough coins to play
					gameForm.Show();
				else
					_isFormClosingForNextRound = false;
			}
			Close();
		}
		private void OpenResultForm()
		{
			PlayerType winner = PlayerType.None;
			if (_field.Winner == _playerCellType)
			{
				winner = PlayerType.Human;
				_roundManager.AddWinToTheFirstPlayer();
			}
			if (_field.Winner == _botCellType)
			{
				winner = PlayerType.Bot;
				_roundManager.AddWinToTheSecondPlayer();
			}

			void backToMainForm(object s, EventArgs e)
			{
				_wasPressedButtonBack = true;
				_isFormClosingForNextRound = false;
				Close();
			}
			GameResultForm resultForm = new GameResultForm(_player, winner, _bot.Difficulty, _roundManager.IsLastRound(), backToMainForm);
			resultForm.ShowDialog();
		}
		private async Task ShowWinningCells(CellType winner)
		{
			const int WINNING_CELL_SIZE_SCALER = 15;

			if (winner == CellType.None)
				return;

			PictureBox pictureBox;
			for (int i = 0; i < _field.WinningCells.Length; i++)
			{
				await Task.Delay(WINNING_CELL_SHOW_DELAY);

				pictureBox = _pictureCells[_field.WinningCells[i].row, _field.WinningCells[i].column];

				pictureBox.Size = new Size(pictureBox.Width + WINNING_CELL_SIZE_SCALER, pictureBox.Height + WINNING_CELL_SIZE_SCALER);
				pictureBox.Location = new Point(pictureBox.Location.X - WINNING_CELL_SIZE_SCALER / 2, pictureBox.Location.Y - WINNING_CELL_SIZE_SCALER / 2);

				if (winner == CellType.Cross)
					pictureBox.BackColor = _backColorWinningCells.Cross;
				else
					pictureBox.BackColor = _backColorWinningCells.Zero;
			}
		}

		private void PictureBoxCell_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox) || pictureBox.Image != null)
				return;

			if (_isBotMoveFirst)
			{
				pictureBox.Image = _bitmapPreviewCell.Zero;
				pictureBox.Tag = _tagPreviewCell.Zero;
			}
			else
			{
				pictureBox.Image = _bitmapPreviewCell.Cross;
				pictureBox.Tag = _tagPreviewCell.Cross;
			}
		}
		private void PictureBoxCell_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			if (pictureBox.Image == _bitmapPreviewCell.Cross || pictureBox.Image == _bitmapPreviewCell.Zero)
			{
				pictureBox.Image = null;
				pictureBox.Tag = null;
			}
		}

		private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			StopTimerToMove();

			_pictureBoxEventHandlers.UnsubscribeAll();
			_customTitleBar.Dispose();

			if (!_isFormClosingForNextRound)
				_mainForm.Show();
		}
	}
}