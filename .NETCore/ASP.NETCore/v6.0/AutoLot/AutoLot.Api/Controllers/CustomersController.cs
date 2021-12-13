namespace AutoLot.Api.Controllers;

public class CustomersController : BaseCrudController<Customer, CustomersController>
{
    public CustomersController(IAppLogging<CustomersController> logger, ICustomerRepo repo)
        : base(logger, repo)
    {
    }
}