using Problem2;

namespace problemTest
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Point pointA = new Point();
            Point pointB = new Point(new int[] {6, 5});
            Rectangle rect = new Rectangle(pointA,pointB);
            Parallelepiped p = new Parallelepiped(3,rect);
            Console.WriteLine(p.Volume());

            Rectangle[] rectangles = { rect, p };

            foreach (var item in rectangles) 
            {
                Console.WriteLine(item.Area());
            }
        }
    }
}