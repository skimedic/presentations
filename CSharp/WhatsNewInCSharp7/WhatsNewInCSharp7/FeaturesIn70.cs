using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhatsNewInCSharp7
{
    //NOTE: Local functions are used for demonstation purposes, do not reflect best use cases for local functions
    public class FeaturesIn70
    {
        #region Local Functions

        public static IEnumerable<char> AlphabetSubset3(char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");

            return AlphabetSubsetImplementation();

            IEnumerable<char> AlphabetSubsetImplementation()
            {
                for (var c = start; c < end; c++)
                    yield return c;
            }
        }

        public Task<string> PerformLongRunningWork(string address, int index, string name)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException(message: "An address is required", paramName: nameof(address));
            if (index < 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(index),
                    message: "The index must be non-negative");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(message: "You must supply a name", paramName: nameof(name));

            return LongRunningWorkImplementation();

            async Task<string> LongRunningWorkImplementation()
            {
                var interimResult = await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    return address;
                });
                var secondResult = await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    return name;
                });
                return $"The results are {interimResult} and {secondResult}. Enjoy.";
            }
        }

        #endregion

        #region Tuples

        public void Tuples()
        {
            void SimpleTuples()
            {
                var letters = ("a", "b");
                var firstLetter = letters.Item1;
                var secondLetter = letters.Item2;
            }

            void NamedTuples()
            {
                //NOTE: Names only exist at compile time - are not accessible through reflection
                //Names can be declared on the left
                (string Alpha, string Beta) leftSideNamedTuple = ("a", "b");
                Console.WriteLine($"{leftSideNamedTuple.Alpha},{leftSideNamedTuple.Beta}");
                //or right side (must use var for this)
                var rightSideNamedTuple = (Alpha: "a", Beta: "b");
                Console.WriteLine($"{rightSideNamedTuple.Alpha},{rightSideNamedTuple.Beta}");
                //If declared on both, ignored on the right
                (string First, string Second) bothSideNamedTuple = (Alpha: "a", Beta: "b");
                Console.WriteLine($"{bothSideNamedTuple.First},{bothSideNamedTuple.Second}");
                //This doesn't compile
                //Console.WriteLine($"{bothSideNamedTuple.Alpha},{bothSideNamedTuple.Beta}");
            }

            void ValueAssignmentWithoutDeconstruction()
            {
                var p = new Point(3.14, 6.28);
                double horizontal = p.X;
                double vertical = p.Y;
                Console.WriteLine($"{horizontal}:{vertical}");
            }

            void Deconstruction()
            {
                var p = new Point(3.14, 6.28);
                //var doesn't need types defined
                var (horizontal, vertical) = p;
                //without var must have types defined
                (double horizontal1, double vertical2) = p;
                Console.WriteLine($"{horizontal}:{vertical}");
            }
        }

        private class Point
        {
            public Point(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            public double X { get; }
            public double Y { get; }

            public void Deconstruct(out double x, out double y)
            {
                x = this.X;
                y = this.Y;
            }
        }

        #endregion

        #region Out Variables

        public bool OutVariables()
        {
            //C# 6
            int oldResult;
            bool oldCanParse = int.TryParse("123", out oldResult);
            //C# 7.0
            bool canParse = int.TryParse("123", out int result);
            bool canParse2 = int.TryParse("123", out var result2);

            if (bool.TryParse("true", out var boolResult))
            {
                //Do something
            }

            return boolResult;
        }

        #endregion

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
            _ = OutVariables();

            void TupleDeconstruction()
            {
                var p = new Point(3.14, 6.28);
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
                _ = OutVariables();
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
            ref int GetArrayPosition(int[] array, int index)
            {
                return ref array[index];
            }
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