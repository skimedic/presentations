using System;
using System.Collections.Generic;
using System.Text;
using WhatsNewInCSharp7.B_Tuples;
using Xunit;

namespace WhatsNewInCSharp7_Tests.B_TuplesTests
{
    public class B_Deconstruction
    {
        [Fact]
        public void ShouldAssignValuesWithoutDeconstruction()
        {
            var first = 3.14;
            var second = 6.28;
            var t = (first, second);
            double horizontal = t.Item1;
            double vertical = t.Item2;
            Assert.Equal(first,horizontal);
            Assert.Equal(second,vertical);
        }

        [Fact]
        public void SimpleDeconstruction()
        {
            var first = 3.14;
            var second = 6.28;
            var t = (first, second);
            var (horizontal, vertical) = t;
            (double horizontal1, double vertical1) = t;
            Assert.Equal(first, horizontal);
            Assert.Equal(second, vertical);
        }

        [Fact]
        public void ShouldAssignValuesWithTypeDeconstruction()
        {
            var first = 3.14;
            var second = 6.28;
            var third = 6.28;
            var p = new MyPoint(first, second, third);
            var (horizontal, vertical, zAxis) = p;
            //without var, need specific type
            (double horizontal1, double vertical1, double zAxis1) = p;
            Assert.Equal(first,horizontal);
            Assert.Equal(second,vertical);
        }

        [Fact]
        public void ShouldDoSomething()
        {
            var t = DoSomething();
            //t.i;
            //t.s;
            //t.p;
        }
        internal (string s,int i,MyPoint p) DoSomething()
        {
            return ("foo",5,new MyPoint(3,2));
        }
    }
    
}
