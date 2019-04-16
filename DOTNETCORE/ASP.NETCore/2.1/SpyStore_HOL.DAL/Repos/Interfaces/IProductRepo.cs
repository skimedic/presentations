using System.Collections.Generic;
using SpyStore_HOL.DAL.Repos.Base;
using SpyStore_HOL.Models.Entities;
using SpyStore_HOL.Models.ViewModels.Base;

namespace SpyStore_HOL.DAL.Repos.Interfaces
{
    public interface IProductRepo : IRepo<Product>
    {
        IList<ProductAndCategoryBase> Search(string searchString);
        IList<ProductAndCategoryBase> GetProductsForCategory(int id);
        IList<ProductAndCategoryBase> GetFeaturedWithCategoryName();
        ProductAndCategoryBase GetOneWithCategoryName(int id);

    }
}