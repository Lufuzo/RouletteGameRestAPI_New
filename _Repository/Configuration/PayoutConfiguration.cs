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
    public  class PayoutConfiguration : IEntityTypeConfiguration<Payout>
    {
        public void Configure(EntityTypeBuilder<Payout> builder)
        {
            builder.HasData(
                new Payout
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    TotalPayout = 522.5m,
                    TimestampUtc = DateTime.UtcNow,
                    BetId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    SpinId = new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"),
                },
                new Payout
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    TotalPayout = 145.5m,
                    TimestampUtc = DateTime.UtcNow,
                    BetId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    SpinId = new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                }); ;
        }
    }
}
