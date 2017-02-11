using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCore_Top_Ten.EF;

namespace EFCore_Top_Ten.EF.Migrations.Store
{
    [DbContext(typeof(StoreContext))]
    [Migration("20160810011200_StoreContext_Initial")]
    partial class StoreContext_Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore_Top_Ten.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountNumber");

                    b.Property<double>("Balance");

                    b.Property<bool?>("IsChanged");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("EFCore_Top_Ten.Models.AccountTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountID");

                    b.Property<double>("Amount");

                    b.Property<bool?>("IsChanged");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("TransactionDate");

                    b.HasKey("Id");

                    b.HasIndex("AccountID");

                    b.ToTable("AccountTransactions");
                });

            modelBuilder.Entity("EFCore_Top_Ten.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("CategoryName")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<bool?>("IsChanged");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("EFCore_Top_Ten.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<decimal>("CurrentPrice");

                    b.Property<string>("Description");

                    b.Property<bool?>("IsChanged");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 150);

                    b.Property<string>("ModelNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int?>("ProductPhotoId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<decimal>("UnitCost");

                    b.Property<int>("UnitsInStock");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EFCore_Top_Ten.Models.ProductPhoto", b =>
                {
                    b.Property<int>("Id");

                    b.Property<byte[]>("Image");

                    b.Property<bool?>("IsChanged");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("ProductPhotos");
                });

            modelBuilder.Entity("EFCore_Top_Ten.Models.Widget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool?>("IsChanged");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Widgets");
                });

            modelBuilder.Entity("EFCore_Top_Ten.Models.AccountTransaction", b =>
                {
                    b.HasOne("EFCore_Top_Ten.Models.Account", "Account")
                        .WithMany("XFers")
                        .HasForeignKey("AccountID");
                });

            modelBuilder.Entity("EFCore_Top_Ten.Models.Category", b =>
                {
                    b.HasOne("EFCore_Top_Ten.Models.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("EFCore_Top_Ten.Models.Product", b =>
                {
                    b.HasOne("EFCore_Top_Ten.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCore_Top_Ten.Models.ProductPhoto", b =>
                {
                    b.HasOne("EFCore_Top_Ten.Models.Product", "ProductParent")
                        .WithOne("Image")
                        .HasForeignKey("EFCore_Top_Ten.Models.ProductPhoto", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
