using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoLot.Dal.Tests.Base;
using AutoLot.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AutoLot.Dal.Tests.IntegrationTests
{
    [Collection("Integration Tests")]
    public class CustomerTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTestFixture>
    {
        [Fact]
        public void ShouldGetAllOfTheCustomers()
        {
            var qs = Context.Customers.ToQueryString();
            var customers = Context.Customers.ToList();
            Assert.Equal(5, customers.Count);
        }

        [Fact]
        public void ShouldGetCustomersWithLastNameW()
        {
            IQueryable<Customer> query = Context.Customers
                .Where(x => x.PersonalInformation.LastName.StartsWith("W"));
            var qs = query.ToQueryString();
            List<Customer> customers = query.ToList();
            Assert.Equal(2, customers.Count);
        }

        [Fact]
        public void ShouldGetCustomersWithLastNameWAndFirstNameMChained()
        {
            IQueryable<Customer> query = Context.Customers
                .Where(x => x.PersonalInformation.LastName.StartsWith("W"))
                .Where(x => x.PersonalInformation.FirstName.StartsWith("M"));
            var qs = query.ToQueryString();
            List<Customer> customers = query.ToList();
            Assert.Single(customers);
        }

        [Fact]
        public void ShouldGetCustomersWithLastNameWAndFirstNameM()
        {
            IQueryable<Customer> query = Context.Customers
                .Where(x => x.PersonalInformation.LastName.StartsWith("W") &&
                            x.PersonalInformation.FirstName.StartsWith("M"));
            var qs = query.ToQueryString();
            List<Customer> customers = query.ToList();
            Assert.Single(customers);
        }

        [Fact]
        public void ShouldGetCustomersWithLastNameWOrH()
        {
            IQueryable<Customer> query = Context.Customers
                .Where(x => x.PersonalInformation.LastName.StartsWith("W") ||
                            x.PersonalInformation.LastName.StartsWith("H"));
            var qs = query.ToQueryString();
            List<Customer> customers = query.ToList();
            Assert.Equal(3, customers.Count);
        }

        [Fact]
        public void ShouldGetCustomersWithLastNameWOrHUsingLike()
        {
            IQueryable<Customer> query = Context.Customers
                .Where(x => EF.Functions.Like(x.PersonalInformation.LastName, "W%") ||
                            EF.Functions.Like(x.PersonalInformation.LastName, "H%"));
            var qs = query.ToQueryString();
            List<Customer> customers = query.ToList();
            Assert.Equal(3, customers.Count);
        }

        [Fact]
        public void ShouldSortByLastNameThenFirstName()
        {
            //Sort by Last name then first name
            var query = Context.Customers
                .OrderBy(x => x.PersonalInformation.LastName)
                .ThenBy(x => x.PersonalInformation.FirstName);
            var qs = query.ToQueryString();
            var customers = query.ToList();
            //if only one customer, nothing to test
            if (customers.Count <= 1)
            {
                return;
            }

            for (int x = 0; x < customers.Count - 1; x++)
            {
                var pi = customers[x].PersonalInformation;
                var pi2 = customers[x + 1].PersonalInformation;
                var compareLastName = string.Compare(pi.LastName,
                    pi2.LastName, StringComparison.CurrentCultureIgnoreCase);
                Assert.True(compareLastName <= 0);
                if (compareLastName != 0) continue;
                var compareFirstName = string.Compare(pi.FirstName,
                    pi2.FirstName, StringComparison.CurrentCultureIgnoreCase);
                Assert.True(compareFirstName <= 0);
            }
        }

        [Fact]
        public void ShouldSortByFirstNameThenLastNameUsingReverse()
        {
            //Sort by Last name then first name then reverse the sort
            var query = Context.Customers
                .OrderBy(x => x.PersonalInformation.LastName)
                .ThenBy(x => x.PersonalInformation.FirstName)
                .Reverse();
            var qs = query.ToQueryString();
            var customers = query.ToList();
            //if only one customer, nothing to test
            if (customers.Count <= 1)
            {
                return;
            }

            for (int x = 0; x < customers.Count - 1; x++)
            {
                var pi1 = customers[x].PersonalInformation;
                var pi2 = customers[x + 1].PersonalInformation;
                var compareLastName = string.Compare(pi1.LastName,
                    pi2.LastName, StringComparison.CurrentCultureIgnoreCase);
                Assert.True(compareLastName >= 0);
                if (compareLastName != 0) continue;
                var compareFirstName = string.Compare(pi1.FirstName,
                    pi2.FirstName, StringComparison.CurrentCultureIgnoreCase);
                Assert.True(compareFirstName >= 0);
            }
        }

        [Fact]
        public void GetFirstMatchingRecordDatabaseOrder()
        {
            //Gets the first record, database order
            var customer = Context.Customers.First();
            Assert.Equal(1, customer.Id);
        }

        [Fact]
        public void GetFirstMatchingRecordNameOrder()
        {
            //Gets the first record, lastname, first name order
            var customer = Context.Customers
                .OrderBy(x => x.PersonalInformation.LastName)
                .ThenBy(x => x.PersonalInformation.FirstName)
                .First();
            Assert.Equal(1, customer.Id);
        }

        [Fact]
        public void GetLastMatchingRecordNameOrder()
        {
            //Gets the last record, lastname desc, first name desc order
            var customer = Context.Customers
                .OrderBy(x => x.PersonalInformation.LastName)
                .ThenBy(x => x.PersonalInformation.FirstName)
                .LastOrDefault();
            Assert.Equal(4, customer.Id);
        }


        [Fact]
        public void FirstShouldThrowExceptionIfNoneMatch()
        {
            //Filters based on Id. Throws due to no match
            Assert.Throws<InvalidOperationException>(() => Context.Customers.First(x => x.Id == 10));
        }

        [Fact]
        public void FirstOrDefaultShouldReturnDefaultIfNoneMatch()
        {
            //Expression<Func<Customer>> is a lambda expression
            Expression<Func<Customer, bool>> expression = x => x.Id == 10;
            //Returns null when nothing is found
            var customer = Context.Customers.FirstOrDefault(expression);
            Assert.Null(customer);
        }

        [Fact]
        public void GetOneMatchingRecordWithSingle()
        {
            //Gets the first record, database order
            var customer = Context.Customers.Single(x => x.Id == 1);
            Assert.Equal(1, customer.Id);
        }

        [Fact]
        public void SingleShouldThrowExceptionIfNoneMatch()
        {
            //Filters based on Id. Throws due to no match
            Assert.Throws<InvalidOperationException>(() => Context.Customers.Single(x => x.Id == 10));
        }

        [Fact]
        public void SingleShouldThrowExceptionIfMoreThenOneMatch()
        {
            //Throws due to more than one match
            Assert.Throws<InvalidOperationException>(() => Context.Customers.Single());
        }

        [Fact]
        public void SingleOrDefaultShouldThrowExceptionIfMoreThenOneMatch()
        {
            //Throws due to more than one match
            Assert.Throws<InvalidOperationException>(() => Context.Customers.SingleOrDefault());
        }

        [Fact]
        public void SingleOrDefaultShouldReturnDefaultIfNoneMatch()
        {
            //Expression<Func<Customer>> is a lambda expression
            Expression<Func<Customer, bool>> expression = x => x.Id == 10;
            //Returns null when nothing is found
            var customer = Context.Customers.SingleOrDefault(expression);
            Assert.Null(customer);
        }
    }
}