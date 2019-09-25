namespace WhatsNewInCSharp8.C_StaticLocalFunctions
{
    public class StaticLocals
    {
        int M()
        {
            int y = 5;
            int x = 7;
            return Add(x, y);

            static int Add(int left, int right) => left + right;
        }
    }
}
