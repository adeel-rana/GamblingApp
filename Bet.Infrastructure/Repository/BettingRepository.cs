namespace Bet.Infrastructure.Repository;
public class BettingRepository : IBettingRepository
{
    private readonly BettingContext _context;

    public BettingRepository(BettingContext context)
    {
        _context = context;
    }

    public async Task<BettingHistory> CreateAsync(BettingHistory entity)
    {
        _context.Set<BettingHistory>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<BettingHistory>> GetAsync(string userId)
    {
        return await _context.BettingHistory.Where(x => x.UserId.Equals(userId)).ToListAsync();
    }

    public double GetBalance(string userId)
    {
        return _context.Transactions.Where(x => x.UserId.Equals(userId)).Sum(x => x.Balance);
    }
}