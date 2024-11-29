using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using TicTacToe.Models.GameInfo;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToe.Models.Utilities.FormUtilities.ControlEventHandlers;
using TicTacToeLibrary;

namespace TicTacToe.Forms
{
	internal enum ActionAfterTimeOver : byte
	{
		BackToMenu,
		Play
	}
	internal partial class GameResultForm : BaseForm
	{
		private readonly Player _player;
		private readonly CoinReward _coinReward;
		private readonly RoundManager _roundManager;
		private readonly GameResult _result;
		private readonly Difficulty? _difficulty = null;
		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();

		private readonly ActionAfterTimeOver _actionAfterTimeOver;
		private readonly EventHandler _backToMainForm;
		private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

		internal GameResultForm(Player player, CoinReward coinReward, RoundManager roundManager,
			GameResult result, EventHandler backToMainForm)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Results", Properties.Resources.info, false, false, false);
			base.guna2BorderlessForm.SetDrag(new Control[] { this, labelScore, labelResult, labelCoinsResult,
				labelDifficultyTitle, labelDifficulty, labelCurrentCoinsTitle, pictureBoxCoin,
				labelCurrentCoins, labelTimeToClose });
			base.guna2BorderlessForm.TransparentWhileDrag = false;
			_player = player;
			_coinReward = coinReward;
			_roundManager = roundManager;
			_result = result;

			if (_roundManager.IsLastRound())
			{
				buttonBack.Text = "Back to menu";
				buttonBack.Location = new Point(100, buttonBack.Location.Y);
				buttonBack.Size = new Size(300, buttonBack.Height);
				buttonPlay.Visible = false;
			}
			_backToMainForm = backToMainForm;
			RepositionControls(false);

			buttonBack.Click += _backToMainForm;
			if (buttonPlay != null)
				ActiveControl = buttonPlay;
			else
				ActiveControl = buttonBack;
			_buttonEventHandlers.SubscribeToHover(buttonBack, buttonPlay);
		}

		internal GameResultForm(Player player, CoinReward coinReward, RoundManager roundManager, GameResult result,
			EventHandler backToMainForm, ActionAfterTimeOver actionAfterTimeOver, byte? delaySecondsToClose)
			: this(player, coinReward, roundManager, result, backToMainForm)
		{
			_actionAfterTimeOver = actionAfterTimeOver;
			RepositionControls(true);

			if (delaySecondsToClose.HasValue && delaySecondsToClose.Value > 0)
				_ = DelayToCloseAsync(delaySecondsToClose.Value);
		}
		internal GameResultForm(Player player, CoinReward coinReward, RoundManager roundManager, GameResult result,
			Difficulty difficulty, EventHandler backToMainForm)
			: this(player, coinReward, roundManager, result, backToMainForm, ActionAfterTimeOver.BackToMenu, 60)
		{ _difficulty = difficulty; }

		private void ResultForm_Load(object sender, EventArgs e)
		{
			if (_roundManager.IsLastRound())
				DisplayScore();

			DisplayGameResult();
			DisplayCoinsChange();
			if (_difficulty.HasValue)
				DisplayDifficultyLabel();
			else
			{
				const int VERTICAL_OFFSET = -50;
				AdjustUIForNoDifficulty(VERTICAL_OFFSET);
			}

			labelCurrentCoins.Text = $"{_player.Coins:N0}".Replace(',', ' ');
		}

		private void RepositionControls(bool isTimerToCloseExist)
		{
			if (isTimerToCloseExist)
			{
				buttonBack.Location = new Point(buttonBack.Location.X, buttonBack.Location.Y - labelTimeToClose.Height);
				buttonPlay.Location = new Point(buttonPlay.Location.X, buttonPlay.Location.Y - labelTimeToClose.Height);
			}
			else
			{
				buttonBack.Location = new Point(buttonBack.Location.X, buttonBack.Location.Y + labelTimeToClose.Height);
				buttonPlay.Location = new Point(buttonPlay.Location.X, buttonPlay.Location.Y + labelTimeToClose.Height);
			}
		}
		private void DisplayScore()
		{
			labelScore.Visible = true;
			labelScore.Text = $"Score:\n{_roundManager.NumberOfWinsFirstPlayer}:{_roundManager.NumberOfWinsSecondPlayer}";
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
		private void DisplayCoinsChange()
		{
			(Color colorWin, Color colorLoss) = (Color.Lime, Color.Red);
			int coinUpdate = _coinReward.GetCoins(_result);

			if (coinUpdate != 0)
			{
				labelCoinsResult.Visible = true;
				switch (_result)
				{
					case GameResult.Loss:
						labelCoinsResult.Text = $"- {Math.Abs(coinUpdate)}";
						labelCoinsResult.ForeColor = colorLoss;
						break;
					case GameResult.Draw:
						labelCoinsResult.Text = string.Empty;
						break;
					case GameResult.Win:
						labelCoinsResult.Text = $"+ {coinUpdate}";
						labelCoinsResult.ForeColor = colorWin;
						break;
					default:
						throw new InvalidOperationException
							($"Unknown game result: {_result.GetType().Name}");
				}
			}
		}
		private void DisplayDifficultyLabel()
		{
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
		private void AdjustUIForNoDifficulty(int verticalOffset)
		{
			MoveControlVertically(labelCurrentCoinsTitle, verticalOffset);
			MoveControlVertically(pictureBoxCoin, verticalOffset);
			MoveControlVertically(labelCurrentCoins, verticalOffset);
			Size = new Size(Width, Height + verticalOffset);
		}
		private void MoveControlVertically(Control control, int offset)
			=> control.Location = new Point(control.Location.X, control.Location.Y + offset);

		private void ButtonPlay_Click(object sender, EventArgs e)
			=> Close();

		private async Task DelayToCloseAsync(byte delaySeconds = 60)
		{
			labelTimeToClose.Visible = true;

			for (int i = delaySeconds; i >= 1; i--)
			{
				if (_cancellationTokenSource.IsCancellationRequested)
					return;

				labelTimeToClose.Text = "This window will close in: " + i.ToString() + " sec.";
				await Task.Delay(1000);
			}

			if (!_cancellationTokenSource.IsCancellationRequested)
			{
				if (_actionAfterTimeOver == ActionAfterTimeOver.BackToMenu)
					_backToMainForm(this, EventArgs.Empty);
				else if (_actionAfterTimeOver == ActionAfterTimeOver.Play)
				{
					if (buttonPlay.Visible)
						ButtonPlay_Click(this, EventArgs.Empty);
					else
						_backToMainForm(this, EventArgs.Empty);
				}
			}
		}
		private void ButtonBack_Click(object sender, EventArgs e)
			=> Close();

		private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_cancellationTokenSource.Cancel();
			buttonBack.Click -= _backToMainForm;

			_buttonEventHandlers.UnsubscribeAll();
		}
	}
}