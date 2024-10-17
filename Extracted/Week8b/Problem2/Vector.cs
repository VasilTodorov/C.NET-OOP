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
            $"Vector: S[{startPoint}], E[{endPoint}]\nLength = {((Comparable)this).SizeOf():F2}\n";
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

        public static Vector operator +(Vector a, Vector b)
        {
            var start = a.startPoint;
            var end = new Point(a.startPoint.X + b.startPoint.X,
                   a.startPoint.Y + b.startPoint.Y,
                   a.startPoint.Z + b.startPoint.Z);
            return new Vector(start, end);
        }
        /// <summary>
        /// Vector product
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator *(Vector a, Vector b)
        {
            // translate vectors to Oxyz
            var sx = a.endPoint.X - a.startPoint.X;
            var sy = a.endPoint.Y - a.startPoint.Y;
            var sz = a.endPoint.Z - a.startPoint.Z;
            var ex = b.endPoint.X - b.startPoint.X;
            var ey = b.endPoint.Y - b.startPoint.Y;
            var ez = b.endPoint.Z - b.startPoint.Z;
            // vector product
            var x = sy * ez - sz * ey;
            var y = -(sx * ez - sz * ex);
            var z = sx * ey - sy * ex;
            return new Vector(new Point(), new Point(x, y, z));
        }
        /// <summary>
        /// Multiple vector by scalar
        /// </summary>
        /// <param name="a"></param>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public static Vector operator *(Vector a, double scalar)
        {

            // vector product
            var x = a.endPoint.X * scalar;
            var y = a.endPoint.Y * scalar;
            var z = a.endPoint.Z * scalar;
            return new Vector(a.startPoint, new Point(x, y, z));
        }
        /// <summary>
        /// Return the length of Vector
        /// </summary>
        /// <returns></returns>
        double Comparable.SizeOf()
        {
            var dx = startPoint.X - endPoint.X;
            var dy = startPoint.Y - endPoint.Y;
            var dz = startPoint.Z - endPoint.Z;
            return Math.Sqrt(dx * dx + dy * dy + dz *dz);
        }

    }
}