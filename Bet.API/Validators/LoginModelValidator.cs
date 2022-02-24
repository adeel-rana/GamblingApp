namespace Bet.API.Validators;
public class LoginModelValidator : AbstractValidator<LoginModel>
{
    public LoginModelValidator()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage("User name is required");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
    }
}