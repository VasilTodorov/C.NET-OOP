using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public delegate  bool GreaterThan(Comparable obj1, Comparable obj2);

    public struct Point :Comparable
    {
        

        public double X { get; set; }
        public double Y { get; set; }

        public double Z { get; set; }

        public Point(double x, double y, double z  )
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Point()
        {
            X = 0;
            Y = 0;
            Z = 0; 
        }

        #region Properties
        public double this[string index]
        {
            get
            { /* return the specified index here */
                if (index == "x" || index == "y" || index == "z")
                {
                    return index switch
                    {
                        "x" => X,
                        "y" => Y,
                        "z" => Z,
                        _ => double.MinValue
                    };

                }
                return double.MinValue;
            }
            set
            { /* set the specified index to value here */
                if (index == "x" || index == "y" || index == "z")
                {
                    X = value;
                    Y = value;
                    Z = value;
                }
            }
        } 
        #endregion

        #region Override Equals
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj == null) return false;
            if (obj!.GetType() != GetType()) return false;
            return ((Point)obj).X == X && ((Point)obj).Y == Y && ((Point)obj).Z == Z;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public static bool operator ==(Point a, Point b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }
        #endregion

        private static bool GetSizeOf(Comparable obj1, Comparable obj2)
        {
          return   obj1.SizeOf() > obj2.SizeOf();
        }
         
        public static GreaterThan GetGreaterThan
        {
            get
            {
                return GetSizeOf;
            }
        }
        public override string ToString()
            => $"[{X:F2}, {Y:F2}, {Z:F2}";
        //=> string.Join(", ", X, Y, Z);

        double Comparable.SizeOf()
        {
            return Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
        }

        
    }

}
 
