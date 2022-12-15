using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IBetService BetService { get; }
        ISpinService SpinService { get; }
        IPayoutService PayoutService { get; }
    }
}
