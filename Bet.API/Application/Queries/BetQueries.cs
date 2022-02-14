using Bet.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Bet.API.Application.Queries
{
    public record BetQueries(string userId): IRequest<List<BettingHistory>>;
}
