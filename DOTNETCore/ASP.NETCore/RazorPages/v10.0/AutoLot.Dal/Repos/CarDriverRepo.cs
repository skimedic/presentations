// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Dal - CarDriverRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/02
// ==================================

namespace AutoLot.Dal.Repos;

public class CarDriverRepo : BaseRepo<CarDriver>, ICarDriverRepo
{
    public CarDriverRepo(ApplicationDbContext context) : base(context)
    {
    }

    internal CarDriverRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    internal IIncludableQueryable<CarDriver, Driver> BuildBaseQuery()
        => Table.Include(c => c.CarNavigation).Include(d => d.DriverNavigation);

    public override IEnumerable<CarDriver> GetAll() => BuildBaseQuery();

    public override IEnumerable<CarDriver> GetAllIgnoreQueryFilters()
        => BuildBaseQuery().IgnoreQueryFilters();

    public override CarDriver Find(int? id)
        => BuildBaseQuery().IgnoreQueryFilters().FirstOrDefault(x => x.Id == id);
}