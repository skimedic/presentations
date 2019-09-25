namespace WhatsNewInCSharp71.B_DefaultLiterals
{
    public class DefaultLiteralDemos
    {
        public void ShouldApplyDefaultLiterals()
        {
            bool trueResult;
            trueResult = 0 == GetDefaultValue<int>();
            var defaultValue = GetDefaultValue<int?>();
            trueResult = false == defaultValue.HasValue;
            trueResult = null == defaultValue;

            trueResult = null == GetDefaultValue<string>();
            trueResult = false == GetDefaultValue<bool>();
            trueResult = '\0' == GetDefaultValue<char>();

            trueResult = MyEnum.DefaultValue == GetDefaultValue<MyEnum>();
            //Enum that doesn't have a zero value can't use this
            trueResult = MyOtherEnum.DefaultValue != GetDefaultValue<MyOtherEnum>();

            var defaultStruct = GetDefaultValue<MyStruct>();
            trueResult = 0 == defaultStruct.NumericValue;
            trueResult = null == defaultStruct.StringValue;
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

        public void DefaultLiterals<T>()
        {
            T t = default(T);
            var s = default(string);
            var d = default(dynamic);
            var i = default(int);
            var n = default(int?); // n is a Nullable int where HasValue is false.
        }
    }
}
