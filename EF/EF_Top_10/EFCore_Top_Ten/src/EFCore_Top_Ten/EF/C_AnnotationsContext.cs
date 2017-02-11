#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - C_AnnotationsContext.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore_Top_Ten.EF
{
    public class AnnotationsContext : DbContext
    {
        public AnnotationsContext()
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }
        public AnnotationsContext(DbContextOptions<AnnotationsContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasIndex(b => b.Title).IsUnique();
            modelBuilder.Entity<Thingie>()
                .HasKey(c => new { c.FirstKey, c.SecondKey});
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
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Thingie> Thingies { get; set; }


    }

    public class PubBase
    {
        [Timestamp]
        public byte[] Timestamp { get; set; }

        //Note: Can use ConcurrencyCheck to specify another field for this

    }
    [Table("OurBooks", Schema = "Data")]
    public class Book : PubBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ISBN_ID_NUMBER")]
        public string ISBN { get; set; }

        //must specift the length
        [Column(TypeName="varchar(200)")]
        public string Title { get; set; }

        public ICollection<Person> Authors { get; set; }
        public ICollection<Person> Reviewers { get; set; }
        public ICollection<Person> Readers { get; set; }

        [ForeignKey("ISBN")]
        public Poster BookPoster { get; set; }
    }

    public class Person : PubBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(25)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        //This isn't supported yet
        //public Address Address { get; set; }

        [ForeignKey("BookWritten")]
        public string WrittenISBN { get; set; }
        [InverseProperty("Authors")]
        public Book BookWritten { get; set; }

        [ForeignKey("BookReviewed")]
        public string ReviewedISBN { get; set; }
        [InverseProperty("Reviewers")]
        public Book BookReviewed { get; set; }

        [ForeignKey("BookRead")]
        public string ReadISBN { get; set; }
        [InverseProperty("readers")]
        public Book BookRead { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }

    [ComplexType]
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    public class Thingie : PubBase
    {
//        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FirstKey { get; set; }
        //[Key, Column(Order = 2), DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SecondKey { get; set; }
        public string Description { get; set; }
        public Book MyBook { get; set; }
    }

    public class Poster : PubBase
    {
        [Key, ForeignKey("Book")]
        public string ISBN { get; set; }

        [Display(Name = "Description")]
        public string PosterDescription { get; set; }

        [Required,InverseProperty("BookPoster")]
        public Book Book { get; set; }
    }
}