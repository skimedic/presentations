// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal.Tests - CarTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/05/27
// ==================================

namespace AutoLot.Dal.Tests.IntegrationTests;

[Collection("Integration Tests")]
public class CarTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTestFixture>
{
    private readonly ICarRepo _carRepo;

    public CarTests(ITestOutputHelper outputHelper) : base(outputHelper)
    {
        _carRepo = new CarRepo(Context);
    }

    public override void Dispose()
    {
        _carRepo.Dispose();
        base.Dispose();
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    [InlineData(5, 3)]
    [InlineData(6, 1)]
    public void ShouldGetTheCarsByMake(int makeId, int expectedCount)
    {
        IQueryable<Car> query = Context.Cars.IgnoreQueryFilters().Where(x => x.MakeId == makeId);
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        var cars = query.ToList();
        Assert.Equal(expectedCount, cars.Count);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    [InlineData(5, 3)]
    [InlineData(6, 1)]
    public void ShouldGetTheCarsByMakeUsingTheRepo(int makeId, int expectedCount)
    {
        var qs = _carRepo.GetAllBy(makeId).AsQueryable().ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        var cars = _carRepo.GetAllBy(makeId).ToList();
        Assert.Equal(expectedCount, cars.Count);
    }

    [Fact]
    public void ShouldReturnDrivableCarsWithQueryFilterSet()
    {
        IQueryable<Car> query = Context.Cars;
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        var cars = query.ToList();
        Assert.NotEmpty(cars);
        Assert.Equal(9, cars.Count);
    }

    [Fact]
    public void ShouldGetAllOfTheCars()
    {
        IQueryable<Car> query = Context.Cars.IgnoreQueryFilters();
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        var cars = query.ToList();
        Assert.Equal(10, cars.Count);
    }

    [Fact]
    public void ShouldGetAllOfTheCarsWithMakes()
    {
        IIncludableQueryable<Car, Make> query = Context.Cars.Include(c => c.MakeNavigation);
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        var cars = query.ToList();
        Assert.Equal(9, cars.Count);
    }

    [Fact]
    public void ShouldGetReferenceRelatedInformationExplicitly()
    {
        var car = Context.Cars.First(x => x.Id == 1);
        Assert.Null(car.MakeNavigation);
        var query = Context.Entry(car).Reference(c => c.MakeNavigation).Query();
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        query.Load();
        Assert.NotNull(car.MakeNavigation);
    }

    [Fact]
    public void ShouldNotGetTheLemonsUsingFromSql()
    {
        var entity = Context.Model.FindEntityType($"{typeof(Car).FullName}");
        var tableName = entity.GetTableName();
        var schemaName = entity.GetSchema();
#pragma warning disable EF1002 // Risk of vulnerability to SQL injection.
        var query = Context.Cars.FromSqlRaw(
            $"Select *,ValidFrom,ValidTo from {schemaName}.{tableName}");
#pragma warning restore EF1002 // Risk of vulnerability to SQL injection.
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        var cars = query.ToList();
        Assert.Equal(9, cars.Count);
    }

    [Fact]
    public void ShouldGetTheCarsUsingSqlQuery()
    {
        var entity = Context.Model.FindEntityType($"{typeof(Car).FullName}");
        var tableName = entity.GetTableName();
        var schemaName = entity.GetSchema();
        var sql = $"Select Id, IsDrivable,DateBuilt, Price, MakeId, Color, PetName from {schemaName}.{tableName}";
        var query = Context.Database.SqlQueryRaw<CarViewModel>(sql);
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        var cars = query.ToList();
        Assert.Equal(10,cars.Count);
    }

    [Fact]
    public void ShouldGetTheCarsUsingFromSqlWithIgnoreQueryFilters()
    {
        var entity = Context.Model.FindEntityType($"{typeof(Car).FullName}");
        var tableName = entity.GetTableName();
        var schemaName = entity.GetSchema();
#pragma warning disable EF1002 // Risk of vulnerability to SQL injection.
        var query = Context.Cars.FromSqlRaw(
            $"Select *,ValidFrom,ValidTo from {schemaName}.{tableName}").IgnoreQueryFilters();
#pragma warning restore EF1002 // Risk of vulnerability to SQL injection.
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        var cars = query.ToList();
        Assert.Equal(10, cars.Count);
    }

    [Fact]
    public void ShouldGetOneCarUsingInterpolation()
    {
        var carId = 1;
        var query = Context.Cars
            .FromSqlInterpolated(
                $"Select *,ValidFrom,ValidTo from dbo.Inventory where Id = {carId}")
            .Include(x => x.MakeNavigation);
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        var car = query.First();
        Assert.Equal("Black", car.Color);
        Assert.Equal("VW", car.MakeNavigation.Name);
    }

    [Fact]
    public void ShouldGetTheCountOfCarsIgnoreQueryFilters()
    {
        var count = Context.Cars.IgnoreQueryFilters().Count();
        Assert.Equal(10, count);
    }

    [Fact]
    public void ShouldGetTheCountOfCars()
    {
        var count = Context.Cars.Count();
        Assert.Equal(9, count);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    [InlineData(5, 3)]
    [InlineData(6, 1)]
    public void ShouldGetTheCarsByMakeUsingFromSql(int makeId, int expectedCount)
    {
        var entity = Context.Model.FindEntityType($"{typeof(Car).FullName}");
        var tableName = entity.GetTableName();
        var schemaName = entity.GetSchema();
#pragma warning disable EF1002 // Risk of vulnerability to SQL injection.
        var cars = Context
            .Cars
            .FromSqlRaw($"Select *,ValidFrom,ValidTo from {schemaName}.{tableName}")
            .Where(x => x.MakeId == makeId).ToList();
#pragma warning restore EF1002 // Risk of vulnerability to SQL injection.
        Assert.Equal(expectedCount, cars.Count);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    [InlineData(5, 3)]
    [InlineData(6, 1)]
    public void ShouldGetTheCountOfCarsByMakeP1(int makeId, int expectedCount)
    {
        var count = Context.Cars.Count(x => x.MakeId == makeId);
        Assert.Equal(expectedCount, count);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    [InlineData(5, 3)]
    [InlineData(6, 1)]
    public void ShouldGetTheCountOfCarsByMakeP2(int makeId, int expectedCount)
    {
        var count = Context.Cars.Where(x => x.MakeId == makeId).Count();
        Assert.Equal(expectedCount, count);
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(11, false)]
    public void ShouldCheckForAnyCarsWithMake(int makeId, bool expectedResult)
    {
        var result = Context.Cars.Any(x => x.MakeId == makeId);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(11, false)]
    public void ShouldCheckForAllCarsWithMake(int makeId, bool expectedResult)
    {
        var result = Context.Cars.All(x => x.MakeId == makeId);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(1, "Zippy")]
    [InlineData(2, "Rusty")]
    [InlineData(3, "Mel")]
    [InlineData(4, "Clunker")]
    [InlineData(5, "Bimmer")]
    [InlineData(6, "Hank")]
    [InlineData(7, "Pinky")]
    [InlineData(8, "Pete")]
    [InlineData(9, "Brownie")]
    public void ShouldGetValueFromStoredProc(int id, string expectedName)
    {
        Assert.Equal(expectedName, _carRepo.GetPetName(id));
    }

    [Fact]
    public void ShouldAddACar()
    {
        ExecuteInATransaction(RunTheTest);

        void RunTheTest()
        {
            var car = new Car
            {
                Color = "Yellow",
                MakeId = 1,
                PetName = "Herbie"
            };
            var carCount = Context.Cars.Count();
            Context.Cars.Add(car);
            Context.SaveChanges();
            var newCarCount = Context.Cars.Count();
            Assert.Equal(carCount + 1, newCarCount);
        }
    }

    [Fact]
    public void ShouldAddACarWithAttach()
    {
        ExecuteInATransaction(RunTheTest);

        void RunTheTest()
        {
            var car = new Car
            {
                Color = "Yellow",
                MakeId = 1,
                PetName = "Herbie"
            };
            var carCount = Context.Cars.Count();
            Context.Cars.Attach(car);
            Assert.Equal(EntityState.Added, Context.Entry(car).State);
            Context.SaveChanges();
            var newCarCount = Context.Cars.Count();
            Assert.Equal(carCount + 1, newCarCount);
        }
    }

    [Fact]
    public void ShouldAddMultipleCars()
    {
        ExecuteInATransaction(RunTheTest);

        void RunTheTest()
        {
            //Have to add 4 to activate batching
            var cars = new List<Car>
            {
                new() { Color = "Yellow", MakeId = 1, PetName = "Herbie" },
                new() { Color = "White", MakeId = 2, PetName = "Mach 5" },
                new() { Color = "Pink", MakeId = 3, PetName = "Avon" },
                new() { Color = "Blue", MakeId = 4, PetName = "Blueberry" },
            };
            var carCount = Context.Cars.Count();
            Context.Cars.AddRange(cars);
            Context.SaveChanges();
            var newCarCount = Context.Cars.Count();
            Assert.Equal(carCount + 4, newCarCount);
        }
    }

    [Fact]
    public void ShouldAddAnObjectGraph()
    {
        ExecuteInATransaction(RunTheTest);

        void RunTheTest()
        {
            var make = new Make { Name = "Honda" };
            var car = new Car
            {
                Color = "Yellow",
                MakeId = 1,
                PetName = "Herbie",
                RadioNavigation = new Radio
                {
                    HasSubWoofers = true,
                    HasTweeters = true,
                    RadioId = "Bose 1234"
                }
            };
            ((List<Car>)make.Cars).Add(car);
            Context.Makes.Add(make);
            var carCount = Context.Cars.Count();
            var makeCount = Context.Makes.Count();
            Context.SaveChanges();
            var newCarCount = Context.Cars.Count();
            var newMakeCount = Context.Makes.Count();
            Assert.Equal(carCount + 1, newCarCount);
            Assert.Equal(makeCount + 1, newMakeCount);
        }
    }

    [Fact]
    public void ShouldUpdateACar()
    {
        ExecuteInASharedTransaction(RunTheTest);

        void RunTheTest(IDbContextTransaction trans)
        {
            var car = Context.Cars.First(c => c.Id == 1);
            Assert.Equal("Black", car.Color);
            car.Color = "White";
            Context.SaveChanges();
            Assert.Equal("White", car.Color);
            var context2 = TestHelpers.GetSecondContext(Context, trans);
            var car2 = context2.Cars.First(c => c.Id == 1);
            Assert.Equal("White", car2.Color);
        }
    }

    [Fact]
    public void ShouldUpdateACarUsingState()
    {
        ExecuteInASharedTransaction(RunTheTest);

        void RunTheTest(IDbContextTransaction trans)
        {
            var car = Context.Cars.AsNoTracking().First(c => c.Id == 1);
            Assert.Equal("Black", car.Color);
            var updatedCar = new Car
            {
                Color = "White", //Original is Black
                Id = car.Id,
                MakeId = car.MakeId,
                PetName = car.PetName,
                TimeStamp = car.TimeStamp,
                IsDrivable = car.IsDrivable
            };
            var context2 = TestHelpers.GetSecondContext(Context, trans);
            context2.Entry(updatedCar).State = EntityState.Modified;
            //context2.Cars.Update(updatedCar);
            context2.SaveChanges();
            var context3 = TestHelpers.GetSecondContext(Context, trans);
            var car2 = context3.Cars.First(c => c.Id == 1);
            Assert.Equal("White", car2.Color);
        }
    }

    [Fact]
    public void ShouldThrowConcurrencyException()
    {
        ExecuteInATransaction(RunTheTest);

        void RunTheTest()
        {
            //Get a car record (doesn’t matter which one)
            var car = Context.Cars.First();
            //Update the database outside of the context
            Context.Database.ExecuteSqlInterpolated(
                $"Update dbo.Inventory set Color='Pink' where Id = {car.Id}");
            //update the car record in the change tracker
            car.Color = "Yellow";
            var ex = Assert.Throws<CustomConcurrencyException>(() => Context.SaveChanges());
            var entry = ((DbUpdateConcurrencyException)ex.InnerException)?.Entries[0];
            PropertyValues originalProps = entry.OriginalValues;
            PropertyValues currentProps = entry.CurrentValues;
            //This needs another database call
            PropertyValues databaseProps = entry.GetDatabaseValues();
        }
    }

    [Fact]
    public void ShouldRemoveACar()
    {
        ExecuteInATransaction(RunTheTest);

        void RunTheTest()
        {
            var carCount = Context.Cars.Count();
            var car = Context.Cars.First(c => c.Id == 8);
            Context.Cars.Remove(car);
            Context.SaveChanges();
            var newCarCount = Context.Cars.Count();
            Assert.Equal(carCount - 1, newCarCount);
            Assert.Equal(EntityState.Detached, Context.Entry(car).State);
        }
    }

    [Fact]
    public void ShouldRemoveACarUsingState()
    {
        ExecuteInASharedTransaction(RunTheTest);

        void RunTheTest(IDbContextTransaction trans)
        {
            var carCount = Context.Cars.Count();
            var car = Context.Cars.AsNoTracking().First(c => c.Id == 8);
            var context2 = TestHelpers.GetSecondContext(Context, trans);
            //context2.Entry(car).State = EntityState.Deleted;
            context2.Cars.Remove(car);
            context2.SaveChanges();
            var newCarCount = Context.Cars.Count();
            Assert.Equal(carCount - 1, newCarCount);
            Assert.Equal(EntityState.Detached, Context.Entry(car).State);
        }
    }

    [Fact]
    public void ShouldFailToRemoveACar()
    {
        ExecuteInATransaction(RunTheTest);

        void RunTheTest()
        {
            var car = Context.Cars.First(c => c.Id == 1);
            Context.Cars.Remove(car);
            Assert.Throws<CustomDbUpdateException>(() => Context.SaveChanges());
        }
    }

    [Fact]
    public void ShouldUpdateInBulk()
    {
        var color = "Pink";
        var makeId = 3;
        ExecuteInATransaction(RunTheTest);
        Context.ChangeTracker.Clear();
        var cars = Context.Cars.Where(c => c.IsDrivable).ToList();
        Assert.False(cars.All(x => x.Color == color));
        Assert.False(cars.All(x => x.MakeId == makeId));

        void RunTheTest()
        {
            var count = _carRepo.SetAllDrivableCarsColorAndMakeId(color, makeId);
            var cars = Context.Cars.Where(c => c.IsDrivable).ToList();
            Assert.True(cars.All(x => x.Color == color));
            Assert.True(cars.All(x => x.MakeId == makeId));
        }
    }

    [Fact]
    public void ShouldDeleteInBulk()
    {
        var carCount1 = Context.Cars.IgnoreQueryFilters().Count();
        ExecuteInATransaction(RunTheTest);
        Context.ChangeTracker.Clear();
        var carCount2 = Context.Cars.IgnoreQueryFilters().Count();
        Assert.Equal(carCount1, carCount2);

        void RunTheTest()
        {
            var count = _carRepo.DeleteNonDrivableCars();
            Assert.NotEqual(carCount1, Context.Cars.IgnoreQueryFilters().Count());
        }
    }
}
