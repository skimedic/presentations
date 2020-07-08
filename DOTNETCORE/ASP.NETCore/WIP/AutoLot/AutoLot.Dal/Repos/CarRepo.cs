using System.Collections.Generic;
using System.Linq;
using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Models.Entities;
using AutoLot.Dal.Repos.Base;
using AutoLot.Dal.Repos.Interfaces;
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

        public override IEnumerable<Car> GetAllIgnoreQueryFilters() 
            => Table.Include(c => c.MakeNavigation).OrderBy(o => o.PetName).IgnoreQueryFilters();

        public IEnumerable<Car> GetAllBy(int makeId)
        {
            Context.MakeId = makeId;
            return Table.Include(c => c.MakeNavigation).OrderBy(c => c.PetName);
        }

        public override Car Find(int? id)
            => Table.IgnoreQueryFilters().Where(x => x.Id == id).Include(m => m.MakeNavigation).FirstOrDefault();
    }
}
