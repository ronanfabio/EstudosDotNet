using System;

namespace DotNet.Performance.StructImpact
{
    public struct Point3_1
    {
        public double X;
        public double Y;
        public double Z;

        // public override bool Equals(object obj)
        // {
        //     if (!(obj is Point3 other))
        //     {
        //         return false;
        //     }

        //     return
        //         Math.Abs(X - other.X) < 0.0001 &&
        //         Math.Abs(Y - other.Z) < 0.0001 &&
        //         Math.Abs(Z - other.Z) < 0.0001;
        // }
    }
}
