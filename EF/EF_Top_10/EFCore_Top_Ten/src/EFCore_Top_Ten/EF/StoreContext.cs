#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - StoreContext.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using EFCore_Top_Ten.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore_Top_Ten.EF
{
    public class StoreContext : DbContext
    {

        public StoreContext()
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Store");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //https://docs.efproject.net/en/latest/querying/client-eval.html#disabling-client-evaluation
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore_Top_Ten;Trusted_Connection=True;MultipleActiveResultSets=true;")
                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            }
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhotos { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountTransaction> AccountTransactions { get; set; }

        public virtual DbSet<Widget> Widgets { get; set; }
    }


}