#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - B_ConventionsContext.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore_Top_Ten.EF
{
    public class ConventionsContext : DbContext
    {
        public ConventionsContext()
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }
        public ConventionsContext(DbContextOptions<ConventionsContext> options)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public virtual DbSet<FirstExample> Tables { get; set; }
        public virtual DbSet<SampleEntity> Samples { get; set; }
    }
    public class SampleEntity
    {
        //Primary Key && Identity
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<RelatedClass> RelatedClasses { get; set; }
        public virtual RelatedClass RelatedClass { get; set; }
        //Will get added automatically if excluded 
        //Cascade Delete
        public int RelatedClassId { get; set; }
        //Not Cascade Delete 
        //public int? RelatedClassId { get; set; }
    }

    //Brought in through type discovery
    //[NotMapped]
    public class RelatedClass
    {
        public int RelatedClassId { get; set; }
        public string Foo { get; set; }

        [NotMapped]
        public string LongName => $"{Foo} some text";
        public int SampleEntityId { get; set; }
        //public int? SampleEntityId { get; set; }
        //public SampleEntity ParentEntity { get; set; }
    }

    //Complex Types
    public class DerivedSample :SampleEntity
    {
        public DerivedSample()
        {
            Details = new Details();
        }
        public Details Details { get; set; }
    }

    public class Details
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
    }
}