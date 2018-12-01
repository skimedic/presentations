using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WhatsNewInCSharp7_Tests.C_OutVariableTests
{
    public class OutVariableTests
    {
        [Fact]
        public void ShouldAssignOutVariableInOneCall()
        {
            //C# 6
            int oldResult;
            bool oldCanParse = int.TryParse("123", out oldResult);

            //C# 7.0
            int.TryParse("123", out int result);
            int.TryParse("123", out var result2);

            var canParse = bool.TryParse("true", out var boolResult);
            Assert.True(canParse);
            Assert.True(boolResult);

        }
    }
}
