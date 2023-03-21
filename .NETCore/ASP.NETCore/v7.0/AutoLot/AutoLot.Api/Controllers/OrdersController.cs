// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Api - OrdersController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/11/26
// ==================================

namespace AutoLot.Api.Controllers;

public class OrdersController : BaseCrudController<Order, OrdersController>
{
    public OrdersController(IAppLogging<OrdersController> logger,IOrderRepo repo)
        : base(logger, repo)
    {
    }
}