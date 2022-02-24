namespace Bet.Domain.Service;
public interface IBettingService
{
    BetResponse GetBettingResponse(BetRequest request);
}