namespace AutoLot.Dal.Repos;

public class MakeRepo : TemporalTableBaseRepo<Make>, IMakeRepo
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
