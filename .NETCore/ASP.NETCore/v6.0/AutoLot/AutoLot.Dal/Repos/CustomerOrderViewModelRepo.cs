// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - CustomerOrderViewModelRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
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
