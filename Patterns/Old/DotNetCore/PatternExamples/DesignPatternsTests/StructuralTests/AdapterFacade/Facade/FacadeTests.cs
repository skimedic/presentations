// Copyright Information
// =============================
// StructuralPatternsTests - FacadeTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using DesignPatterns.Structural.AdapterFacade.Facade;
using Xunit;

namespace DesignPatternsTests.StructuralTests.AdapterFacade.Facade
{
    [Collection("FacadeTests")]
    public class FacadeTests
    {
        [Fact]
        public void ShouldExecuteConfusingAPICalls()
        {
            IBetterAPI betterAPI = new BetterAPI();
            //IBetterAPI betterAPIOldStyle = new BetterAPI(new Confusing(), new Overdone("foo"));
            Assert.Equal(6, betterAPI.AddThreeNumbers(1, 2, 3));
            Assert.Equal(20, betterAPI.AddThenMultiply(4, 5));
            Assert.Equal(35, betterAPI.AddThenMultiply(4, 3, 5));
            Assert.Equal(45, betterAPI.AddThenMultiply(4, 3, 2, 5));
        }
    }
}