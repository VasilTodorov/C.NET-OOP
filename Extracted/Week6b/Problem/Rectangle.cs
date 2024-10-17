using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{

    public delegate double CompareBy(Rectangle r);

    /// <summary>
    /// Rectangle class
    /// </summary>
    public class Rectangle
    {
        #region Data members
        private double length;
        private double width;
        private Point? leftLowerPoint;

        public readonly string R_ID;
        private static int cnt = 1;
        // codes for idexation
        private char[] codes = { 'x', 'y', 'w', 'h' }; 
        #endregion

        #region Constructors 
        /// <summary>
        /// Canonical constructor
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="leftLowerPoint"></param>
        public Rectangle(double length,
                         double width,
                         Point leftLowerPoint)
        {
            Length = length;
            Width = width;
            LeftLowerPoint = leftLowerPoint;
            // unique ID for each Rectangle object
            R_ID = string.Format("{0:D06}", cnt++);
        }
        /// <summary>
        /// Default constgructor
        /// </summary>
        public Rectangle() : this(0, 0, new Point())
        {

        }
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="r"></param>
        public Rectangle(Rectangle r)
            : this(r.length, r.width, r.leftLowerPoint!)
        {

        }
        #endregion

        #region Properties 
        public Point LeftLowerPoint
        {
            get { return new Point(leftLowerPoint!); }
            set
            {
                if (value != null)
                {
                    leftLowerPoint = new Point(value);
                }
                else
                {
                    leftLowerPoint = new Point();
                }
            }
        }

        public double Width
        {
            get { return width; }
            set { width = value >= 0 ? value : 0; }
        }

        public double Length
        {
            get { return length; }
            set { length = value >= 0 ? value : 0; }
        }

        public double this[char index]
        {
            get
            { /* return the specified index here */

                return index switch
                {
                    'x' => leftLowerPoint!.Coords[0],
                    'y' => leftLowerPoint!.Coords[1],
                    'w' => width,
                    'h' => length,
                    _ => double.MinValue,
                };
            }
            set
            { /* set the specified index to value here */
                if (index > 0 && codes.Contains(index))
                {
                    switch (index)
                    {
                        case 'x':
                            leftLowerPoint!.Coords[0] = (int)value; break;
                        case 'y':
                            leftLowerPoint!.Coords[1] = (int)value; break;
                        case 'w':
                            Width = value; break;
                        case 'h':
                            Length = value; break;
                        default:
                            break;
                    }
                }
            }
        }
        #endregion

        #region Utility methods 
        /// <summary>
        /// Computre area of Rectangle
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static double Area(Rectangle rectangle)
        {
            return rectangle.width * rectangle.length;
        }

        /// <summary>
        /// Computes the diagonal of rectangle
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static double Diagonal(Rectangle r)
        {
            return Math.Sqrt(r.width * r.width + r.length * r.length);

        }
        /// <summary>
        /// Sort a List<Rectangle> by ComprareBy delegate
        /// </Rectangle>
        /// </summary>
        /// <param name="list">list of rectangles</param>
        /// <param name="compareBy"> delegate</param>
        /// <returns></returns>
        public static IEnumerable<Rectangle> SortBy(List<Rectangle> list, CompareBy compareBy)
        {
            // sort by descending
            var sorted = list.OrderByDescending(rectangle => compareBy(rectangle));
            return sorted;
        }
        #endregion

        public override string ToString()
    => $"{R_ID}: width={width}, length={length}\n" +
        $"LeftPoint={leftLowerPoint}\n";
    }
}
