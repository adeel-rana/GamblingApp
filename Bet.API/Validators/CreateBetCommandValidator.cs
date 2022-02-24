namespace Bet.API.Validators;
public class CreateBetCommandValidator : AbstractValidator<CreateBetCommand>
{
    private const int MinBet = 0;
    private const int MaxBet = 9;
    private const int MinPoints = 1;
    public CreateBetCommandValidator()
    {
        RuleFor(x => x.BetNumber)
            .GreaterThanOrEqualTo(MinBet)
            .NotNull().WithMessage("Bet number is required")
            .LessThanOrEqualTo(MaxBet).WithMessage("Bet number must be between 0 to 9");
        RuleFor(x => x.Points)
            .GreaterThanOrEqualTo(MinPoints).WithMessage("Bet points must be greater than 0")
            .NotEmpty().WithMessage("Points are required");

    }
}