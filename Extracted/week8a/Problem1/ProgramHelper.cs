using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Problem1
{
    public class ProgramHelper : ProgramConverter, IConvertible, ICodeChecker
    {
        string IConvertible.ConvertToCSharp(string vbString)
        {
           return $"ProgramHelper.IConvertible.ConvertToCSharp converts {vbString} to CS code";
        }

        string IConvertible.ConvertToVB(string csString)
        {
            return $"ProgramHelper.IConvertible.ConvertToVB converts {csString} to VB code";
        }

        //public  string ConvertToCSharp(string vbString)
        //{
        //    return $"ProgramHelper.IConvertible.ConvertToCSharp converts {vbString} to CS code";
        //}


        /// <summary>
        /// Check code to be equal to language
        /// </summary>
        /// <param name="code"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        bool ICodeChecker.CodeCheckSyntax(string code, string language)
        {
            return code.Equals(language);
        }


    }
}
