using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISpinService
    {
        Task<IEnumerable<SpinDto>> GetAllSpinsAsync(bool trackChanges);
        Task<SpinDto> GetSpinAsync(Guid spinId, bool trackChanges);
        Task<SpinDto> GetNextSpinAsync(Guid betId, bool trackChanges);
    }
}
