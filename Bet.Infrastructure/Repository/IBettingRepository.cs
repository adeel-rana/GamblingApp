using Bet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bet.Infrastructure.Repository
{
    public interface IBettingRepository
    {
        Task<BettingHistory> CreateAsync(BettingHistory entity);
        Task<List<BettingHistory>> GetAsync(string userId);
        double GetBalance(string userId);
    }
}
