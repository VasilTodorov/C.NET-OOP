namespace Lab3aProblem3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Random randomNumbers = new Random();
            var number = randomNumbers.Next(2);
            Console.WriteLine(number.ToString());
        }
    }
}