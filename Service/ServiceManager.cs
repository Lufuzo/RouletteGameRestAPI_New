using AutoMapper;
using Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBetService> _betService;
        private readonly Lazy<ISpinService> _spinService;
        private readonly Lazy<IPayoutService> _payoutService;


        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerManager logger, IMapper mapper)
        {
            _betService = new Lazy<IBetService>(() =>
                new BetService(repositoryManager, logger, mapper));
            _spinService = new Lazy<ISpinService>(() =>
                new SpinService(repositoryManager, logger, mapper));
            _payoutService = new Lazy<IPayoutService>(() =>
                new PayoutService(repositoryManager, logger, mapper));
        }

        public IBetService BetService => _betService.Value;
        public ISpinService SpinService => _spinService.Value;
        public IPayoutService PayoutService => _payoutService.Value;

    }
}
