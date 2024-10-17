using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
   public  class Program
    {
        public static void Main(string[] args)
        {
            // Test A) and B)
            //Provide an implementation on the class that can only be accessed through the interface! 
            IConvertible tool = new ProgramHelper();
            ProgramHelper directTool = (ProgramHelper)tool;
            Console.WriteLine();
            Console.WriteLine("ProgramHelper implementations of IConvertible" );
          
            // Execute the implementation of IConvertible in ProgramHelper
            Console.WriteLine(tool.ConvertToCSharp("Some VB source code"));
            Console.WriteLine(tool.ConvertToVB2015("Some C# source code"));

            /* The following code won't compile
            Console.WriteLine(tool.ConvertToCSharp("Some VB source code"));
            Console.WriteLine(tool.ConvertToVB2015("Some C# source code"));
            */


            IConvertible baseTool = new ProgramConverter();
            ProgramConverter baseDirectTool = (ProgramConverter)tool;
            Console.WriteLine();
            Console.WriteLine("ProgramConverter implementations of IConvertible");
           
            // Execute the implementation of IConvertible in ProgramConverter
            Console.WriteLine("ProgramHelper implementations of IConvertible");
            Console.WriteLine(baseTool.ConvertToCSharp("Some VB source code"));
            Console.WriteLine(baseTool.ConvertToVB2015("Some C# source code"));

            // At the same time
            Console.WriteLine("Is  tool IConvertible {0}",      tool is IConvertible);
            Console.WriteLine("Is  tool ProgramConverter {0}",  tool is ProgramConverter);
            Console.WriteLine("Is  baseTool  IConvertible {0}", baseTool is IConvertible);

            ICodeChecker checkTool = new ProgramHelper();
            ProgramHelper directCheckTool = (ProgramHelper)checkTool;
            // Execute the implementation of ICodeChecker in ProgramHelper
            // Provides access to all the implemented methods of ICodeChecker
            Console.WriteLine();
            Console.WriteLine("ProgramHelper implementations of ICodeChecker");
            
            Console.WriteLine(checkTool.ConvertToVB2015("Some CSharp source code"));
            Console.WriteLine(checkTool.ConvertToCSharp("Some VB source code"));
            Console.WriteLine("Check VB code: {0}",checkTool.CodeCheckSyntax("VB source code", "VB source code"));


            IConvertible fromCodeChecker = checkTool;
            Console.WriteLine();
            Console.WriteLine("ICodeChecker implementations of IConvertible");
            Console.WriteLine(fromCodeChecker.ConvertToCSharp("Some VB source code"));
            Console.WriteLine(fromCodeChecker.ConvertToVB2015("Some C# source code"));

            IConvertible fromICodeChecker = directCheckTool as ICodeChecker;
            Console.WriteLine();
            Console.WriteLine("IConvertible implementations  from ProgramHelper");
            Console.WriteLine(fromICodeChecker.ConvertToCSharp("Some VB source code"));
            Console.WriteLine(fromICodeChecker.ConvertToVB2015("Some C# source code"));

        }
    }
}
