using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static GreaterThan GreaterThan
        {
            get
            {
                return GetSizeOf;
            }
        }

        /// <summary>
        /// Multiply triangle by scalar
        /// </summary>
        /// <param name="a"></param>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public static Triangle operator *(Triangle a, double scalar)
        {

            // vector product
            var aSide = a.sideA * scalar;
            var bSide = a.sideB * scalar;

            return new Triangle(aSide, bSide);
        }

        public override string ToString()
            => $"Triangle: Side   a:{sideA}, Side b: {sideB}\nArea= {((Comparable)this).SizeOf():F2}";

        double Comparable.SizeOf()
        {
            var vp = sideA * sideB;  // find vector product a x b
             
            return ((Comparable)vp).SizeOf() / 2;  // |a x b|/2

        }
    }
}
