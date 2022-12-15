using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGameAPI.UnitTests.Fixtures
{
    public static class SpinFixture
    {
        public static List<SpinDto> GetAllSpins()
        {
            return new List<SpinDto>
            {
                new SpinDto
                {
                    Id = new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"),
                    SpinResult = 5,
                    TimestampUtc = DateTime.UtcNow,
                },
                new SpinDto
                {
                    Id = new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                    SpinResult = 7,
                    TimestampUtc = DateTime.UtcNow,
                }
            };
        }
        public static SpinDto GetSpin(Guid id)
        {
            return GetAllSpins().Find(x => x.Id == id);
        }
        public static SpinDto GetNextSpin()
        {
            return new SpinDto
            {
                Id = new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"),
                SpinResult = 5,
                TimestampUtc = DateTime.UtcNow,
            };
        }
    }
}
