using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsNewInCSharp72
{
    public class FeaturesIn72
    {
        #region Reference Semantics and Value Types

        private class Point3D
        {
            public double X { get;set; }
            public double Y { get;set; }
            public double Z { get;set; }
        }

        #region The in Keyword
        private static double CalculateDistance(in Point3D point1, in Point3D point2 = default)
        {
            double xDifference = point1.X - point2.X;
            double yDifference = point1.Y - point2.Y;
            double zDifference = point1.Z - point2.Z;

            return Math.Sqrt(xDifference * xDifference + yDifference * yDifference + zDifference * zDifference);
        }

        public void TheInKeyWord()
        {
            var pt1 = new Point3D {X=12, Y=14, Z=16};
            var pt2 = new Point3D {X=8, Y=6, Z=4};
            var distance0 = CalculateDistance(pt1, pt2);
            var distance1 = CalculateDistance(in pt1, in pt2);
            var distance2 = CalculateDistance(in pt1, new Point3D());
        }


        #endregion        #endregion
        #region Ref readonly Return
        public void RefsReadOnlyReturn()
        {
            var position = 3;
            int[] a = new[] { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Original value: {a[position]}");
            ref readonly int item = ref GetArrayPosition(a, position);
            Console.WriteLine($"Retrieved value: {item}");
            //Compile time error
            //item = 5;
            ref int GetArrayPosition(int[] array, int index)
            {
                return ref array[index];
            }
        }
        #endregion
        #region readonly struct
        public readonly struct ReadonlyPoint3D
        {
            public ReadonlyPoint3D(double x, double y, double z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }
            public double X { get; }
            public double Y { get; }
            public double Z { get; }

            private static readonly ReadonlyPoint3D origin = new ReadonlyPoint3D();
            public static ref readonly ReadonlyPoint3D Origin => ref origin;
        }
        #endregion 
        #region Readonly Ref Struct
        readonly ref struct ReadOnlyRefPoint2D
        {
            public int X { get; }
            public int Y { get; }
            public ReadOnlyRefPoint2D(int x, int y) => (X, Y) = (x, y);
        }
        #endregion
        #endregion

        #region Numeric Literal Improvements
        public const int Sixteen = 0b_0001_0000;
        public const int ThirtyTwo = 0b_0010_0000;
        public const int SixtyFour = 0b_0100_0000;
        public const int OneHundredTwentyEight = 0b_1000_0000;
        #endregion

    }
}
