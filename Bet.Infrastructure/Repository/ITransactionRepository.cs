namespace Bet.Infrastructure.Repository;
public interface ITransactionRepository
{
    Task<Transaction> CreateAsync(Transaction entity);
}