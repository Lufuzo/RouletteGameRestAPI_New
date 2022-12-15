using _Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPayoutRepository
    {
        Task<IEnumerable<Payout>> GetAllPayoutsAsync(Guid spinId, Guid betId, bool trackChanges);
        Task<Payout> GetPayoutAsync(Guid Id, Guid spinId, Guid betId, bool trackChanges);
    }
}
