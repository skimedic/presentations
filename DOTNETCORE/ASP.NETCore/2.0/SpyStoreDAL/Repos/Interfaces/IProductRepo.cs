using System.Collections.Generic;
using SpyStoreDAL.Repos.RepoBase;
using SpyStoreModels.Models;
using SpyStoreModels.ViewModels.Base;

namespace SpyStoreDAL.Repos.Interfaces
{
    public interface IProductRepo : IRepo<Product>
    {
        IEnumerable<Product> GetAll();
        IList<ProductAndCategoryBase> GetProductsForCategory(int id);
        IList<ProductAndCategoryBase> GetFeaturedWithCategoryName();
        ProductAndCategoryBase GetOneWithCategoryName(int id);
    }
}