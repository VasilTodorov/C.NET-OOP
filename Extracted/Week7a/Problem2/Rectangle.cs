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

		#region Constructors 
		/// <summary>
		/// General purpose constructor
		/// </summary>
		/// <param name="upperLeftPoint"></param>
		/// <param name="lowerRightPoint"></param>
		public Rectangle(Point? upperLeftPoint, Point? lowerRightPoint)
			: base(upperLeftPoint!)
		{
			LowerRightPoint = lowerRightPoint!;
		}
		/// <summary>
		/// Default constructor
		/// </summary>
		public Rectangle() : this(new Point(), new Point())
		{

		}
		/// <summary>
		/// Copy constructor
		/// </summary>
		/// <param name="r"></param>
		public Rectangle(Rectangle r) : this(r.UpperLeftPoint, r.lowerRightPoint)
		{

		} 
		#endregion

		#region Properties 
		public Point LowerRightPoint
		{
			get { return new Point(lowerRightPoint!); }
			set
			{
				lowerRightPoint = value != null ?
								 new Point(value) : new Point();
			}
		}

		public double Length
		{
			get=> Math.Abs(base[0] - lowerRightPoint![0]);
        }
		public double Width
		{
			get => Math.Abs(base[1] - lowerRightPoint![1]);
        }
		public Point UpperLeftPoint
		{
			get => new Point(base.Coords);
			//set => base.Coords = value != null ?
			//	   new int[]{value[0], value[1]}: new int[2];   

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
        #endregion

		/// <summary>
		/// Compute area of this rectangle
		/// </summary>
		/// <returns></returns>
		public virtual double Area()
		{
			 
			return Width * Length;
		}

        public override string ToString()
        {
			return $"R:{base.ToString()}, {lowerRightPoint}";
        }

    }
}
