using System;

namespace WhatsNewInCSharp72.A_PerfImprovForValueTypes
{
    public class A_InKeywordDemos
    {
        //int is not a good candidate - in fact, performance might degrade

        internal void AllowModification(int i)
        {
            i = 5;
        }
        internal void DontAllowModification(in int i)
        {
            //Compilation error
            //i = 5;
        }
        public double CalculateDistance(in Point3D point1, in Point3D point2 = default)
        {
            double xDifference = point1.X - point2.X;
            double yDifference = point1.Y - point2.Y;
            double zDifference = point1.Z - point2.Z;

            return Math.Sqrt(xDifference * xDifference + yDifference * yDifference + zDifference * zDifference);
        }


    }
}