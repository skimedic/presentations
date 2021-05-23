#region Copyright
// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal.Tests - RepoTestsBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 03/04/2019
// See License.txt for more information
// ==================================
#endregion

using System;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Initialization;

namespace SpyStore.Hol.Dal.Tests.RepoTests.Base
{
    public class RepoTestsBase : IDisposable
    {
        protected readonly StoreContext Db;
        public RepoTestsBase()
        {
            Db = new StoreContextFactory().CreateDbContext(new string[0]);
            CleanDatabase();
        }

        public virtual void Dispose()
        {
            Db.Dispose();
        }
        protected void CleanDatabase()
        {
            SampleDataInitializer.ClearData(Db);
        }

        protected void LoadDatabase()
        {
            SampleDataInitializer.InitializeData(Db);
        }
        //protected IList<Product> CreateProducts()
        //{
        //    var prods = new List<Product>
        //    {
        //        new Product() {CurrentPrice = 12.99M, ModelName = "Product 1", ModelNumber = "P1"},
        //        new Product() {CurrentPrice = 9.99M, ModelName = "Product 2", ModelNumber = "P2"},
        //    };
        //    return prods;
        //}

    }
}