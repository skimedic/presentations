namespace WhatsNewInCSharp8.C_StaticLocalFunctions
{
    public class StaticLocals
    {
        int M()
        {
            int y = 5;
            int x = 7;
            return Add(x, y);

            static int Add(int left, int right)
            {
                //x = 12; Compiler 
                return left + right;
            }
        }
        int MOld()
        {
            int y = 5;
            int x = 7;
            return Add();

            int Add()
            {
                x = 2;
                return x + y;
            }
        }
    }
}
