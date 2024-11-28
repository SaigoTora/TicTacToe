using System;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.GameClientServer.Core;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;
using TicTacToeLibrary;

namespace TicTacToe.Forms.Game.Games3on3
{
	internal partial class BaseGame3on3Form : BaseGameForm
	{
		private BaseGame3on3Form()
		{ InitializeComponent(); }
		internal BaseGame3on3Form(MainForm mainForm, Player player, Bot bot, RoundManager roundManager,
			CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(mainForm, player, bot, roundManager, playerCellType, isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			field = FieldParser.Parse(FieldSize.Size3on3);
		}
		internal BaseGame3on3Form(MainForm mainForm, Player player, CoinReward coinReward, RoundManager roundManager,
			CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(mainForm, player, coinReward, roundManager, playerCellType, isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			field = FieldParser.Parse(FieldSize.Size3on3);
		}
		internal BaseGame3on3Form(MainForm mainForm, Player player, GameServer gameServer, RoundManager roundManager,
			int coinsBet, CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(mainForm, player, gameServer, roundManager, coinsBet, playerCellType, isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			field = FieldParser.Parse(FieldSize.Size3on3);
		}
		internal BaseGame3on3Form(MainForm mainForm, Player player, GameClient gameClient, RoundManager roundManager,
			int coinsBet, CellType playerCellType, bool isTimerEnabled, bool isGameAssistsEnabled)
			: base(mainForm, player, gameClient, roundManager, coinsBet, playerCellType, isTimerEnabled, isGameAssistsEnabled)
		{
			InitializeComponent();

			field = FieldParser.Parse(FieldSize.Size3on3);
		}

		protected void InitializeBaseGame(EventHandler cellClick, BaseGame3on3Form nextGameForm)
		{
			const int TIMER_MOVE_DELAY = 900;

			PictureBox[,] pictureCells = new[,]
			{
				{ pictureBoxCell1, pictureBoxCell2, pictureBoxCell3 },
				{ pictureBoxCell4, pictureBoxCell5, pictureBoxCell6 },
				{ pictureBoxCell7, pictureBoxCell8, pictureBoxCell9 }
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
				buttonChangeView });
			ManagePictureCellsEventClick(true);
		}
		protected void SetPlayerNamesSize(params Label[] names)
		{
			foreach (var name in names)
				if (name.Text.Length > 15)
					name.Font = new Font(name.Font.FontFamily, 12);
		}
	}
}