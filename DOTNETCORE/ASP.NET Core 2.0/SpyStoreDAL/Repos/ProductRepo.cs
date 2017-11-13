using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SpyStoreDAL.EfContext;
using SpyStoreDAL.Repos.Interfaces;
using SpyStoreDAL.Repos.RepoBase;
using SpyStoreModels.Models;
using SpyStoreModels.ViewModels.Base;

namespace SpyStoreDAL.Repos
{
    public class ProductRepo : RepoBase<Product>, IProductRepo
    {
        public ProductRepo(ApplicationDbContext context) : base(context)
        { }

        public IEnumerable<Product> GetAll() => Table.OrderBy(x => x.ModelName);
        //public IEnumerable<Product> GetRange(int skip, int take)
        //    => GetRange(Table.OrderBy(x => x.ModelName), skip, take);

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
                .OrderBy(x => x.ModelName)
                .Select(item => GetRecord(item, item.Category))
                .ToList();

        public IList<ProductAndCategoryBase> GetFeaturedWithCategoryName()
            => Table
                .Where(p => p.IsFeatured)
                .Include(p => p.Category)
                .OrderBy(x => x.ModelName)
                .Select(item => GetRecord(item, item.Category))
                .ToList();

        public ProductAndCategoryBase GetOneWithCategoryName(int id)
            => Table
                .Where(p => p.Id == id)
                .Include(p => p.Category)
                .Select(item => GetRecord(item, item.Category))
                .FirstOrDefault();

    }
}