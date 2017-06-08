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
            _counter++;
        }

        public void Dispose()
        {
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
