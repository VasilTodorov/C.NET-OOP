using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    public class ProgramConverter : IConvertible
    {

        #region IConvertible Members

       string IConvertible.ConvertToCSharp(string input)
        {
            return "ProgramConverter.IConvertible.ConvertToCSharp()" + input;
        }

         string IConvertible.ConvertToVB2015(string input)
        {
            return "ProgramConverter.IConvertible.ConvertToVB2005()" + input;
        }

        #endregion
    }
}
