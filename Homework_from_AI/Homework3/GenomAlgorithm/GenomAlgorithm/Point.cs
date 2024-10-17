using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenomAlgorithm
{
    public class Point
    {
        private double[]? coords;

        #region Property
        /// <summary>
        /// index: snipet
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double this[int index]
        {
            get => index >= 0 && index < 2 ? coords![index] : 0;
            set => coords![index] = index >= 0 && index < 2 ? value : 0;
        }
        public double[] Coords
        {
            get { return new double[] { coords![0], coords![1] }; }
            set
            {
                coords = value != null && value.Length == 2 ?
                                            value : new double[2];
            }
        }

        #endregion

        #region Constructor
        public Point(double[]? coords)
        {
            Coords = coords!;
        }

        public Point() : this(new double[2])
        {

        }

        public Point(Point point) : this(point.coords)
        {

        }
        #endregion

        public double DistanceTo(Point point)
        {
            return Math.Sqrt((coords![0] - point.coords![0]) * (coords[0] - point.coords[0]) +
                            (coords[1] - point.coords[1]) * (coords[1] - point.coords[1]));
        }

        //public override bool Equals(object? obj)
        //{
        //    if (obj == null) return false;
        //    var o = (Point)obj;
        //    return o.coords![0] == coords![0] && o.coords![1] == coords![1];
            
        //}

        public override string ToString()
        {
            return string.Format("[{0:F2},{1:F2}]", coords![0], coords![1]);
        }

    }

    public class PointInPath : Point 
    {
        public int Index { get; set; }

        public PointInPath(double[]? coords, int index) : base(coords) 
        { Index = index; }
        public PointInPath() : this(new double[2],-1)
        {}

        public PointInPath(PointInPath p) : this(p.Coords, p.Index) 
        {}

        public PointInPath(Point p, int index) : this(p.Coords, index)
        { }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            var o = (PointInPath)obj;
            return o.Index == Index ;

        }
        public override string ToString()
        {
            return base.ToString() + ": " + Index;
        }
    }
}
