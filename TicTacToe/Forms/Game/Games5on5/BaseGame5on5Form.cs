using System;
using System.Windows.Forms;

using TicTacToe.Models.GameClientServer.Core;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;
using TicTacToeLibrary.AI;
using TicTacToeLibrary.Core;

namespace TicTacToe.Forms.Game.Games5on5
{
	internal partial class BaseGame5on5Form : BaseGameForm
	{
		private BaseGame5on5Form()
		{ InitializeComponent(); }
		internal BaseGame5on5Form(MainForm mainForm, Player player, Bot bot, RoundManager roundManager,
			CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(mainForm, player, bot, roundManager, playerCellType, isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			field = FieldParser.Parse(FieldSize.Size5on5);
		}
		internal BaseGame5on5Form(MainForm mainForm, Player player, CoinReward coinReward, RoundManager roundManager,
			CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(mainForm, player, coinReward, roundManager, playerCellType, isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			field = FieldParser.Parse(FieldSize.Size5on5);
		}
		internal BaseGame5on5Form(MainForm mainForm, Player player, GameServer gameServer, RoundManager roundManager,
			int coinsBet, CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(mainForm, player, gameServer, roundManager, coinsBet, playerCellType, isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			field = FieldParser.Parse(FieldSize.Size5on5);
		}
		internal BaseGame5on5Form(MainForm mainForm, Player player, GameClient gameClient, RoundManager roundManager,
			int coinsBet, CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(mainForm, player, gameClient, roundManager, coinsBet, playerCellType, isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			field = FieldParser.Parse(FieldSize.Size5on5);
		}

		protected void InitializeBaseGame(EventHandler cellClick, BaseGame5on5Form nextGameForm)
		{
			const int TIMER_MOVE_DELAY = 2000;

			PictureBox[,] pictureCells = new[,]
			{
				{ pictureBoxCell1, pictureBoxCell2, pictureBoxCell3,pictureBoxCell4, pictureBoxCell5 },
				{ pictureBoxCell6, pictureBoxCell7, pictureBoxCell8, pictureBoxCell9, pictureBoxCell10 },
				{ pictureBoxCell11, pictureBoxCell12, pictureBoxCell13, pictureBoxCell14, pictureBoxCell15 },
				{ pictureBoxCell16, pictureBoxCell17, pictureBoxCell18, pictureBoxCell19, pictureBoxCell20 },
				{ pictureBoxCell21, pictureBoxCell22, pictureBoxCell23, pictureBoxCell24, pictureBoxCell25 }
			};

			PlayersInfo playersInfo = new PlayersInfo(pictureBoxPlayerAvatar, labelPlayerName, labelOpponentName);
			TimerInfo timerInfo = new TimerInfo(progressBarTimer, progressBarCircleTimer, TIMER_MOVE_DELAY);
			GameAssistsInfo gameAssistsInfo = new GameAssistsInfo(pictureBoxUndoMove, pictureBoxHint,
				pictureBoxSurrender, buttonChangeView, flpGameAssistants);

			GameFormInfo gameFormInfo = new GameFormInfo(playersInfo, labelScore, pictureCells,
				cellClick, timerInfo, gameAssistsInfo, nextGameForm);
			InitializeGame(gameFormInfo);

			DisplayPlayerRoles(pictureBoxPlayerCellTypeIndicator, pictureBoxOpponentCellTypeIndicator);
			SetColorForControls(new[] { labelPlayerName, labelScore, labelOpponentName },
				new Control[]{ pictureBoxLine1, pictureBoxLine2, pictureBoxLine3, pictureBoxLine4,
				pictureBoxLine5, pictureBoxLine6, pictureBoxLine7, pictureBoxLine8, buttonChangeView });
			ManagePictureCellsEventClick(true);
		}
	}
}