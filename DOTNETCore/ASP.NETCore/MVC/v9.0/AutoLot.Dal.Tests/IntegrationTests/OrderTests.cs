﻿// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Dal.Tests - OrderTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Dal.Tests.IntegrationTests;

[Collection("Integration Tests")]
public class OrderTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTestFixture>
{
    private readonly IOrderRepo _repo;

    public OrderTests(ITestOutputHelper outputHelper) : base(outputHelper)
    {
        _repo = new OrderRepo(Context);
    }

    public override void Dispose()
    {
        _repo.Dispose();
        base.Dispose();
    }

    [Fact]
    public void ShouldGetAllOrdersExceptFiltered()
    {
        var qs = Context.Orders.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        var orders = Context.Orders.ToList();
        Assert.NotEmpty(orders);
        Assert.Equal(4, orders.Count);
    }

    [Fact]
    public void ShouldGetAllOrders()
    {
        var query = Context.Orders.IgnoreQueryFilters();
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        var orders = query.ToList();
        Assert.NotEmpty(orders);
        Assert.Equal(5, orders.Count);
    }
}