using FontAwesome.Sharp;
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

namespace TicTacToe.Forms.Game
{
	internal partial class BaseGameForm : BaseForm
	{
		private const int WINNING_CELL_SHOW_DELAY = 350;

		protected readonly MainForm mainForm;
		protected readonly Player player;
		protected readonly Bot bot;
		protected readonly RoundManager roundManager;
		protected Field field;
		private GameFormInfo _gameInfo;

		private List<PictureBox> _sequenceSelectedCells;
		private readonly PictureBoxEventHandlers _pictureBoxEventHandlers = new PictureBoxEventHandlers();

		protected readonly CellType playerCellType, opponentCellType;
		private readonly (Bitmap Cross, Bitmap Zero) _bitmapPreviewCell;
		private readonly (string Cross, string Zero) _tagPreviewCell = ("Preview Cross", "Preview Zero");

		private CancellationTokenSource _cancellationTokenSourceTimer,
			_cancellationTokenSourceHint;
		private PictureBox _pictureBoxCellHint;
		private bool _wasAssistUsed, _isCellHintHovered,
			_isFormClosingForNextRound, _wasPressedButtonBack;

		private BaseGameForm()
		{ InitializeComponent(); }
		internal BaseGameForm(MainForm mainForm, Player player, Bot bot, RoundManager roundManager, CellType playerCellType)
			: this(mainForm, player, roundManager, playerCellType)
		{ this.bot = bot; }
		internal BaseGameForm(MainForm mainForm, Player player, RoundManager roundManager, CellType playerCellType)
		{
			const float PREVIEW_OPACITY_LEVEL = 0.35f;

			InitializeComponent();

			this.player = player;
			this.roundManager = roundManager;
			this.mainForm = mainForm;

			this.playerCellType = playerCellType;
			opponentCellType = playerCellType == CellType.Cross ? CellType.Zero : CellType.Cross;

			_bitmapPreviewCell.Cross = Resources.cross.ChangeOpacity(PREVIEW_OPACITY_LEVEL);
			_bitmapPreviewCell.Zero = Resources.zero.ChangeOpacity(PREVIEW_OPACITY_LEVEL);
		}

		#region Initialization
		protected void InitializeGame(GameFormInfo gameFormInfo)
		{
			_gameInfo = gameFormInfo;

			_gameInfo.Score.Text = $"{roundManager.NumberOfWinsFirstPlayer} : {roundManager.NumberOfWinsSecondPlayer}";
			_sequenceSelectedCells = new List<PictureBox>(_gameInfo.PictureCells.Length);
			BackColor = player.Preferences.BackgroundGame.Color;
			InitializePlayerInfo(_gameInfo.PlayerInfo);
			InitializeGameAssists(_gameInfo.GameAssistsInfo);
		}
		private void InitializePlayerInfo(PlayerInfo playerInfo)
		{
			playerInfo.Avatar.Image = player.Preferences.Avatar.Image;
			playerInfo.Name.Text = player.Name;
		}
		private void InitializeGameAssists(GameAssistsInfo gameAssistsInfo)
		{
			Color gameAssistHoverColor = Color.FromArgb(150, 229, 158, 31);

			ManageGameAssistsEvents(true);
			_pictureBoxEventHandlers.SubscribeToHover(gameAssistHoverColor,
				gameAssistsInfo.UndoMove, gameAssistsInfo.Hint, gameAssistsInfo.Surrender);
		}

		private void ManageGameAssistsEvents(bool subscribe)
		{
			if (subscribe)
			{
				_gameInfo.GameAssistsInfo.UndoMove.Click += PictureBoxUndoMove_Click;
				_gameInfo.GameAssistsInfo.Hint.Click += PictureBoxHint_Click;
				_gameInfo.GameAssistsInfo.Surrender.Click += PictureBoxSurrender_Click;
				_gameInfo.GameAssistsInfo.ButtonChangeView.Click += ButtonChangeView_Click;
				_gameInfo.GameAssistsInfo.ButtonChangeView.MouseEnter += ButtonChangeView_MouseEnter;
			}
			else
			{
				_gameInfo.GameAssistsInfo.UndoMove.Click -= PictureBoxUndoMove_Click;
				_gameInfo.GameAssistsInfo.Hint.Click -= PictureBoxHint_Click;
				_gameInfo.GameAssistsInfo.Surrender.Click -= PictureBoxSurrender_Click;
				_gameInfo.GameAssistsInfo.ButtonChangeView.Click -= ButtonChangeView_Click;
				_gameInfo.GameAssistsInfo.ButtonChangeView.MouseEnter -= ButtonChangeView_MouseEnter;
			}
		}

		protected void TryToDeductCoins(Difficulty botDifficulty)
		{
			try
			{ player.DeductCoins(botDifficulty); }
			catch (NotEnoughCoinsToStartGameException exception)
			{
				CustomMessageBox.Show(exception.Message, "Not enough coins", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				Close();
			}
		}
		protected Bitmap GetBotAvatar(Difficulty difficulty)
		{
			switch (difficulty)
			{
				case Difficulty.Easy:
					return Resources.botEasy;
				case Difficulty.Medium:
					return Resources.botMedium;
				case Difficulty.Hard:
					return Resources.botHard;
				case Difficulty.Impossible:
					return Resources.botImpossible;
				default:
					throw new InvalidOperationException($"Unknown difficulty: {difficulty}");
			}
		}

		protected void SetColorForControls(Label[] labels, Control[] otherControls)
		{
			(Color darkLabels, Color lightLabels) = (Color.White, Color.Black);
			(Color darkControls, Color lightControls) = (Color.FromArgb(200, 200, 200), Color.FromArgb(20, 20, 20));

			double avgBackColor = BackColor.R * 0.299 + BackColor.G * 0.587 + BackColor.B * 0.114;
			if (avgBackColor < byte.MaxValue / 2)
			{// If the background color of the form is dark enough.
				SetLabelsForeColor(labels, darkLabels);
				SetControlsBackColor(otherControls, darkControls);
				_gameInfo.TimerInfo.CircleTimer.Image = Resources.clockWhite;
			}
			else
			{
				SetLabelsForeColor(labels, lightLabels);
				SetControlsBackColor(otherControls, lightControls);
				_gameInfo.TimerInfo.CircleTimer.Image = Resources.clockBlack;
			}

		}
		private void SetLabelsForeColor(Label[] labels, Color labelColor)
		{
			for (int i = 0; i < labels.Length; i++)
				labels[i].ForeColor = labelColor;
		}
		private void SetControlsBackColor(Control[] controls, Color controlColor)
		{
			for (int i = 0; i < controls.Length; i++)
			{
				if (controls[i] is IconButton iconButton)
					iconButton.IconColor = controlColor;
				else
					controls[i].BackColor = controlColor;
			}
		}
		#endregion

		#region Actions of the game
		protected async Task PictureBoxCell_DefaultClick(PictureBox pictureBox, bool wasClicked)
		{
			_wasAssistUsed = false;
			_isCellHintHovered = false;
			ChangeGameViewVisibility(false, needToChangeScore: false);
			StopTimerToMove();
			StopGivingHint();
			await Task.Delay(10);// Add a delay to complete the current execution of the timer

			SetPictureBoxesEnabled(false);
			Cell cell = FindIndexPictureBoxCell(pictureBox);
			field.FillCell(cell, playerCellType);

			FillCellWithImage(cell, playerCellType, wasClicked);

			if (field.IsGameEnd())
				await FinishGameAsync();
			else if (bot != null)
				await BotMoveAsync();
		}
		protected async Task BotMoveAsync()
		{
			const int BOT_MOVE_DELAY = 600;

			SetPictureBoxesEnabled(false);

			Cell botMove = bot.Move(field, opponentCellType);
			field.FillCell(botMove, opponentCellType);
			await Task.Delay(BOT_MOVE_DELAY);

			FillCellWithImage(botMove, opponentCellType, false);

			if (field.IsGameEnd())
				await FinishGameAsync();

			SetPictureBoxesEnabled(true);
			ChangeGameViewVisibility(true);
			StartTimerToMove();
		}
		private void FillCellWithImage(Cell cell, CellType cellType, bool wasClicked)
		{
			PictureBox pictureBox = _gameInfo.PictureCells[cell.row, cell.column];
			_sequenceSelectedCells.Add(pictureBox);
			pictureBox.Tag = null;
			pictureBox.Cursor = Cursors.Default;

			if (cellType == CellType.Zero)
				pictureBox.Image = Resources.zero;
			else if (cellType == CellType.Cross)
				pictureBox.Image = Resources.cross;
			else
				throw new InvalidOperationException($"Unknown cell type: {cellType}");

			pictureBox.Click -= _gameInfo.CellClick;

			if (wasClicked)// Subscribe to one-time event handler
				pictureBox.MouseLeave += EnableHoverAfterMouseLeave;
			else
				_pictureBoxEventHandlers.SubscribeToHover(pictureBox);
		}

		private Cell FindIndexPictureBoxCell(PictureBox pictureBox)
		{
			Cell result = new Cell();

			for (int i = 0; i < _gameInfo.PictureCells.GetLength(0); i++)
				for (int j = 0; j < _gameInfo.PictureCells.GetLength(1); j++)
					if (_gameInfo.PictureCells[i, j] == pictureBox)
					{
						result.row = i;
						result.column = j;
					}

			return result;
		}
		private void SetPictureBoxesEnabled(bool enabled)
		{
			for (int i = 0; i < _gameInfo.PictureCells.GetLength(0); i++)
				for (int j = 0; j < _gameInfo.PictureCells.GetLength(1); j++)
					_gameInfo.PictureCells[i, j].Enabled = enabled;
		}

		protected void PictureBoxCell_DefaultMouseEnter(PictureBox pictureBox)
		{
			if (pictureBox == _pictureBoxCellHint)
				_isCellHintHovered = true;

			if (pictureBox.Image != null)
				return;

			switch (playerCellType)
			{
				case CellType.Cross:
					pictureBox.Image = _bitmapPreviewCell.Cross;
					pictureBox.Tag = _tagPreviewCell.Cross;
					break;
				case CellType.Zero:
					pictureBox.Image = _bitmapPreviewCell.Zero;
					pictureBox.Tag = _tagPreviewCell.Zero;
					break;
				default:
					throw new InvalidOperationException($"Unknown cell type: {playerCellType}");
			}
		}
		protected void PictureBoxCell_DefaultMouseLeave(PictureBox pictureBox)
		{
			if (pictureBox == _pictureBoxCellHint)
				_isCellHintHovered = false;

			if (pictureBox.Image == _bitmapPreviewCell.Cross || pictureBox.Image == _bitmapPreviewCell.Zero)
			{
				pictureBox.Image = null;
				pictureBox.Tag = null;
			}
		}
		private void EnableHoverAfterMouseLeave(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			_pictureBoxEventHandlers.SubscribeToHover(pictureBox);
			pictureBox.MouseLeave -= EnableHoverAfterMouseLeave;
		}
		#endregion

		#region End of the game
		private async Task FinishGameAsync()
		{
			player.ReturnCoins();
			SetPictureBoxesEnabled(false);

			await ShowWinningCellsAsync(field.Winner);
			await Task.Delay(WINNING_CELL_SHOW_DELAY);
			OpenResultForm();

			_isFormClosingForNextRound = true;
			if (roundManager.IsLastRound() || _wasPressedButtonBack)
				mainForm.Show();
			else
			{
				roundManager.AddRound();

				BaseGameForm nextGameForm = _gameInfo.NextGameForm;
				if (!nextGameForm.IsDisposed)// If a player have enough coins to play
					nextGameForm.Show();
				else
					_isFormClosingForNextRound = false;
			}
			Close();
		}
		private void OpenResultForm()
		{
			GameResult gameResult = GameResult.Draw;
			if (field.Winner == playerCellType)
			{
				gameResult = GameResult.Win;
				roundManager.AddWinToTheFirstPlayer();
			}
			if (field.Winner == opponentCellType)
			{
				gameResult = GameResult.Loss;
				roundManager.AddWinToTheSecondPlayer();
			}

			void backToMainForm(object s, EventArgs e)
			{
				_wasPressedButtonBack = true;
				_isFormClosingForNextRound = false;
				Close();
			}

			GameResultForm resultForm;
			if (bot == null)
				resultForm = new GameResultForm(player, gameResult, roundManager.IsLastRound(), backToMainForm);
			else
				resultForm = new GameResultForm(player, gameResult, bot.Difficulty, roundManager.IsLastRound(), backToMainForm);
			resultForm.ShowDialog();
		}

		private async Task ShowWinningCellsAsync(CellType winner)
		{
			if (winner == CellType.None)
				return;

			const int WINNING_CELL_SIZE_SCALER = 15;
			(Color CrossBack, Color ZeroBack) = (Color.FromArgb(220, 173, 162),
				Color.FromArgb(162, 190, 220));
			PictureBox pictureBox;

			for (int i = 0; i < field.WinningCells.Length; i++)
			{
				await Task.Delay(WINNING_CELL_SHOW_DELAY);

				pictureBox = _gameInfo.PictureCells[field.WinningCells[i].row, field.WinningCells[i].column];

				pictureBox.Size = new Size(pictureBox.Width + WINNING_CELL_SIZE_SCALER, pictureBox.Height + WINNING_CELL_SIZE_SCALER);
				pictureBox.Location = new Point(pictureBox.Location.X - WINNING_CELL_SIZE_SCALER / 2, pictureBox.Location.Y - WINNING_CELL_SIZE_SCALER / 2);

				if (winner == CellType.Cross)
					pictureBox.BackColor = CrossBack;
				else
					pictureBox.BackColor = ZeroBack;
			}
		}
		#endregion

		#region Timer
		protected void StartTimerToMove()
		{
			_cancellationTokenSourceTimer?.Cancel();
			_cancellationTokenSourceTimer = new CancellationTokenSource();

			_ = TimerForMoveAsync(_cancellationTokenSourceTimer.Token);
		}
		protected void StopTimerToMove()
			=> _cancellationTokenSourceTimer?.Cancel();
		private async Task TimerForMoveAsync(CancellationToken cancellationToken)
		{
			_gameInfo.TimerInfo.CircleTimer.Maximum = _gameInfo.TimerInfo.TimerDelay;
			_gameInfo.TimerInfo.Timer.Maximum = _gameInfo.TimerInfo.TimerDelay;

			_gameInfo.TimerInfo.CircleTimer.Value = _gameInfo.TimerInfo.CircleTimer.Maximum;
			_gameInfo.TimerInfo.Timer.Value = _gameInfo.TimerInfo.Timer.Maximum;
			Color currentColor;
			for (int i = _gameInfo.TimerInfo.TimerDelay; i >= 0; i--)
			{
				if (cancellationToken.IsCancellationRequested || IsDisposed)
					return;

				currentColor = GetColorForPercentage((double)i / _gameInfo.TimerInfo.TimerDelay);
				_gameInfo.TimerInfo.CircleTimer.Value = i;
				_gameInfo.TimerInfo.Timer.Value = i;

				_gameInfo.TimerInfo.CircleTimer.ProgressColor = currentColor;
				_gameInfo.TimerInfo.Timer.ProgressColor = currentColor;
				await Task.Delay(1);
			}

			Cell selectedCell = SelectCellAfterInactivity();
			StopGivingHint();

			if (cancellationToken.IsCancellationRequested || IsDisposed)
				return;

			_gameInfo.CellClick(_gameInfo.PictureCells[selectedCell.row, selectedCell.column], EventArgs.Empty);
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
				if (field.GetCell(cellHint) == CellType.None)
					return cellHint;
			}

			for (int i = 0; i < _gameInfo.PictureCells.GetLength(0); i++)
				for (int j = 0; j < _gameInfo.PictureCells.GetLength(1); j++)
					if (_gameInfo.PictureCells[i, j].Tag?.ToString() == _tagPreviewCell.Zero
						|| _gameInfo.PictureCells[i, j].Tag?.ToString() == _tagPreviewCell.Cross)
						return new Cell(i, j);

			return field.GetRandomEmptyCell();
		}
		#endregion

		#region Game view
		protected void ChangeGameViewVisibility(bool visible, bool needToChangeButton = true, bool needToChangeScore = true)
		{
			if (needToChangeButton)
				_gameInfo.GameAssistsInfo.ButtonChangeView.Visible = visible;

			switch (player.Preferences.GameView)
			{
				case GameView.Score:
					SetScoreViewVisibility(visible, needToChangeScore);
					break;
				case GameView.AssistTools:
					SetGameAssistsViewVisibility(visible);
					break;
				default:
					throw new InvalidOperationException
						($"Unknown game view: {player.Preferences.GameView.GetType().Name}");
			}
		}
		private void ButtonChangeView_Click(object sender, EventArgs e)
		{
			ActiveControl = null;

			// Turn off visibility of current view
			ChangeGameViewVisibility(false, false);

			// Turn on visibility of the next view
			switch (player.Preferences.GameView)
			{
				case GameView.Score:
					player.Preferences.GameView = GameView.AssistTools;
					SetGameAssistsViewVisibility(true);
					break;
				case GameView.AssistTools:
					player.Preferences.GameView = GameView.Score;
					SetScoreViewVisibility(true);
					break;
				default:
					throw new InvalidOperationException
						($"Unknown game view: {player.Preferences.GameView.GetType().Name}");
			}
		}
		protected void ButtonChangeView_MouseEnter(object sender, EventArgs e)
		{
			if (sender is IconButton button)
				button.BackColor = BackColor;
		}

		private void SetScoreViewVisibility(bool visible, bool needToChangeScore = true)
		{
			_gameInfo.TimerInfo.CircleTimer.Visible = visible;
			if (needToChangeScore)
				_gameInfo.Score.Visible = visible;
		}
		private void SetGameAssistsViewVisibility(bool visible)
		{
			const int MINIMUM_NUMBER_OF_MOVES_TO_SHOW = 2;

			_gameInfo.TimerInfo.Timer.Visible = visible;
			if (field.CountFilledCells() >= MINIMUM_NUMBER_OF_MOVES_TO_SHOW)
				if (!visible || !_wasAssistUsed && visible)
				{
					_gameInfo.GameAssistsInfo.AssistantsPanel.Visible = visible;
					SetGameAssistsVisibility(visible);
				}
		}
		private void SetGameAssistsVisibility(bool visible)
		{
			bool actualVisible;
			foreach (var item in player.CountableItemsInventory.GetItems())
			{
				actualVisible = visible && item.Count > 0;

				switch (item.Type)
				{
					case GameAssistType.UndoMove:
						_gameInfo.GameAssistsInfo.UndoMove.Visible = actualVisible;
						break;
					case GameAssistType.Hint:
						_gameInfo.GameAssistsInfo.Hint.Visible = actualVisible;
						break;
					case GameAssistType.Surrender:
						_gameInfo.GameAssistsInfo.Surrender.Visible = actualVisible;
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
			player.CountableItemsInventory.UseItem(GameAssistType.UndoMove);
			ChangeGameViewVisibility(false);
			StopTimerToMove();

			UndoLastMove();
			await Task.Delay(UNDO_MOVE_DELAY);
			UndoLastMove();
			ChangeGameViewVisibility(true);
			StartTimerToMove();
			TryToIndicateLastGameAssist(player.CountableItemsInventory.GetItem(GameAssistType.UndoMove));
		}
		private void UndoLastMove()
		{
			if (_sequenceSelectedCells.Count <= 0)
				return;

			PictureBox pictureBoxLastMove = _sequenceSelectedCells[_sequenceSelectedCells.Count - 1];

			Cell cellLastMove = FindIndexPictureBoxCell(pictureBoxLastMove);
			field.FillCell(cellLastMove, CellType.None);
			pictureBoxLastMove.Image = null;
			pictureBoxLastMove.Cursor = Cursors.Hand;

			pictureBoxLastMove.MouseLeave -= EnableHoverAfterMouseLeave;
			_pictureBoxEventHandlers.Unsubscribe(pictureBoxLastMove);
			pictureBoxLastMove.Click += _gameInfo.CellClick;

			_sequenceSelectedCells.RemoveAt(_sequenceSelectedCells.Count - 1);
		}

		private void PictureBoxHint_Click(object sender, EventArgs e)
		{
			_wasAssistUsed = true;
			player.CountableItemsInventory.UseItem(GameAssistType.Hint);
			ChangeGameViewVisibility(false);
			Cell cellHint = PerfectMoveFinder.FindCell(field, playerCellType);
			_pictureBoxCellHint = _gameInfo.PictureCells[cellHint.row, cellHint.column];

			_cancellationTokenSourceHint?.Cancel();
			_cancellationTokenSourceHint = new CancellationTokenSource();
			_ = StartGivingHintAsync(_cancellationTokenSourceHint.Token);
			ChangeGameViewVisibility(true);
			TryToIndicateLastGameAssist(player.CountableItemsInventory.GetItem(GameAssistType.Hint));
		}
		private async Task StartGivingHintAsync(CancellationToken cancellationToken)
		{
			const int FLICKER_DELAY = 500;
			Bitmap flickerImage = playerCellType == CellType.Cross ?
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
			player.CountableItemsInventory.UseItem(GameAssistType.Surrender);

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

		protected void BaseGameForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			StopTimerToMove();
			ManageGameAssistsEvents(false);
			_pictureBoxEventHandlers.UnsubscribeAll();

			if (!_isFormClosingForNextRound)
				mainForm.Show();
		}
	}
}