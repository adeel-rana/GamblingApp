using Bet.Domain.Models;
using System;

namespace Bet.Domain.Service
{
    public class BettingService : IBettingService
    {
        public BetResponse GetBetResponse(BetRequest request)
        {
            var betStatus  = GetBetStatus(request.BetNumber);
            var points = betStatus ? request.Points * 9 : -request.Points;
            return new BetResponse(request.Balance + points,
                betStatus ? BetResult.Won : BetResult.Lost, points);
        }

        private static bool GetBetStatus(int betNumber)
        {
            Random generator = new Random();
            var randomNumber = generator.Next(0, 9);
            return randomNumber == betNumber ? true : false;
        }
    }
}
