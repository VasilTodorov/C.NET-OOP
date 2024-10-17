namespace Lab3aProblem2
{
    internal class Program
    {
        //const double ACCURACY = 0.000001;
        static void Main(string[] args)
        {
            double userInput;
            Console.WriteLine("Give accuracy 0 < E < 1: ");
            if (!double.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Wrong input");
                return;
            }
            double x;
            x = 1.45;
            Console.WriteLine($"Cos accurate: {x}: {(Math.Cos(x))}");
            Console.WriteLine($"Cos approx:   {x}: {(ComputeCos(x, userInput))}");
            Console.WriteLine($"Accuracy: {userInput}");
        }
        static double ComputeCos(double x, double accuracy)
        {
            // declaration of varsa
            double cosResult;
            int counter;
            double term;

            // initialization
            counter = 0;
            term = 1.0;
            cosResult = term;

            // processing

            do {
                counter +=2; 
                term = -term * x * x/ ((counter -  1)* counter);
                cosResult += term;
            } 
            
            while (Math.Abs(term) > accuracy);


            return cosResult;
        }
    }
}