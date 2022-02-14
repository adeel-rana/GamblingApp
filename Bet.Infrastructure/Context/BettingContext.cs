using Bet.Domain.Models;
using Bet.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bet.Infrastructure.Context
{
    public class BettingContext : IdentityDbContext<ApplicationUser>, IBettingContext
    {
        public BettingContext(DbContextOptions<BettingContext> options)
            : base(options)
        {

        }
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<BettingHistory> BettingHistory => Set<BettingHistory>();
    }
}
