namespace AutoLot.Dal.Tests.IntegrationTests;

[Collection("Integration Tests")]
public class CustomerTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTestFixture>
{
    public CustomerTests(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    [Fact]
    public void ShouldGetAllOfTheCustomers()
    {
        var qs = Context.Customers.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        var customers = Context.Customers.ToList();
        Assert.Equal(5, customers.Count);
    }

    [Fact]
    public void ShouldGetCustomersWithLastNameW()
    {
        IQueryable<Customer> query = Context.Customers
            .Where(x => x.PersonInformation.LastName.StartsWith("W"));
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        List<Customer> customers = query.ToList();
        Assert.Equal(2, customers.Count);
        foreach (var customer in customers)
        {
            var pi = customer.PersonInformation;
            Assert.StartsWith("W", pi.LastName, StringComparison.OrdinalIgnoreCase);
        }
    }

    [Fact]
    public void ShouldGetCustomersWithLastNameWAndFirstNameMChained()
    {
        IQueryable<Customer> query = Context.Customers
            .Where(x => x.PersonInformation.LastName.StartsWith("W"))
            .Where(x => x.PersonInformation.FirstName.StartsWith("M"));
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        List<Customer> customers = query.ToList();
        Assert.Single(customers);
        foreach (var customer in customers)
        {
            var pi = customer.PersonInformation;
            Assert.StartsWith("W", pi.LastName, StringComparison.OrdinalIgnoreCase);
            Assert.StartsWith("M", pi.FirstName, StringComparison.OrdinalIgnoreCase);
        }
    }

    [Fact]
    public void ShouldGetCustomersWithLastNameWAndFirstNameM()
    {
        IQueryable<Customer> query = Context.Customers
            .Where(x => x.PersonInformation.LastName.StartsWith("W") &&
                        x.PersonInformation.FirstName.StartsWith("M"));
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        List<Customer> customers = query.ToList();
        Assert.Single(customers);
        foreach (var customer in customers)
        {
            var pi = customer.PersonInformation;
            Assert.StartsWith("W", pi.LastName, StringComparison.OrdinalIgnoreCase);
            Assert.StartsWith("M", pi.FirstName, StringComparison.OrdinalIgnoreCase);
        }
    }

    [Fact]
    public void ShouldGetCustomersWithLastNameWOrH()
    {
        IQueryable<Customer> query = Context.Customers
            .Where(x => x.PersonInformation.LastName.StartsWith("W") ||
                        x.PersonInformation.LastName.StartsWith("H"));
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        List<Customer> customers = query.ToList();
        Assert.Equal(3, customers.Count);
        foreach (var customer in customers)
        {
            var pi = customer.PersonInformation;
            Assert.True(pi.LastName.StartsWith("W", StringComparison.OrdinalIgnoreCase) ||
                pi.LastName.StartsWith("H", StringComparison.OrdinalIgnoreCase));
        }
    }

    [Fact]
    public void ShouldGetCustomersWithLastNameWOrHUsingLike()
    {
        IQueryable<Customer> query = Context.Customers
            .Where(x => EF.Functions.Like(x.PersonInformation.LastName, "W%") ||
                        EF.Functions.Like(x.PersonInformation.LastName, "H%"));
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        List<Customer> customers = query.ToList();
        Assert.Equal(3, customers.Count);
        foreach (var customer in customers)
        {
            var pi = customer.PersonInformation;
            Assert.True(pi.LastName.StartsWith("W", StringComparison.OrdinalIgnoreCase) ||
                pi.LastName.StartsWith("H", StringComparison.OrdinalIgnoreCase));
        }
    }

    [Fact]
    public void ShouldSortByLastNameThenFirstName()
    {
        //Sort by Last name then first name descending
        var query = Context.Customers
            .OrderBy(x => x.PersonInformation.LastName)
            .ThenByDescending(x => x.PersonInformation.FirstName);
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        var customers = query.ToList();
        for (int x = 0; x < customers.Count - 1; x++)
        {
            Compare(customers[x].PersonInformation, customers[x + 1].PersonInformation);
        }
        static void Compare(Person p1, Person p2)
        {
            var compareValue = string.Compare(p1.LastName, p2.LastName, StringComparison.CurrentCultureIgnoreCase);
            Assert.True(compareValue <= 0);
            if (compareValue == 0)
            {
                //Descending first name sort
                Assert.True(string.Compare(p1.FirstName, p2.FirstName, StringComparison.CurrentCultureIgnoreCase) >= 0);
            }
        }
    }

    [Fact]
    public void ShouldSortByFirstNameThenLastNameUsingReverse()
    {
        //Sort by Last name then first name then reverse the sort
        var query = Context.Customers
            .OrderBy(x => x.PersonInformation.LastName)
            .ThenByDescending(x => x.PersonInformation.FirstName)
            .Reverse();
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        var customers = query.ToList();
        for (int x = 0; x < customers.Count - 1; x++)
        {
            Compare(customers[x].PersonInformation, customers[x + 1].PersonInformation);
        }
        static void Compare(Person p1, Person p2)
        {
            var compareValue = string.Compare(p1.LastName, p2.LastName, StringComparison.CurrentCultureIgnoreCase);
            Assert.True(compareValue >= 0);
            if (compareValue == 0)
            {
                //Descending first name sort
                Assert.True(string.Compare(p1.FirstName, p2.FirstName, StringComparison.CurrentCultureIgnoreCase) <= 0);
            }
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
            .OrderBy(x => x.PersonInformation.LastName)
            .ThenBy(x => x.PersonInformation.FirstName)
            .First();
        Assert.Equal(1, customer.Id);
    }

    [Fact]
    public void GetLastMatchingRecordNameOrder()
    {
        //Gets the last record, lastname desc, first name desc order
        var customer = Context.Customers
            .OrderBy(x => x.PersonInformation.LastName)
            .ThenBy(x => x.PersonInformation.FirstName)
            .LastOrDefault();
        Assert.Equal(4, customer.Id);
    }

    [Fact]
    public void LastShouldThrowIfNoSortSpecified()
    {
        Assert.Throws<InvalidOperationException>(() => Context.Customers.Last());
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
