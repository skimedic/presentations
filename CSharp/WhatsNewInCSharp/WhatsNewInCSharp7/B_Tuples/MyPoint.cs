using System;

namespace WhatsNewInCSharp7.B_Tuples
{
    public class MyPoint
    {
        public MyPoint(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public void Deconstruct(out double x, out double y, out double z)
        {
            x = this.X;
            y = this.Y;
            z = this.Z;
        }
    }
}
