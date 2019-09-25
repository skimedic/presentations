namespace WhatsNewInCSharp73.A_MoreEfficientSafeCode
{
    public class B_ReassignRefLocalVariables
    {
        public ref int GetPositionInArray(int[] intArray, int position)
        {
            return ref intArray[position];
        }
        public void RefsLocalsAndReturnsEnclosedExample()
        {
            var position = 3;
            int[] a = new[] { 1, 2, 3, 4, 5 };
            ref int item = ref GetArrayPosition(a, position);
            item = 5;

            int[] b = new[] {2, 4, 6, 8, 10};
            item = ref GetArrayPosition(b, position);
            //item = 8
            ref int GetArrayPosition(int[] array, int index) => ref array[index];
        }

    }
}