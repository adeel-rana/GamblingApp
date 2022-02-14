using Bet.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bet.Infrastructure.Context
{
    public interface IBettingContext
    {
        DbSet<Transaction> Transactions { get; }
        DbSet<BettingHistory> BettingHistory { get; }
        
    }
}
