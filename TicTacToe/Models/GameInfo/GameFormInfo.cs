using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

using TicTacToe.Forms.Game;

namespace TicTacToe.Models.GameInfo
{
	internal class GameFormInfo
	{
		internal PlayersInfo PlayersInfo { get; }
		internal Label Score { get; }
		internal PictureBox[,] PictureCells { get; }
		internal EventHandler CellClick { get; }
		internal TimerInfo TimerInfo { get; }
		internal GameAssistsInfo GameAssistsInfo { get; }
		internal BaseGameForm NextGameForm;

		internal GameFormInfo(PlayersInfo playersInfo, Label score,
			PictureBox[,] pictureCells, EventHandler cellClick,
			TimerInfo timerInfo, GameAssistsInfo gameAssistsInfo,
			BaseGameForm nextGameForm)
		{
			PlayersInfo = playersInfo;
			Score = score;
			PictureCells = pictureCells;
			CellClick = cellClick;
			TimerInfo = timerInfo;
			GameAssistsInfo = gameAssistsInfo;
			NextGameForm = nextGameForm;
		}
	}

	internal class PlayersInfo
	{
		internal PictureBox PlayerAvatar { get; }
		internal Label PlayerName { get; }
		internal Label OpponentName { get; }

		internal PlayersInfo(PictureBox playerAvatar, Label playerName, Label opponentName)
		{
			PlayerAvatar = playerAvatar;
			PlayerName = playerName;
			OpponentName = opponentName;
		}
	}
	internal class TimerInfo
	{
		internal Guna2ProgressBar Timer { get; }
		internal Guna2CircleProgressBar CircleTimer { get; }
		internal int TimerDelay { get; }

		internal TimerInfo(Guna2ProgressBar timer,
			Guna2CircleProgressBar circleTimer, int timerDelay)
		{
			Timer = timer;
			CircleTimer = circleTimer;
			TimerDelay = timerDelay;
		}
	}
	internal class GameAssistsInfo
	{
		internal PictureBox UndoMove { get; }
		internal PictureBox Hint { get; }
		internal PictureBox Surrender { get; }
		internal IconButton ButtonChangeView { get; }
		internal FlowLayoutPanel AssistantsPanel { get; }


		internal GameAssistsInfo(PictureBox undoMove, PictureBox hint,
			PictureBox surrender, IconButton buttonchangeView,
			FlowLayoutPanel assistantsPanel)
		{
			UndoMove = undoMove;
			Hint = hint;
			Surrender = surrender;
			ButtonChangeView = buttonchangeView;
			AssistantsPanel = assistantsPanel;
		}
	}
}