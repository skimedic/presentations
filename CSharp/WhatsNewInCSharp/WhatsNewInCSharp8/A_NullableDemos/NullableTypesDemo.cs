using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace WhatsNewInCSharp8.A_NullableDemos
{
//#nullable disable
//#nullable enable
    public class NullableTypesDemo
    {
        private MySampleType? _sampleNullable;
        private MySampleType _sampleNonNullable;

        public NullableTypesDemo()
        {
            _sampleNonNullable = new MySampleType();
            _sampleNullable = null;
            // Cannot convert null literal to non-nullable reference type CS 8625
            //_sampleNonNullable = null;
            if (_sampleNullable!=null)
            {
                //HasValue and Value aren't supported yet
                //var foo = _sampleNullable.Value;
            }
        }

        //Allow null for setter, returns default value
        private string _screenName = GenerateRandomScreenName();
        [AllowNull]
        public string ScreenName
        {
            get => _screenName;
            set => _screenName = value ?? GenerateRandomScreenName();
        }
        public static string GenerateRandomScreenName() => "Foo";

        [DisallowNull]
        public string? ReviewComment
        {
            get => _comment;
            set => _comment = value ?? throw new ArgumentNullException(nameof(value), "Cannot set to null");
        }
        string? _comment;

        [return: MaybeNull]
        public T Find<T>(IEnumerable<T> sequence, Func<T, bool> match)
        {
            var list = sequence.ToList();
            if (list.Count == 0)
            {
                return default;
            }
            else
            {
                return list[0];
            }
        }

        public void EnforceNotNullInCall<T>([NotNull] ref T[]? inputList)
        {

        }

        public bool TryGetMessage(string key, 
            [NotNullWhen(true)] out string? message)
        {
            if (key.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                message = key;
                return true;
            }

            message = null;
            return false;
        }
        public bool TryGetMessage2(string key, 
            [MaybeNullWhen(true)] out string? message)
        {
            if (key.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                message = null;
                return true;
            }

            message = null;
            return false;
        }
        public void MyMethod(string? s)
        {
            //Use the null coalescing operator
            Console.WriteLine(s ?? "?");
            // Warning: Dereference of a possible null reference CS8602
            //Console.WriteLine(s.Length);
            //Use the null forgiving operator
            Console.WriteLine(s!.Length);
        }
    }
}
