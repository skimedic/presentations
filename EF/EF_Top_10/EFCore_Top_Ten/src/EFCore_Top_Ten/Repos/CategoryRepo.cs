#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - CategoryRepo.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore_Top_Ten.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Top_Ten.Repos
{
    public class CategoryRepo:RepoBase<Category>,IRepo<Category>
    {
        public CategoryRepo()
        {
            Table = Context.Categories;
        }

        public Category GetFirst() => Table.FirstOrDefault();

        public List<Category> GetAllWithProducts() => 
            Table.Include(x => x.Products).ToList();

        public async Task<List<Category>> GetAllWithProductsAync() => 
            await Table.Include(x => x.Products).ToListAsync();

        public List<Category> GetAll() =>
            Table.OrderBy(x => x.CategoryName).ToList();

        public async Task<List<Category>> GetAllAsync() => 
            await Table.OrderBy(x => x.CategoryName).ToListAsync();

    }
}
