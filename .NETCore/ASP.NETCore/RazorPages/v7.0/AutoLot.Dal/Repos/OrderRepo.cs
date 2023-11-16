// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Dal - OrderRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

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
