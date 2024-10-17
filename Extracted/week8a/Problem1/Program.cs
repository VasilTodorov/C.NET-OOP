using System.Runtime.InteropServices;

namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test No.1  ProgramHelper");
            ProgramHelper ph = new ProgramHelper();

            var csCode = ((IConvertible)ph).ConvertToCSharp("VB code sample");
            Console.WriteLine(csCode);
            var vbCode = ((IConvertible)ph).ConvertToVB("CS code sample");
            Console.WriteLine(vbCode);

            Console.WriteLine("Test No.2  ProgramHelper");
            Console.WriteLine("ProgramHelper.CodeCheckSyntax test");
            Console.WriteLine(((ICodeChecker)ph).CodeCheckSyntax("CS", "CS"));
            // Console.WriteLine(((IConvertible)ph).CodeCheckSyntax("CS", "CS"));

            Console.WriteLine("\nTest No.1  ProgramConverter\n");
            ProgramConverter pc = new ProgramConverter();
            Console.WriteLine("\nTest with \"is\"");
            if (pc is IConvertible pcConvertible)
            {
                vbCode = pcConvertible.ConvertToVB("CS code sample");
                Console.WriteLine(vbCode);
            }
            Console.WriteLine("\nTest with \"as\"");
            pcConvertible = pc as IConvertible;
            if (pcConvertible != null)
            {
                vbCode = pcConvertible.ConvertToVB("CS code sample");
                Console.WriteLine(vbCode);
            }
        }
    }
}
