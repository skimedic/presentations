// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal.Tests - OrderTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/27
// ==================================

using System.Linq;
using AutoLot.Dal.Repos;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Dal.Tests.Base;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AutoLot.Dal.Tests.ContextTests
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
            var query = Context.Orders.AsQueryable();
            var queryString = query.ToQueryString();
            var orders = query.ToList();
            Assert.NotEmpty(orders);
            Assert.Equal(4,orders.Count);
        }

        [Fact]
        public void ShouldGetAllOrders()
        {
            var query = Context.Orders.IgnoreQueryFilters();
            var queryString = query.ToQueryString();
            var orders = query.ToList();
            Assert.NotEmpty(orders);
            Assert.Equal(5,orders.Count);
        }


    }
}