using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SpyStore.Dal.EfStructures;
using SpyStore.Dal.Repos.Base;
using SpyStore.Dal.Repos.Interfaces;
using SpyStore.Models.Entities;

namespace SpyStore.Dal.Repos
{
    public class CategoryRepo : RepoBase<Category>, ICategoryRepo
    {
        public CategoryRepo(StoreContext context) : base(context)
        {
        }

        internal CategoryRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public override IEnumerable<Category> GetAll() => base.GetAll(x => x.CategoryName);


    }
}
