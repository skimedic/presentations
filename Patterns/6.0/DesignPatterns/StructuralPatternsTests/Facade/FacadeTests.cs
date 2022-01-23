// Copyright Information
// ==================================
// DesignPatterns - StructuralPatternsTests - FacadeTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace StructuralPatternsTests.Facade;

[Collection("FacadeTests")]
public class FacadeTests
{
    [Fact]
    public void ShouldExecuteConfusingApiCalls()
    {
        IBetterApi betterApi = new BetterApi();
        //IBetterAPI betterAPIOldStyle = new BetterAPI(new Confusing(), new Overdone("foo"));
        Assert.Equal(6, betterApi.AddThreeNumbers(1, 2, 3));
        Assert.Equal(20, betterApi.AddThenMultiply(4, 5));
        Assert.Equal(35, betterApi.AddThenMultiply(4, 3, 5));
        Assert.Equal(45, betterApi.AddThenMultiply(4, 3, 2, 5));
    }
}