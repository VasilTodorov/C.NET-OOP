using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public interface IConvertible
    {
        /// <summary>
        /// Converts VB code to CS
        /// </summary>
        /// <param name="vbString"></param>
        /// <returns></returns>
        string ConvertToCSharp(string vbString);
        /// <summary>
        /// Converts CS code to VB
        /// </summary>
        /// <param name="csString"></param>
        /// <returns></returns>
        string ConvertToVB(string csString);
    }
}
