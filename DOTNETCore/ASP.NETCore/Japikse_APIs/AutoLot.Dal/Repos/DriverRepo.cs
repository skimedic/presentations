// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - DriverRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
// ==================================

namespace AutoLot.Dal.Repos;

public class DriverRepo : BaseRepo<Driver>, IDriverRepo
{
    public DriverRepo(ApplicationDbContext context) : base(context)
    {
    }

    internal DriverRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    internal IOrderedQueryable<Driver> BuildQuery()
        => Table.OrderBy(m => m.PersonInformation.LastName).ThenBy(f => f.PersonInformation.FirstName);

    public override IEnumerable<Driver> GetAll() => BuildQuery();

    public override IEnumerable<Driver> GetAllIgnoreQueryFilters()
        => BuildQuery().IgnoreQueryFilters();
}