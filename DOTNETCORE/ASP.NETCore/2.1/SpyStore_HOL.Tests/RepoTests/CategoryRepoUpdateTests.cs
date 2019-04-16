using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SpyStore_HOL.DAL.Repos;
using SpyStore_HOL.Models.Entities;
using Xunit;

namespace SpyStore_HOL.Tests.RepoTests
{
    [Collection("SpyStore.DAL")]
    public class CategoryRepoUpdateTests : IDisposable
    {
        private readonly CategoryRepo _repo;

        public CategoryRepoUpdateTests()
        {
            _repo = new CategoryRepo();
            CleanDatabase();
        }
        public void Dispose()
        {
            CleanDatabase();
            _repo.Dispose();
        }

        private void CleanDatabase()
        {
            _repo.Context.Database.ExecuteSqlCommand("Delete from Store.Categories");
            _repo.Context.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"Store.Categories\", RESEED, -1);");
        }

        [Fact]
        public void ShouldUpdateACategoryEntity()
        {
            var category = new Category { CategoryName = "Foo" };
            _repo.AddRange(new List<Category>
            {
                category,
            });
            category.CategoryName = "Bar";
            _repo.Update(category, false);
            var count = _repo.SaveChanges();
            Assert.Equal(1, count);
            var repo = new CategoryRepo();
            var cat = repo.Find(category.Id);
            Assert.Equal(cat.CategoryName, category.CategoryName);

        }
        [Fact]
        public void ShouldUpdateARangeOfCategoryEntities()
        {
            var categories = new List<Category>
            {
                new Category { CategoryName = "Foo" },
                new Category { CategoryName = "Bar" },
                new Category { CategoryName = "FooBar" }
            };
            _repo.AddRange(categories);
            categories[0].CategoryName = "Foo1";
            categories[1].CategoryName = "Foo2";
            categories[2].CategoryName = "Foo3";
            _repo.UpdateRange(categories, false);
            var count = _repo.SaveChanges();
            Assert.Equal(3, count);
            var repo = new CategoryRepo();
            var cat = repo.Find(categories[0].Id);
            Assert.Equal("Foo1", cat.CategoryName);

        }
    }

}
