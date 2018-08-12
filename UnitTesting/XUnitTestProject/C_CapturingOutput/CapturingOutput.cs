#region Copyright
// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - CapturingOutput.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion

using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject.C_CapturingOutput
{
    public class CapturingOutput
    {
        private readonly ITestOutputHelper _output;

        public CapturingOutput(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void MyTest()
        {
            var temp = "my class!";
            _output.WriteLine("This is output from {0}", temp);
        }
    }
}
