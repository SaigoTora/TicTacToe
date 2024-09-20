using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using TicTacToe.Models.CustomExceptions;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.Utilities;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToe.Properties;
using TicTacToeLibrary;

namespace TicTacToe.Forms
{
	internal partial class GameForm : BaseForm
	{
		private const int TIMER_MOVE_DELAY = 900;
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
		private readonly List<PictureBox> _sequenceSelectedCells;
		private readonly CustomTitleBar _customTitleBar;
		private readonly PictureBoxEventHandlers _pictureBoxEventHandlers = new PictureBoxEventHandlers();

		private readonly bool _isBotMoveFirst = false;
		private readonly CellType _playerCellType;
		private readonly CellType _botCellType;

		private readonly (Bitmap Cross, Bitmap Zero) _bitmapPreviewCell;
		private readonly (string Cross, string Zero) _tagPreviewCell = ("Preview Cross", "Preview_Zero");

		private CancellationTokenSource _cancellationTokenSourceTimer;
		private CancellationTokenSource _cancellationTokenSourceHint;
		private PictureBox _pictureBoxCellHint;

		private bool _wasAssistUsed = false;
		private bool _isCellHintHovered = false;
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
			_sequenceSelectedCells = new List<PictureBox>(_pictureCells.Length);

			_bitmapPreviewCell.Cross = Resources.cross.ChangeOpacity(PREVIEW_OPACITY_LEVEL);
			_bitmapPreviewCell.Zero = Resources.zero.ChangeOpacity(PREVIEW_OPACITY_LEVEL);
		}

		private void GameForm_Load(object sender, EventArgs e)
		{
			Color gameAssistHoverColor = Color.FromArgb(150, 229, 158, 31);

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

			_pictureBoxEventHandlers.SubscribeToHover(gameAssistHoverColor, pictureBoxUndoMove, pictureBoxHint, pictureBoxSurrender);

			if (_isBotMoveFirst)
				_ = BotMoveAsync();
			else
			{
				ChangeGameViewVisibility(true);
				StartTimerToMove();
			}
		}

		#region Initialization
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
				SetPicturesColor(Color.FromArgb(200, 200, 200));
				progressBarCircleTimer.Image = Resources.clockWhite;
			}
			else
			{
				SetLabelsColor(Color.Black);
				SetPicturesColor(Color.FromArgb(20, 20, 20));
				progressBarCircleTimer.Image = Resources.clockBlack;
			}

		}
		private void SetLabelsColor(Color labelColor)
		{
			labelPlayerName.ForeColor = labelColor;
			labelScore.ForeColor = labelColor;
			labelBotName.ForeColor = labelColor;
		}
		private void SetPicturesColor(Color lineColor)
		{
			pictureBoxLine1.BackColor = lineColor;
			pictureBoxLine2.BackColor = lineColor;
			pictureBoxLine3.BackColor = lineColor;
			pictureBoxLine4.BackColor = lineColor;
			buttonChangeView.IconColor = lineColor;
		}
		#endregion

		#region Actions of the game
		private void FillCellWithImage(Cell cell, PlayerType playerType, bool wasButtonClick)
		{
			PictureBox pictureBox = _pictureCells[cell.row, cell.column];
			_sequenceSelectedCells.Add(pictureBox);
			pictureBox.Tag = null;
			pictureBox.Cursor = Cursors.Default;

			if (_isBotMoveFirst && playerType == PlayerType.Human || !_isBotMoveFirst && playerType == PlayerType.Bot)
				pictureBox.Image = Resources.zero;
			else
				pictureBox.Image = Resources.cross;

			pictureBox.Click -= PictureBoxCell_Click;

			if (playerType == PlayerType.Human && wasButtonClick)// Subscribe to one-time event handler
				pictureBox.MouseLeave += EnableHoverAfterMouseLeave;
			else
				_pictureBoxEventHandlers.SubscribeToHover(pictureBox);
		}
		private async void PictureBoxCell_Click(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			_wasAssistUsed = false;
			_isCellHintHovered = false;
			ChangeGameViewVisibility(false, needToChangeScore: false);
			StopTimerToMove();
			StopGivingHint();
			await Task.Delay(10);// Add a delay to complete the current execution of the timer

			SetPictureBoxesEnabled(false);
			Cell cell = FindIndexPictureBoxCell(pictureBox);
			_field.FillCell(cell, _playerCellType);

			FillCellWithImage(cell, PlayerType.Human, e != EventArgs.Empty);

			if (_field.IsGameEnd())
				await FinishGameAsync();
			else
				await BotMoveAsync();
		}
		private async Task BotMoveAsync()
		{
			const int BOT_MOVE_DELAY = 600;

			SetPictureBoxesEnabled(false);

			Cell botMove = _bot.Move(_field, _botCellType);
			_field.FillCell(botMove, _botCellType);
			await Task.Delay(BOT_MOVE_DELAY);
			FillCellWithImage(botMove, PlayerType.Bot, false);

			if (_field.IsGameEnd())
				await FinishGameAsync();

			SetPictureBoxesEnabled(true);
			ChangeGameViewVisibility(true);
			StartTimerToMove();
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
		private void SetPictureBoxesEnabled(bool enabled)
		{
			for (int i = 0; i < _pictureCells.GetLength(0); i++)
				for (int j = 0; j < _pictureCells.GetLength(1); j++)
					_pictureCells[i, j].Enabled = enabled;
		}

		private void EnableHoverAfterMouseLeave(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			_pictureBoxEventHandlers.SubscribeToHover(pictureBox);
			pictureBox.MouseLeave -= EnableHoverAfterMouseLeave;
		}
		private void PictureBoxCell_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			if (pictureBox == _pictureBoxCellHint)
				_isCellHintHovered = true;

			if (pictureBox.Image != null)
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

			if (pictureBox == _pictureBoxCellHint)
				_isCellHintHovered = false;

			if (pictureBox.Image == _bitmapPreviewCell.Cross || pictureBox.Image == _bitmapPreviewCell.Zero)
			{
				pictureBox.Image = null;
				pictureBox.Tag = null;
			}
		}
		#endregion

		#region Timer
		private void StartTimerToMove()
		{
			_cancellationTokenSourceTimer?.Cancel();
			_cancellationTokenSourceTimer = new CancellationTokenSource();

			_ = TimerForMoveAsync(_cancellationTokenSourceTimer.Token);
		}
		private void StopTimerToMove()
			=> _cancellationTokenSourceTimer?.Cancel();
		private async Task TimerForMoveAsync(CancellationToken cancellationToken)
		{
			progressBarCircleTimer.Maximum = TIMER_MOVE_DELAY;
			progressBarTimer.Maximum = TIMER_MOVE_DELAY;

			progressBarCircleTimer.Value = progressBarCircleTimer.Maximum;
			progressBarTimer.Value = progressBarTimer.Maximum;
			Color currentColor;
			for (int i = TIMER_MOVE_DELAY; i >= 0; i--)
			{
				if (cancellationToken.IsCancellationRequested || IsDisposed)
					return;

				currentColor = GetColorForPercentage((double)i / TIMER_MOVE_DELAY);
				progressBarCircleTimer.Value = i;
				progressBarTimer.Value = i;

				progressBarCircleTimer.ProgressColor = currentColor;
				progressBarTimer.ProgressColor = currentColor;
				await Task.Delay(1);
			}

			Cell selectedCell = SelectCellAfterInactivity();
			StopGivingHint();

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
			if (_pictureBoxCellHint != null)
			{
				Cell cellHint = FindIndexPictureBoxCell(_pictureBoxCellHint);
				if (_field.GetCell(cellHint) == CellType.None)
					return cellHint;
			}

			for (int i = 0; i < _pictureCells.GetLength(0); i++)
				for (int j = 0; j < _pictureCells.GetLength(1); j++)
					if (_isBotMoveFirst && _pictureCells[i, j].Tag?.ToString() == _tagPreviewCell.Zero
						|| !_isBotMoveFirst && _pictureCells[i, j].Tag?.ToString() == _tagPreviewCell.Cross)
						return new Cell(i, j);

			return _field.GetRandomEmptyCell();
		}
		#endregion

		#region End of the game
		private async Task FinishGameAsync()
		{
			_player.ReturnCoins();
			SetPictureBoxesEnabled(false);

			await ShowWinningCellsAsync(_field.Winner);
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
		private async Task ShowWinningCellsAsync(CellType winner)
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
		#endregion

		#region Game view
		private void ButtonChangeView_Click(object sender, EventArgs e)
		{
			ActiveControl = null;

			ChangeGameViewVisibility(false, false);
			switch (_player.Preferences.GameView)
			{
				case GameView.Score:
					_player.Preferences.GameView = GameView.AssistTools;
					SetGameAssistsViewVisibility(true);
					break;
				case GameView.AssistTools:
					_player.Preferences.GameView = GameView.Score;
					SetScoreViewVisibility(true);
					break;
				default:
					throw new InvalidOperationException
						($"Unknown game view: {_player.Preferences.GameView.GetType().Name}");
			}
		}
		private void ChangeGameViewVisibility(bool visible, bool needToChangeButton = true, bool needToChangeScore = true)
		{
			if (needToChangeButton)
				buttonChangeView.Visible = visible;

			switch (_player.Preferences.GameView)
			{
				case GameView.Score:
					SetScoreViewVisibility(visible, needToChangeScore);
					break;
				case GameView.AssistTools:
					SetGameAssistsViewVisibility(visible);
					break;
				default:
					throw new InvalidOperationException
						($"Unknown game view: {_player.Preferences.GameView.GetType().Name}");
			}
		}

		private void SetScoreViewVisibility(bool visible, bool needToChangeScore = true)
		{
			progressBarCircleTimer.Visible = visible;
			if (needToChangeScore)
				labelScore.Visible = visible;
		}
		private void SetGameAssistsViewVisibility(bool visible)
		{
			progressBarTimer.Visible = visible;
			if (_field.CountFilledCells() >= 2)
				if (!visible || !_wasAssistUsed && visible)
				{
					flpGameAssistants.Visible = visible;
					SetGameAssistsVisibility(visible);
				}
		}
		private void SetGameAssistsVisibility(bool visible)
		{
			bool actualVisible;
			foreach (var item in _player.CountableItemsInventory.GetItems())
			{
				actualVisible = visible && item.Count > 0;

				switch (item.Type)
				{
					case GameAssistType.UndoMove:
						pictureBoxUndoMove.Visible = actualVisible;
						break;
					case GameAssistType.Hint:
						pictureBoxHint.Visible = actualVisible;
						break;
					case GameAssistType.Surrender:
						pictureBoxSurrender.Visible = actualVisible;
						break;
					default:
						throw new InvalidOperationException
							($"Unknown item type: {item.Type.GetType().Name}");
				}
			}
		}
		#endregion

		#region Game assistants
		private async void PictureBoxUndoMove_Click(object sender, EventArgs e)
		{
			int UNDO_MOVE_DELAY = 400;

			_wasAssistUsed = true;
			_player.CountableItemsInventory.UseItem(GameAssistType.UndoMove);
			ChangeGameViewVisibility(false);
			StopTimerToMove();

			UndoLastMove();
			await Task.Delay(UNDO_MOVE_DELAY);
			UndoLastMove();
			ChangeGameViewVisibility(true);
			StartTimerToMove();
			TryToIndicateLastGameAssist(_player.CountableItemsInventory.GetItem(GameAssistType.UndoMove));
		}
		private void UndoLastMove()
		{
			if (_sequenceSelectedCells.Count <= 0)
				return;

			PictureBox pictureBoxLastMove = _sequenceSelectedCells[_sequenceSelectedCells.Count - 1];

			Cell cellLastMove = FindIndexPictureBoxCell(pictureBoxLastMove);
			_field.FillCell(cellLastMove, CellType.None);
			pictureBoxLastMove.Image = null;
			pictureBoxLastMove.Cursor = Cursors.Hand;

			pictureBoxLastMove.MouseLeave -= EnableHoverAfterMouseLeave;
			_pictureBoxEventHandlers.Unsubscribe(pictureBoxLastMove);
			pictureBoxLastMove.Click += PictureBoxCell_Click;

			_sequenceSelectedCells.RemoveAt(_sequenceSelectedCells.Count - 1);
		}

		private void PictureBoxHint_Click(object sender, EventArgs e)
		{
			_wasAssistUsed = true;
			_player.CountableItemsInventory.UseItem(GameAssistType.Hint);
			ChangeGameViewVisibility(false);
			Cell cellHint = PerfectMoveFinder.FindCell(_field, _playerCellType);
			_pictureBoxCellHint = _pictureCells[cellHint.row, cellHint.column];

			_cancellationTokenSourceHint?.Cancel();
			_cancellationTokenSourceHint = new CancellationTokenSource();
			_ = StartGivingHintAsync(_cancellationTokenSourceHint.Token);
			ChangeGameViewVisibility(true);
			TryToIndicateLastGameAssist(_player.CountableItemsInventory.GetItem(GameAssistType.Hint));
		}
		private async Task StartGivingHintAsync(CancellationToken cancellationToken)
		{
			const int FLICKER_DELAY = 500;
			Bitmap flickerImage = _playerCellType == CellType.Cross ?
				_bitmapPreviewCell.Cross : _bitmapPreviewCell.Zero;

			while (!cancellationToken.IsCancellationRequested && !IsDisposed)
			{
				if (!_isCellHintHovered)
					ShowHint(flickerImage);
				await Task.Delay(FLICKER_DELAY, cancellationToken);
				if (!_isCellHintHovered)
					HideHint();
				await Task.Delay(FLICKER_DELAY, cancellationToken);
			}
		}
		private void StopGivingHint()
		{
			_cancellationTokenSourceHint?.Cancel();
			HideHint();
			_pictureBoxCellHint = null;
		}
		private void ShowHint(Bitmap flickerImage)
		{
			if (_pictureBoxCellHint != null)
				_pictureBoxCellHint.Image = flickerImage;
		}
		private void HideHint()
		{
			if (_pictureBoxCellHint != null)
				_pictureBoxCellHint.Image = null;
		}

		private void PictureBoxSurrender_Click(object sender, EventArgs e)
		{
			_wasAssistUsed = true;
			_player.CountableItemsInventory.UseItem(GameAssistType.Surrender);

			StopTimerToMove();
			ChangeGameViewVisibility(false, needToChangeScore: false);
			_ = FinishGameAsync();
		}

		private void TryToIndicateLastGameAssist(CountableItem item)
		{
			if (item != null && item.Count <= 0)
				CustomMessageBox.Show($"The last helper \"{item.Name}\" was used.",
					"Information", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information);
		}
		#endregion

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