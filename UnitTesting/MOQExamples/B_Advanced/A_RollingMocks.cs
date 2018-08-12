using System.Collections.Generic;
using Moq;
using MOQExamples.SystemsUnderTest;
using Xunit;

namespace MOQExamples.B_Advanced
{
    public class A_RollingMocks
    {
        [Theory]
        [InlineData(0,12,"Bob")]
        [InlineData(1,17,"Sue")]
        [InlineData(2,100065,"Tony")]
        public void Should_Enable_Rolling_Mocks(int index, int id, string name)
        {
            var customers = new List<Customer>
            {
                new Customer {Id = 12, Name = "Bob"},
                new Customer {Id = 17, Name = "Sue"},
                new Customer {Id = 100065, Name = "Tony"},
            };
            var mock = new Mock<IRepo>();
            mock.Setup(x => x.Find(It.IsInRange(0, 2, Range.Inclusive)))
                .Returns((int x) => customers[x]);

            var controller = new TestController(mock.Object);
            var cust = controller.GetCustomer(index);
            Assert.Equal(id,cust.Id);
            Assert.Equal(name,cust.Name);
        }
    }
}