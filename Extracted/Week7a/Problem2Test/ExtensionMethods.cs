using Problem2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2Test
{
    static class ExtensionMethods
    {

        public static double Volume(this Parallelepiped p) { 
        
            return p.Length * p.Height * p.Width;
        }



    }
}
