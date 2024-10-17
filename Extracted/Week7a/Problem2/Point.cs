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


        #region Constructors 
        /// <summary>
        /// General- purpose (canonical) constructor
        /// </summary>
        /// <param name="coords"></param>

        public Point(int[]? coords)
        {
            Coords = coords!;
        }
        /// <summary>
        /// 
        /// Default 
        /// </summary>
        public Point() : this(new int[2])
        {

        }
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="point"></param>
        public Point(Point point) : this(point.coords)
        {

        } 
        #endregion

        #region Properties 

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int this[int index]
        {
            get => index >= 0 && index < 2 ? coords![index] : 0;

            set => coords![index] = index >= 0 && index < 2 ? value : 0;
        }
        /// <summary>
        /// Property
        /// </summary>
        public int[] Coords
        {
            get { return new int[] { coords![0], coords[1] }; }
            set
            {
                coords = value != null && value.Length == 2 ?
                                 value : new int[2];
            }
        }

        #endregion

        public override string ToString()
                            => $"[{string.Join(", ", coords!)}]";
    }
}
