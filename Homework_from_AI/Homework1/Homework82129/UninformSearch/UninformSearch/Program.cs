using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace UninformSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //8
            //-1
            //1 2 3
            //4 5 6
            //0 7 8
            //Example();
            //5 6 3 4
            //8 0 1 15
            //10 7 2 11
            //12 9 14 13

            //15
            //-1 hard
            //9 5 1 12
            //10 0 11 13
            //3 7 14 6
            //2 8 15 4

            ////global::System.Console.WriteLine("ddd");
            ////<1    secuda
            //Stopwatch stopWatch = new Stopwatch();
            //int[,] example = { { 5, 6, 3, 4 },
            //                    { 8, 0, 1, 15},
            //                    { 10, 7, 2, 11},
            //                    { 12, 9, 14, 13} };
            //Board board = new Board(example, -1);
            //Console.WriteLine(board);




            //Console.WriteLine(board.Ida_Start());
            //ReadInfo();
            //stopWatch.Stop();
            //// Get the elapsed time as a TimeSpan value.
            //TimeSpan ts = stopWatch.Elapsed;
            //Console.WriteLine(ts);

            ReadInfo();
            //Example();
            //Console.ReadLine();
        }

        static void ReadInfo()
        {
           

            int N;
            //var l = Console.ReadLine();
            if (!int.TryParse(Console.ReadLine(), out N))
            {
                Console.WriteLine("failer1");
                return;
            }

            int position;
            if (!int.TryParse(Console.ReadLine(), out position))
            {
                Console.WriteLine("failer2");
                return;
            }

            int size = (int)Math.Sqrt(N + 1);
            int[,] array = new int[size, size];
            string line;
            
            for (int i = 0; i < array.GetLength(0); i++)
            {
                line = Console.ReadLine()!;
                if (line == null)
                {
                    Console.WriteLine("Line!!!");
                    return; }
                var r = line.Split(" ");
                for(int j = 0; j < r.Length; j++) 
                {
                    //Console.WriteLine("tt");
                    if (!int.TryParse(r[j], out array[i,j]))
                    {
                        Console.WriteLine("failer3"+i+" "+j);
                        return;
                    }
                }
            }

            Board input = new Board(array, position);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine(input.Ida_Start());
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine(ts);
            //Console.ReadLine();
        }

        static void Example()
        {
            int[,] example1 = { { 1, 2, 3 },
                                { 4, 5, 6},
                                { 0, 7, 8} };

            int[,] example2 = { { 1, 2, 0 },
                                { 3, 4, 5},
                                { 6 , 7, 8} };

            int[,] example3 = { { 1, 2, 3, 4},
                                { 5, 6, 7, 8},
                                { 9 , 10, 11, 12},
                                { 13, 14, 0, 15} };

            int[,] example4 = { { 1, 2, 3 },
                                { 4, 5, 6},
                                { 0 , 7, 8} };

            int[,] example5 = { { 1, 2, 3 },
                                { 4, 5, 6},
                                { 7, 8, 0} };

            int[,] example6 = { { 6, 5, 3 },
                                { 2, 4, 8},
                                { 7 , 0, 1} };

            int[,] example7 = { { 1, 2, 3},
                                { 4, 5, 0},
                                { 6 , 7, 8} };

            int[,] example8 = { { 1, 2, 3},
                                { 4, 5, 0},
                                { 8 , 7, 0} };

            Board board1 = new Board(example1, -1);

            Board board2 = new Board(example2, 0);

            Board board3 = new Board(example3, -1);

            Board board4 = new Board(example4, 8);

            Board board5 = new Board(example5, -1);

            Board board6 = new Board(example6, -1);

            Board board7 = new Board(example7, 4);

            Board board8 = new Board(example8, -1);


            Console.WriteLine(board1);
            Console.WriteLine(board1.Ida_Start());

            Console.WriteLine(board2);
            Console.WriteLine(board2.Ida_Start());
            Console.WriteLine(board3);
            Console.WriteLine(board3.Ida_Start());
            Console.WriteLine(board4);
            Console.WriteLine(board4.Ida_Start());
            Console.WriteLine(board5);
            Console.WriteLine(board5.Ida_Start());
            Console.WriteLine(board6);
            Console.WriteLine(board6.Ida_Start());
            Console.WriteLine(board7);
            Console.WriteLine(board7.Ida_Start());
            Console.WriteLine(board8);
            Console.WriteLine(board8.Ida_Start());

        }

    }
}