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
    internal sealed class SpinService : ISpinService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SpinService(IRepositoryManager repository,
            ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SpinDto>> GetAllSpinsAsync(bool trackChanges)
        {
            var spins = await _repository.Spin.GetAllSpinsAsync(trackChanges);

            var spinsDto = _mapper.Map<IEnumerable<SpinDto>>(spins);

            return spinsDto;
        }

        public async Task<SpinDto> GetNextSpinAsync(Guid betId, bool trackChanges)
        {
            var bet = await _repository.Bet.GetBetAsync(betId, trackChanges);
            if (bet is null)
                throw new BetNotFoundException(betId);

            var spin = await _repository.Spin.GetNextSpinAsync(betId, trackChanges);
            _repository.SaveAsync();
            var sipnDto = _mapper.Map<SpinDto>(spin);

            return sipnDto;
        }

        public async Task<SpinDto> GetSpinAsync(Guid spinId, bool trackChanges)
        {
            var spin = await _repository.Spin.GetSpinAsync(spinId, trackChanges);
            if (spin is null)
                throw new SpinNotFoundException(spinId);

            var sipnDto =  _mapper.Map<SpinDto>(spin);

            return sipnDto;
        }


    }
}
