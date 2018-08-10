#region Copyright
// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - A_ConstructorAndDispose.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject.B_SharedContexts
{
    public class A_ConstructorAndDispose : IDisposable
    {
        private int _counter = 0;
        public A_ConstructorAndDispose()
        {
            //Test Setup
            _counter++;
        }

        public void Dispose()
        {
            //Test Teardown
            _counter--;
        }

        [Fact]
        public void ShouldBeOne()
        {
            Assert.Equal(1,_counter);
        }
        [Fact]
        public void ShouldAlsoBeOne()
        {
            Assert.Equal(1,_counter);
        }
    }
}
