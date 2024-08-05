using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using TicTacToe.Models.PlayerInfo;
using TicTacToeLibrary;

namespace TicTacToe.Forms
{
	internal partial class ResultForm : Form
	{
		private const byte DELAY_SECONDS_TO_CLOSE = 7;

		private const string TEXT_WIN = "Win!";
		private const string TEXT_DRAW = "Draw!";
		private const string TEXT_LOSS = "Loss!";

		private readonly (Color Win, Color Loss) _colorOfPoints = (Color.Lime, Color.Red);

		private readonly (Color Easy, Color Medium, Color Hard) _colorOfDifficulty =
			(Color.FromArgb(0, 107, 60), Color.FromArgb(229, 158, 31), Color.FromArgb(127, 24, 13));

		private readonly Player _player;
		private readonly PlayerType _winner;
		private readonly Difficulty _difficult;

		internal ResultForm(Player player, PlayerType winner, Difficulty difficult)
		{
			InitializeComponent();

			_player = player;
			_winner = winner;
			_difficult = difficult;
		}

		private void ResultForm_Load(object sender, EventArgs e)
		{
			if (_winner == PlayerType.Human) labelResult.Text = TEXT_WIN;
			else if (_winner == PlayerType.None) labelResult.Text = TEXT_DRAW;
			else if (_winner == PlayerType.Bot) labelResult.Text = TEXT_LOSS;

			DisplayPointsResult();
			DisplayDifficultyLabel();
			labelCurrentPoints.Text = _player.Points.ToString();

			DelayToClose(DELAY_SECONDS_TO_CLOSE);
		}

		private void DisplayPointsResult()
		{
			int prevPoints = _player.Points;
			_player.UpdatePoints(_difficult, _winner);

			if (_player.Points > prevPoints)
			{
				labelPointsResult.Text = '+' + (_player.Points - prevPoints).ToString();
				labelPointsResult.ForeColor = _colorOfPoints.Win;
			}
			else if (_player.Points == prevPoints)
				labelPointsResult.Text = string.Empty;
			else
			{
				labelPointsResult.Text = '-' + (prevPoints - _player.Points).ToString();
				labelPointsResult.ForeColor = _colorOfPoints.Loss;
			}
		}
		private void DisplayDifficultyLabel()
		{
			labelDifficult.Text = _difficult.ToString();

			if (_difficult == Difficulty.Easy)
				labelDifficult.BackColor = _colorOfDifficulty.Easy;
			else if (_difficult == Difficulty.Medium)
				labelDifficult.BackColor = _colorOfDifficulty.Medium;
			else if (_difficult == Difficulty.Hard)
				labelDifficult.BackColor = _colorOfDifficulty.Hard;
		}

		private async void DelayToClose(int seconds)
		{
			for (int i = seconds; i >= 1; i--)
			{
				labelTimeToClose.Text = "This window will close in: " + i.ToString() + " sec.";
				await Task.Delay(1000);
			}

			Close();
		}
	}
}