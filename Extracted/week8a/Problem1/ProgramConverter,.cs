using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Problem1
{
    public class ProgramConverter : IConvertible
    {
        string IConvertible.ConvertToCSharp(string vbString)
        {
            return $"ProgramConverter.IConvertible.ConvertToCSharp converts {vbString} to CS code";
        }

        string IConvertible.ConvertToVB(string csString)
        {
            return $"ProgramConverter.IConvertible.ConvertToVB converts {csString} to VB code";
        }
    }
}
