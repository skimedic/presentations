using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhatsNewInCSharp7.B_Tuples;
using WhatsNewInCSharp7.C_OutVariables;

namespace WhatsNewInCSharp7.E_Discards
{
    public class DiscardExamples
    {
        public int DoSomething()
        {
            return 5;
        }
        public void Discards()
        {
            //Out parameters
            bool canParse = int.TryParse("123", out _);

            //Stand alone discard
            _ = DoSomething();

            void TupleDeconstruction()
            {
                var p = new MyPoint(3.14, 6.28);
                //same var/non var rules apply
                (double horizontal, _) = p;
                //var (horizontal, _) = p;
            }

            int DiscardsWithPatternMatching(IEnumerable<object> values)
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
                            sum += DiscardsWithPatternMatching(subList);
                            break;
                        case IEnumerable<object> subList:
                            break;
                        case string _:
                            break;
                        case null:
                            break;
                        default:
                            throw new InvalidOperationException("unknown item type");
                    }
                }

                return sum;
            }
            void Watchout1()
            {
                //Compiler error - using before declaring
                //When used as a discard, _ is write only, can't be read
                //_ = DoSomething();
                var _ = "foo";
            }

            void Watchout2()
            {
                var _ = "Foo";
                //When used as a variable name, it's type is already set, and can't be used as a discard for a different data type
                //Compiler error - invalid type conversion
                //_ = OutVariables();
            }

            void Watchout3()
            {
                var _ = true;
                //No compiler error, but unintended consequence
                _ = new OutVariableExamples().OutVariables();
            }
        }
    }
}
