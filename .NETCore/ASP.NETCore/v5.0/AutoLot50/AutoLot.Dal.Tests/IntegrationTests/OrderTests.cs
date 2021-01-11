using System.Linq;
using AutoLot.Dal.Repos;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Dal.Tests.Base;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AutoLot.Dal.Tests.IntegrationTests
{
    [Collection("Integration Tests")]
    public class OrderTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTestFixture>
    {
        private readonly IOrderRepo _repo;
        public OrderTests()
        {
            _repo = new OrderRepo(Context);
        }

        public override void Dispose()
        {
            _repo.Dispose();
        }

        [Fact]
        public void ShouldGetAllOrdersExceptFiltered()
        {
            var qs = Context.Orders.ToQueryString();
            var orders = Context.Orders.ToList();
            Assert.NotEmpty(orders);
            Assert.Equal(4,orders.Count);
        }

        [Fact]
        public void ShouldGetAllOrders()
        {
            var query = Context.Orders.IgnoreQueryFilters();
            var qs = query.ToQueryString();
            var orders = query.ToList();
            Assert.NotEmpty(orders);
            Assert.Equal(5,orders.Count);
        }

        [Fact]
        public void ShouldGetAllViewModels()
        {
            var query = _repo.GetOrdersViewModel();
            var qs = query.ToQueryString();
            var orders = query.ToList();
            Assert.NotEmpty(orders);
            Assert.Equal(5,orders.Count);
        }
		
        [Theory]
        [InlineData("Black",2)]
        [InlineData("Rust",1)]
        [InlineData("Yellow",1)]
        [InlineData("Green",0)]
        [InlineData("Pink",1)]
        [InlineData("Brown",0)]
        public void ShouldGetAllViewModelsByColor(string color, int expectedCount)
        {
            var query = _repo.GetOrdersViewModel()
                .Where(x=>x.Color == color);
            var qs = query.ToQueryString();
            var orders = query.ToList();
            Assert.Equal(expectedCount,orders.Count);
        }


    }
}