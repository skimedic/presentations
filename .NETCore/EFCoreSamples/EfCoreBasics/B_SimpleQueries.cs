// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - SimpleQueries.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using EfCoreBasics.EfStructures;
using EfCoreBasics.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreBasics
{
    public class SimpleQueries
    {
        private AwDbContext _context = null;

        public SimpleQueries()
        {
            ResetContext();
        }

        public void RunSamples()
        {
            LinqExecutionTiming();
            GetByPrimaryKey();
            GetSingleRecord();
            ProblemQueries();
            SelectWithMultipleClauses();
            UsingCSharpLikeFunction();
            SortDataServerSide();
            PageRecords();
        }
        private void ResetContext()
        {
            _context = new AwDbContextFactory().CreateDbContext(null);
        }

        internal void LinqExecutionTiming()
        {
            //Nothing Happens
            IQueryable<Person> query = _context.Person.AsQueryable();
            //Now query executes
            List<Person> list = query.ToList();
            //Also here:
            foreach (var p in query) { }
            //And here:
            _ = query.FirstOrDefault();
            //And here:
            _ = query.SingleOrDefault(x => x.BusinessEntityId == 1);
            //And here
            _ = _context.Person.Find(1);
        }
        internal void GetByPrimaryKey()
        {
            //Get by primary key with immediate execution
            _ = _context.Person.Find(1);
            //Complex PK with immediate execution
            _ = _context.ProductVendor.Find(2, 1688);
        }
        internal void GetSingleRecord()
        {
            //All immediate execution
            //NOTE: should use an order by with these
            _ = _context.Person.Where(x => x.BusinessEntityId == 1).FirstOrDefault();
            _ = _context.Person.FirstOrDefault(x => x.BusinessEntityId == 1);
            //Using Single - Exception if more than one is found
            _ = _context.Person.SingleOrDefault(x => x.BusinessEntityId == 1);
        }
        public void ProblemQueries()
        {
            try
            {
                //This can't be translated into SQL by the SQL Server tranlsation engine
                _ = _context.Person.LastOrDefault(x => x.PersonType == "em");
            }
            catch (InvalidOperationException ex)
            {
                //Console.WriteLine(ex);
            }
            try
            {
                //This will throw an error
                _ = _context.Person.SingleOrDefault(x => x.BusinessEntityId <= 2);
                /*
                Executed Query: 
                SELECT TOP(2) * -- actual fields listed in real query
                FROM [Person].[Person] AS [p]
                WHERE [p].[BusinessEntityID] <= 2
                 */
            }
            catch (InvalidOperationException ex)
            {
                //Two records were returned - this happens client-side
                //Console.WriteLine(ex);
            }

        }
        public void SelectWithMultipleClauses()
        {
            //All in one statement
            var query1 = _context.Person
                .Where(x => x.PersonType == "em" && x.EmailPromotion == 1);
            //Chained statements
            var query2 = _context.Person
                .Where(x => x.PersonType == "em").Where(x => x.EmailPromotion == 1);
            //Built up over disparate calls
            var query3 = _context.Person.Where(x => x.PersonType == "em");
            query3 = query3.Where(x => x.EmailPromotion == 1);

            //Or's can't be chained
            var query4 = _context.Person
                .Where(x => x.PersonType == "em" || x.EmailPromotion == 1);
        }
        public void UsingCSharpLikeFunction()
        {
            List<int> list = new List<int> { 1, 3, 5 };
            var query = _context.Person.Where(x => list.Contains(x.BusinessEntityId));
            _ = _context.Person.Where(x => x.LastName.Contains("UF"));
            _ = _context.Person.Where(x => EF.Functions.Like(x.LastName,"%UF%"));
            //IsDate translates to the TSQL IsDate function 
            _ = _context.Person.Where(x => EF.Functions.IsDate(x.ModifiedDate.ToString()));
            decimal sum = _context.Product.Sum(x => x.ListPrice);
            int count = _context.Product.Count(x => x.ListPrice != 0);
            decimal avg = _context.Product.Average(x=>(decimal?)x.ListPrice)??0;
            decimal max = _context.Product.Max(x => (decimal?)x.ListPrice) ?? 0;
            decimal min = _context.Product.Min(x => (decimal?)x.ListPrice) ?? 0;
            bool any = _context.Product.Any(x => x.ListPrice != 0);
            bool all = _context.Product.All(x => x.ListPrice != 0);
        }
        public void SortDataServerSide()
        {
            IOrderedQueryable<Person> query1 =
                _context.Person.OrderBy(x => x.PersonType).ThenBy(x => x.EmailPromotion);
            IOrderedQueryable<Person> query2 =
                _context.Person.OrderByDescending(x => x.PersonType).ThenBy(x => x.EmailPromotion);
        }
        public void PageRecords()
        {
            var prodList = _context.Person
                .Where(x => x.PersonType == "em")
                .OrderBy(x=>x.EmailPromotion)
                .Skip(25).Take(50);
        }
    }
}