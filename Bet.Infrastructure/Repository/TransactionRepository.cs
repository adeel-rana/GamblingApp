namespace Bet.Infrastructure.Repository;
public class TransactionRepository : ITransactionRepository
{
    private readonly BettingContext _context;

    public TransactionRepository(BettingContext context)
    {
        _context = context;
    }

    public async Task<Transaction> CreateAsync(Transaction entity)
    {
        _context.Set<Transaction>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
