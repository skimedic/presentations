#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - A_FirstContext.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore_Top_Ten.EF
{
    public class FirstContext : DbContext
    {
        public FirstContext()
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }
        public FirstContext(DbContextOptions<FirstContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();
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

        public virtual DbSet<FirstExample> Tables { get; set; }
        //public virtual DbSet<Foo> Foos { get; set; }

    }

    public class Foo
    {
        public int Id { get; set; }
    }

    public class FirstExample
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

}