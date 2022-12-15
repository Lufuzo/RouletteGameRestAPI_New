using _Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Repository.Configuration
{
    public class SpinConfiguration : IEntityTypeConfiguration<Spin>
    {
        public void Configure(EntityTypeBuilder<Spin> builder)
        {
            builder.HasData(
                new Spin
                {
                    Id = new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"),
                    SpinResult = 5,
                    TimestampUtc = DateTime.UtcNow,
                    BetId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Spin
                {
                    Id = new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                    SpinResult = 7,
                    TimestampUtc = DateTime.UtcNow,
                    BetId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                });
        }
    }
}
