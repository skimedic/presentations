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
            //Arrange
            var id = 12;
            var name = "Fred FlintStone";
            var customer = new Customer {Id = id, Name = name};
            var mockRepo = new Mock<IRepo>();
            mockRepo.Setup(x => x.Find(id)).Returns(customer);

            var controller = new TestController(mockRepo.Object);
            //Act
            var actual = controller.GetCustomer(id);
            //Assert
            Assert.Same(customer,actual);
            Assert.Equal(id,actual.Id);
            Assert.Equal(name,actual.Name);
        }

        [Fact]
        public void Should_Mock_Repetitive_Function_Calls_With_Return_Values()
        {
            var id1 = 12;
            var name1 = "Fred FlintStone";
            var customer1 = new Customer {Id = id1, Name = name1};
            var id2 = 1;
            var name2 = "Wilma FlintStone";
            var customer2 = new Customer {Id = id2, Name = name2};
            var mock = new Mock<IRepo>();
            mock.SetupSequence(x => x.Find(It.IsAny<int>()))
                .Returns(customer1)
                .Returns(customer2);

            var controller = new TestController(mock.Object);
            var actual = controller.GetCustomer(id1);
            Assert.Same(customer1,actual);
            Assert.Equal(id1,actual.Id);
            Assert.Equal(name1,actual.Name);
            actual = controller.GetCustomer(id2);
            Assert.Same(customer2,actual);
            Assert.Equal(id2,actual.Id);
            Assert.Equal(name2,actual.Name);
        }

        [Fact]
        public void Should_Mock_Function_With_Void_Return()
        {
            var id = 12;
            var name = "Fred FlintStone";
            var customer = new Customer {Id = id, Name = name};
            var mock = new Mock<IRepo>();
            mock.Setup(x => x.AddRecord(customer));

            var controller = new TestController(mock.Object);
            controller.SaveCustomer(customer);
        }
    }
}
