namespace AutoLot.Dal.Repos;

public class CarRepo : TemporalTableBaseRepo<Car>, ICarRepo
{
    public CarRepo(ApplicationDbContext context) : base(context)
    {
    }

    internal CarRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    internal IOrderedQueryable<Car> BuildBaseQuery()
        => Table.Include(x => x.MakeNavigation).OrderBy(p => p.PetName);

    public override IEnumerable<Car> GetAll()
        => BuildBaseQuery();

    public override IEnumerable<Car> GetAllIgnoreQueryFilters()
        => BuildBaseQuery().IgnoreQueryFilters();

    public IEnumerable<Car> GetAllBy(int makeId)
        => BuildBaseQuery().Where(x => x.MakeId == makeId);

    public override Car Find(int? id)
        => Table
            .IgnoreQueryFilters()
            .Where(x => x.Id == id)
            .Include(m => m.MakeNavigation)
            .FirstOrDefault();

    public string GetPetName(int id)
    {
        var parameterId = new SqlParameter
        {
            ParameterName = "@carId",
            SqlDbType = SqlDbType.Int,
            Value = id,
        };

        var parameterName = new SqlParameter
        {
            ParameterName = "@petName",
            SqlDbType = SqlDbType.NVarChar,
            Size = 50,
            Direction = ParameterDirection.Output
        };
        ExecuteParameterizedQuery("EXEC [dbo].[GetPetName] @carId, @petName OUTPUT",
            new[] { parameterId, parameterName });
        //_ = Context.Database.ExecuteSqlRaw("EXEC [dbo].[GetPetName] @carId, @petName OUTPUT",parameterId, parameterName);
        return (string)parameterName.Value;
    }
}