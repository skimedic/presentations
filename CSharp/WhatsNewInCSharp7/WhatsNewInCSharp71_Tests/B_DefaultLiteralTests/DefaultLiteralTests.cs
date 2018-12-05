using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WhatsNewInCSharp71_Tests.B_DefaultLiteralTests
{
    public class DefaultLiteralTests
    {
        [Fact]
        public void ShouldApplyDefaultLiterals()
        {
            Assert.Equal(0,GetDefaultValue<int>());
            var defaultValue = GetDefaultValue<int?>();
            Assert.False(defaultValue.HasValue);
            Assert.Null(defaultValue);

            Assert.Null(GetDefaultValue<string>());
            Assert.False(GetDefaultValue<bool>());
            Assert.Equal('\0',GetDefaultValue<char>());

            Assert.Equal(MyEnum.DefaultValue,GetDefaultValue<MyEnum>());
            //Enum that doesn't have a zero value can't use this
            Assert.NotEqual(MyOtherEnum.DefaultValue,GetDefaultValue<MyOtherEnum>());

            var defaultStruct = GetDefaultValue<MyStruct>();
            Assert.Equal(0,defaultStruct.NumericValue);
            Assert.Null(defaultStruct.StringValue);
        }

        internal T GetDefaultValue<T>()
        {
            return default;
        }

        internal enum MyEnum
        {
            DefaultValue = 0,
            FirstValue = 1
        }
        internal enum MyOtherEnum
        {
            DefaultValue = 1,
            FirstValue = 2
        }

        internal struct MyStruct
        {
            public int NumericValue { get; set; }
            public string StringValue { get; set; }
        }
    }
}
