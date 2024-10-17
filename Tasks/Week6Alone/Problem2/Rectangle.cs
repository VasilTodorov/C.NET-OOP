using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class Rectangle
    {
        private Point[]? points;

        #region Constructors
        public Rectangle(Point[] points)
        {
            Points = points;
        }
        public Rectangle() : this(new Point[2])
        {

        }
        public Rectangle(Rectangle r) : this(r.points!)
        {

        }
        #endregion
        #region Properties
        public Point[] Points
        {
            get
            {
                return new Point[] { new Point(points![0]), new Point(points[1]) };
            }
            set
            {
                if (value != null && value.Length == 2 &&
                    value[0] != null && value[1] != null &&
                    value[0]['x'] <= value[1]['x'] && value[0]['y'] >= value[1]['y'])
                {
                    points = new Point[] { new Point(value[0]), new Point(value[1]) };
                }
                else
                {
                    points = new Point[] { new Point(), new Point()};
                }
            }
        }
        #endregion

        public double Parameter()
        {
            int width = Math.Abs(points![1]['x'] - points[0]['x']);
            int hight = Math.Abs(points[1]['y'] - points[0]['y']);

            return width * 2 + hight * 2;
        }

        public override string ToString()
        {
            return $"Rectangle: \n" +
                $"UpperLeftCorner: {points![0].ToString()}\n" +
                $"LowerRightCorner: {points[1].ToString()}";
        }
    }
}
