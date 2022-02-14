using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Domain.Models
{
    public record BetResponse(double Balance, string Status,double Points);
}
