using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    public interface IConvertible
    {
        /// <summary>
        /// Converts input to c#
        /// </summary>
        /// <param name="input">the code</param>
        /// <returns>C# code</returns>
        string ConvertToCSharp(string input);

        /// <summary>
        /// Converts input to VB2015
        /// </summary>
        /// <param name="input">the code</param>
        /// <returns>VB code</returns>
        string ConvertToVB2015(string input);
    }
}
