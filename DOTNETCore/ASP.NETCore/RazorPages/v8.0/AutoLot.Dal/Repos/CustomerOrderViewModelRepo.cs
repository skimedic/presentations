// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Dal - CustomerOrderViewModelRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Dal.Repos;

public class CustomerOrderViewModelRepo : BaseViewRepo<CustomerOrderViewModel>, ICustomerOrderViewModelRepo
{
    public CustomerOrderViewModelRepo(ApplicationDbContext context) : base(context)
    {
    }

    internal CustomerOrderViewModelRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
