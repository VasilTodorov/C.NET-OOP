using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    public class ProgramHelper : ProgramConverter, IConvertible, ICodeChecker
    {

        #region ICodeChecker Members
        bool ICodeChecker.CodeCheckSyntax(string codeToCheck, string codeLanguage)
        {
            return codeToCheck.Equals(codeLanguage);
        }
        #endregion

        #region IConvertible Members

        string IConvertible.ConvertToCSharp(string input)
        {
            return "ProgramHelper.IConvertible.ConvertToCSharp()" + input;
        }

        string IConvertible.ConvertToVB2015(string input)
        {
            return "ProgramHelper.IConvertible.ConvertToVB2015()" + input;
        }

        #endregion
    }
}
