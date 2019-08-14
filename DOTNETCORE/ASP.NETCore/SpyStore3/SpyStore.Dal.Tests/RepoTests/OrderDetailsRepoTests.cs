using System.Linq;
using SpyStore.Dal.Repos;
using SpyStore.Dal.Repos.Interfaces;
using SpyStore.Dal.Tests.RepoTests.Base;
using Xunit;

namespace SpyStore.Dal.Tests.RepoTests
{
    [Collection("SpyStore.Dal")]
    public class OrderDetailRepoTests : RepoTestsBase
    {
        private readonly IOrderDetailRepo _repo;

        public OrderDetailRepoTests()
        {
            _repo = new OrderDetailRepo(Context);
            Context.CustomerId = 1;
            LoadDatabase();
        }
        public override void Dispose()
        {
            _repo.Dispose();
        }

        [Fact]
        public void ShouldGetAllOrderDetails()
        {
            var orders = _repo.GetAll().ToList();
            Assert.Equal(_repo.Table.Count(),orders.Count());
        }

        [Fact]
        public void ShouldGetLineItemTotal()
        {
            var orderDetails = _repo.GetOrderDetailsWithProductInfoForOrder(1).ToList();
            var orderDetail = orderDetails.First(x=>x.ProductId == 25);
            Assert.Equal(1799.9700M, orderDetail.LineItemTotal);
        }

    }
}
