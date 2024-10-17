using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem2;

namespace TestAssembly
{
    
    public static class ExtensionMethod
    {
        public static double CircleArea(this Problem2.Rectangle rectangle)
        {
            double radius;
            Point upperLeft;
            Point lowerRight;

            upperLeft = rectangle.Points[0];
            lowerRight = rectangle.Points[1];

            radius = Math.Sqrt((upperLeft['x'] - lowerRight['x']) * (upperLeft['x'] - lowerRight['x']) +
                    (upperLeft['y'] - lowerRight['y']) * (upperLeft['y'] - lowerRight['y'])) / 2;

            return radius * radius * Math.PI;
        }
    }
}
