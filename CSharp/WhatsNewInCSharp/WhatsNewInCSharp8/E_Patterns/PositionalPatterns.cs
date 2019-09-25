namespace WhatsNewInCSharp8.E_Patterns
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) => (X, Y) = (x, y);

        public void Deconstruct(out int x, out int y) =>
            (x, y) = (X, Y);
    }
    public enum Quadrant
    {
        Unknown,
        Origin,
        One,
        Two,
        Three,
        Four,
        OnBorder
    }

    public class PositionalPatterns
    {

    }
}