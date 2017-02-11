#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - AnnotationsContextModelSnapshot.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCore_Top_Ten.EF;

namespace EFCore_Top_Ten.EF.Migrations.Annotations
{
    [DbContext(typeof(AnnotationsContext))]
    partial class AnnotationsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore_Top_Ten.EF.Book", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnName("ISBN_ID_NUMBER");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Title")
                        .HasColumnType("varchar(200)");

                    b.HasKey("ISBN");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("OurBooks","Data");
                });

            modelBuilder.Entity("EFCore_Top_Ten.EF.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .HasAnnotation("MaxLength", 25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("ReadISBN");

                    b.Property<string>("ReviewedISBN");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("WrittenISBN");

                    b.HasKey("Id");

                    b.HasIndex("ReadISBN");

                    b.HasIndex("ReviewedISBN");

                    b.HasIndex("WrittenISBN");

                    b.ToTable("People");
                });

            modelBuilder.Entity("EFCore_Top_Ten.EF.Poster", b =>
                {
                    b.Property<string>("ISBN");

                    b.Property<string>("PosterDescription");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("ISBN");

                    b.HasIndex("ISBN")
                        .IsUnique();

                    b.ToTable("Poster");
                });

            modelBuilder.Entity("EFCore_Top_Ten.EF.Thingie", b =>
                {
                    b.Property<string>("FirstKey");

                    b.Property<string>("SecondKey");

                    b.Property<string>("Description");

                    b.Property<string>("MyBookISBN");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("FirstKey", "SecondKey");

                    b.HasIndex("MyBookISBN");

                    b.ToTable("Thingies");
                });

            modelBuilder.Entity("EFCore_Top_Ten.EF.Person", b =>
                {
                    b.HasOne("EFCore_Top_Ten.EF.Book", "BookRead")
                        .WithMany("Readers")
                        .HasForeignKey("ReadISBN");

                    b.HasOne("EFCore_Top_Ten.EF.Book", "BookReviewed")
                        .WithMany("Reviewers")
                        .HasForeignKey("ReviewedISBN");

                    b.HasOne("EFCore_Top_Ten.EF.Book", "BookWritten")
                        .WithMany("Authors")
                        .HasForeignKey("WrittenISBN");
                });

            modelBuilder.Entity("EFCore_Top_Ten.EF.Poster", b =>
                {
                    b.HasOne("EFCore_Top_Ten.EF.Book", "Book")
                        .WithOne("BookPoster")
                        .HasForeignKey("EFCore_Top_Ten.EF.Poster", "ISBN")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCore_Top_Ten.EF.Thingie", b =>
                {
                    b.HasOne("EFCore_Top_Ten.EF.Book", "MyBook")
                        .WithMany()
                        .HasForeignKey("MyBookISBN");
                });
        }
    }
}
