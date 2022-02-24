namespace Bet.API.Application.Commands;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseInfo>
{
    private readonly ITransactionRepository _repository;
    private readonly UserManager<ApplicationUser> _userManager;
    public CreateUserCommandHandler(ITransactionRepository repository,
        UserManager<ApplicationUser> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    public async Task<ResponseInfo> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByNameAsync(request.UserName);
        if (userExists != null)
        {
            return new ResponseInfo { StatusCode = StatusCodes.Status500InternalServerError, Status = "Error", Message = "User already exists!" };
        }

        ApplicationUser user = new ApplicationUser()
        {
            Email = request.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = request.UserName
        };
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return new ResponseInfo { StatusCode = StatusCodes.Status500InternalServerError, Data = result };
        }

        await _repository.CreateAsync(new Transaction(user.Id, 10000));
        return new ResponseInfo { StatusCode = StatusCodes.Status200OK, Status = "Success", Message = "User created successfully!", Data = result };

    }
}
