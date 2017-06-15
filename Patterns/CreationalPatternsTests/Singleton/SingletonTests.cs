using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreationalPatterns.Singleton;
using Xunit;

namespace CreationalPatternsTests.Singleton
{
    [Collection("CreationalPatternsTests")]
    public class SingletonTests
    {
        [Fact]
        public void ShouldCreateJustOneInstance()
        {
            MySingletonClass first = MySingletonClass.Instance;
            MySingletonClass second = MySingletonClass.Instance;
            Assert.Same(first, second);
            first.SomeValue++;
            Assert.Equal(first.SomeValue, second.SomeValue);
            second.SomeValue++;
            Assert.Equal(first.SomeValue, second.SomeValue);
        }
    }
}
