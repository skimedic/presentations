using System;
using Xunit;

namespace XUnitTestProject.A_Basics
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
            Exception ex = Record.Exception(() => ThrowAnError());
            Assert.Equal(_customMessage, ex.Message);
        }

        private void ThrowAnError()
        {
            throw new InvalidOperationException(_customMessage);
        }
    }

}