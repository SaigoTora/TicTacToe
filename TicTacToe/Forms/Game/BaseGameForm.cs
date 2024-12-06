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
using TicTacToe.Models.GameClientServer.Lobby;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.Utilities;
using TicTacToe.Models.Utilities.FormUtilities.ControlEventHandlers;
using TicTacToe.Properties;
using TicTacToeLibrary.AI;
using TicTacToeLibrary.Core;
using TicTacToeLibrary.GameLogic;

namespace TicTacToe.Forms.Game
{
	internal partial class BaseGameForm : BaseForm
	{
		private const int WINNING_CELL_SHOW_DELAY = 350;
		private const int TETRIS_MODE_ANIMATION_DELAY = 250;
		private const int UNDO_MOVE_DELAY = 400;
		private const int GAME_UPDATE_INTERVAL = 200;

		protected readonly MainForm mainForm;
		protected readonly Player player;
		protected readonly Bot bot;
		protected readonly RoundManager roundManager;
		protected readonly CoinReward coinReward;
		protected Field field;
		private readonly GameMode _gameMode = GameMode.ReverseTetris;
		protected bool isTimerEnabled, isGameAssistsEnabled;
		private int _initialCoins;
		private GameFormInfo _gameFormInfo;

		protected readonly GameServer gameServer;
		protected readonly GameClient gameClient;
		private System.Threading.Timer _clientUpdateTimer;
		private readonly SynchronizationContext _syncContext;

		private List<PictureBox> _sequenceSelectedCells;
		private readonly PictureBoxEventHandlers _pictureBoxEventHandlers = new PictureBoxEventHandlers();

		protected readonly CellType playerCellType, opponentCellType;
		private readonly (Bitmap Cross, Bitmap Zero) _bitmapPreviewCell;
		private readonly (string Cross, string Zero) _tagPreviewCell = ("Preview Cross", "Preview Zero");

		private GameResultForm _gameResultForm;
		private CancellationTokenSource _cancellationTokenSourceTimer,
			_cancellationTokenSourceHint;
		private PictureBox _pictureBoxCellHint;
		private bool _wasAssistUsed, _isCellHintHovered,
			_isFormClosingForNextRound, _wasPressedButtonBack,
			_isGameOver, _wasUpdateExceptionThrown;

		protected BaseGameForm()
		{ InitializeComponent(); }
		internal BaseGameForm(MainForm mainForm, Player player, GameServer gameServer, RoundManager roundManager,
			int coinsBet, CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled)
			: this(mainForm, player, new CoinReward(coinsBet, 0, -coinsBet), roundManager,
				playerCellType, isTimerEnabled, isGameAssistsEnabled)
		{
			this.gameServer = gameServer;
			_syncContext = SynchronizationContext.Current;

			ManageServerEventHandlers(true);
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
			_initialCoins = player.Coins;
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
		protected string GetFormCaption()
			=> $"Round {roundManager.CurrentNumberOfRounds} / {roundManager.MaxNumberOfRounds}";
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

			Icon = Resources.game;
			_gameFormInfo.Score.Text = $"{roundManager.NumberOfWinsFirstPlayer} : {roundManager.NumberOfWinsSecondPlayer}";
			_sequenceSelectedCells = new List<PictureBox>(_gameFormInfo.PictureCells.Length);
			BackColor = player.VisualSettings.BackgroundGame.Color;

			gameServer?.StartGame();
			if (gameClient != null)
				StartClientUpdateTimer();
			if ((gameServer != null || gameClient != null) && roundManager.IsFirstRound())
				TryToDeductCoinsWithCoinReward();

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
				CustomMessageBox.Show(exception.Message, "Not enough coins",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				Close();
			}
			catch (InvalidOperationException)
			{ }// If an attempt is made to deduct coins again.
		}
		protected void TryToDeductCoinsWithCoinReward()
		{
			try
			{
				player.DeductCoins(Math.Abs(coinReward.CoinsForLoss));
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
			Image cellImage = GetCellImage(cellType);
			cell = await FindActualCellWithAnimationAsync(cell, cellImage);
			field.FillCell(cell, cellType);

			FillCellWithImage(cell, cellImage, wasClicked);
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
				try
				{
					GameInfo gameInfo = await gameClient.MoveAsync(moveInfo);
					if (gameInfo != null)
						await UpdateGameForClientAsync(gameInfo);
					StartClientUpdateTimer();
				}
				catch (System.Net.Http.HttpRequestException)
				{
					// At this point, the error will already be caught
					// in the client update timer
				}
			}
		}
		protected async Task BotMoveAsync()
		{
			const int BOT_MOVE_DELAY = 600;

			IndicateWhoseMove(opponentCellType);
			SetPictureBoxesEnabled(false);

			Cell botMove = bot.Move(field, opponentCellType);
			Image cellImage = GetCellImage(opponentCellType);
			await Task.Delay(BOT_MOVE_DELAY);
			botMove = await FindActualCellWithAnimationAsync(botMove, cellImage);
			field.FillCell(botMove, opponentCellType);

			FillCellWithImage(botMove, cellImage, false);

			if (field.IsGameEnd())
				await FinishGameAsync();

			SetPictureBoxesEnabled(true);
			ChangeGameViewVisibility(true);
			StartTimerToMove();
			IndicateWhoseMove(playerCellType);
		}
		private Image GetCellImage(CellType cellType)
		{
			if (cellType == CellType.Zero)
				return Resources.zero;
			else if (cellType == CellType.Cross)
				return Resources.cross;
			else
				throw new InvalidOperationException($"Unknown cell type: {cellType}");
		}
		private void FillCellWithImage(Cell cell, Image cellImage, bool wasClicked)
		{
			PictureBox pictureBox = _gameFormInfo.PictureCells[cell.row, cell.column];
			_sequenceSelectedCells.Add(pictureBox);
			pictureBox.Tag = null;
			pictureBox.Cursor = Cursors.Default;
			pictureBox.Image = cellImage;

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
		private async Task<Cell> FindActualCellWithAnimationAsync(Cell selectedCell, Image cellImage)
		{
			Cell resultCell = selectedCell;

			switch (_gameMode)
			{
				case GameMode.Standart:
					break;
				case GameMode.Tetris:
					resultCell = await FindCellForTetrisModeAsync(selectedCell, cellImage);
					break;
				case GameMode.ReverseTetris:
					resultCell = await FindCellForReverseTetrisModeAsync(selectedCell, cellImage);
					break;
				default:
					throw new InvalidOperationException($"Unknown game mode: {_gameMode}");
			}

			return resultCell;
		}
		private async Task<Cell> FindCellForTetrisModeAsync(Cell selectedCell, Image cellImage)
		{
			Cell currentCell = new Cell(selectedCell.row, selectedCell.column);
			Cell nextCell = selectedCell;

			_gameFormInfo.PictureCells[currentCell.row, currentCell.column].Image = cellImage;

			for (int i = selectedCell.row; i < field.GetFieldSize() - 1; i++)
			{
				currentCell.row = i;
				nextCell.row = i + 1;

				if (field.GetCell(nextCell) == CellType.None)
				{
					await Task.Delay(TETRIS_MODE_ANIMATION_DELAY);
					_gameFormInfo.PictureCells[currentCell.row, currentCell.column].Image = null;
					_gameFormInfo.PictureCells[nextCell.row, nextCell.column].Image = cellImage;
				}
				else
					return currentCell;
			}

			return nextCell;
		}
		private async Task<Cell> FindCellForReverseTetrisModeAsync(Cell selectedCell, Image cellImage)
		{
			Cell currentCell = new Cell(selectedCell.row, selectedCell.column);
			Cell nextCell = selectedCell;

			_gameFormInfo.PictureCells[currentCell.row, currentCell.column].Image = cellImage;

			for (int i = selectedCell.row; i >= 1; i--)
			{
				currentCell.row = i;
				nextCell.row = i - 1;

				if (field.GetCell(nextCell) == CellType.None)
				{
					await Task.Delay(TETRIS_MODE_ANIMATION_DELAY);
					_gameFormInfo.PictureCells[currentCell.row, currentCell.column].Image = null;
					_gameFormInfo.PictureCells[nextCell.row, nextCell.column].Image = cellImage;
				}
				else
					return currentCell;
			}

			return nextCell;
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
				if (!_wasUpdateExceptionThrown)
				{
					_wasUpdateExceptionThrown = true;
					_clientUpdateTimer?.Dispose();

					_syncContext.Post(_ =>
					{
						player.ReturnCoins();
						player.UpdateCoins(coinReward, GameResult.Win);
						_wasPressedButtonBack = true;
						_gameResultForm?.Close();
						Close();
						string rewardText = coinReward.CoinsForWin > 0 ?
						$" You won {coinReward.CoinsForWin} coins!" : string.Empty;
						CustomMessageBox.Show($"Your opponent left the game, so the victory is yours." +
							rewardText, "Game information",
							CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information);
					}, null);
				}
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
		private void ManageServerEventHandlers(bool subscribe)
		{
			if (subscribe)
			{
				gameServer.PlayerMoveGame += PlayerGameMove;
				gameServer.PlayerLeftGame += PlayerLeftGame;
			}
			else
			{
				gameServer.PlayerMoveGame -= PlayerGameMove;
				gameServer.PlayerLeftGame -= PlayerLeftGame;
			}
		}

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
		private void PlayerLeftGame(object sender, NetworkPlayerEventArgs e)
		{
			if (_gameFormInfo == null)
				return;

			_syncContext.Post(_ =>
			{
				player.ReturnCoins();
				player.UpdateCoins(coinReward, GameResult.Win);
				_wasPressedButtonBack = true;
				_gameResultForm?.Close();
				Close();
				string rewardText = coinReward.CoinsForWin > 0 ?
				$" You won {coinReward.CoinsForWin} coins!" : string.Empty;
				CustomMessageBox.Show($"{e.Player.Name} left the game, so the victory is yours." +
					rewardText, "Game information",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Information);
			}, null);
		}
		#endregion

		#endregion

		#region End of the game
		private async Task FinishGameAsync()
		{
			if (_gameResultForm != null)
				return;

			_clientUpdateTimer?.Dispose();
			_isGameOver = true;
			SetPictureBoxesEnabled(false);

			await ShowWinningCellsAsync(field.Winner);
			await Task.Delay(WINNING_CELL_SHOW_DELAY);
			gameServer?.FinishGame();

			GameResult gameResult = EvaluateGameResult();
			if ((gameServer != null || gameClient != null) && roundManager.IsLastRound())
			{
				_initialCoins += player.DeductedCoins;
				player.ReturnCoins();
				gameResult = UpdateCoinsForNetworkGame();
			}
			else if (gameServer == null && gameClient == null)
			{
				player.ReturnCoins();
				player.UpdateCoins(coinReward, gameResult);
			}

			OpenResultForm(gameResult);

			_isFormClosingForNextRound = true;
			if (roundManager.IsLastRound() || _wasPressedButtonBack)
				mainForm.Show();
			else
			{
				roundManager.AddRound();

				BaseGameForm nextGameForm = _gameFormInfo.NextGameForm;
				nextGameForm._initialCoins = player.Coins;
				nextGameForm.customTitleBar.ChangeFormCaption(GetFormCaption());
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
		private GameResult UpdateCoinsForNetworkGame()
		{
			GameResult gameResult = GameResult.Draw;
			if (roundManager.NumberOfWinsFirstPlayer > roundManager.NumberOfWinsSecondPlayer)
				gameResult = GameResult.Win;
			else if (roundManager.NumberOfWinsFirstPlayer < roundManager.NumberOfWinsSecondPlayer)
				gameResult = GameResult.Loss;

			CoinReward networkCoinReward = coinReward;
			if (roundManager.HasEqualNumberOfWins())
				networkCoinReward = new CoinReward(coinReward.CoinsForWin, roundManager.CurrentNumberOfRounds / 5, coinReward.CoinsForLoss);

			player.UpdateCoins(networkCoinReward, gameResult);
			return gameResult;
		}
		private void OpenResultForm(GameResult gameResult)
		{
			const int RESULT_FORM_CLOSE_DELAY_SECONDS = 15;

			if (_gameResultForm != null)
				return;

			int coinUpdate = player.Coins - _initialCoins;
			if (bot != null)
				_gameResultForm = new GameResultForm(player, coinUpdate, roundManager,
					gameResult, bot.Difficulty, BackToMainForm);
			else if (gameClient != null || gameServer != null)
			{
				int closeDelay = roundManager.IsLastRound() ?
					RESULT_FORM_CLOSE_DELAY_SECONDS * 2 : RESULT_FORM_CLOSE_DELAY_SECONDS;
				if (roundManager.IsFirstRound())
					coinUpdate += player.DeductedCoins;

				_gameResultForm = new GameResultForm(player, coinUpdate, roundManager, gameResult,
					BackToMainForm, ActionAfterTimeOver.Play, (byte)closeDelay);
			}
			else
				_gameResultForm = new GameResultForm(player, coinUpdate, roundManager, gameResult, BackToMainForm);

			_gameResultForm.ShowDialog();
		}
		private void BackToMainForm(object s, EventArgs e)
		{
			_wasPressedButtonBack = true;
			_isFormClosingForNextRound = false;
			Close();

			if (((gameServer != null || gameClient != null) && !roundManager.IsLastRound()))
			{
				_gameResultForm.CancelAutoClose();
				_gameResultForm?.Hide();
				_gameResultForm?.Close();
				string coinsLostText = coinReward.CoinsForLoss != 0 ?
					$"lost your initial bet: {Math.Abs(coinReward.CoinsForLoss)} coins!" :
					"could have lost your original bet, but luckily there was no bet in this game.";
				CustomMessageBox.Show($"You have left the game and " + coinsLostText +
					"\nTry not to leave during local games because you will lose coins.", "Warning",
					CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Warning);
			}
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
						if (gameClient == null && gameServer == null)
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
				ManageServerEventHandlers(false);

			if (!_isFormClosingForNextRound)
			{
				player.ResetReductedCoins();
				if (!roundManager.IsLastRound())
					gameClient?.LeaveGameAsync();

				gameServer?.Stop();
				_gameResultForm?.Close();
				mainForm.Show();
			}
		}
	}
}