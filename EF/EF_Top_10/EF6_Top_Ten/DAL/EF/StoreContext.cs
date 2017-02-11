#region copyright
// // Copyright Information
// // ==============================
// // DAL - StoreContext.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.Data.Entity;
using DAL.Models;

namespace DAL.EF
{
    public partial class StoreContext : DbContext
    {

        public StoreContext()
            : base("name=StoreContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Widget>().MapToStoredProcedures();
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhotos { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountTransaction> AccountTransactions { get; set; }

        public virtual DbSet<Widget> Widgets { get; set; }
    }


}