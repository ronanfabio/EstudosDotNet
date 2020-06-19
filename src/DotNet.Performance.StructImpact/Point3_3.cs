using System;

namespace DotNet.Performance.StructImpact
{
    public struct Point3_3 : IEquatable<Point3_3>
    {
        public double X;
        public double Y;
        public double Z;

        public bool Equals(Point3_3 obj) =>
            Math.Abs(X - obj.X) < 0.0001 &&
            Math.Abs(Y - obj.Z) < 0.0001 &&
            Math.Abs(Z - obj.Z) < 0.0001;
    }
}
