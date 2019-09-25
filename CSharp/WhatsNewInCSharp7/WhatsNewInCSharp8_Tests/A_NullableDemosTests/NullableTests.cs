using System;
using System.Collections.Generic;
using System.Text;
using WhatsNewInCSharp8.A_NullableDemos;
using Xunit;

namespace WhatsNewInCSharp8_Tests.A_NullableDemosTests
{
    public class NullableTests
    {
        private NullableTypesDemo _mainSut;

        public NullableTests()
        {
            _mainSut = new NullableTypesDemo();
        }

        [Fact]
        public void ShouldProperlyHandleNullableAndNullableInAConstructor()
        {
            var foo = new NullableTypesDemo();
        }
        [Fact]
        public void ShouldHandleNullReferenceTypesWhenNull()
        {
            string? sut = null;
            //Use the null coalescing operator
            Assert.Equal('?',sut?[0] ?? '?');
        }

        [Fact]
        public void ShouldHandleNullReferenceTypesWhenNotNull()
        {
            string? sut = "Hello";
            //Use the null forgiving operator if you know the variable is not null
            Assert.Equal(5, sut!.Length);
            //Use the null coalescing operator
            Assert.Equal('H', sut?[0] ?? '?');
        }

        [Fact]
        public void ShouldAllowNullInput()
        {
            _mainSut.ScreenName = null;
            Assert.Equal("Foo", _mainSut.ScreenName);
        }

        /*
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

        public bool TryGetMessage(string key, [NotNullWhen(true)] out string? message)
        {
            if (key.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                message = key;
                return true;
            }

            message = null;
            return false;
        }
        public bool TryGetMessage2(string key, [MaybeNullWhen(true)] out string? message)
        {
            if (key.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                message = null;
                return true;
            }

            message = null;
            return false;
        }

         */
    }
}
