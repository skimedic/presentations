using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatsNewInCSharp7.D_PatternMatching
{
    public class PatternMatchingExamples
    {
        public int DiceSum(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                if (item is int val)
                    sum += val;
                else if (item is IEnumerable<object> subList)
                    sum += DiceSum(subList);
            }

            return sum;
        }

        public int DiceSum2(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                switch (item)
                {
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
                    default:
                        throw new InvalidOperationException("unknown item type");
                }
            }

            return sum;
        }

    }
}
