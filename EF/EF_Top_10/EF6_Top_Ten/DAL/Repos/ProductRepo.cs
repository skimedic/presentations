#region copyright
// // Copyright Information
// // ==============================
// // DAL - ProductRepo.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repos
{
    public class ProductRepo:RepoBase<Product>,IRepo<Product>
    {
        public ProductRepo():this(true)
        {
        }

        public ProductRepo(bool useLazyLoading) : base(useLazyLoading)
        {
            Table = Context.Products;
        }
        public List<Product> GetAll() => 
            Table.OrderBy(x=>x.ModelName).ToList();

        public async Task<List<Product>> GetAllAsync() => 
            await Table.OrderBy(x => x.ModelName).ToListAsync();
        public List<Product> GetAllWithImage() => 
            Table.Include(x=>x.Image).OrderBy(x=>x.ModelName).ToList();

        public async Task<List<Product>> GetAllWithImageAsync() => 
            await Table.Include(x => x.Image).OrderBy(x => x.ModelName).ToListAsync();


    }
}
