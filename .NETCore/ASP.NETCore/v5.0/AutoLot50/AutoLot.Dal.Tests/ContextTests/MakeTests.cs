// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal.Tests - MakeTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System.Linq;
using AutoLot.Dal.Repos;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Dal.Tests.Base;
using Xunit;

namespace AutoLot.Dal.Tests.ContextTests
{
    [Collection("Integration Tests")]
    public class MakeTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTestFixture>
    {
        private readonly IMakeRepo _repo;
        public MakeTests()
        {
            _repo = new MakeRepo(Context);
        }

        public override void Dispose()
        {
            _repo.Dispose();
        }

        [Fact]
        public void ShouldGetMakesWithCarsThatHaveOrders()
        {
            var makes = _repo.GetOrderByMake().ToList();
            Assert.NotNull(makes);
            Assert.NotEmpty(makes);
            Assert.NotEmpty(makes.Where(x=>x.Cars.Any()));
            Assert.Equal(2,makes.First(m=>m.Id==5).Cars.Count());
            Assert.Equal(1,makes.First(m=>m.Id==1).Cars.Count());
            Assert.Equal(1,makes.First(m=>m.Id==4).Cars.Count());
        }
    }
}