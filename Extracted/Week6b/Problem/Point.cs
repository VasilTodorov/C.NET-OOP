using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public class Point
    {
        private int[] coords;

        #region Constructors
        /// <summary>
        /// General-purpose constructor (canonical)
        /// </summary>
        /// <param name="coords"></param>
        public Point(int[] coords)
        {
            Coords = coords;
        }
        /// <summary>
        /// Default constructor
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
        public int[] Coords
        {
            get
            {
                //int[] temp = new int[2];
                // for (int i = 0;i < temp.Length;i++)
                //{
                //	temp[i] = coords[i];
                //}
                //return temp; 
                return new int[] { coords[0], coords[1] };
            }
            set
            {
                if (value != null && value.Length == 2)
                {
                    //coords = new int[2];
                    //for (int i = 0; i < value.Length; i++)
                    //{
                    //    coords[i] = value[i];
                    //}
                    coords = new int[] { value[0], value[1] };
                }
                else
                {
                    coords = new int[] { 0, 0 };// default & valid value
                }
            } 
            
        }
        #endregion

        public override string ToString()
                  => string.Format("[{0}]",string.Join(", ", coords));
    }
}
