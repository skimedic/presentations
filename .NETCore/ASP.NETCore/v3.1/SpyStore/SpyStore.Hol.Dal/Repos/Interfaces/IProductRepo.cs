using System;
using System.Collections.Generic;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Dal.Repos.Interfaces
{
    public interface IProductRepo : IRepo<Product>
    {
        IList<Product> Search(string searchString);
        IList<Product> GetProductsForCategory(int id);
        IList<Product> GetFeaturedWithCategoryName();
        Product GetOneWithCategoryName(int id);

    }
}