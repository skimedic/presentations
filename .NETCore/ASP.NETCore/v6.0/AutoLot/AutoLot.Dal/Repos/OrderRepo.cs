namespace AutoLot.Dal.Repos;

public class OrderRepo : TemporalTableBaseRepo<Order>, IOrderRepo
{
    public OrderRepo(ApplicationDbContext context) : base(context)
    {
    }

    internal OrderRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

}
