using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomAlgorithm
{
    public class Travel
    {
        const int NUMBER_KNOWN = 12;
        const double LIMIT = 1000;
		private readonly PointInPath[] BASE_PATH;
		private Path[] population;

        public Travel(int numberOfCities)
        {
            BASE_PATH = new PointInPath[numberOfCities];
            for(int i = 0; i < BASE_PATH.Length; i++)
                BASE_PATH[i] = new PointInPath(generateRandomPoint(), i);
            //SIZE = numberOfCities * 2;
            population = new Path[numberOfCities * 100];
            generateRandomPopulation();            
        }
        //TODO Get Total Distance, Parent selection(By one whole chace), reproducion , mutation , new generation
        public Travel()
        {
            BASE_PATH = new PointInPath[NUMBER_KNOWN];
            string data = "uk12_xy.csv";
            string path = @"C:\Users\Vasil\source\repos\C#OOP\Homework_from_AI\Homework3\GenomAlgorithm\" + data;
            if (File.Exists(path))
            {
                //Console.WriteLine("Exists");
                int counter = 0;
                string line;

                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader(path);

                while ((line = file.ReadLine()!) != null)
                {
                    var l = line.Split(',');
                    double[] h = new double[2];
                    for (int i = 0; i <  2; i++)
                    {
                        //float h = float.Parse(v);
                        h[i] = double.Parse(l[i]);
                        //Console.WriteLine($"{h:F8}");
                        //Console.WriteLine(string.Format("{}"));
                    }
                    //Console.WriteLine("");
                    BASE_PATH[counter] = new PointInPath(h, counter); 
                    counter++;
                }

                file.Close();
            }

            population = new Path[NUMBER_KNOWN * 100];
            generateRandomPopulation();

        }

        public void FilePrint()
        {
            string[] citeis = new string[NUMBER_KNOWN];
            string data = "uk12_name.csv";
            string path = @"C:\Users\Vasil\source\repos\C#OOP\Homework_from_AI\Homework3\GenomAlgorithm\" + data;
            if (File.Exists(path))
            {
                //Console.WriteLine("Exists");
                int counter = 0;
                string line;

                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader(path);

                while ((line = file.ReadLine()!) != null)
                {
                    
                    //Console.WriteLine("");
                    citeis[counter] = line;
                    counter++;
                }

                file.Close();
            }

            var finalPath = population[0];
            for(int i = 0; i < NUMBER_KNOWN; i++)
            {
                Console.Write(" => "+citeis[finalPath[i].Index]);
            }
        }
        public double FindUltimate(int numberOfGenerations,bool isTest = false)
        {

            for(int i = 0;i < numberOfGenerations; i++) 
            {
                var parents = Selection();
                var chidren = Reproduction(parents);
                Mutation(chidren);
                BuildNextGenerartion(chidren);
                if(isTest)
                    Console.WriteLine(population[0].CalculatePath());
            }

            return population[0].CalculatePath();
        }
        public void BuildNextGenerartion(Path[] children) 
        {
            int length = population.Length;
            //Path[] newGeneration =(Path[]) population.Concat(children);
            var newGeneration = population.Concat(children).OrderBy(n => n.CalculatePath());
            int index = 0;

            foreach(Path path in newGeneration) 
            {
                if(index < population.Length)
                    population[index++] = path;
            }
            
        }
        public void Mutation(Path[] children)
        {
            Random random = new Random();
            foreach(Path child in children) 
            {
                if (random.NextDouble() < 0.45)
                    child.MutationOfPath();
                
            }
        }
        public Path[] Reproduction(Path[] parents)
        {
            Path[] children = new Path[parents.Length];
            for(int i = 0;i < children.Length-1;i++) 
            {
                children[i] = new Path(parents[i].GetChildTwoPointCrossOver(parents[i+1]));
            }
            children[children.Length - 1] = new Path(parents[children.Length - 1].GetChildTwoPointCrossOver(parents[0]));

            return children;
        }
        public Path[] Selection()
        {
            Random random = new Random();
            //int length = population.Length/3;
            Path[] selection = new Path[(10*population.Length/13)];
            double[] evaluation = EvaluatePopulatio();
            double chance;

            for(int i = 0;i < selection.Length;i++) 
            {
                chance = random.NextDouble();
                for (int j = 0; j < evaluation.Length; j++)
                {
                    if(chance <= evaluation[j])
                    {
                        selection[i] = population[j];
                        break;
                    }
                }
            }
            //for (int i = 0; i < selection.Length; i++)
            //    Console.WriteLine(selection[i]);
            return selection;
        }
        private double[] EvaluatePopulatio()
        {
            double[] evaluation = new double[population.Length];
            double totalDistance = TotalDistance();
            double totalEvalulation = 0;

            for (int i = 0; i < evaluation.Length; i++)
            {
                evaluation[i] = totalDistance/ population[i].CalculatePath() ;
            }

            totalEvalulation = evaluation.Sum();

            for (int i = 0; i < evaluation.Length; i++)
            {
                evaluation[i] /= totalEvalulation;
            }
            for (int i = 1; i < evaluation.Length; i++)
            {
                evaluation[i] += evaluation[i-1];
            }
            //for (int i = 0; i < evaluation.Length; i++)
            //{
            //    Console.WriteLine(evaluation[i]);
            //}
            return evaluation;
        }
        private double TotalDistance()
        {
            double sum = 0;
            for(int i = 0;i < population.Length;i++) 
            {
                sum += population[i].CalculatePath();
            }

            return sum;
        }
        private bool percentChance(double chance) 
        { 
            Random random = new Random();
            return random.NextDouble() < chance;
        }
        private Point generateRandomPoint()
        {
            var random = new Random();
            double x;
            double y;

            x = random.NextDouble() * LIMIT - LIMIT/2;
            y = random.NextDouble() * LIMIT - LIMIT / 2;

            return new Point(new double[] { x, y });
        }
        private Path generateRandomPath()
        {
            Random random = new Random();
            // PointInPath[] chain = new PointInPath[BASE_PATH.Length];
            var s = BASE_PATH.OrderBy(n => random.NextDouble()).ToArray();
            Path path = new Path(s);
           // path;
           return path;

        }
        private void generateRandomPopulation()
        {
            Random random = new Random();
            for (int i = 0; i < population.Length; i++)
            {
                population[i] = generateRandomPath();
            }
                
        }

        public void Test()
        {
            var a1 = population[0].GetChildTwoPointCrossOver(population[1]);
            var a2 = population[0].GetChildTwoPointCrossOver(population[2]);
            var a3 = population[0].GetChildTwoPointCrossOver(population[3]);
            a1.MutationOfPath();
            Console.WriteLine(a1);
            a2.MutationOfPath();
            Console.WriteLine(a2);
            a3.MutationOfPath();
            Console.WriteLine(a3);
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < population.Length; i++)
            {
                str += population[i].ToString() + '\n';
            }
            return str;
        }
    }
}
