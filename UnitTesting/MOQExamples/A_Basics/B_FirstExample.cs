using System;
using System.Linq.Expressions;
using Moq;
using MOQExamples.SystemsUnderTest;
using Xunit;

namespace MOQExamples.A_Basics
{
    public class B_FirstExample
    {
        [Fact]
        public void Should_Verify_Mock_Functions_Executed_Marked_Verifiable()
        {
            var id = 12;
            var name = "Fred Flinstone";
            var customer = new Customer { Id = id, Name = name };
            var mock = new Mock<IRepo>();
            Expression<Func<IRepo, Customer>> call = x => x.Find(id);
            mock.Setup(call).Returns(customer).Verifiable("Method not called");
            var controller = new TestController(mock.Object);
            var actual = controller.GetCustomer(id);
            Assert.Same(customer, actual);
            Assert.Equal(id, actual.Id);
            Assert.Equal(name, actual.Name);
            mock.Verify(call);
        }

        [Fact]
        public void Should_Verify_All_Mock_Functions()
        {
            var id = 12;
            var name = "Fred Flinstone";
            var customer = new Customer { Id = id, Name = name };
            var mock = new Mock<IRepo>();
            mock.Setup(x => x.Find(id)).Returns(customer);

            Assert.Throws<MockException>(() => mock.VerifyAll());
        }

        [Fact]
        public void Should_Not_Verify_Mock_Functions_Not_Verifiable()
        {
            var id = 12;
            var name = "Fred Flinstone";
            var customer = new Customer { Id = id, Name = name };
            var mock = new Mock<IRepo>();
            Expression<Func<IRepo, Customer>> call = x => x.Find(id);
            mock.Setup(call).Returns(customer);
            mock.Verify();
        }

        [Fact]
        public void Should_Verify_Mock_Functions_Not_Executed_Marked_Verifiable()
        {
            var id = 12;
            var name = "Fred Flinstone";
            var customer = new Customer { Id = id, Name = name };
            var mock = new Mock<IRepo>();
            Expression<Func<IRepo, Customer>> call = x => x.Find(id);
            var errorMessage = "Method not called";
            mock.Setup(call).Returns(customer).Verifiable(errorMessage);
            var ex = Assert.Throws<MockException>(()=>mock.Verify(call));
        }


    }
}
