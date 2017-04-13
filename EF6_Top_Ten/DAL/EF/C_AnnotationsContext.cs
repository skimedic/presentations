#region copyright
// // Copyright Information
// // ==============================
// // DAL - C_AnnotationsContext.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL.EF
{
    public class AnnotationsContext : DbContext
    {
        public AnnotationsContext()
              : base("name=StoreContext")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        [ForeignKey("BookPoster")]
        public string ISBN { get; set; }

        [Index("Title", IsUnique = true),Column(TypeName="varchar")]
        public string Title { get; set; }

        public ICollection<Person> Authors { get; set; }
        public ICollection<Person> Reviewers { get; set; }
        public ICollection<Person> Readers { get; set; }
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

        public Address Address { get; set; }

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
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FirstKey { get; set; }
        [Key, Column(Order = 2), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SecondKey { get; set; }
        public string Description { get; set; }
        public Book MyBook { get; set; }
    }

    public class Poster : PubBase
    {
        [Key, ForeignKey("Book")]
        public string ISBN { get; set; }

        [Display(Name="Description")]
        public string PosterDescription { get; set; }

        [Required,InverseProperty("BookPoster")]
        public Book Book { get; set; }
    }

}