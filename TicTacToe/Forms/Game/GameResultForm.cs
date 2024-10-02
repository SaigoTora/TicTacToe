using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToeLibrary;

namespace TicTacToe.Forms
{
	internal partial class GameResultForm : BaseForm
	{
		private readonly Player _player;
		private readonly GameResult _result;
		private readonly Difficulty? _difficulty = null;
		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();

		private readonly EventHandler _backToMainForm;
		private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

		internal GameResultForm(Player player, RoundManager roundManager, GameResult result, bool isLastRound, EventHandler backToMainForm)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Results", Properties.Resources.info, false, false, false);
			base.guna2BorderlessForm.SetDrag(new Control[] { this, labelScore, labelResult, labelCoinsResult,
				labelDifficultyTitle, labelDifficulty, labelCurrentCoinsTitle, pictureBoxCoin,
				labelCurrentCoins, labelTimeToClose });
			base.guna2BorderlessForm.TransparentWhileDrag = false;
			_player = player;
			_result = result;

			if (isLastRound)
			{
				buttonBack.Text = "Back to menu";
				buttonBack.Location = new Point(100, buttonBack.Location.Y);
				buttonBack.Size = new Size(300, buttonBack.Height);
				buttonPlay.Visible = false;

				DisplayScore(roundManager);
			}
			_backToMainForm = backToMainForm;
			buttonBack.Click += _backToMainForm;
			if (buttonPlay != null)
				ActiveControl = buttonPlay;
			else
				ActiveControl = buttonBack;
			_buttonEventHandlers.SubscribeToHover(buttonBack, buttonPlay);
		}
		internal GameResultForm(Player player, RoundManager roundManager, GameResult result,
			Difficulty difficulty, bool isLastRound, EventHandler backToMainForm)
			: this(player, roundManager, result, isLastRound, backToMainForm)
		{ _difficulty = difficulty; }

		private void ResultForm_Load(object sender, EventArgs e)
		{
			DisplayGameResult();
			DisplayCoinsResult();
			DisplayDifficultyLabel();
			labelCurrentCoins.Text = _player.Coins.ToString();

			_ = DelayToCloseAsync();
		}

		private void DisplayGameResult()
		{
			(string textWin, string textDraw, string textLoss) = ("Win!", "Draw!", "Loss!");
			(Color colorWin, Color colorDraw, Color colorLoss) = (Color.FromArgb(71, 167, 106),
					Color.White, Color.Maroon);

			switch (_result)
			{
				case GameResult.Loss:
					labelResult.Text = textLoss;
					labelResult.ForeColor = colorLoss;
					break;
				case GameResult.Draw:
					labelResult.Text = textDraw;
					labelResult.ForeColor = colorDraw;
					break;
				case GameResult.Win:
					labelResult.Text = textWin;
					labelResult.ForeColor = colorWin;
					break;
				default:
					throw new InvalidOperationException($"Unknown game result: {_result}");
			}
		}
		private void DisplayCoinsResult()
		{
			(Color colorWin, Color colorLoss) = (Color.Lime, Color.Red);
			int prevCoins = _player.Coins;
			if (_difficulty.HasValue)
				_player.UpdateCoins(_difficulty.Value, _result);

			if (_player.Coins > prevCoins)
			{
				labelCoinsResult.Text = '+' + (_player.Coins - prevCoins).ToString();
				labelCoinsResult.ForeColor = colorWin;
			}
			else if (_player.Coins == prevCoins)
				labelCoinsResult.Text = string.Empty;
			else
			{
				labelCoinsResult.Text = '-' + (prevCoins - _player.Coins).ToString();
				labelCoinsResult.ForeColor = colorLoss;
			}
		}
		private void DisplayDifficultyLabel()
		{
			if (!_difficulty.HasValue)
				return;

			(Color colorEasy, Color colorMedium, Color colorHard, Color colorImpossible) =
				(Color.FromArgb(30, 129, 69), Color.FromArgb(236, 124, 38), Color.FromArgb(155, 17, 30), Color.FromArgb(83, 55, 122));
			labelDifficulty.Text = _difficulty.ToString();

			labelDifficultyTitle.Visible = true;
			labelDifficulty.Visible = true;
			if (_difficulty == Difficulty.Easy)
				labelDifficulty.BackColor = colorEasy;
			else if (_difficulty == Difficulty.Medium)
				labelDifficulty.BackColor = colorMedium;
			else if (_difficulty == Difficulty.Hard)
				labelDifficulty.BackColor = colorHard;
			else if (_difficulty == Difficulty.Impossible)
				labelDifficulty.BackColor = colorImpossible;
		}
		private void DisplayScore(RoundManager roundManager)
		{
			labelScore.Visible = true;
			labelScore.Text = $"Score:\n{roundManager.NumberOfWinsFirstPlayer}:{roundManager.NumberOfWinsSecondPlayer}";
		}

		private void ButtonPlay_Click(object sender, EventArgs e)
			=> Close();

		private async Task DelayToCloseAsync()
		{
			const byte DELAY_SECONDS_TO_CLOSE = 60;

			for (int i = DELAY_SECONDS_TO_CLOSE; i >= 1; i--)
			{
				if (_cancellationTokenSource.IsCancellationRequested)
					return;

				labelTimeToClose.Text = "This window will close in: " + i.ToString() + " sec.";
				await Task.Delay(1000);
			}

			if (!_cancellationTokenSource.IsCancellationRequested)
				_backToMainForm(this, EventArgs.Empty);
		}
		private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_cancellationTokenSource.Cancel();
			buttonBack.Click -= _backToMainForm;

			_buttonEventHandlers.UnsubscribeAll();
		}
	}
}