using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IBetRepository> _betRepository;
        private readonly Lazy<ISpinRepository> _spinRepository;
        private readonly Lazy<IPayoutRepository> _payoutRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _betRepository = new Lazy<IBetRepository>(() => new BetRepository(repositoryContext));
            _spinRepository = new Lazy<ISpinRepository>(() => new SpinRepository(repositoryContext));
            _payoutRepository = new Lazy<IPayoutRepository>(() => new PayoutRepository(repositoryContext));
        }

        public IBetRepository Bet => _betRepository.Value;
        public ISpinRepository Spin => _spinRepository.Value;
        public IPayoutRepository Payout => _payoutRepository.Value;
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
