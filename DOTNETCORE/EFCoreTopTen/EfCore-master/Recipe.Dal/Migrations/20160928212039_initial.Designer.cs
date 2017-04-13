using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Recipe.Dal.Models;

namespace Recipe.Dal.Migrations
{
    [DbContext(typeof(RecipeContext))]
    [Migration("20160928212039_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Recipe.Dal.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Recipe.Dal.Models.Direction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<long>("LineNumber");

                    b.Property<long?>("RecipeId");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId")
                        .HasName("IX_Recipe_RecipeId");

                    b.HasIndex("RecipeId", "LineNumber")
                        .HasName("IX_Directions_RecipeLineNumber");

                    b.HasIndex("LineNumber", "Description", "RecipeId", "Id")
                        .HasName("_dta_index_Directions_5_709577566__K4_K1_2_3");

                    b.ToTable("Direction");
                });

            modelBuilder.Entity("Recipe.Dal.Models.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<long?>("RecipeId");

                    b.Property<int?>("SortOrder");

                    b.Property<string>("UnitType")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Units")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasIndex("RecipeId")
                        .HasName("IX_Recipe_RecipeId");

                    b.HasIndex("SortOrder", "Units", "UnitType", "Description", "RecipeId", "Id")
                        .HasName("_dta_index_Ingredients_5_661577395__K6_K1_2_3_4_5");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("Recipe.Dal.Models.Recipe", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("ServingMeasure")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<decimal?>("ServingQuantity")
                        .HasColumnType("decimal");

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 1024);

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .HasName("IX_Recipes_Title");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("Recipe.Dal.Models.RecipeCategory", b =>
                {
                    b.Property<long>("RecipeId");

                    b.Property<long>("CategoryId");

                    b.HasKey("RecipeId", "CategoryId")
                        .HasName("PK_dbo.RecipeCategories");

                    b.HasIndex("CategoryId")
                        .HasName("IX_Category_CategoryId");

                    b.HasIndex("RecipeId")
                        .HasName("IX_Recipe_RecipeId");

                    b.ToTable("RecipeCategory");
                });

            modelBuilder.Entity("Recipe.Dal.Models.Direction", b =>
                {
                    b.HasOne("Recipe.Dal.Models.Recipe", "Recipe")
                        .WithMany("Direction")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("Recipe.Dal.Models.Ingredient", b =>
                {
                    b.HasOne("Recipe.Dal.Models.Recipe", "Recipe")
                        .WithMany("Ingredient")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("Recipe.Dal.Models.RecipeCategory", b =>
                {
                    b.HasOne("Recipe.Dal.Models.Category", "Category")
                        .WithMany("RecipeCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Recipe.Dal.Models.Recipe", "Recipe")
                        .WithMany("RecipeCategory")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
