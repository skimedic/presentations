using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using MOQExamples.SystemsUnderTest;
using Xunit;

//https://github.com/Moq/moq4/wiki/Quickstart

namespace MOQExamples.A_Basics
{
    public class A_FirstExample
    {
        [Fact]
        public void Should_Mock_Function_With_Return_Value()
        {
            var id = 12;
            var name = "Fred Flinstone";
            var customer = new Customer {Id = id, Name = name};
            var mock = new Mock<IRepo>();
            mock.Setup(x => x.Find(id)).Returns(customer);

            var controller = new TestController(mock.Object);
            var actual = controller.GetCustomer(id);
            Assert.Same(customer,actual);
            Assert.Equal(id,actual.Id);
            Assert.Equal(name,actual.Name);
        }

        [Fact]
        public void Should_Mock_Function_With_Void_Return()
        {
            var id = 12;
            var name = "Fred Flinstone";
            var customer = new Customer {Id = id, Name = name};
            var mock = new Mock<IRepo>();
            mock.Setup(x => x.AddRecord(customer));

            var controller = new TestController(mock.Object);
            controller.SaveCustomer(customer);
        }
    }
}
