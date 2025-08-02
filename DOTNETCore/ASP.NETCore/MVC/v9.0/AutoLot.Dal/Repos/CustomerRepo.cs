// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Dal - CustomerRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Dal.Repos;

public class CustomerRepo : BaseRepo<Customer>, ICustomerRepo
{
    public CustomerRepo(ApplicationDbContext context) : base(context)
    {
    }

    internal CustomerRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public override IEnumerable<Customer> GetAll()
        => Table.Include(c => c.Orders).OrderBy(o => o.PersonInformation.LastName);
}
