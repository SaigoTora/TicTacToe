using FluentValidation;

namespace TicTacToe.Models.PlayerInfo
{
	internal class PlayerValidator : AbstractValidator<Player>
	{
		internal const int MAX_NAME_LENGTH = 20;

		private const string PLAYER_NAME = "Nickname";
		private const string EXCEPT_NAME_CHARS = @"!@#%\^&\*\(\)\+\[\]\{\}:;'\""\\,/`<>?=";
		private const int MIN_NAME_LENGTH = 3;
		internal PlayerValidator()
		{
			RuleFor(player => player.Name).NotNull().MinimumLength(MIN_NAME_LENGTH).MaximumLength(MAX_NAME_LENGTH).WithName(PLAYER_NAME);
			RuleFor(player => player.Name).Matches($"^[^{EXCEPT_NAME_CHARS}]*$").WithMessage($"'{PLAYER_NAME}' " +
				"cannot contain the following characters:\n! @ # % ^ & * () + [] {} : ; \' \" , \\ / ` <> ? =");
		}
	}
}