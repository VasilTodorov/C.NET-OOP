using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Patterns.AEP
{
    class GameEllipse
    {
        static double _width;
        static double _height;

        public Ellipse Shape { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Vx { get; set; }

        public double Vy { get; set; }

        public void UpdatePosition()
        {
            X += Vx;
            Y += Vy;

            if (X <= 0 || X >= _width)
                Vx = -Vx;

            if (Y <= 0 || Y >= _height)
                Vy = -Vy;
        }

        public static void SetBoundary(double width, double height)
        {
            _width = width;
            _height = height;
        }
    }
}
