namespace WhatsNewInCSharp72.A_PerfImprovForValueTypes
{
    public class B_RefReadOnlyDemos
    {
        public void RefsLocalsAndReturnsEnclosedExample()
        {
            var position = 3;
            int[] a = new[] { 1, 2, 3, 4, 5 };
            ref readonly int item = ref GetArrayPosition(a, position);
            //Compile error
            //item = 5;

            ref int GetArrayPosition(int[] array, int index) => ref array[index];
        }

    }
}