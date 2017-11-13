using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStoreDAL.EfContext;
using SpyStoreDAL.Repos.Interfaces;
using SpyStoreDAL.Repos.RepoBase;
using SpyStoreModels.Models;

namespace SpyStoreDAL.Repos
{
    public class CategoryRepo : RepoBase<Category>, ICategoryRepo
    {
        public CategoryRepo(ApplicationDbContext context) : base(context)
        { }

        public Category Find(int id) => Table.FirstOrDefault(x => x.Id==id);
        public IEnumerable<Category> GetAll()
            => Table.OrderBy(x => x.CategoryName);

        public Category GetOneWithProducts(int? id)
            => Table.Include(x => x.Products).FirstOrDefault(x => x.Id == id);

        public IEnumerable<Category> GetAllWithProducts()
            => Table.Include(x => x.Products);
    }
}
