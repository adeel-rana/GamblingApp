namespace Bet.API.Application.Queries;
public record BetQueries(string userId) : IRequest<List<BettingHistory>>;
