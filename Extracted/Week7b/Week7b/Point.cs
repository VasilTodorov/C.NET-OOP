using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class Point
    {
        private int[]? coords;

        #region Property
        /// <summary>
        /// index: snipet
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int this[int index]
        {
            get => index >= 0 && index < 2 ? coords![index] : 0;
            set => coords![index] = index >= 0 && index < 2 ? value : 0;
        }
        public int[] Coords
        {
            get { return new int[] { coords![0], coords![1] }; }
            set
            {
                coords = value != null && value.Length == 2 ?
                                            value : new int[2];
            }
        }
        #endregion

        #region Constructor
        public Point(int[]? coords)
        {
            Coords = coords!;
        }

        public Point() : this(new int[2])
        {

        }

        public Point(Point point) : this(point.coords)
        {

        }
        #endregion

        public override string ToString()
        {
            return string.Format("[{0},{1}]", coords![0], coords![1]);
        }

    }
}
