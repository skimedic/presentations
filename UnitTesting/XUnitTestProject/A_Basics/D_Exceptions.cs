#region Copyright
// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - D_Exceptions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using System;
using Xunit;
using Xunit.Sdk;

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
            //Doesn't check the exception type in the action
            if (!(ex is InvalidOperationException))
            {
                Assert.True(false);
            }
            Assert.Equal(_customMessage, ex.Message);
        }

        private void ThrowAnError()
        {
            throw new InvalidOperationException(_customMessage);
        }
    }

}