using Moq;
using MOQExamples.SystemsUnderTest;
using Xunit;

namespace MOQExamples.A_Basics
{
    public class E_Arguments
    {
        [Fact]
        public void Should_Return_Null_When_No_Argument_Match()
        {
            var id = 12;
            var name = "Fred FlintStone";
            var customer = new Customer { Id = id, Name = name };
            var mock = new Mock<IRepo>();
            mock.Setup(x => x.Find(id)).Returns(customer);

            var controller = new TestController(mock.Object);
            var actual = controller.GetCustomer(id+1);
            Assert.Null(actual);
        }
        [Fact]
        public void Should_Return_When_Arguments_Match()
        {
            var id = 12;
            var name = "Fred FlintStone";
            var customer = new Customer { Id = id, Name = name };
            var mock = new Mock<IRepo>();
            mock.Setup(x => x.Find(It.IsAny<int>())).Returns(customer);
            //mock.Setup(x => x.Find(It.Is<int>(i => i > 0))).Returns(customer);
            //mock.Setup(x => x.Find(It.IsInRange(0,100,Range.Inclusive))).Returns(customer);

            var controller = new TestController(mock.Object);
            var actual = controller.GetCustomer(id);
            Assert.Same(customer, actual);
            Assert.Equal(id, actual.Id);
            Assert.Equal(name, actual.Name);
        }
    }
}
