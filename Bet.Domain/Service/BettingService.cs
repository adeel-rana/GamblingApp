namespace Bet.Domain.Service;
public class BettingService : IBettingService
{
    public BetResponse GetBettingResponse(BetRequest request)
    {
        var points = GetRandomNumber() == request.BetNumber ? request.Points * 9 : -request.Points;
        return new BetResponse(request.Balance + points,
            GetRandomNumber() == request.BetNumber ?
            BetResult.Won : BetResult.Lost, points);
    }

    private static int GetRandomNumber()
    {
        return new Random().Next(0, 10);
    }
}