using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestingExamples.xUnitTests
{
    public class D_Exceptions
    {
        string _customMessage = "Custom message";
        [Fact]
        public void ShouldThrowAnException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ThrowAnError());
            Assert.Equal(_customMessage,ex.Message);
        }

        [Fact]
        public void ShouldRecordAnException()
        {
            //Better follows AAA syntax
            var ex = Record.Exception(() => ThrowAnError());
            Assert.Equal(_customMessage, ex.Message);
        }

        private void ThrowAnError()
        {
            throw new InvalidOperationException(_customMessage);
        }
    }

}