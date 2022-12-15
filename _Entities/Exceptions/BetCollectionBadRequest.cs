using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Entities.Exceptions
{
    public sealed class BetCollectionBadRequest : BadRequestException
    {
        public BetCollectionBadRequest()
            : base("Bet collection sent from a client is null.")
        {
        }
    }
}
