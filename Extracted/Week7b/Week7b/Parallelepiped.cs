using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class Parallelepiped : Rectangle
    {
		private int hight;
        //reference type can be null, but value type cant
        //so we must check for null

        #region Constructor
        public Parallelepiped(int hight, Rectangle rectangle)
            : base(rectangle)
        {
            Hight = hight;
        }

        public Parallelepiped() : this(0, new Rectangle())
        {

        }

        public Parallelepiped(Parallelepiped p) : this(p.Hight, p.BaseSide)
        {

        } 
        #endregion
        #region Properties
        public int Hight
        {
            get { return hight; }
            set { hight = value >= 0 ? value : 0; }
        }

        public Rectangle BaseSide
        {
            get => new Rectangle(base.UperLeftPoint, base.LowerRightPoint);
            set
            {
                if (value != null)
                {
                    base.UperLeftPoint = new Point(value.Coords);
                    base.LowerRightPoint = new Point(value.LowerRightPoint);
                }
                else
                {
                    base.UperLeftPoint = new Point();
                    base.LowerRightPoint = new Point();
                }
            }
        }
        #endregion

        public override double Area()
        => 2 * (base.Area() + hight*Length + hight*Width);

        public override string ToString()
        => $"p: Hight= {hight}, BaseSide= {base.ToString()} ";
    }
}
