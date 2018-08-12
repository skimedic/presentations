using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using MOQExamples.SystemsUnderTest;
using Xunit;

namespace MOQExamples.A_Basics
{
    public class D_Exceptions
    {
        [Fact]
        public void Should_Mock_General_Exceptions()
        {
            var id = 12;
            var mock = new Mock<IRepo>();
            mock.Setup(x => x.Find(id)).Throws<ArgumentException>();

            var controller = new TestController(mock.Object);
            Assert.Throws<ArgumentException>(() => controller.GetCustomer(12));
        }
        [Fact]
        public void Should_Mock_Specific_Exceptions()
        {
            var id = 12;
            var mock = new Mock<IRepo>();
            var param = "Id";
            var message = "Missing parameter";
            mock.Setup(x => x.Find(id)).Throws(new ArgumentException(message,param));

            var controller = new TestController(mock.Object);
            var ex = Assert.Throws<ArgumentException>(() => controller.GetCustomer(id));
            Assert.Equal($"{message}\r\nParameter name: {param}",ex.Message);
            Assert.Equal(param,ex.ParamName);
        }
    }

}
