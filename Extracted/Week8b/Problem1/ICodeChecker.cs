using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    public interface ICodeChecker : IConvertible
    {
        /// <summary>
        /// Checks if a code is in a specific programming language
        /// </summary>
        /// <param name="code">the code to check</param>
        /// <param name="lang">the language</param>
        /// <returns>TRUE if the code is in the specific language</returns>
        bool CodeCheckSyntax(string codeToCheck, string codeLanguage);
    }
}
