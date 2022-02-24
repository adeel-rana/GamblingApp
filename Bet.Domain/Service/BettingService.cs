namespace Bet.Domain.Service;
public class BettingService : IBettingService
{
    public BetResponse GetBettingResponse(BetRequest request)
    {
        var betStatus = GetBettingStatus(request.BetNumber);
        var points = betStatus ? request.Points * 9 : -request.Points;
        return new BetResponse(request.Balance + points,
            betStatus ? BetResult.Won : BetResult.Lost, points);
    }

    private static bool GetBettingStatus(int betNumber)
    {
        Random generator = new Random();
        var randomNumber = generator.Next(0, 10);
        return randomNumber == betNumber ? true : false;
    }
}