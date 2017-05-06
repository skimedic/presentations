using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore_HOL.DAL.EF;
using SpyStore_HOL.DAL.Repos.Base;
using SpyStore_HOL.DAL.Repos.Interfaces;
using SpyStore_HOL.Models.Entities;

namespace SpyStore_HOL.DAL.Repos
{
    public class CategoryRepo : RepoBase<Category>, ICategoryRepo
    {
        public CategoryRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public CategoryRepo()
        {
        }
        public override IEnumerable<Category> GetAll() 
            => Table.OrderBy(x => x.CategoryName);

        public override IEnumerable<Category> GetRange(int skip, int take) 
            => GetRange(Table.OrderBy(x => x.CategoryName),skip,take);
    }
}