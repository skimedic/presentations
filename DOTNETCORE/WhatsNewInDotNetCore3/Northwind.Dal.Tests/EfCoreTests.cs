using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Northwind.Dal.EfStructures;
using Xunit;

namespace Northwind.Dal.Tests
{
    public class EfCoreTests : IDisposable
    {
        private AdventureWorksDbContext _context;
        public EfCoreTests()
        {
            _context = new AdventureWorksDbContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact]
        public void ShouldNotAllowClientExecution()
        {
            var query = _context.Employee.Where(x=>IsEvenMonth(x.HireDate));
            var ex = Assert.Throws<InvalidOperationException>(() => query.ToList());
            Assert.Contains("The LINQ expression", ex.Message);
            Assert.Contains("could not be translated", ex.Message);
        }
        internal bool IsEvenMonth(DateTime date)
        {
            return date.Month % 2 == 0;
        }
        [Fact]
        public void ShouldExecuteQueryWithJoin()
        {
            var test = _context.Product
                .Include(x => x.BillOfMaterialsComponent)
                .Where(x => x.Name.Contains("Caps"))
                .ToList();
        }

        [Fact]
        public async Task ShouldProcessAsyncQuery()
        {
            var orders =
                from o in _context.Product
                where o.Name.Contains(("Caps"))
                select o;

            await foreach(var o in orders.AsAsyncEnumerable())
            {
                var foo = "foo";
                //Process(o);
            }
        }
    }
}
