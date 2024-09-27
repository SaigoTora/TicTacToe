using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

namespace TicTacToe.Models.GameInfo
{
	internal class GameFormInfo
	{
		internal PlayerInfo PlayerInfo { get; }
		internal Label Score { get; }
		internal PictureBox[,] PictureCells { get; }
		internal EventHandler CellClick { get; }
		internal TimerInfo TimerInfo { get; }
		internal GameAssistsInfo GameAssistsInfo { get; }

		internal GameFormInfo(PlayerInfo playerInfo, Label score,
			PictureBox[,] pictureCells, EventHandler cellClick,
			TimerInfo timerInfo, GameAssistsInfo gameAssistsInfo)
		{
			PlayerInfo = playerInfo;
			Score = score;
			PictureCells = pictureCells;
			CellClick = cellClick;
			TimerInfo = timerInfo;
			GameAssistsInfo = gameAssistsInfo;
		}
	}

	internal class PlayerInfo
	{
		internal PictureBox Avatar { get; }
		internal Label Name { get; }

		internal PlayerInfo(PictureBox avatar, Label name)
		{
			Avatar = avatar;
			Name = name;
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