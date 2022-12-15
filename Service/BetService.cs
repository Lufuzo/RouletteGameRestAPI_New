using _Entities.Exceptions;
using _Entities.Models;
using AutoMapper;
using Contracts;
using Services.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BetService : IBetService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BetService(IRepositoryManager repository,
            ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<(IEnumerable<BetDto> bets, MetaData MetaData)> GetAllBetsAsync(BetParameters betParameters, bool trackChanges)
        {
            if (!betParameters.ValidValueRange)
                throw new MaxValueRangeBadRequestException();
            var betsWithMetaData = await _repository.Bet.GetAllBetsAsync(betParameters, trackChanges);

            var betsDto = _mapper.Map<IEnumerable<BetDto>>(betsWithMetaData);

            return (bets: betsDto, MetaData: betsWithMetaData.MetaData);
        }

        public async Task<BetDto> GetBetAsync(Guid id, bool trackChanges)
        {
            var bet = await _repository.Bet.GetBetAsync(id, trackChanges);
            if (bet is null)
                throw new BetNotFoundException(id);

            var BetDto = _mapper.Map<BetDto>(bet);
            return BetDto;
        }

        public async Task<BetDto> PlaceBetForNextSpinAsync(BetCreateDto betForCreation, bool trackChanges)
        {
            var betEntity = _mapper.Map<Bet>(betForCreation);

            _repository.Bet.PlaceBetForNextSpin(betEntity);
            await _repository.SaveAsync();

            var betToReturn = _mapper.Map<BetDto>(betEntity);

            return betToReturn;
        }

        public async Task<IEnumerable<BetDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var betEntities = await _repository.Bet.GetByIdsAsync(ids, trackChanges);
            if (ids.Count() != betEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var betsToReturn = _mapper.Map<IEnumerable<BetDto>>(betEntities);

            return betsToReturn;
        }

        public async Task<(IEnumerable<BetDto> bets, string ids)> CreateBetCollectionAsync
        (IEnumerable<BetCreateDto> betCollection)
        {
            if (betCollection is null)
                throw new BetCollectionBadRequest();

            var betEntities = _mapper.Map<IEnumerable<Bet>>(betCollection);
            foreach (var bet in betEntities)
            {
                _repository.Bet.PlaceBetForNextSpin(bet);
            }

            await _repository.SaveAsync();

            var betCollectionToReturn = _mapper.Map<IEnumerable<BetDto>>(betEntities);
            var ids = string.Join(",", betCollectionToReturn.Select(c => c.Id));

            return (bets: betCollectionToReturn, ids: ids);
        }

        public async Task UpdateBetAsync(Guid betId,
        BetUpdateDto betForUpdate, bool trackChanges)
        {
            var bet = await _repository.Bet.GetBetAsync(betId, trackChanges);
            if (bet is null)
                throw new BetNotFoundException(betId);

            _mapper.Map(betForUpdate, bet);
            await _repository.SaveAsync();
        }
    }
}
