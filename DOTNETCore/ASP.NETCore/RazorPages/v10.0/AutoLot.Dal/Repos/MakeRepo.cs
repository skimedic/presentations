// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Dal - MakeRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/02
// ==================================

namespace AutoLot.Dal.Repos;

public class MakeRepo : BaseRepo<Make>, IMakeRepo
{
    public MakeRepo(ApplicationDbContext context) : base(context)
    {
    }

    internal MakeRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    internal IOrderedQueryable<Make> BuildQuery() => Table.OrderBy(m => m.Name);

    public override IEnumerable<Make> GetAll() => BuildQuery();

    public override IEnumerable<Make> GetAllIgnoreQueryFilters()
        => BuildQuery().IgnoreQueryFilters();
}