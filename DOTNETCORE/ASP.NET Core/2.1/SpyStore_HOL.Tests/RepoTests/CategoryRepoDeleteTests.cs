using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore_HOL.DAL.Repos;
using SpyStore_HOL.Models.Entities;
using Xunit;

namespace SpyStore_HOL.Tests.RepoTests
{
    [Collection("SpyStore.DAL")]
    public class CategoryRepoDeleteTests : IDisposable
    {
        private readonly CategoryRepo _repo;

        public CategoryRepoDeleteTests()
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

        //private IList<Product> CreateProducts()
        //{
        //    var prods = new List<Product>
        //    {
        //        new Product() {CurrentPrice = 12.99M, ModelName = "Product 1", ModelNumber = "P1"},
        //        new Product() {CurrentPrice = 9.99M, ModelName = "Product 2", ModelNumber = "P2"},
        //    };
        //    return prods;
        //}

        [Fact]
        public void ShouldDeleteACategoryEntityFromDbSet()
        {
            _repo.AddRange(new List<Category>
            {
                new Category { CategoryName = "Foo" },
            });
            Assert.Equal(1, _repo.Count);
            var category = _repo.GetAll().First();
            var count = _repo.Delete(category);
            Assert.Equal(1, count);
            Assert.Equal(0, _repo.Count);
        }

        [Fact]
        public void ShouldDeleteACategoryRangeFromDbSet()
        {
            var categories = new List<Category>
            {
                new Category { CategoryName = "Foo" },
                new Category { CategoryName = "Bar" },
                new Category { CategoryName = "FooBar" }
            };
            _repo.AddRange(categories);
            Assert.Equal(3, _repo.Count);
            var count = _repo.DeleteRange(categories);
            Assert.Equal(3, count);
            Assert.Equal(0, _repo.Count);
        }

        [Fact]
        public void ShouldDeleteACategoryRangeAndPersistManuallyFromDbSet()
        {
            var categories = new List<Category>
            {
                new Category { CategoryName = "Foo" },
                new Category { CategoryName = "Bar" },
                new Category { CategoryName = "FooBar" }
            };
            _repo.AddRange(categories);
            Assert.Equal(3, _repo.Count);
            var count = _repo.DeleteRange(categories, false);
            Assert.Equal(0, count);
            count = _repo.SaveChanges();
            Assert.Equal(3, count);
            Assert.Equal(0, _repo.Count);
        }

        [Fact]
        public void ShouldDeleteACategoryEntityFromContext()
        {
            _repo.AddRange(new List<Category>
            {
                new Category { CategoryName = "Foo" },
            });
            Assert.Equal(1, _repo.Count);
            var category = _repo.GetAll().First();
            _repo.Context.Remove(category);
            var count = _repo.SaveChanges();
            Assert.Equal(1, count);
            Assert.Equal(0, _repo.Count);
        }

        [Fact]
        public void ShouldDeleteACategoryEntityAndNotPersist()
        {
            _repo.AddRange(new List<Category>
            {
                new Category { CategoryName = "Foo" },
            });
            Assert.Equal(1, _repo.Count);
            var category = _repo.GetAll().First();
            var count = _repo.Delete(category, false);
            Assert.Equal(0, count);
            Assert.Equal(1, _repo.Count);
        }

        [Fact]
        public void ShouldDeleteACategoryFromDifferentContext()
        {
            _repo.AddRange(new List<Category>
            {
                new Category { CategoryName = "Foo" },
            });
            Assert.Equal(1, _repo.Count);
            var category = _repo.GetAll().First();
            CategoryRepo repo = new CategoryRepo();
            var count = repo.Delete(category.Id, category.TimeStamp, false);
            Assert.Equal(0, count);
            count = repo.Context.SaveChanges();
            Assert.Equal(1, count);
            Assert.Equal(0, repo.Count);
        }

        [Fact]
        public void ShouldDeleteACategoryFromSameContext()
        {
            var category = new Category { CategoryName = "Foo" };
            _repo.Add(category);
            Assert.Equal(1, _repo.Count);
            var count = _repo.Delete(category.Id, category.TimeStamp, false);
            Assert.Equal(0, count);
            count = _repo.SaveChanges();
            Assert.Equal(1, count);
            Assert.Equal(0, _repo.Count);
        }
    }

}
