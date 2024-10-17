using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public struct Triangle : Comparable
    {
        public Vector sideA;
        public Vector sideB;

        public Triangle(Vector a, Vector b)
        {
            sideA = a;
            sideB = b;
        }

        private static bool GetSizeOf(Comparable obj1, Comparable obj2)
        {
            return obj1.SizeOf() > obj2.SizeOf();
        }

 

        public static GreaterThan GetGreaterThan
        {
            get
            {
                return GetSizeOf;
            }
        }
        public override string ToString()
            => $"Triangle: Side   a:{sideA}, Side b: {sideB}";

        double Comparable.SizeOf()
        {

            var sc = sideA.startPoint.X * sideB.startPoint.X +
                     sideA.startPoint.Y * sideB.startPoint.Y +
                     sideA.startPoint.Z * sideB.startPoint.Z;
            var lengths = ((Comparable)sideB).SizeOf() * ((Comparable)sideA).SizeOf();
            double cosA = sc / lengths;
            double sinA = Math.Sqrt (1 - cosA * cosA);

            return sinA * lengths / 2.0;

        }
    }
}
