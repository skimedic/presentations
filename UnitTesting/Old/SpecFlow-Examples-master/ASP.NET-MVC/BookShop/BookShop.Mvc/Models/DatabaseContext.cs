using System.Data.Entity;

namespace BookShop.Mvc.Models
{
    public class DatabaseContext
        : DbContext
    {
        public DatabaseContext()
            : base(@"Data Source=(localdb)\v11.0;Initial Catalog=BookShop;Integrated Security=True;MultipleActiveResultSets=True")
        {
        }
        
        public DbSet<Order> Orders { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }
    }
}