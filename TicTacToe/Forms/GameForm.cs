﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

using TicTacToe.Models.CustomExceptions;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities;
using TicTacToeLibrary;

namespace TicTacToe.Forms
{
	internal partial class GameForm : Form
	{
		private const int BOT_MOVE_DELAY = 500;
		private const int WINNING_CELL_SHOW_DELAY = 300;
		private const int WINNING_CELL_SIZE_SCALER = 15;
		private const float PREVIEW_OPACITY_LEVEL = 0.2f;

		private readonly (Color Cross, Color Zero) _backColorWinningCells = (Color.FromArgb(220, 173, 162),
			Color.FromArgb(162, 190, 220));

		private readonly MainForm _mainForm;
		private readonly Field _field = new Field(3, 3);
		private readonly Player _player;
		private readonly Bot _bot;
		private readonly RoundManager _roundManager;
		private readonly PictureBox[,] _pictureCells;

		private readonly bool _isBotMoveFirst = false;
		private readonly CellType _playerCellType;
		private readonly CellType _botCellType;

		private readonly Bitmap previewCross;
		private readonly Bitmap previewZero;

		private bool _isFormClosingForNextRound = false;

		internal GameForm(MainForm mainForm, Player player, Bot bot, RoundManager roundManager, bool isBotFirst)
		{
			InitializeComponent();

			_player = player;
			_bot = bot;
			_isBotMoveFirst = isBotFirst;
			_roundManager = roundManager;
			_mainForm = mainForm;

			if (isBotFirst)
			{
				_playerCellType = CellType.Zero;
				_botCellType = CellType.Cross;
			}
			else
			{
				_playerCellType = CellType.Cross;
				_botCellType = CellType.Zero;
			}

			try
			{
				player.DeductPoints(bot.Difficulty);
			}
			catch (NotEnoughPointToStartGameException exception)
			{
				MessageBox.Show(exception.Message, "Not enough points", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
			}

			_pictureCells = new[,]{ { pictureBoxCell1, pictureBoxCell2, pictureBoxCell3 },
									{ pictureBoxCell4, pictureBoxCell5, pictureBoxCell6 },
									{ pictureBoxCell7, pictureBoxCell8, pictureBoxCell9 } };

			previewCross = ChangeImageOpacity(Properties.Resources.cross, PREVIEW_OPACITY_LEVEL);
			previewZero = ChangeImageOpacity(Properties.Resources.zero, PREVIEW_OPACITY_LEVEL);
		}

		private void GameForm_Load(object sender, EventArgs e)
		{
			BackColor = _player.Settings.BackgroundGame;

			pictureBoxPlayerAvatar.Image = _player.Settings.Avatar;
			SetBotAvatar();

			labelPlayerName.Text = _player.Name;
			labelBotName.Text = _bot.Name;
			SetPlayerNameSize(labelPlayerName);
			SetPlayerNameSize(labelBotName);

			labelScore.Text = $"{_roundManager.NumberOfWinsFirstPlayer} : {_roundManager.NumberOfWinsSecondPlayer}";
			Text = $"Round # {_roundManager.CurrentNumberOfRounds} of {_roundManager.MaxNumberOfRounds}";

			if (_isBotMoveFirst)
				_ = BotMove();
		}

		private Bitmap ChangeImageOpacity(Image image, float opacity)
		{
			if (image == null)
				throw new ArgumentNullException(nameof(image));

			Bitmap bmp = new Bitmap(image.Width, image.Height);
			using (Graphics graphics = Graphics.FromImage(bmp))
			{
				ColorMatrix matrix = new ColorMatrix
				{ Matrix33 = opacity };

				ImageAttributes attributes = new ImageAttributes();
				attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

				graphics.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0,
					image.Width, image.Height, GraphicsUnit.Pixel, attributes);
			}

			return bmp;
		}

		private void SetPlayerNameSize(Label label)
		{
			if (label.Text.Length > 15)
				label.Font = new Font(label.Font.FontFamily, 12);
		}
		private void SetBotAvatar()
		{
			if (_bot.Difficulty == Difficulty.Easy)
				pictureBoxBotAvatar.Image = Properties.Resources.botEasy;
			else if (_bot.Difficulty == Difficulty.Medium)
				pictureBoxBotAvatar.Image = Properties.Resources.botMedium;
			else if (_bot.Difficulty == Difficulty.Hard)
				pictureBoxBotAvatar.Image = Properties.Resources.botHard;
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

			if (_isBotMoveFirst && playerType == PlayerType.Human || !_isBotMoveFirst && playerType == PlayerType.Bot)
				pictureBox.Image = Properties.Resources.zero;
			else
				pictureBox.Image = Properties.Resources.cross;

			pictureBox.Click -= PictureBoxCell_Click;

			if (playerType == PlayerType.Human)// Subscribe to one-time event handler
				pictureBox.MouseLeave += EnableHoverAfterMouseLeave;
			else
				FormEventHandlers.SubscribeToHoverPictureBoxes(pictureBox);
		}
		private void EnableHoverAfterMouseLeave(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			FormEventHandlers.SubscribeToHoverPictureBoxes(pictureBox);
			pictureBox.MouseLeave -= EnableHoverAfterMouseLeave;
		}

		private async Task BotMove()
		{
			SetPictureBoxesEnabled(false);

			Cell botMove = _bot.Move(_field, _botCellType);
			_field.FillCell(botMove, _botCellType);
			await Task.Delay(BOT_MOVE_DELAY);
			FillCellWithImage(botMove, PlayerType.Bot);

			if (_field.IsGameEnd())
				await FinishGame();

			SetPictureBoxesEnabled(true);
		}
		private void SetPictureBoxesEnabled(bool enabled)
		{
			for (int i = 0; i < _pictureCells.GetLength(0); i++)
				for (int j = 0; j < _pictureCells.GetLength(1); j++)
					_pictureCells[i, j].Enabled = enabled;
		}

		private async Task FinishGame()
		{
			_player.ReturnPoints(_bot.Difficulty);
			SetPictureBoxesEnabled(false);

			await ShowWinningCells(_field.Winner);

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

			ResultForm resultForm = new ResultForm(_player, winner, _bot.Difficulty);
			await Task.Delay(WINNING_CELL_SHOW_DELAY);
			resultForm.ShowDialog();

			_isFormClosingForNextRound = true;
			if (_roundManager.IsLastRound())
				_mainForm.Show();
			else
			{
				_roundManager.AddRound();

				GameForm gameForm = new GameForm(_mainForm, _player, _bot, _roundManager, !_isBotMoveFirst);
				if (!gameForm.IsDisposed)// If a player have enough points to play
					gameForm.Show();
				else
					_isFormClosingForNextRound = false;
			}
			Close();
		}
		private async Task ShowWinningCells(CellType winner)
		{
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

				pictureBox.Click -= PictureBoxCell_Click;
			}
		}

		private void PictureBoxCell_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox) || pictureBox.Image != null)
				return;

			if (_isBotMoveFirst)
				pictureBox.Image = previewZero;
			else
				pictureBox.Image = previewCross;
		}
		private void PictureBoxCella_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is PictureBox pictureBox))
				return;

			if (pictureBox.Image == previewCross || pictureBox.Image == previewZero)
				pictureBox.Image = null;
		}

		private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (!_isFormClosingForNextRound)
				_mainForm.Show();
		}
	}
}