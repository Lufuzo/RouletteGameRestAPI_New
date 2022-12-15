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
    public class SpinRepository : RepositoryBase<Spin>, ISpinRepository
    {

        public SpinRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Spin>> GetAllSpinsAsync(bool trackChanges) =>
           await FindAll(trackChanges)
            .OrderBy(c => c.TimestampUtc)
            .ToListAsync();

        public async Task<Spin> GetSpinAsync(Guid spinId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(spinId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<Spin> GetNextSpinAsync(Guid betId, bool trackChanges)
        {
            Spin? nextSpin = await FindAll(trackChanges)
                .Where(s => !s.SpinResult.HasValue)
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync();
            if (nextSpin == null)
            {
                Create(nextSpin = new Spin()
                {
                    Id = Guid.NewGuid(),
                    SpinResult = Random.Shared.Next(1, 37),
                    TimestampUtc = DateTime.UtcNow,
                    BetId = betId,
                });
            }
            return nextSpin;
        }
    }
}
