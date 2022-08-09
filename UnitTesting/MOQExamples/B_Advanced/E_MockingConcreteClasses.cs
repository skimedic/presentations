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
using Moq.Protected;
using MOQExamples.SystemsUnderTest;
using Xunit;

namespace MOQExamples.B_Advanced
{
    public class E_MockingConcreteClasses
    {
        [Fact]
        public void Should_Replace_Concrete_Implementation()
        {
            var skimedic = "Fred FlintStone";
            var cust = new Customer { Id = 12, Name = skimedic };
            var mockRepo = new Mock<FakeRepo>();
            var mock = new Mock<IRepo>();

            mock.Setup(x => x.Find(It.IsAny<int>())).Returns(cust);
            var sut = new TestController(mock.Object);
            var cust2 = sut.GetCustomer(13);
            Assert.Equal(cust.Id, cust2.Id);
            Assert.Equal(cust.Name, cust2.Name);
            mock.Verify(x => x.Find(13));
        }

        [Fact]
        public void Should_Mock_Protected_Members()
        {
            var mock = new Mock<FakeRepo>();
            mock.Protected().Setup<int>("GetNumber").Returns(12);
            Assert.Equal(12, mock.Object.CallProtectedMember());
            mock.Protected().Setup<int>("GetNumberWithParam",ItExpr.IsAny<int>()).Returns(15);
            Assert.Equal(15, mock.Object.CallProtectedMemberWithParam(4));
        }
        [Fact]
        public void Should_Mock_Protected_Members_Using_Lambdas()
        {
            var mock = new Mock<FakeRepo>();
            mock.Protected().As<FakeMockInterface>().Setup(m => m.GetNumber()).Returns(12);
            Assert.Equal(12, mock.Object.CallProtectedMember());
            mock.Protected().As<FakeMockInterface>().Setup(m => m.GetNumberWithParam(It.IsAny<int>())).Returns(15);
            Assert.Equal(15, mock.Object.CallProtectedMemberWithParam(4));
        }

        public interface FakeMockInterface
        {
            int GetNumber();
            int GetNumberWithParam(int param);

        }
    }
}