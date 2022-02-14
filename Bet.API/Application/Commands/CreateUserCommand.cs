using Bet.Domain.Models;
using MediatR;

namespace Bet.API.Application.Commands
{
    public record CreateUserCommand(string UserName, string Email, string Password) : IRequest<ResponseInfo>;
}
