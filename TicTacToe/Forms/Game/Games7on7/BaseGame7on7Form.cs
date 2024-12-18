﻿using System;
using System.Windows.Forms;

using TicTacToe.Models.GameClientServer.Core;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;
using TicTacToeLibrary.AI;
using TicTacToeLibrary.Core;
using TicTacToeLibrary.GameLogic;

namespace TicTacToe.Forms.Game.Games7on7
{
	internal partial class BaseGame7on7Form : BaseGameForm
	{
		private BaseGame7on7Form()
		{ InitializeComponent(); }
		internal BaseGame7on7Form(MainForm mainForm, Player player, Bot bot,
			RoundManager roundManager, GameMode gameMode, CellType playerCellType,
			bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(mainForm, player, bot, roundManager, gameMode, playerCellType,
				  isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			field = FieldParser.Parse(FieldSize.Size7on7);
		}
		internal BaseGame7on7Form(MainForm mainForm, Player player, CoinReward coinReward,
			RoundManager roundManager, GameMode gameMode, CellType playerCellType,
			bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(mainForm, player, coinReward, roundManager, gameMode, playerCellType,
				  isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			field = FieldParser.Parse(FieldSize.Size7on7);
		}
		internal BaseGame7on7Form(MainForm mainForm, Player player, GameServer gameServer, int coinsBet,
			RoundManager roundManager, GameMode gameMode, CellType playerCellType,
			bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(mainForm, player, gameServer, coinsBet, roundManager, gameMode, playerCellType,
				  isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			field = FieldParser.Parse(FieldSize.Size7on7);
		}
		internal BaseGame7on7Form(MainForm mainForm, Player player, GameClient gameClient, int coinsBet,
			RoundManager roundManager, GameMode gameMode, CellType playerCellType,
			bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(mainForm, player, gameClient, coinsBet, roundManager, gameMode, playerCellType,
				  isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			field = FieldParser.Parse(FieldSize.Size7on7);
		}

		protected void InitializeBaseGame(EventHandler cellClick, BaseGame7on7Form nextGameForm)
		{
			const int TIMER_MOVE_DELAY = 2500;

			PictureBox[,] pictureCells = new[,]
			{
				{ pictureBoxCell1, pictureBoxCell2, pictureBoxCell3, pictureBoxCell4, pictureBoxCell5, pictureBoxCell6, pictureBoxCell7 },
				{ pictureBoxCell8, pictureBoxCell9, pictureBoxCell10, pictureBoxCell11, pictureBoxCell12, pictureBoxCell13, pictureBoxCell14 },
				{ pictureBoxCell15, pictureBoxCell16, pictureBoxCell17, pictureBoxCell18, pictureBoxCell19, pictureBoxCell20, pictureBoxCell21 },
				{ pictureBoxCell22, pictureBoxCell23, pictureBoxCell24, pictureBoxCell25, pictureBoxCell26, pictureBoxCell27, pictureBoxCell28 },
				{ pictureBoxCell29, pictureBoxCell30, pictureBoxCell31, pictureBoxCell32, pictureBoxCell33, pictureBoxCell34, pictureBoxCell35 },
				{ pictureBoxCell36, pictureBoxCell37, pictureBoxCell38, pictureBoxCell39, pictureBoxCell40, pictureBoxCell41, pictureBoxCell42 },
				{ pictureBoxCell43, pictureBoxCell44, pictureBoxCell45, pictureBoxCell46, pictureBoxCell47, pictureBoxCell48, pictureBoxCell49 }
			};

			PlayersInfo playersInfo = new PlayersInfo(pictureBoxPlayerAvatar,
				labelPlayerName, labelOpponentName);
			TimerInfo timerInfo = new TimerInfo(progressBarTimer,
				progressBarCircleTimer, TIMER_MOVE_DELAY);
			GameAssistsInfo gameAssistsInfo = new GameAssistsInfo(pictureBoxUndoMove,
				pictureBoxHint, pictureBoxSurrender, buttonChangeView, flpGameAssistants);

			GameFormInfo gameFormInfo = new GameFormInfo(playersInfo, labelScore,
				pictureCells, cellClick, timerInfo, gameAssistsInfo, nextGameForm);
			InitializeGame(gameFormInfo);

			DisplayPlayerRoles(pictureBoxPlayerCellTypeIndicator, pictureBoxOpponentCellTypeIndicator);
			SetColorForControls(new[] { labelPlayerName, labelScore, labelOpponentName },
				new Control[]{ pictureBoxLine1, pictureBoxLine2, pictureBoxLine3, pictureBoxLine4,
				pictureBoxLine5, pictureBoxLine6, pictureBoxLine7, pictureBoxLine8, pictureBoxLine9,
				pictureBoxLine10, pictureBoxLine11, pictureBoxLine12, buttonChangeView });
			ManagePictureCellsEventClick(true);
		}
	}
}