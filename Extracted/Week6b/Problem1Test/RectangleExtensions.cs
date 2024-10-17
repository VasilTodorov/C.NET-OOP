using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Problem1Test
{
    public static class RectangleExtensions
    {
     /// <summary>
     /// COMPUTES PERIMETGER OF RECTANGLE
     /// </summary>
     /// <param name="r"></param>
     /// <returns></returns>
        public static double Perimeter(this Problem.Rectangle r)
        {
            return 2 * (r.Length + r.Width);
        }

    }
}
