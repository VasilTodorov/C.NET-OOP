using System.Drawing;
using System.IO;

namespace GenomAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //double x = 0.190032E-03;
            //Console.WriteLine(x);
            //string data = "uk12_xy.csv";
            //string path = @"C:\Users\Vasil\source\repos\C#OOP\Homework_from_AI\Homework3\GenomAlgorithm\" + data;

            //if (File.Exists(path))
            //{
            //    Console.WriteLine("Exists");
            //    int counter = 0;
            //    string line;

            //    // Read the file and display it line by line.
            //    System.IO.StreamReader file = new System.IO.StreamReader(path);

            //    while ((line = file.ReadLine()!) != null)
            //    {
            //        var l = line.Split(',');
            //        foreach (var v in l)
            //        {
            //            //float h = float.Parse(v);
            //            double h = double.Parse(v);
            //            Console.WriteLine($"{h:F8}");
            //            //Console.WriteLine(string.Format("{}"));
            //        }
            //        Console.WriteLine("");
            //        counter++;
            //    }

            //    file.Close();
            //}
            //    // Suspend the screen.
            //    //Console.ReadLine();
            //}



            //Travel travel = new Travel(7);

            //Console.WriteLine(travel);
            //var goal = travel.FindUltimate(10);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine(travel);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine(goal);

            Travel travel = new Travel();
            //Console.WriteLine(travel);
            Console.WriteLine();
            Console.WriteLine("\n distance: "+travel.FindUltimate(50,true));
            Console.WriteLine();
            //Console.WriteLine(travel);
            Console.WriteLine();
            travel.FilePrint();

            //Travel t = new Travel(98);

            //Console.WriteLine("\n distance: " + t.FindUltimate(500, true));
            //Console.WriteLine(t);
        }
    }
}
