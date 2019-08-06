// Copyright Information
// =============================
// CreationalPatternsTests - SingletonTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using DesignPatterns.Creational.Singleton;
using Xunit;

namespace DesignPatternsTests.CreationalTests.Singleton
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
