using System.IO.IsolatedStorage;

namespace Problem2 {

    public class Program     {         static void BubbleSort(Comparable[] structs, GreaterThan g)
        {
            for (int i = 0; i < structs.Length - 1; i++)
            {
                for (int j = 0; j < structs.Length - 1; j++)
                {
                    if (!g(structs[j], structs[j + 1]))
                    {
                        //exchange
                        var temp = structs[j];
                        structs[j] = structs[j + 1];
                        structs[j + 1] = temp;
                    }
                }
            }
        }
         static void Main(string[] args)         {             Console.WriteLine("Test Point");             var pointA = new Point(10, 11, 22);             Console.WriteLine(pointA);             Point pointB = new(100, 10, 0);             Console.WriteLine(pointB);              Vector sideA = new (new Point(), pointA);

            Console.WriteLine("SideA");             Console.WriteLine(sideA);
            Console.WriteLine("SideA by 2");             var sideABy2 = sideA * 2;             Console.WriteLine(sideABy2);             Vector sideB = new (new Point(), pointB);             Console.WriteLine(sideB);             pointB.Z = 100;             Console.WriteLine(sideB);             Console.WriteLine("SideA size");             Console.WriteLine(((Comparable)sideA).SizeOf());              var triangle = new Triangle(sideB, sideA);             Console.WriteLine("Traiangle test:");             Console.WriteLine(  triangle);              Comparable[] points = new Comparable[] { new Point(), new Point(100, 200, 300), new Point(10, 20, 30) };             Console.WriteLine("\nUnsorted points ");             foreach (var point in points)
            {
                Console.WriteLine(((Comparable)point).SizeOf());
            }             BubbleSort(points, Point.GreaterThan);             Console.WriteLine("\nPoints sorted by size: ");             foreach (var point in points)
            {
                Console.WriteLine(((Comparable)point).SizeOf());
            }         }     } }