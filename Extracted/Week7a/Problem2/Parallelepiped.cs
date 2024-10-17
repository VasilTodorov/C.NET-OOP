using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class Parallelepiped : Rectangle
    {
        private double height;

        #region Constructors
        public Parallelepiped(double height, Rectangle rectangle)
    : base(rectangle)
        {
            Height = height;
        }

        public Parallelepiped() : this(0, new Rectangle())
        {

        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="p"></param>
        public Parallelepiped(Parallelepiped p)
            : this(p.height, p.BaseSide) { }


        #endregion

        #region Properties

        public double Height

        {
            get { return height; }
            set { height = value >= 0 ? value : 0; }
        }

        public Rectangle BaseSide
        {

            get => new Rectangle(base.UpperLeftPoint, base.LowerRightPoint);
            set
            {
                if (value != null)
                {
                    base.UpperLeftPoint = new Point(value.Coords);
                    base.LowerRightPoint = new Point(value.LowerRightPoint);
                }
                else
                {
                    base.UpperLeftPoint = new Point();
                    base.LowerRightPoint = new Point();
                }
            }
            
        }
        #endregion

        public override double Area() 
          => 2*( base.Area()  +  (height * Width) + (height * Length ));


        public override string ToString()
        {
            return $"P:Height= {Height}\nBase={base.ToString()}";
        }
    }
}
