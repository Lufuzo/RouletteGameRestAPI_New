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
    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasData(
                new Bet
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    BetOn = "HIGH",
                    BetValue = 50.62m,
                    TimestampUtc = DateTime.UtcNow
                },
                new Bet
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    BetOn = "RED",
                    BetValue = 46.45m,
                    TimestampUtc = DateTime.UtcNow,
                }); ;
        }

    }
}
