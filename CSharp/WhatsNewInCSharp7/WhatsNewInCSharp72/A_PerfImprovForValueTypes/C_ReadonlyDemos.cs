namespace WhatsNewInCSharp72.A_PerfImprovForValueTypes
{
    public class C_ReadonlyDemos
    {
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

    }
}