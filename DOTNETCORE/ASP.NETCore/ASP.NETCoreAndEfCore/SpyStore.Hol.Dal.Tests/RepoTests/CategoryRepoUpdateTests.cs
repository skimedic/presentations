using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Repos;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Dal.Tests.RepoTests.Base;
using SpyStore.Hol.Models.Entities;
using Xunit;

namespace SpyStore.Hol.Dal.Tests.RepoTests
{
    [Collection("SpyStore.DAL")]
    public class CategoryRepoUpdateTests : RepoTestsBase
    {
        private readonly ICategoryRepo _repo;

        public CategoryRepoUpdateTests()
        {
            _repo = new CategoryRepo(Db);
        }
        public override void Dispose()
        {
            _repo.Dispose();
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
            using (var context = new StoreContextFactory().CreateDbContext(null))
            {
                using (var repo = new CategoryRepo(context))
                {
                    var cat = repo.Find(category.Id);
                    Assert.Equal(cat.CategoryName, category.CategoryName);
                }
            }
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
            using (var context = new StoreContextFactory().CreateDbContext(null))
            {
                using (var repo = new CategoryRepo(context))
                {
            var cat = repo.Find(categories[0].Id);
            Assert.Equal("Foo1", cat.CategoryName);
                }
            }

        }
    }

}
