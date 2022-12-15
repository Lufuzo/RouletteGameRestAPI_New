using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPayoutService
    {
        Task<IEnumerable<PayoutDto>> GetAllPayoutsAsync(Guid spinId, Guid betId, bool trackChanges);
        Task<PayoutDto> GetPayoutAsync(Guid Id, Guid spinId, Guid betId, bool trackChanges);
    }
}
