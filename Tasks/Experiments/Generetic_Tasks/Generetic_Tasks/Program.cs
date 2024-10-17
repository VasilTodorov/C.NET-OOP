using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Generetic_Tasks
{
    class Animal
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string a = "Heloo";
            string b = "Hello";
            Console.WriteLine(EqG(a, b)?"Yes":"No");
            Collection<Animal> c = new Collection<Animal>();
            Animal bep = new Animal { Name = a, Count = 3 };
            c.Add(bep);
            Console.WriteLine("No1");
            foreach (var e in  c) {
                Console.WriteLine(e.Name);
            }
            bep.Name = "Boo";
            Console.WriteLine("No2");
            foreach (var e in c)
            {
                Console.WriteLine(e.Name);
            }
            c[0].Name = "mom";
            Console.WriteLine("No3");
            foreach (var e in c)
            {
                Console.WriteLine(e.Name);
            }
        }

        public static bool EqG<T>(T a, T b) 
            where T : class
        {
            if(a.Equals(b))
            {
                return true;
            }
            return false;
        }

        
    }
}
