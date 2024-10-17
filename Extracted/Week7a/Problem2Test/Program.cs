namespace Problem2Test
{
    using Problem2;
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point(new int[] { 10, 11 });
            Console.WriteLine(point);

            Rectangle rectangle = new Rectangle(point, new Point());
            Console.WriteLine(rectangle);
            Parallelepiped parallelepiped = new (10,rectangle);
            
            var volume = parallelepiped.Volume();
            Console.WriteLine(  $"Volume: {volume:f2}");

            var volumeE = ExtensionMethods.Volume(parallelepiped);
            Console.WriteLine($"Volume: {volumeE:f2}");
        }
    }
}