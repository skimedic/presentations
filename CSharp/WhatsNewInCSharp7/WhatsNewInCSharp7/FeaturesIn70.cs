using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhatsNewInCSharp7.B_Tuples;
using WhatsNewInCSharp7.C_OutVariables;

namespace WhatsNewInCSharp7
{
    //NOTE: Local functions are used here for demonstration purposes,
    //and do not reflect best use cases for local functions.
    public class FeaturesIn70
    {


        #region Pattern Matching

        public void PatternMatching()
        {
            int DiceSum(IEnumerable<object> values)
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

            int DiceSum2(IEnumerable<object> values)
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

        #endregion

        #region Discards
        public void Discards()
        {
            //Out parameters
            bool canParse = int.TryParse("123", out _);
            //Stand alone discard
            _ = new OutVariableExamples().OutVariables();

            void TupleDeconstruction()
            {
                var p = new MyPoint(3.14, 6.28);
                //same var/non var rules apply
                (double horizontal, _) = p;
                //var (horizontal, _) = p;
                Console.WriteLine($"{horizontal}");
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
                //_ = OutVariables();
                var _ = "foo";
            }

            void Watchout2()
            {
                var _ = "Foo";
                //Compiler error - invalid type conversion
                //_ = OutVariables();
            }

            void Watchout3()
            {
                var _ = true;
                //No compiler error, but uninteded consequence
                _ = new OutVariableExamples().OutVariables();
            }
        }

        #endregion

        #region Ref Locals and Returns
        public void RefsLocalsAndReturns()
        {
            var position = 3;
            int[] a = new[] {1, 2, 3, 4, 5};
            Console.WriteLine($"Original value: {a[position]}");
            ref int item = ref GetArrayPosition(a,position);
            Console.WriteLine($"Retrieved value: {item}");
            item = 5;
            Console.WriteLine($"Updated value: {a[position]}");
            ref int GetArrayPosition(int[] array, int index) => ref array[index];
        }
        #endregion

        #region Throw Expressions
        public class ThrowExpressions
        {
            private string _name;
            public string Name
            {
                get => _name;
                set => _name = value ?? throw new ArgumentNullException("Oops");
            }
        }
        #endregion

        #region Generalized async return types

        public async ValueTask<int> GeneralAsyncReturnTypes()
        {
            await Task.Delay(100);
            return 5;
        }
        #endregion

        #region Numeric Literal Improvements
        public const int Sixteen = 0b0001_0000;
        public const int ThirtyTwo = 0b0010_0000;
        public const int SixtyFour = 0b0100_0000;
        public const int OneHundredTwentyEight = 0b1000_0000;
        public const long BillionsAndBillions = 100_000_000_000;
        public const double AvogadroConstant = 6.022_140_857_747_474e23;
        public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;
        #endregion
    }
}