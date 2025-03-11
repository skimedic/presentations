// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - CarRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
// ==================================

namespace AutoLot.Dal.Repos;

public class CarRepo : BaseRepo<Car>, ICarRepo
{
    public CarRepo(ApplicationDbContext context) : base(context)
    {
    }

    internal CarRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    internal IOrderedQueryable<Car> BuildBaseQuery()
        => Table.Include(x => x.MakeNavigation).OrderBy(p => p.PetName);

    public override IEnumerable<Car> GetAll() => BuildBaseQuery();

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

    public int SetAllDrivableCarsColorAndMakeId(string color, int makeId)
        => ExecuteBulkUpdate(x => x.IsDrivable,
            c => c.SetProperty(x => x.Color, color).SetProperty(x => x.MakeId, makeId));

    public int DeleteNonDrivableCars() => ExecuteBulkDelete(x => !x.IsDrivable);

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
        ExecuteParameterizedQuery("EXEC [dbo].[GetPetName] @carId, @petName OUTPUT", [parameterId, parameterName]);
        return (string)parameterName.Value;
    }
}