// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Dal.Tests - DriverTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/02
// ==================================

namespace AutoLot.Dal.Tests.IntegrationTests;

[Collection("Integration Tests")]
public class DriverTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTestFixture>
{
    private readonly IDriverRepo _repo;

    public DriverTests(ITestOutputHelper outputHelper) : base(outputHelper)
    {
        _repo = new DriverRepo(Context);
    }

    public override void Dispose()
    {
        _repo.Dispose();
        base.Dispose();
    }

    [Fact(Skip="Just showing the example, doesn't work due to the computed column")]
    public void ShouldUpdateInBulk()
    {
        var person = new Person { FirstName = "George", LastName = "Jetson" };
        var driver = _repo.Find(1);
        Assert.Equal("Fred", driver.PersonInformation.FirstName);
        Assert.Equal("Flintstone", driver.PersonInformation.LastName);
        ExecuteInATransaction(RunTheTest);

        void RunTheTest()
        {
            var count = _repo.ExecuteBulkUpdate(x => x.Id == 1, s => s.SetProperty(b => b.PersonInformation, person));
            Context.ChangeTracker.Clear();
            var updatedDriver = _repo.Find(1);
            Assert.Equal(person.FirstName, updatedDriver.PersonInformation.FirstName);
            Assert.Equal(person.LastName, updatedDriver.PersonInformation.LastName);
        }
    }
}