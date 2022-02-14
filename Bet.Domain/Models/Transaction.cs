using System;

namespace Bet.Domain.Models
{
    public record Transaction(string UserId, double Balance)
    {
        public int Id { get; set; }
        public DateTime TransactionTime { get; private set; } = DateTime.Now;
        public BettingHistory BettingHistory { get; set; }
    }
}
