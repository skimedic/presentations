#region Copyright
// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - A_MockingInterfaces.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion

using Moq;
using MOQExamples.SystemsUnderTest;
using Xunit;

namespace MOQExamples.B_Advanced
{
    public class B_MockingConcreteClasses
    {
        [Fact]
        public void ShouldReplaceConcreteImplementation()
        {
            var skimedic = "Skimedic";
            var cust = new Customer {Id = 12, Name = skimedic};
            var mock = new Mock<IRepo>();

            mock.Setup(x => x.Find(It.IsAny<int>())).Returns(cust);
            var sut = new TestController(mock.Object);
            var cust2 = sut.GetCustomer(13);
            //Assert.Equal(cust.Id, cust2.Id);
            //Assert.Equal(cust.Name, cust2.Name);
            mock.Verify(x => x.Find(13));
        }
    }
}