#region copyright
// Copyright Information
// ==============================
// PatternsExamplesTests - B_FacadeTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion
using Xunit;

namespace PatternsExamplesTests.B_StructuralTests
{
    [Collection("FacadeTests")]
    public class FacadeTests
    {
        [Fact]
        public void ShouldExecuteConfusingAPICalls()
        {
            //IBetterAPI betterAPI = IOCContainer.Instance.GetFacadeForBadAPI();
            //IBetterAPI betterAPIOldStyle = new BetterAPI(new Confusing(), new Overdone("foo"));
            //Assert.Equal(6, betterAPI.AddThreeNumbers(1, 2, 3));
            //Assert.Equal(20, betterAPI.AddThenMultiply(4, 5));
            //Assert.Equal(35, betterAPI.AddThenMultiply(4, 3, 5));
            //Assert.Equal(45, betterAPI.AddThenMultiply(4, 3, 2, 5));
        }
    }
}