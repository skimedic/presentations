namespace WhatsNewInCSharp72.B_NumericLiterals
{
    public class ConditionalRefExpressionDemo
    {
        public ref int GetArrayValue(int[] arr, int[] otherArr)
        {
            return ref (arr != null ? ref arr[0] : ref otherArr[0]);
        }
    }
}