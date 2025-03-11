// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal.Tests - MakeTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/05/27
// ==================================

namespace AutoLot.Dal.Tests.IntegrationTests;

[Collection("Integration Tests")]
public class MakeTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTestFixture>
{
    private readonly IMakeRepo _repo;

    public MakeTests(ITestOutputHelper outputHelper) : base(outputHelper)
    {
        _repo = new MakeRepo(Context);
    }

    public override void Dispose()
    {
        _repo.Dispose();
        base.Dispose();
    }

    [Fact]
    public void ShouldGetAllMakesAndCarsThatAreYellow()
    {
        var query = Context.Makes.IgnoreQueryFilters()
            .Include(x => x.Cars.Where(x => x.Color == "Yellow"));
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        var makes = query.ToList();
        Assert.NotNull(makes);
        Assert.NotEmpty(makes);
        Assert.NotEmpty(makes.Where(x => x.Cars.Any()));
        Assert.Empty(makes.First(m => m.Id == 1).Cars);
        Assert.Empty(makes.First(m => m.Id == 2).Cars);
        Assert.Empty(makes.First(m => m.Id == 3).Cars);
        Assert.Single(makes.First(m => m.Id == 4).Cars);
        Assert.Empty(makes.First(m => m.Id == 5).Cars);
    }

    [Fact]
    public void ShouldGetAllMakesAndCarsThatAreYellowAsSplitQuery()
    {
        var query = Context.Makes.AsSplitQuery().IgnoreQueryFilters()
            .Include(x => x.Cars.Where(x => x.Color == "Yellow"));
        var makes = query.ToList();
        Assert.NotNull(makes);
        Assert.NotEmpty(makes);
        Assert.NotEmpty(makes.Where(x => x.Cars.Any()));
        Assert.Empty(makes.First(m => m.Id == 1).Cars);
        Assert.Empty(makes.First(m => m.Id == 2).Cars);
        Assert.Empty(makes.First(m => m.Id == 3).Cars);
        Assert.Single(makes.First(m => m.Id == 4).Cars);
        Assert.Empty(makes.First(m => m.Id == 5).Cars);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    [InlineData(5, 3)]
    [InlineData(6, 1)]
    public void ShouldGetAllCarsForAMakeExplicitlyWithQueryFilters(int makeId, int carCount)
    {
        var make = Context.Makes.First(x => x.Id == makeId);
        IQueryable<Car> query = Context.Entry(make).Collection(c => c.Cars).Query();
        var qs = query.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        query.Load();
        Assert.Equal(carCount, make.Cars.Count());
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    [InlineData(5, 3)]
    [InlineData(6, 1)]
    public void ShouldGetAllCarsForAMakeExplicitly(int makeId, int carCount)
    {
        var make = Context.Makes.First(x => x.Id == makeId);
        IQueryable<Car> query = Context.Entry(make).Collection(
            c => c.Cars).Query().IgnoreQueryFilters();
        var qs = query.IgnoreQueryFilters().ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        query.Load();
        Assert.Equal(carCount, make.Cars.Count());
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    [InlineData(5, 3)]
    [InlineData(6, 1)]
    public void ShouldGetAllCarsForAMakeWithFunction(int makeId, int carCount)
    {
        var cars = Context.GetCarsFor(makeId).IgnoreQueryFilters();
        string qs = Context.GetCarsFor(makeId).ToQueryString();
        Assert.Equal(carCount, cars.Count());
    }

    [Fact]
    public void ShouldUseFunctionInServerSideQuery()
    {
        var query =
            Context.Makes
                .Where(x => ApplicationDbContext.InventoryCountFor(x.Id) > 2);
        var list = query.ToList();
        Assert.Single(list);
    }
}