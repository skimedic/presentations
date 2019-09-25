using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace WhatsNewInCSharp7_Tests.D_PatternMatchingTests
{
    public class PatternMatchingTests
    {
        internal int DiceSum(IEnumerable<object> rolls)
        {
            var sum = 0;
            foreach (var item in rolls)
            {
                //this also works with custom classes and interfaces
                if (item is int val)
                    sum += val;
                else if (item is IEnumerable<object> subList)
                    sum += DiceSum(subList);
            }
            return sum;
        }
        [Fact]
        public void ShouldUsePatternMatchingWithIs()
        {
            IEnumerable<object> rolls = new List<object>
            {
                5,
                new List<object> {3, 4},
                12
            };
            Assert.Equal(24,DiceSum(rolls));
        }
        internal int DiceSum2(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                switch (item)
                {
                    //NOTE: Order now matters. Flipping this and int val breaks the functionality
                    case 0:
                        break;
                    case int val:
                        sum += val;
                        break;
                    case IEnumerable<object> subList when subList.Any():
                        sum += DiceSum2(subList);
                        break;
                    case IEnumerable<object> subList:
                        break;
                    case var i when i is string:
                        break;
                    case null:
                        break;
                    //default is always evaluated last, when all else fail
                    default:
                        throw new InvalidOperationException("unknown item type");
                }
            }

            return sum;
        }
        [Fact]
        public void ShouldUseAdditionalPatternMatchingWithSwitch()
        {
            IEnumerable<object> rolls = new List<object>
            {
                5,
                new List<object> {3, 4},
                12
            };
            Assert.Equal(24, DiceSum2(rolls));
        }

    }
}
