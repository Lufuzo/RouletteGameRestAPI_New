using AutoMapper;
using Contracts;
using _Entities.Exceptions;
using Services.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class PayoutService : IPayoutService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PayoutService(IRepositoryManager repository,
            ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PayoutDto>> GetAllPayoutsAsync(Guid spinId, Guid betId, bool trackChanges)
        {
            var payouts = await _repository.Payout.GetAllPayoutsAsync(spinId, betId, trackChanges);

            var payoutsDto = _mapper.Map<IEnumerable<PayoutDto>>(payouts);

            return payoutsDto;
        }

        public async Task<PayoutDto> GetPayoutAsync(Guid Id, Guid spinId, Guid betId, bool trackChanges)
        {
            var bet = await _repository.Bet.GetBetAsync(betId, trackChanges);
            if (bet is null)
                throw new BetNotFoundException(betId);

            var payout = await _repository.Payout.GetPayoutAsync(Id, spinId, betId, trackChanges);

            if (payout is null)
                throw new PayoutNotFoundException(Id);

            var payoutDto = _mapper.Map<PayoutDto>(payout);
            return payoutDto;
        }


    }
}
