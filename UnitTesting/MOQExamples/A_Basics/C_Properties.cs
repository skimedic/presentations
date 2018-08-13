using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using MOQExamples.SystemsUnderTest;
using Xunit;

namespace MOQExamples.A_Basics
{
    public class C_Properties
    {
        [Fact]
        public void Should_Mock_Properties_Specifically()
        {
            var mock = new Mock<IRepo>();
            var tenantId = 5;
            mock.Setup(x => x.TenantId).Returns(tenantId);

            var controller = new TestController(mock.Object);
            Assert.Equal(tenantId,controller.TenantId());
        }

        [Fact]
        public void Should_Stub_Properties()
        {
            var mock = new Mock<IRepo>();
            var tenantId = 5;
            //Setup without a default value
            //mock.SetupProperty(x => x.TenantId);

            //This sets a default value
            mock.SetupProperty(x => x.TenantId,tenantId);

            var controller = new TestController(mock.Object);
            Assert.Equal(tenantId,controller.TenantId());

            var newTenantId = 12;
            mock.Object.TenantId = newTenantId;
            Assert.Equal(newTenantId, controller.TenantId());
        }

        [Fact]
        public void Should_Mock_And_Verify_Setter()
        {
            var mock = new Mock<IRepo>();
            var tenantId = 5;
            Action<IRepo> set = x => x.TenantId = tenantId;
            mock.SetupSet(set);
            var controller = new TestController(mock.Object);
            controller.SetTenantId(tenantId);
            mock.VerifySet(set);
        }

        [Fact]
        public void Should_Mock_Nested_Properties()
        {
            //properties need to be virtual if nested
            var mock = new Mock<IOrder>();
            mock.Setup(x => x.CustomerOnOrder.AddressNavigation.StreetName).Returns("Elm");
            var controller = new OrderController(mock.Object);

            Assert.Equal("Elm",controller.GetCustomer().AddressNavigation.StreetName);
        }

    }
}
