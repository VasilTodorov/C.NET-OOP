using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public struct Vector : Comparable
    {
        public Point startPoint;
        public Point endPoint;
        public Vector(Point s, Point e)
        {
            startPoint = s;
            endPoint = e;
        }

        public override string ToString() =>
            $"Vector: S[{startPoint}], E[{endPoint}]";
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

        public static Vector operator +(Vector a, Vector b)
        {
            var start = a.startPoint;
            var end = new Point(a.startPoint.X + b.startPoint.X,
                   a.startPoint.Y + b.startPoint.Y,
                   a.startPoint.Z + b.startPoint.Z);
            return new Vector(start, end);
        }

        /// <summary>
        /// Return the length of Vector
        /// </summary>
        /// <returns></returns>
        double Comparable.SizeOf()
        {
            var dx = startPoint.X - endPoint.X;
            var dy = startPoint.Y - endPoint.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}