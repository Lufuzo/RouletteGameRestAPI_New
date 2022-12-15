using _Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBetRepository
    {
        Task<PagedList<Bet>> GetAllBetsAsync(BetParameters betParameters, bool trackChanges);
        Task<Bet> GetBetAsync(Guid betId, bool trackChanges);
        void PlaceBetForNextSpin(Bet bet);
        Task<IEnumerable<Bet>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    }
}
