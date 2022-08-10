// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - CustomersController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Api.Controllers;

public class CustomersController : BaseCrudController<Customer, CustomersController>
{
    public CustomersController(IAppLogging<CustomersController> logger, ICustomerRepo repo)
        : base(logger, repo)
    {
    }
}