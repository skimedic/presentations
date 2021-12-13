namespace AutoLot.Dal.Tests.IntegrationTests;

[Collection("Integration Tests")]
public class CustomerOrderViewModelTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTestFixture>
{
    ICustomerOrderViewModelRepo _repo;
    public CustomerOrderViewModelTests(ITestOutputHelper outputHelper) : base(outputHelper)
    {
        _repo = new CustomerOrderViewModelRepo(Context);
    }
    public override void Dispose()
    {
        _repo.Dispose();
        base.Dispose();
    }
    [Fact]
    public void ShouldGetAllViewModels()
    {
        var qs = Context.CustomerOrderViewModels.ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        List<Models.ViewModels.CustomerOrderViewModel> list = Context.CustomerOrderViewModels.ToList();
        Assert.NotEmpty(list);
        Assert.Equal(5, list.Count);
    }
    [Fact]
    public void ShouldGetAllViewModelsUsingTheRepo()
    {
        var qs = _repo.GetAll().AsQueryable().ToQueryString();
        OutputHelper.WriteLine($"Query: {qs}");
        List<Models.ViewModels.CustomerOrderViewModel> list = _repo.GetAll().ToList();
        Assert.NotEmpty(list);
        Assert.Equal(5, list.Count);
    }
}
