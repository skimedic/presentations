using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsNewInCSharp7.F_RefLocalsAndReturns
{
    public class RefLocalsAndReturnsDemos
    {
        public ref int GetPositionInArray(int[] intArray,int position)
        {
            return ref intArray[position];
        }
        public void RefsLocalsAndReturnsEnclosedExample()
        {
            var position = 3;
            int[] a = new[] { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Original value: {a[position]}");
            ref int item = ref GetArrayPosition(a, position);
            Console.WriteLine($"Retrieved value: {item}");
            item = 5;
            Console.WriteLine($"Updated value: {a[position]}");
            ref int GetArrayPosition(int[] array, int index) => ref array[index];
        }

    }
}
