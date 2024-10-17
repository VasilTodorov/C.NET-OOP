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
        public Point(int[] coords)
        {
            Coords = coords;
        }
        public Point() : this(new int[2])
        {

        }
        public Point(Point p) : this(p.coords!)
        {

        }
        #endregion
        #region Properties
        public int this[int indexer]
        {
            get { return indexer >= 0 && indexer < 2 ? coords![indexer] : int.MinValue; }
        }

        public int this[char indexer]
        {
            get 
            {
                return indexer switch
                {
                    'x' => coords![0],
                    'y' => coords![1],
                    _ => int.MinValue,
                };
            }
        }
        public int[] Coords
        {
            get
            {
                return new int[] { coords![0], coords[1] };
            }
            set
            {
                if (value != null && value.Length == 2)
                {
                    coords = new int[] { value[0], value[1] };
                }
                else
                {
                    coords = new int[2] ;
                }
            }
        }
        #endregion

        public override string ToString()
        {
            return $"Point: ({coords![0]}, {coords[1]})";
        }
    }
}
