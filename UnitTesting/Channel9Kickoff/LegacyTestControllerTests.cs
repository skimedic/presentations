using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Castle.Core.Logging;
using Channel9Kickoff.SystemsUnderTest;
using Moq;
using Xunit;

namespace Channel9Kickoff
{
    public class LegacyTestControllerTests
    {
        [Fact]
        public void Should_Mock_Function_With_Return_Value()
        {
            //Arrange
            var id = 12;
            var name = "Fred Flinstone";
            var customer = new Customer { Id = id, Name = name };
            var mock = new Mock<IRepo>();
            mock.Setup(x => x.Find(id)).Returns(customer);

            var controller = new TestController(mock.Object);
            //Act
            var actual = controller.GetCustomer(id);
            //Assert
            Assert.Same(customer, actual);
            Assert.Equal(id, actual.Id);
            Assert.Equal(name, actual.Name);
        }

        [Fact]
        public void Should_Log_Exceptions_When_Getting_Customer()
        {
            //Arrange
            var mockRepo = new Mock<IRepo>();
            var mockLogger = new Mock<ILogger>();
            var id = 12;
            Expression<Action<ILogger>> expression = x => x.Error(It.IsAny<string>());
            mockLogger.Setup(expression).Verifiable();
            mockRepo.Setup(x => x.Find(id)).Throws<ArgumentException>();
            var controller = new TestController(mockRepo.Object, mockLogger.Object);
            //Act
            //Assert.Throws<ArgumentException>(()=>controller.GetCustomer(id));
            var cust = controller.GetCustomer(id);
            //Assert
            Assert.Null(cust);
            mockLogger.Verify(expression,Times.Once);
        }

        /*

         *         public Customer GetCustomer(int id)
        {
            try
            {
                return _repo.Find(id);

            }
            catch (Exception ex)
            {
            //TODO: Add logging
                throw;
            }
        }


         */
    }
}
