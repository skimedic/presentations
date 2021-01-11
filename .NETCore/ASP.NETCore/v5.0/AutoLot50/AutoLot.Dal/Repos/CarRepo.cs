using System.Collections.Generic;
using System.Data;
using System.Linq;
using AutoLot.Dal.EfStructures;
using AutoLot.Models.Entities;
using AutoLot.Dal.Repos.Base;
using AutoLot.Dal.Repos.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Dal.Repos
{
    public class CarRepo : BaseRepo<Car>, ICarRepo
    {
        public CarRepo(ApplicationDbContext context) : base(context)
        {
        }

        internal CarRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override IEnumerable<Car> GetAll()
            => Table.Include(c => c.MakeNavigation).OrderBy(o => o.PetName);

        public override IEnumerable<Car> GetAllIgnoreQueryFilters()
            => Table.Include(c => c.MakeNavigation).OrderBy(o => o.PetName).IgnoreQueryFilters();

        public IEnumerable<Car> GetAllBy(int makeId)
        {
            return Table.Where(x=>x.MakeId == makeId).Include(c => c.MakeNavigation).OrderBy(c => c.PetName);
        }

public string GetPetName(int id)
{
    var parameterId = new SqlParameter
    {
        ParameterName = "@carId",
        SqlDbType = System.Data.SqlDbType.Int,
        Value = id,
    };

    var parameterName = new SqlParameter
    {
        ParameterName = "@petName",
        SqlDbType = System.Data.SqlDbType.NVarChar,
        Size = 50,
        Direction = ParameterDirection.Output
    };

    var result = Context.Database
        .ExecuteSqlRaw("EXEC [dbo].[GetPetName] @carId, @petName OUTPUT",parameterId, parameterName);
    return (string)parameterName.Value;
}

        public override Car? Find(int? id)
            => Table.IgnoreQueryFilters().Where(x => x.Id == id).Include(m => m.MakeNavigation).FirstOrDefault();
    }
}
