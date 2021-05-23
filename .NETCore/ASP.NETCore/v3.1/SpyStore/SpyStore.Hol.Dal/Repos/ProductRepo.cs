using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Dal.Repos
{
    public class ProductRepo : RepoBase<Product>,IProductRepo
    {
        public ProductRepo(StoreContext context) : base(context)
        {
        }

        internal ProductRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public override IEnumerable<Product> GetAll() => base.GetAll(x => x.Details.ModelName);

        public IList<Product> Search(string searchString)
            => Table.Where(p => EF.Functions.Like(p.Details.Description, $"%{searchString}%")
                                || EF.Functions.Like(p.Details.ModelName, $"%{searchString}%"))
                .Include(p => p.CategoryNavigation)
                .OrderBy(x => x.Details.ModelName)
                .ToList();

        public IList<Product> GetProductsForCategory(int id)
            => Table.Where(p => p.CategoryId == id)
                .Include(p => p.CategoryNavigation)
                .OrderBy(x => x.Details.ModelName)
                .ToList();

        public IList<Product> GetFeaturedWithCategoryName()
            => Table.Where(p => p.IsFeatured)
                .Include(p => p.CategoryNavigation)
                .OrderBy(x => x.Details.ModelName)
                .ToList();

        public Product GetOneWithCategoryName(int id)
            => Table.Where(p => p.Id == id)
                .Include(p => p.CategoryNavigation)
                .FirstOrDefault();
    }
}
