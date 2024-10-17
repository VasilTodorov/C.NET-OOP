using System;
using System.Collections.Generic;
using Problem2;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problemTest
{
    static class ExtensionMethods
    {
        public static double Volume(this Parallelepiped r)
            => r.Width * r.Hight * r.Length;
    }
}
