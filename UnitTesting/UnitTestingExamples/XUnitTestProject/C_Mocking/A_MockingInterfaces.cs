using System;
using System.Text;
using Moq;
using Xunit;

namespace XUnitTestProject.C_Mocking
{
    [Collection("MockingTests")]
    public class A_MockingInterfaces
    {
        [Fact]
        public void ShouldReplaceConcreteImplementation()
        {
            var skimedic = "Skimedic";
            var cust = new Customer {Id = 12, Name = skimedic};
            var mock = new Mock<IRepo>();

            mock.Setup(foo => foo.Find(It.IsAny<int>())).Returns(cust);
            var sut = new TestController(mock.Object);
            var cust2 = sut.GetCustomer(12);
            Assert.Equal(cust.Id, cust2.Id);
            Assert.Equal(cust.Name, cust2.Name);
            mock.Verify(foo => foo.Find(12));
        }
    }
}