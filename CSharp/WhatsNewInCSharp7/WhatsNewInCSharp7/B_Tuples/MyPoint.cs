using System;

namespace WhatsNewInCSharp7.B_Tuples
{
    public class MyPoint
    {
        public MyPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public void Deconstruct(out double x, out double y)
        {
            x = this.X;
            y = this.Y;
        }
    }
}
