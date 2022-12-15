using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class BetParameters : RequestParameters
    {

        public BetParameters() => OrderBy = "BetOn";
        public uint MinValue { get; set; }
        public uint MaxValue { get; set; } = int.MaxValue;
        public bool ValidValueRange => MaxValue > MinValue;
        public string? SearchTerm { get; set; }
    }
}
