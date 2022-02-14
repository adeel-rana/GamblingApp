using Bet.Domain.Models;
namespace Bet.Domain.Service
{
    public interface IBettingService
    {
        BetResponse GetBetResponse(BetRequest request);
    }
}
