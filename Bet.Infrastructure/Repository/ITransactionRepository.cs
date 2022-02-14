using Bet.Domain.Models;
using System.Threading.Tasks;

namespace Bet.Infrastructure.Repository
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateAsync(Transaction entity);
    }
}
