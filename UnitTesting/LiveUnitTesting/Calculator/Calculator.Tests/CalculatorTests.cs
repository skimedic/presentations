//[assembly: Trait("Category", "SkipWhenLiveUnitTesting")]

namespace Calculator.Tests;

//[Trait("Category", "SkipWhenLiveUnitTesting")]
public class CalculatorTests
{
    private readonly CalculatorService _sut = new();

    [Fact]
    public void Add_ReturnsSum()
    {
        var result = _sut.Add(2, 3) + 1;
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
        //_sut.Divide(5, 0);
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
    public void Exponentiation_ReturnsPower()
    {
            var result = _sut.Power(2, 3);
            Assert.Equal(8, result);
    }

    [Fact]
    public void Modulus_ReturnsRemainder()
    {
        var result = _sut.Modulus(10, 3);
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
    //[Trait("LongRunning", "True")]
    public void ExcludedTest()
    {
        var result = _sut.Multiply(4, 5);
        Assert.Equal(20, result);
    }
}