using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{

    public record SpinDto
    {
        public Guid Id { get; init; }
        public long SpinResult { get; init; }
        public DateTime TimestampUtc { get; init; }
    };
}
