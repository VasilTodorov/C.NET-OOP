namespace ExperimentRef
{
    internal class Program
    {
        static readonly int[] S = { 3, 3, 43 };
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int[] b = { 4, 3, 14 };
            Console.WriteLine(InTest2(in b));
            S[0] += 4;
            Console.WriteLine(S[0]);
        }

        static int InTest1(in int a)
        {
            //a += 3;
            return a + 1;
        }
        static int InTest2(in int[] a)
        {
            //a += 3;
            a[0] += 11;
            int[] b = { 4, 3, 14 };
            //a = b;
            return a[0];
        }

    }
}
