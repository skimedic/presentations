using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore_HOL.DAL.EF;
using SpyStore_HOL.DAL.Repos.Base;
using SpyStore_HOL.DAL.Repos.Interfaces;
using SpyStore_HOL.Models.Entities;
using SpyStore_HOL.Models.ViewModels.Base;

namespace SpyStore_HOL.DAL.Repos
{
    public class ProductRepo : RepoBase<Product>, IProductRepo
    {
        public ProductRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public ProductRepo() : base()
        {
        }
        public override IEnumerable<Product> GetAll()
            => Table.OrderBy(x => x.ModelName);
        public override IEnumerable<Product> GetRange(int skip, int take)
            => GetRange(Table.OrderBy(x => x.ModelName), skip, take);

        internal ProductAndCategoryBase GetRecord(Product p, Category c)
            => new ProductAndCategoryBase()
            {
                CategoryName = c.CategoryName,
                CategoryId = p.CategoryId,
                CurrentPrice = p.CurrentPrice,
                Description = p.Description,
                IsFeatured = p.IsFeatured,
                Id = p.Id,
                ModelName = p.ModelName,
                ModelNumber = p.ModelNumber,
                ProductImage = p.ProductImage,
                ProductImageLarge = p.ProductImageLarge,
                ProductImageThumb = p.ProductImageThumb,
                TimeStamp = p.TimeStamp,
                UnitCost = p.UnitCost,
                UnitsInStock = p.UnitsInStock
            };

        public IList<ProductAndCategoryBase> GetProductsForCategory(int id)
            => Table
                .Where(p => p.CategoryId == id)
                .Include(p => p.Category)
                .Select(item => GetRecord(item, item.Category))
                .OrderBy(x => x.ModelName).ToList();
    
        public IList<ProductAndCategoryBase> GetFeaturedWithCategoryName()
            => Table
                .Where(p => p.IsFeatured)
                .Include(p => p.Category)
                .Select(item => GetRecord(item, item.Category))
                .OrderBy(x => x.ModelName).ToList();

        public ProductAndCategoryBase GetOneWithCategoryName(int id)
            => Table
                .Where(p => p.Id == id)
                .Include(p => p.Category)
                .Select(item => GetRecord(item, item.Category))
                .SingleOrDefault();

        public IList<ProductAndCategoryBase> Search(string searchString)
            => Table
                .Where(p =>
                    p.Description.ToLower().Contains(searchString.ToLower())
                    || p.ModelName.ToLower().Contains(searchString.ToLower()))
                .Include(p => p.Category)
                .Select(item => GetRecord(item, item.Category))
                .OrderBy(x => x.ModelName).ToList();
    }
}
