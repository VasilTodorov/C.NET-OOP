namespace Problem1Test
{
    using Problem;
    internal class Program
    {
        static void Main(string[] args)
        {
            Problem.Point point = new Problem.Point();
            Console.WriteLine(point);

            Problem.Rectangle rectangle = new Problem.Rectangle(10,10, point);

            Console.WriteLine(rectangle);
            var perimeter = rectangle.Perimeter();

            Console.WriteLine(perimeter);

            var perimeter2 = RectangleExtensions.Perimeter(rectangle);
            Console.WriteLine(  perimeter2);

        }
    }
}