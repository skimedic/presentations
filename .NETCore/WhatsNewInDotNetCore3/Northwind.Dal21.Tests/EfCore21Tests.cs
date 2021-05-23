using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Northwind.Dal21.Models;
using Xunit;

namespace Northwind.Dal21.Tests
{
    public class EfCore21Tests : IDisposable
    {
        private AdventureWorksDbContext _context;

        public EfCore21Tests()
        {
            _context = new AdventureWorksDbContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        [Fact]
        public void ShouldExecuteQueryWithJoin()
        {
            var test = _context.Product
                .Include(x => x.BillOfMaterialsComponent)
                .Where(x => x.Name.Contains("Caps"))
                .ToList();
        }
    }
}
