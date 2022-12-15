using _Entities.Models;
using _Repository.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SpinConfiguration());
            modelBuilder.ApplyConfiguration(new PayoutConfiguration());
            modelBuilder.ApplyConfiguration(new BetConfiguration());
        }

        public DbSet<Spin>? Spins { get; set; }
        public DbSet<Bet>? Bets { get; set; }
        public DbSet<Payout>? Payouts { get; set; }
    }
}
