using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToeLibrary;

namespace TicTacToe.Forms
{
	internal partial class ResultForm : BaseForm
	{
		private readonly Player _player;
		private readonly PlayerType _winner;
		private readonly Difficulty _difficult;
		private readonly CustomTitleBar _customTitleBar;
		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();

		private readonly EventHandler _backToMainForm;
		private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
		internal ResultForm(Player player, PlayerType winner, Difficulty difficult, bool isGameEnd, EventHandler backToMainForm)
		{
			InitializeComponent();

			_customTitleBar = new CustomTitleBar(this, "Results", Properties.Resources.info, false, false, false);
			_player = player;
			_winner = winner;
			_difficult = difficult;

			if (isGameEnd)
			{
				buttonBack.Text = "Back to menu";
				buttonBack.Location = new Point(100, buttonBack.Location.Y);
				buttonBack.Size = new Size(300, buttonBack.Height);
				buttonPlay.Visible = false;
			}
			_backToMainForm = backToMainForm;
			buttonBack.Click += _backToMainForm;
			_buttonEventHandlers.SubscribeToHoverButtons(buttonBack, buttonPlay);
		}

		private void ResultForm_Load(object sender, EventArgs e)
		{
			DisplayGameResult();
			DisplayCoinsResult();
			DisplayDifficultyLabel();
			labelCurrentCoins.Text = _player.Coins.ToString();

			_ = DelayToClose();
		}

		private void DisplayGameResult()
		{
			(string textWin, string textDraw, string textLoss) = ("Win!", "Draw!", "Loss!");
			(Color colorWin, Color colorDraw, Color colorLoss) = (Color.FromArgb(71, 167, 106),
					Color.White, Color.Maroon);

			if (_winner == PlayerType.Human)
			{
				labelResult.Text = textWin;
				labelResult.ForeColor = colorWin;

			}
			else if (_winner == PlayerType.None)
			{
				labelResult.Text = textDraw;
				labelResult.ForeColor = colorDraw;
			}
			else if (_winner == PlayerType.Bot)
			{
				labelResult.Text = textLoss;
				labelResult.ForeColor = colorLoss;
			}
		}
		private void DisplayCoinsResult()
		{
			(Color colorWin, Color colorLoss) = (Color.Lime, Color.Red);
			int prevCoins = _player.Coins;
			_player.UpdateCoins(_difficult, _winner);

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
			(Color colorEasy, Color colorMedium, Color colorHard, Color colorImpossible) =
				(Color.FromArgb(30, 129, 69), Color.FromArgb(236, 124, 38), Color.FromArgb(155, 17, 30), Color.FromArgb(83, 55, 122));
			labelDifficult.Text = _difficult.ToString();

			if (_difficult == Difficulty.Easy)
				labelDifficult.BackColor = colorEasy;
			else if (_difficult == Difficulty.Medium)
				labelDifficult.BackColor = colorMedium;
			else if (_difficult == Difficulty.Hard)
				labelDifficult.BackColor = colorHard;
			else if (_difficult == Difficulty.Impossible)
				labelDifficult.BackColor = colorImpossible;
		}


		private void ButtonPlay_Click(object sender, EventArgs e)
			=> Close();

		private async Task DelayToClose()
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
			_customTitleBar.Dispose();
		}
	}
}