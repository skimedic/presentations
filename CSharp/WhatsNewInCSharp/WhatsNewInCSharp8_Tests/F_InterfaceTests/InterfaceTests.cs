using System;
using System.Collections.Generic;
using System.Text;
using WhatsNewInCSharp8.F_Interfaces;
using Xunit;

namespace WhatsNewInCSharp8_Tests.F_InterfaceTests
{
    public class InterfaceTests
    {
        [Fact]
        public void ShouldGetNameFromInitialPerson()
        {
            var sut = new Person();
            Assert.Equal("Jane Doe",((IPerson)sut).GetName());
        }
        [Fact]
        public void ShouldGetNameFromUpdatedPerson()
        {
            var sut = new NewPerson();
            Assert.Equal("Unknown Person",((IPerson)sut).GetName());
        }
    }
}
