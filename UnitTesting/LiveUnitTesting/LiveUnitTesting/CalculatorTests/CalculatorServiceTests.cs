using LiveUnitTesting;
[assembly: Trait("Category", "SkipWhenLiveUnitTesting")]

namespace CalculatorTests;

//[Trait("Category", "SkipWhenLiveUnitTesting")]
public class CalculatorServiceTests
{
    private readonly CalculatorService _sut = new();

    [Fact]
    public void Add_ReturnsSum()
    {
        var result = _sut.Add(2, 3);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Subtract_ReturnsDifference()
    {
        var result = _sut.Subtract(5, 2);
        Assert.Equal(3, result);
    }

    [Fact]
    public void Divide_ByZero_Throws()
    {
        Assert.Throws<DivideByZeroException>(() => _sut.Divide(10, 0));
    }

    [Fact]
    public void Divide_Returns_Result()
    {
        var result = _sut.Divide(10, 2);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Multiply_ReturnsProduct()
    {
        var result = _sut.Multiply(4, 5);
        Assert.Equal(20, result);
    }
    [Fact]
    public void Exponentation_ReturnsPower()
    {
        var result = _sut.Power(2, 3);
        Assert.Equal(8, result);
    }

    /*
 Use the following attributes to exclude individual methods from Live Unit Testing:

xUnit: [Trait("Category", "SkipWhenLiveUnitTesting")]
NUnit: [Category("SkipWhenLiveUnitTesting")]
MSTest: [TestCategory("SkipWhenLiveUnitTesting")]

Use the following attributes to exclude an entire assembly of tests from Live Unit Testing:

xUnit: [assembly: AssemblyTrait("Category", "SkipWhenLiveUnitTesting")]
NUnit: [assembly: Category("SkipWhenLiveUnitTesting")]
MSTest: [assembly: TestCategory("SkipWhenLiveUnitTesting")]
    */

    [Fact]
    [Trait("Category", "SkipWhenLiveUnitTesting")]
    public void LongRunningTest()
    {
        Task.Delay(5000).Wait();
    }
}