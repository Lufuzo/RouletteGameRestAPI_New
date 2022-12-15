using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGameAPI.UnitTests.Fixtures
{
    public static class PayoutFixture
    {
        public static List<PayoutDto> GetAllPayouts()
        {
            return new List<PayoutDto>
            {
                  new PayoutDto
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    TotalPayout = 522.5m,
                    TimestampUtc = DateTime.UtcNow
                },
                new PayoutDto
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    TotalPayout = 145.5m,
                    TimestampUtc = DateTime.UtcNow
                }
            };
        }
        public static PayoutDto GetPayout(Guid id)
        {
            return GetAllPayouts().Find(x => x.Id == id);
        }

    }
}
