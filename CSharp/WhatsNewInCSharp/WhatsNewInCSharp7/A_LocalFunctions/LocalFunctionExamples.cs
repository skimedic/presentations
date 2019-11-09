using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhatsNewInCSharp7.A_LocalFunctions
{
    public class LocalFunctionExamples
    {
        //Encapsulation
        public decimal GetWeightForHolloBar(decimal outerDiameter, decimal innerDiameter, decimal length)
        {
            return Math.Round(GetWeight(outerDiameter / 2) - GetWeight(innerDiameter / 2),2);

            decimal GetWeight(decimal radius)
            {
                return (decimal)(Math.Pow((double)(radius), 2) * 
                                 (double)length * 
                                 (double).2833 * Math.PI);
            }
        }


        //Iterator
        public IEnumerable<char> AlphabetSubset3OldWay(char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");

            //for (var c = start; c < end; c++)
            //    yield return c;
                for (var c = start; c < end; c++)
                    yield return c;
        }

        public IEnumerable<char> AlphabetSubset3(char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");
            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");

            //for (var c = start; c < end; c++)
            //    yield return c;
            return AlphabetSubsetImplementation();
            IEnumerable<char> AlphabetSubsetImplementation()
            {
                for (var c = start; c < end; c++)
                    yield return c;
            }
        }

        //Async
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
    }
}
