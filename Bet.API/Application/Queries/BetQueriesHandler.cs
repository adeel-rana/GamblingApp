using Bet.Domain.Models;
using Bet.Infrastructure.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bet.API.Application.Queries
{
    public record BetQueriesHandler : IRequestHandler<BetQueries, List<BettingHistory>>
    {
        private readonly IBettingRepository _repository;
        public BetQueriesHandler(IBettingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BettingHistory>> Handle(BetQueries request, CancellationToken cancellationToken)
        {
            return  await _repository.GetAsync(request.userId);
        }
    }
}
