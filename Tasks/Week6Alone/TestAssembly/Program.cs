using System.Drawing;


namespace TestAssembly
{
    using Problem2;
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Point point1 = new Point();
            Point point2 = new Point(new int[] {2,-2});
            Rectangle r = new Rectangle(new Point[] {point1, point2});
            Console.WriteLine(r);
            Console.WriteLine(r.Parameter());
            Console.WriteLine(r.CircleArea());
        }
    }
}
