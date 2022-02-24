namespace Bet.Infrastructure.Context;
public interface IBettingContext
{
    DbSet<Transaction> Transactions { get; }
    DbSet<BettingHistory> BettingHistory { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
