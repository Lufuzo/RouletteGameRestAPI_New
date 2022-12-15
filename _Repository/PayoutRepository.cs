using _Entities.Models;
using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Repository
{
    public class PayoutRepository : RepositoryBase<Payout>, IPayoutRepository
    {
        public PayoutRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Payout>> GetAllPayoutsAsync(Guid spinId, Guid betId, bool trackChanges) =>
          await FindAll(trackChanges)
          .Where(Id => Id.SpinId == spinId && Id.BetId == betId)
          .OrderBy(c => c.TimestampUtc)
          .ToListAsync();

        public async Task<Payout> GetPayoutAsync(Guid Id, Guid spinId, Guid betId, bool trackChanges) =>
           await FindByCondition(c => c.Id.Equals(Id) && c.BetId.Equals(betId) && c.SpinId.Equals(spinId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
