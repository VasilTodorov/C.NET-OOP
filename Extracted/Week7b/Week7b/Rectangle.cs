using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class Rectangle : Point
    {
        private Point? lowerRightPoint;
        //protected string data;

        #region Constructors
        public Rectangle(Point? uperLeftPoint, Point? lowerRightPoint)
            : base(uperLeftPoint!)
        {
            LowerRightPoint = lowerRightPoint!;
        }

        public Rectangle() : this(new Point(), new Point())
        {

        }
        public Rectangle(Rectangle r) : this(r.LowerRightPoint, r.UperLeftPoint)
        {

        }
        #endregion

        #region Properties
        public Point LowerRightPoint
        {
            get { return new Point(lowerRightPoint!); }
            set { lowerRightPoint = value != null ? new Point(value) : new Point(); }
        }

        public Point UperLeftPoint
        {
            get => new Point(base.Coords);
            //set => base.Coords = value!=null?
            //					new int[] { value[0], value[1] } : new int[2];
            set
            {
                if (value != null)
                {
                    base[0] = value[0];
                    base[1] = value[1];
                }
                else
                {
                    base[0] = 0;
                    base[1] = 0;
                }
            }
        }

        public double Length
        { get { return Math.Abs(base[1] - lowerRightPoint![1]); } }
        /// <summary>
        /// returns the width of rectangle
        /// </summary>
        public double Width
        { get { return Math.Abs(base[0] - lowerRightPoint![0]); } }
        #endregion

        public virtual double Area()
        {


            return Width * Length;
        }
        public override string ToString()
        //{
        //    return $"R:{Width}, {Length}";
        //}
        => $"R: UpperLeftPoint= {base.ToString()},\n" +
           $"   LowerRightpoint= {LowerRightPoint}";

        //static void Main()
        //{
        //    Rectangle rect = new Rectangle();
        //    Point point1 = rect;
        //    rect.data = "alala";
        //    point1 = rect;

        //    //point1.data = "SA";

        //    //protected is accesible in only the class or derived classes ONLY!
        //    //difference between java
        //}
    }
}
