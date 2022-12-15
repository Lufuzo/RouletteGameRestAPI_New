using _Entities.Models;
using _Repository.Extensions;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Repository
{
    public class BetRepository : RepositoryBase<Bet>, IBetRepository
    {
        public BetRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<PagedList<Bet>> GetAllBetsAsync(BetParameters betParameters, bool trackChanges)
        {
            var bets = await FindAll(trackChanges)
                         .FilterBets(betParameters.MinValue, betParameters.MaxValue)
                           .Search(betParameters.SearchTerm)
                             .Skip((betParameters.PageNumber - 1) * betParameters.PageSize)
                               .Take(betParameters.PageSize)
                                 .Sort(betParameters.OrderBy)
                                     .ToListAsync();
            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Bet>(bets, count, betParameters.PageNumber,
                betParameters.PageSize);
        }

        public async Task<Bet> GetBetAsync(Guid betId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(betId), trackChanges)
            .SingleOrDefaultAsync();

        public void PlaceBetForNextSpin(Bet bet)
        {
            Create(bet);
        }
        public async Task<IEnumerable<Bet>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
          await FindByCondition(x => ids.Contains(x.Id), trackChanges)
          .ToListAsync();
    }
}
