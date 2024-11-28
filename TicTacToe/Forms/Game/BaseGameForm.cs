using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using TicTacToe.Models.CustomExceptions;
using TicTacToe.Models.GameClientServer.Core;
using TicTacToe.Models.GameClientServer.Game;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.Utilities;
using TicTacToe.Models.Utilities.FormUtilities.ControlEventHandlers;
using TicTacToe.Properties;
using TicTacToeLibrary;

namespace TicTacToe.Forms.Game
{
	internal partial class BaseGameForm : BaseForm
	{
		private const int WINNING_CELL_SHOW_DELAY = 350;
		private const int UNDO_MOVE_DELAY = 400;
		private const int GAME_UPDATE_INTERVAL = 200;

		protected readonly MainForm mainForm;
		protected readonly Player player;
		protected readonly Bot bot;
		protected readonly RoundManager roundManager;
		protected readonly CoinReward coinReward;
		protected Field field;
		private GameFormInfo _gameFormInfo;
		protected bool isTimerEnabled, isGameAssistsEnabled;

		protected readonly GameServer gameServer;
		protected readonly GameClient gameClient;
		private System.Threading.Timer _clientUpdateTimer;
		private readonly SynchronizationContext _syncContext;

		private List<PictureBox> _sequenceSelectedCells;
		private readonly PictureBoxEventHandlers _pictureBoxEventHandlers = new PictureBoxEventHandlers();

		protected readonly CellType playerCellType, opponentCellType;
		private readonly (Bitmap Cross, Bitmap Zero) _bitmapPreviewCell;
		private readonly (string Cross, string Zero) _tagPreviewCell = ("Preview Cross", "Preview Zero");

		private CancellationTokenSource _cancellationTokenSourceTimer,
			_cancellationTokenSourceHint;
		private PictureBox _pictureBoxCellHint;
		private bool _wasAssistUsed, _isCellHintHovered,
			_isFormClosingForNextRound, _wasPressedButtonBack, _isGameOver;

		protected BaseGameForm()
		{ InitializeComponent(); }
		internal BaseGameForm(MainForm mainForm, Player player, GameServer gameServer, RoundManager roundManager,
			int coinsBet, CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled)
			: this(mainForm, player, new CoinReward(coinsBet, 0, -coinsBet), roundManager,
				playerCellType, isTimerEnabled, isGameAssistsEnabled)
		{
			this.gameServer = gameServer;
			_syncContext = SynchronizationContext.Current;

			this.gameServer.PlayerMoveGame += PlayerGameMove;
		}
		internal BaseGameForm(MainForm mainForm, Player player, GameClient gameClient, RoundManager roundManager,
			int coinsBet, CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled)
			: this(mainForm, player, new CoinReward(coinsBet, 0, -coinsBet), roundManager,
				playerCellType, isTimerEnabled, isGameAssistsEnabled)
		{
			this.gameClient = gameClient;
			_syncContext = SynchronizationContext.Current;
		}

		internal BaseGameForm(MainForm mainForm, Player player, Bot bot, RoundManager roundManager,
			CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled)
			: this(mainForm, player, new CoinReward(bot.Difficulty), roundManager,
				  playerCellType, isTimerEnabled, isGameAssistsEnabled)
		{ this.bot = bot; }
		internal BaseGameForm(MainForm mainForm, Player player, CoinReward coinReward, RoundManager roundManager,
			CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled)
		{
			const float PREVIEW_OPACITY_LEVEL = 0.35f;

			InitializeComponent();

			this.player = player;
			this.coinReward = coinReward;
			this.roundManager = roundManager;
			this.mainForm = mainForm;

			this.playerCellType = playerCellType;
			opponentCellType = playerCellType == CellType.Cross ? CellType.Zero : CellType.Cross;
			this.isTimerEnabled = isTimerEnabled;
			this.isGameAssistsEnabled = isGameAssistsEnabled;

			_bitmapPreviewCell.Cross = Resources.cross.ChangeOpacity(PREVIEW_OPACITY_LEVEL);
			_bitmapPreviewCell.Zero = Resources.zero.ChangeOpacity(PREVIEW_OPACITY_LEVEL);
		}

		#region Initialization
		protected void DisplayPlayerRoles(Guna2PictureBox playerPictureBox, Guna2PictureBox opponentPictureBox)
		{
			(Color markerColorZero, Color markerColorCross) = (Color.FromArgb(82, 217, 255), Color.FromArgb(255, 97, 95));

			if (playerCellType == CellType.Cross)
			{
				playerPictureBox.FillColor = markerColorCross;
				opponentPictureBox.FillColor = markerColorZero;
			}
			else
			{
				playerPictureBox.FillColor = markerColorZero;
				opponentPictureBox.FillColor = markerColorCross;
			}
		}
		protected void InitializeGame(GameFormInfo gameFormInfo)
		{
			_gameFormInfo = gameFormInfo;

			_gameFormInfo.Score.Text = $"{roundManager.NumberOfWinsFirstPlayer} : {roundManager.NumberOfWinsSecondPlayer}";
			_sequenceSelectedCells = new List<PictureBox>(_gameFormInfo.PictureCells.Length);
			BackColor = player.VisualSettings.BackgroundGame.Color;
			if (gameClient != null)
				StartClientUpdateTimer();

			InitializePlayersInfo(_gameFormInfo.PlayersInfo);
			InitializeGameAssists(_gameFormInfo.GameAssistsInfo);
		}
		private void InitializePlayersInfo(PlayersInfo playersInfo)
		{
			playersInfo.PlayerAvatar.Image = player.VisualSettings.Avatar.Image;
			playersInfo.PlayerName.Text = player.Name;
		}
		private void InitializeGameAssists(GameAssistsInfo gameAssistsInfo)
		{
			Color gameAssistHoverColor = Color.FromArgb(200, 240, 230, 140);

			ManageGameAssistsEvents(true);
			_pictureBoxEventHandlers.SubscribeToHover(gameAssistHoverColor,
				gameAssistsInfo.UndoMove, gameAssistsInfo.Hint, gameAssistsInfo.Surrender);
		}

		protected void ManagePictureCellsEventClick(bool subscribe)
		{
			for (int i = 0; i < _gameFormInfo.PictureCells.GetLength(0); i++)
				for (int j = 0; j < _gameFormInfo.PictureCells.GetLength(1); j++)
				{
					if (subscribe)
						_gameFormInfo.PictureCells[i, j].Click += _gameFormInfo.CellClick;
					else
						_gameFormInfo.PictureCells[i, j].Click -= _gameFormInfo.CellClick;
				}
		}
		protected void ManagePictureCellsEventHover(EventHandler mouseEnter, EventHandler mouseLeave, bool subscribe)
		{
			for (int i = 0; i < _gameFormInfo.PictureCells.GetLength(0); i++)
				for (int j = 0; j < _gameFormInfo.PictureCells.GetLength(1); j++)
				{
					if (subscribe)
					{
						_gameFormInfo.PictureCells[i, j].MouseEnter += mouseEnter;
						_gameFormInfo.PictureCells[i, j].MouseLeave += mouseLeave;
					}
					else
					{
						_gameFormInfo.PictureCells[i, j].MouseEnter -= mouseEnter;
						_gameFormInfo.PictureCells[i, j].MouseLeave -= mouseLeave;
					}
				}
		}
		private void ManageGameAssistsEvents(bool subscribe)
		{
			if (subscribe)
			{
				_gameFormInfo.GameAssistsInfo.UndoMove.Click += PictureBoxUndoMove_Click;
				_gameFormInfo.GameAssistsInfo.Hint.Click += PictureBoxHint_Click;
				_gameFormInfo.GameAssistsInfo.Surrender.Click += PictureBoxSurrender_Click;
				_gameFormInfo.GameAssistsInfo.ButtonChangeView.Click += ButtonChangeView_Click;
				_gameFormInfo.GameAssistsInfo.ButtonChangeView.MouseEnter += ButtonChangeView_MouseEnter;
			}
			else
			{
				_gameFormInfo.GameAssistsInfo.UndoMove.Click -= PictureBoxUndoMove_Click;
				_gameFormInfo.GameAssistsInfo.Hint.Click -= PictureBoxHint_Click;
				_gameFormInfo.GameAssistsInfo.Surrender.Click -= PictureBoxSurrender_Click;
				_gameFormInfo.GameAssistsInfo.ButtonChangeView.Click -= ButtonChangeView_Click;
				_gameFormInfo.GameAssistsInfo.ButtonChangeView.MouseEnter -= ButtonChangeView_MouseEnter;
			}
		}

		protected void TryToDeductCoins(Difficulty botDifficulty)
		{
			try
			{
				player.DeductCoins(botDifficulty);
			}
			catch (NotEnoughCoinsToStartGameException exception)
			{
				CustomMessageBox.Show(exception.Message, "Not enough coins", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				Close();
			}
			catch (InvalidOperationException)
			{ }// If an attempt is made to deduct coins again.
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

			if (IsGameBackLight())
			{
				SetLabelsForeColor(labels, lightLabels);
				SetControlsBackColor(otherControls, lightControls);
				_gameFormInfo.TimerInfo.CircleTimer.Image = Resources.clockBlack;
			}
			else
			{
				SetLabelsForeColor(labels, darkLabels);
				SetControlsBackColor(otherControls, darkControls);
				_gameFormInfo.TimerInfo.CircleTimer.Image = Resources.clockWhite;
			}
		}
		private bool IsGameBackLight()
		{// Checks if the game background color is light
			double avgBackColor = BackColor.R * 0.299 + BackColor.G * 0.587 + BackColor.B * 0.114;
			return avgBackColor >= byte.MaxValue / 2;
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
		protected async Task PictureBoxCell_DefaultClick(PictureBox pictureBox, CellType cellType, bool wasClicked,
			bool disablePictureCells = true, bool sendMoveInfoOverNetwork = true)
		{
			if (gameClient != null && sendMoveInfoOverNetwork)
				_clientUpdateTimer?.Dispose();

			_wasAssistUsed = false;
			_isCellHintHovered = false;
			ChangeGameViewVisibility(false, needToChangeScore: false);
			StopTimerToMove();
			StopGivingHint();
			await Task.Delay(10);// Add a delay to complete the current execution of the timer

			if (disablePictureCells)
				SetPictureBoxesEnabled(false);
			Cell cell = FindIndexPictureBoxCell(pictureBox);
			field.FillCell(cell, cellType);

			FillCellWithImage(cell, cellType, wasClicked);
			if (sendMoveInfoOverNetwork)
				await NetworkMoveAsync(cell);

			if (field.IsGameEnd())
				await FinishGameAsync();
			else if (bot != null)
				await BotMoveAsync();
			else if (sendMoveInfoOverNetwork && (gameServer != null || gameClient != null))
				IndicateWhoseMove(opponentCellType);
		}
		private async Task NetworkMoveAsync(Cell cell)
		{
			MoveInfo moveInfo = new MoveInfo(cell, playerCellType);
			if (gameServer != null)
				gameServer.Move(moveInfo);
			else if (gameClient != null)
			{
				GameInfo gameInfo = await gameClient.MoveAsync(moveInfo);
				if (gameInfo != null)
					await UpdateGameForClientAsync(gameInfo);
				StartClientUpdateTimer();
			}
		}
		protected async Task BotMoveAsync()
		{
			const int BOT_MOVE_DELAY = 600;

			IndicateWhoseMove(opponentCellType);
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
			IndicateWhoseMove(playerCellType);
		}
		private void FillCellWithImage(Cell cell, CellType cellType, bool wasClicked)
		{
			PictureBox pictureBox = _gameFormInfo.PictureCells[cell.row, cell.column];
			_sequenceSelectedCells.Add(pictureBox);
			pictureBox.Tag = null;
			pictureBox.Cursor = Cursors.Default;

			if (cellType == CellType.Zero)
				pictureBox.Image = Resources.zero;
			else if (cellType == CellType.Cross)
				pictureBox.Image = Resources.cross;
			else
				throw new InvalidOperationException($"Unknown cell type: {cellType}");

			pictureBox.Click -= _gameFormInfo.CellClick;

			if (wasClicked)// Subscribe to one-time event handler
				pictureBox.MouseLeave += EnableHoverAfterMouseLeave;
			else
				_pictureBoxEventHandlers.SubscribeToHover(pictureBox);
		}

		private Cell FindIndexPictureBoxCell(PictureBox pictureBox)
		{
			Cell result = new Cell();

			for (int i = 0; i < _gameFormInfo.PictureCells.GetLength(0); i++)
				for (int j = 0; j < _gameFormInfo.PictureCells.GetLength(1); j++)
					if (_gameFormInfo.PictureCells[i, j] == pictureBox)
					{
						result.row = i;
						result.column = j;
					}

			return result;
		}
		protected void SetPictureBoxesEnabled(bool enabled)
		{
			for (int i = 0; i < _gameFormInfo.PictureCells.GetLength(0); i++)
				for (int j = 0; j < _gameFormInfo.PictureCells.GetLength(1); j++)
					_gameFormInfo.PictureCells[i, j].Enabled = enabled;
		}

		protected void SetupMoveTransition(CellType currentCellType, bool isGameViewVisible)
		{
			IndicateWhoseMove(currentCellType);
			ChangeGameViewVisibility(isGameViewVisible);
			if (isGameViewVisible)
				StartTimerToMove();
		}
		private void IndicateWhoseMove(CellType currentCellType)
		{
			Label playerName = _gameFormInfo.PlayersInfo.PlayerName;
			Label opponentName = _gameFormInfo.PlayersInfo.OpponentName;

			(Color moveColorLight, Color moveColorDark) =
				(Color.Goldenrod, Color.FromArgb(255, 223, 0));
			Color defaultColor = playerName.ForeColor == moveColorLight || playerName.ForeColor == moveColorDark ?
				opponentName.ForeColor : playerName.ForeColor;

			Label activeName, inactiveName;
			if (currentCellType == playerCellType)
			{
				activeName = playerName;
				inactiveName = opponentName;
			}
			else
			{
				activeName = opponentName;
				inactiveName = playerName;
			}

			if (IsGameBackLight())
				activeName.ForeColor = moveColorLight;
			else
				activeName.ForeColor = moveColorDark;
			inactiveName.ForeColor = defaultColor;
		}
		protected void PictureBoxCell_DefaultMouseEnter(PictureBox pictureBox, CellType cellType)
		{
			if (pictureBox == _pictureBoxCellHint)
				_isCellHintHovered = true;

			if (pictureBox.Image != null)
				return;

			switch (cellType)
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
					throw new InvalidOperationException($"Unknown cell type: {cellType}");
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

		#region Network
		#region Client
		private void StartClientUpdateTimer()
			=> _clientUpdateTimer = new System.Threading.Timer(UpdateTimerCallBack, null, 0, GAME_UPDATE_INTERVAL);
		private async void UpdateTimerCallBack(object state)
			=> await UpdateGameForClientAsync();
		private async Task UpdateGameForClientAsync()
		{
			try
			{
				GameInfo gameInfo = await gameClient.UpdateGameAsync();
				_syncContext.Post(async _ =>
				{
					if (gameInfo != null)
						await UpdateGameForClientAsync(gameInfo);
				}, null);
			}
			catch (System.Net.Http.HttpRequestException)
			{
				//if (!_wasUpdateExceptionThrown)
				//{
				//	_wasUpdateExceptionThrown = true;
				//	_updateTimer?.Dispose();
				//	_syncContext.Post(_ =>
				//	{
				//		Close();
				//		CustomMessageBox.Show($"Failed to connect because the player " +
				//		"who created the lobby has finished waiting for players.", "Error",
				//		CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				//	}, null);
				//}
			}
		}
		private async Task UpdateGameForClientAsync(GameInfo gameInfo)
		{
			bool wasFieldChanged = await UpdateFieldAndCheckChangesAsync(gameInfo.Field);

			if (gameInfo.WhoseMove == playerCellType && !_isGameOver)
			{
				SetPictureBoxesEnabled(true);
				if (wasFieldChanged)
				{
					IndicateWhoseMove(playerCellType);
					ChangeGameViewVisibility(true);
					StartTimerToMove();
				}
			}
		}
		private async Task<bool> UpdateFieldAndCheckChangesAsync(Field updatedField)
		{
			bool wasFieldChanged = false;
			CellType[,] cells = updatedField.GetAllCells();
			Cell currentCell = new Cell(0, 0);

			for (int i = 0; i < cells.GetLength(0); i++)
				for (int j = 0; j < cells.GetLength(1); j++)
				{
					currentCell.row = i;
					currentCell.column = j;

					if (field.GetCell(currentCell) != cells[i, j])
					{
						wasFieldChanged = true;
						PictureBox currentPictureBox = _gameFormInfo.PictureCells[i, j];

						if (cells[i, j] == CellType.None)
						{
							field.FillCell(currentCell, CellType.None);
							ClearPictureBox(currentPictureBox);
						}
						else if (!_sequenceSelectedCells.Contains(currentPictureBox))
							await PictureBoxCell_DefaultClick(currentPictureBox, cells[i, j], false, sendMoveInfoOverNetwork: false);
					}
				}

			return wasFieldChanged;
		}
		#endregion

		#region Server
		private void PlayerGameMove(object sender, MoveGameEventArgs e)
		{
			if (_gameFormInfo == null)
				return;

			_syncContext.Post(async _ =>
			{
				if (e.MoveInfo.IsMoveCancelled)
				{
					UndoLastMove();
					await Task.Delay(UNDO_MOVE_DELAY);
					UndoLastMove();
				}
				else
				{
					Cell cell = e.MoveInfo.Cell;
					PictureBox pictureBox = _gameFormInfo.PictureCells[cell.row, cell.column];
					await PictureBoxCell_DefaultClick(pictureBox, e.MoveInfo.CellType, false, sendMoveInfoOverNetwork: false);
					SetupMoveTransition(playerCellType, true);
				}
				SetPictureBoxesEnabled(gameServer.WhoseMove() == playerCellType);
			}, null);
		}
		#endregion

		#endregion

		#region End of the game
		private async Task FinishGameAsync()
		{
			player.ReturnCoins();
			_clientUpdateTimer?.Dispose();
			_isGameOver = true;
			SetPictureBoxesEnabled(false);

			await ShowWinningCellsAsync(field.Winner);
			await Task.Delay(WINNING_CELL_SHOW_DELAY);
			gameServer?.FinishGame();

			GameResult gameResult = EvaluateGameResult();
			player.UpdateCoins(coinReward, gameResult);
			OpenResultForm(gameResult);

			_isFormClosingForNextRound = true;
			if (roundManager.IsLastRound() || _wasPressedButtonBack)
			{
				mainForm.Show();
				gameServer?.Stop();
			}
			else
			{
				roundManager.AddRound();

				BaseGameForm nextGameForm = _gameFormInfo.NextGameForm;
				if (!nextGameForm.IsDisposed)// If a player have enough coins to play
					nextGameForm.Show();
				else
					_isFormClosingForNextRound = false;
			}
			Close();
		}
		private GameResult EvaluateGameResult()
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

			return gameResult;
		}
		private void OpenResultForm(GameResult gameResult)
		{
			void backToMainForm(object s, EventArgs e)
			{
				_wasPressedButtonBack = true;
				_isFormClosingForNextRound = false;
				Close();
			}

			GameResultForm resultForm;
			if (bot != null)
				resultForm = new GameResultForm(player, coinReward, roundManager, gameResult, bot.Difficulty, backToMainForm);
			else if (gameClient != null || gameServer != null)
				resultForm = new GameResultForm(player, coinReward, roundManager, gameResult, backToMainForm, ActionAfterTimeOver.Play, 15);
			else
				resultForm = new GameResultForm(player, coinReward, roundManager, gameResult, backToMainForm);

			resultForm.ShowDialog();
		}

		private async Task ShowWinningCellsAsync(CellType winner)
		{
			if (winner == CellType.None)
				return;

			int WINNING_CELL_SIZE_SCALER = _gameFormInfo.PictureCells[0, 0].Height / 10;
			(Color CrossBack, Color ZeroBack) = (Color.FromArgb(220, 173, 162),
				Color.FromArgb(162, 190, 220));
			PictureBox pictureBox;

			for (int i = 0; i < field.WinningCells.Length; i++)
			{
				await Task.Delay(WINNING_CELL_SHOW_DELAY);

				pictureBox = _gameFormInfo.PictureCells[field.WinningCells[i].row, field.WinningCells[i].column];

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
		private void StartTimerToMove()
		{
			if (!isTimerEnabled)
				return;

			_cancellationTokenSourceTimer?.Cancel();
			_cancellationTokenSourceTimer = new CancellationTokenSource();

			_ = TimerForMoveAsync(_cancellationTokenSourceTimer.Token);
		}
		private void StopTimerToMove()
		{
			if (!isTimerEnabled)
				return;

			_cancellationTokenSourceTimer?.Cancel();
		}
		private async Task TimerForMoveAsync(CancellationToken cancellationToken)
		{
			_gameFormInfo.TimerInfo.CircleTimer.Maximum = _gameFormInfo.TimerInfo.TimerDelay;
			_gameFormInfo.TimerInfo.Timer.Maximum = _gameFormInfo.TimerInfo.TimerDelay;

			_gameFormInfo.TimerInfo.CircleTimer.Value = _gameFormInfo.TimerInfo.CircleTimer.Maximum;
			_gameFormInfo.TimerInfo.Timer.Value = _gameFormInfo.TimerInfo.Timer.Maximum;
			Color currentColor;
			for (int i = _gameFormInfo.TimerInfo.TimerDelay; i >= 0; i--)
			{
				if (cancellationToken.IsCancellationRequested || IsDisposed)
					return;

				currentColor = GetColorForPercentage((double)i / _gameFormInfo.TimerInfo.TimerDelay);
				_gameFormInfo.TimerInfo.CircleTimer.Value = i;
				_gameFormInfo.TimerInfo.Timer.Value = i;

				_gameFormInfo.TimerInfo.CircleTimer.ProgressColor = currentColor;
				_gameFormInfo.TimerInfo.Timer.ProgressColor = currentColor;
				await Task.Delay(1);
			}

			Cell selectedCell = SelectCellAfterInactivity();
			StopGivingHint();

			if (cancellationToken.IsCancellationRequested || IsDisposed)
				return;

			_gameFormInfo.CellClick(_gameFormInfo.PictureCells[selectedCell.row, selectedCell.column], EventArgs.Empty);
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

			for (int i = 0; i < _gameFormInfo.PictureCells.GetLength(0); i++)
				for (int j = 0; j < _gameFormInfo.PictureCells.GetLength(1); j++)
					if (_gameFormInfo.PictureCells[i, j].Tag?.ToString() == _tagPreviewCell.Zero
						|| _gameFormInfo.PictureCells[i, j].Tag?.ToString() == _tagPreviewCell.Cross)
						return new Cell(i, j);

			return field.GetRandomEmptyCell();
		}
		#endregion

		#region Game view
		private void ChangeGameViewVisibility(bool visible, bool needToChangeButton = true, bool needToChangeScore = true)
		{
			if (needToChangeButton)
				_gameFormInfo.GameAssistsInfo.ButtonChangeView.Visible = visible;

			switch (player.VisualSettings.GameView)
			{
				case GameView.Score:
					SetScoreViewVisibility(visible, needToChangeScore);
					break;
				case GameView.AssistTools:
					SetGameAssistsViewVisibility(visible);
					break;
				default:
					throw new InvalidOperationException
						($"Unknown game view: {player.VisualSettings.GameView.GetType().Name}");
			}
		}
		private void ButtonChangeView_Click(object sender, EventArgs e)
		{
			ActiveControl = null;

			// Turn off visibility of current view
			ChangeGameViewVisibility(false, false);

			// Turn on visibility of the next view
			switch (player.VisualSettings.GameView)
			{
				case GameView.Score:
					player.VisualSettings.GameView = GameView.AssistTools;
					SetGameAssistsViewVisibility(true);
					break;
				case GameView.AssistTools:
					player.VisualSettings.GameView = GameView.Score;
					SetScoreViewVisibility(true);
					break;
				default:
					throw new InvalidOperationException
						($"Unknown game view: {player.VisualSettings.GameView.GetType().Name}");
			}
		}
		protected void ButtonChangeView_MouseEnter(object sender, EventArgs e)
		{
			if (sender is IconButton button)
				button.BackColor = BackColor;
		}

		private void SetScoreViewVisibility(bool visible, bool needToChangeScore = true)
		{
			if (isTimerEnabled)
				_gameFormInfo.TimerInfo.CircleTimer.Visible = visible;
			if (needToChangeScore)
				_gameFormInfo.Score.Visible = visible;
		}
		private void SetGameAssistsViewVisibility(bool visible)
		{
			const int MINIMUM_NUMBER_OF_MOVES_TO_SHOW = 2;

			if (isTimerEnabled)
				_gameFormInfo.TimerInfo.Timer.Visible = visible;
			if (isGameAssistsEnabled && field.CountFilledCells() >= MINIMUM_NUMBER_OF_MOVES_TO_SHOW)
				if (!visible || !_wasAssistUsed && visible)
				{
					_gameFormInfo.GameAssistsInfo.AssistantsPanel.Visible = visible;
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
						_gameFormInfo.GameAssistsInfo.UndoMove.Visible = actualVisible;
						break;
					case GameAssistType.Hint:
						if (field.GetFieldSize() == 3)
							_gameFormInfo.GameAssistsInfo.Hint.Visible = actualVisible;
						break;
					case GameAssistType.Surrender:
						_gameFormInfo.GameAssistsInfo.Surrender.Visible = actualVisible;
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
			_wasAssistUsed = true;
			player.CountableItemsInventory.UseItem(GameAssistType.UndoMove);
			_clientUpdateTimer?.Dispose();
			ChangeGameViewVisibility(false);
			StopTimerToMove();

			UndoLastMove();
			await Task.Delay(UNDO_MOVE_DELAY);
			UndoLastMove();
			ChangeGameViewVisibility(true);

			MoveInfo moveInfo = new MoveInfo(true);
			if (gameServer != null)
				gameServer.Move(moveInfo);
			else if (gameClient != null)
				await gameClient.MoveAsync(moveInfo);

			StartTimerToMove();
			TryToIndicateLastGameAssist(player.CountableItemsInventory.GetItem(GameAssistType.UndoMove));
			if (gameClient != null)
				StartClientUpdateTimer();
		}
		private void UndoLastMove()
		{
			if (_sequenceSelectedCells.Count <= 0)
				return;

			PictureBox pictureBoxLastMove = _sequenceSelectedCells[_sequenceSelectedCells.Count - 1];

			Cell cellLastMove = FindIndexPictureBoxCell(pictureBoxLastMove);
			field.FillCell(cellLastMove, CellType.None);
			ClearPictureBox(pictureBoxLastMove);
		}
		private void ClearPictureBox(PictureBox pictureBox)
		{
			pictureBox.Image = null;
			pictureBox.Cursor = Cursors.Hand;

			pictureBox.MouseLeave -= EnableHoverAfterMouseLeave;
			_pictureBoxEventHandlers.Unsubscribe(pictureBox);
			pictureBox.Click += _gameFormInfo.CellClick;

			_sequenceSelectedCells.Remove(pictureBox);
		}

		private void PictureBoxHint_Click(object sender, EventArgs e)
		{
			_wasAssistUsed = true;
			player.CountableItemsInventory.UseItem(GameAssistType.Hint);
			ChangeGameViewVisibility(false);
			Cell cellHint = PerfectMoveFinder.FindCell(field, playerCellType);
			_pictureBoxCellHint = _gameFormInfo.PictureCells[cellHint.row, cellHint.column];

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
			ManagePictureCellsEventClick(false);
			ManageGameAssistsEvents(false);
			_clientUpdateTimer?.Dispose();
			_pictureBoxEventHandlers.UnsubscribeAll();

			if (gameServer != null)
				gameServer.PlayerMoveGame -= PlayerGameMove;

			if (!_isFormClosingForNextRound)
			{
				gameClient?.LeaveGameAsync();
				gameServer?.Stop();
				mainForm.Show();
			}
		}
	}
}