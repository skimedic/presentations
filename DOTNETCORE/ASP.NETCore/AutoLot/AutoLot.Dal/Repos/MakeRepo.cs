using System.Collections.Generic;
using System.Linq;
using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Models.Entities;
using AutoLot.Dal.Repos.Base;
using AutoLot.Dal.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Dal.Repos
{
    public class MakeRepo : BaseRepo<Make>, IMakeRepo
    {
        public MakeRepo(ApplicationDbContext context) : base(context)
        {
        }

        internal MakeRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override IEnumerable<Make> GetAll()
            => Table.OrderBy(m => m.Name);
    }
}