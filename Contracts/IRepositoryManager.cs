using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ISpinRepository Spin { get; }
        IPayoutRepository Payout { get; }
        IBetRepository Bet { get; }
        Task SaveAsync();
    }
}
