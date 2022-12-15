using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Entities.Exceptions
{
    public sealed class PayoutNotFoundException : NotFoundException
    {
        public PayoutNotFoundException(Guid payoutId) :
                   base($"The payout with id: {payoutId} doesn't exist in the database.")
        {
        }

    }
}
