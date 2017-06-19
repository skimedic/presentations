// Copyright Information
// =============================
// PatternsExamplesTests - A_MySingletonClassTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using NUnit.Framework;
using PatternsExamples.A_Creational.A_Singleton;

namespace PatternsExamplesTests.A_CreationalTests
{
    [TestFixture]
    public class MySingletonClassTests
    {
        [Test]
        public void ShouldReturnSameInstanceWithMultipleCalls()
        {
            MySingletonClass first = MySingletonClass.Instance;
            MySingletonClass second = MySingletonClass.Instance;
            Assert.AreSame(first, second);
            first.SomeValue++;
            Assert.AreEqual(first.SomeValue, second.SomeValue);
            second.SomeValue++;
            Assert.AreEqual(first.SomeValue, second.SomeValue);
            first.Dispose();
            second.Dispose();
        }
    }
}