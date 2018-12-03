namespace WhatsNewInCSharp72
{
    public class D_RefStructureType
    {
        readonly ref struct ReadOnlyRefPoint2D
        {
            public int X { get; }
            public int Y { get; }
            public ReadOnlyRefPoint2D(int x, int y) => (X, Y) = (x, y);
        }

    }
}