using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Dal.Repos
{
    public class CategoryRepo : RepoBase<Category>, ICategoryRepo
    {
        public CategoryRepo(StoreContext context) : base(context)
        {
        }

        internal CategoryRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public override IEnumerable<Category> GetAll() => 
            base.GetAll(x=>x.CategoryName);
        //public override IEnumerable<Category> GetAll() => base.GetAll(x => x.CategoryName);


    }
}
