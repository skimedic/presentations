using System.Collections.Generic;
using SpyStoreDAL.Repos.RepoBase;
using SpyStoreModels.Models;

namespace SpyStoreDAL.Repos.Interfaces
{
    public interface ICategoryRepo : IRepo<Category>
    {
        IEnumerable<Category> GetAll();

        Category GetOneWithProducts(int? id);

        IEnumerable<Category> GetAllWithProducts();
        Category Find(int id);
    }
}