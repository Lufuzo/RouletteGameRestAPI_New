using _Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;


using System.Collections.Generic;


using Xunit;

namespace RouletteGameAPI.UnitTests.Repositories
{
    public class TestBetRepository : IDisposable
    {
        protected readonly RepositoryContext _context;
        public TestBetRepository()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite("Data Source= TestRouletteDB.db")
                .Options;

            _context = new RepositoryContext(options);
            _context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();

        }

    }
}
