using _Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISpinRepository
    {
        Task<IEnumerable<Spin>> GetAllSpinsAsync(bool trackChanges);
        Task<Spin> GetSpinAsync(Guid spinId, bool trackChanges);
        Task<Spin> GetNextSpinAsync(Guid betId, bool trackChanges);
    }
}
