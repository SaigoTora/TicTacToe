namespace TicTacToe.Models.GameInfo
{
	internal class RoundManager
	{
		internal int NumberOfWinsFirstPlayer { get; private set; }
		internal int NumberOfWinsSecondPlayer { get; private set; }
		internal int CurrentNumberOfRounds { get; private set; }
		internal int MaxNumberOfRounds { get; private set; }

		internal RoundManager(int MaxRounds)
		{
			MaxNumberOfRounds = MaxRounds;
			CurrentNumberOfRounds = 1;
		}

		internal bool IsLastRound() => CurrentNumberOfRounds >= MaxNumberOfRounds;
		internal void AddRound() => CurrentNumberOfRounds++;
		internal void AddWinToTheFirstPlayer() => NumberOfWinsFirstPlayer++;
		internal void AddWinToTheSecondPlayer() => NumberOfWinsSecondPlayer++;
	}
}