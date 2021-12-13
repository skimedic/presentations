namespace AutoLot.Dal.Repos.Base;

public abstract class TemporalTableBaseRepo<T> : BaseRepo<T>, ITemporalTableBaseRepo<T> where T : BaseEntity, new()
{
    protected TemporalTableBaseRepo(ApplicationDbContext context) : base(context)
    {
    }

    protected TemporalTableBaseRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    internal static DateTime ConvertToUtc(DateTime dateTime) 
        => TimeZoneInfo.ConvertTimeToUtc(dateTime, TimeZoneInfo.Local);

    internal static IEnumerable<TemporalViewModel<T>> ExecuteQuery(IQueryable<T> query) 
        => query.OrderBy(e => EF.Property<DateTime>(e, "ValidFrom"))
            .Select(e => new TemporalViewModel<T>
            {
                Entity = e,
                ValidFrom = EF.Property<DateTime>(e, "ValidFrom"),
                ValidTo = EF.Property<DateTime>(e, "ValidTo")
            });

    public IEnumerable<TemporalViewModel<T>> GetAllHistory() 
        => ExecuteQuery(Table.TemporalAll());

    public IEnumerable<TemporalViewModel<T>> GetHistoryAsOf(DateTime dateTime) 
        => ExecuteQuery(Table.TemporalAsOf(ConvertToUtc(dateTime)));

    public IEnumerable<TemporalViewModel<T>> GetHistoryBetween(
        DateTime startDateTime, DateTime endDateTime) 
        => ExecuteQuery(Table.TemporalBetween(ConvertToUtc(startDateTime), ConvertToUtc(endDateTime)));

    public IEnumerable<TemporalViewModel<T>> GetHistoryContainedIn(
        DateTime startDateTime, DateTime endDateTime)
        => ExecuteQuery(Table.TemporalContainedIn(ConvertToUtc(startDateTime), ConvertToUtc(endDateTime)));

    public IEnumerable<TemporalViewModel<T>> GetHistoryFromTo(
        DateTime startDateTime, DateTime endDateTime) 
        => ExecuteQuery(Table.TemporalFromTo(ConvertToUtc(startDateTime), ConvertToUtc(endDateTime)));
}