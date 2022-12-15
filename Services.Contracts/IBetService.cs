using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBetService
    {
        Task<(IEnumerable<BetDto> bets, MetaData MetaData)> GetAllBetsAsync(BetParameters betParameters, bool trackChanges);
        Task<BetDto> GetBetAsync(Guid betId, bool trackChanges);
        Task<BetDto> PlaceBetForNextSpinAsync(BetCreateDto betCreation, bool trackChanges);
        Task<IEnumerable<BetDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        Task<(IEnumerable<BetDto> bets, string ids)> CreateBetCollectionAsync(IEnumerable<BetCreateDto> betCollection);
        Task UpdateBetAsync(Guid betid, BetUpdateDto betForUpdate, bool trackChanges);
    }
}
