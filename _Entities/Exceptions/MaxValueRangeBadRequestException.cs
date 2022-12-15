using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Entities.Exceptions
{
    public sealed class MaxValueRangeBadRequestException : BadRequestException
    {

        public MaxValueRangeBadRequestException() :
            base("Max value can't be less than min value.")
        {
        }
    }
}
