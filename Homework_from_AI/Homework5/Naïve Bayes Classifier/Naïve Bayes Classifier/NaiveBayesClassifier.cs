using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Naïve_Bayes_Classifier
{
    struct Info
    {
        public string Class;
        public string[] Results;

        public Info(string[] data)
        {
            Class = data[0];
            Results = new string[data.Length - 1];
            for (int i = 1; i < data.Length; i++)
                Results[i - 1] = data[i];
        }
    }
    public class NaiveBayesClassifier
    {
        const int LAMBDA = 1;
        Dictionary<string, double> priorProbabilities;
        Dictionary<int, Dictionary<string, Dictionary<string, double>>> conditionalProbabilities;
        string[] Classes; 
        //string pro
        private Info[] ProcessData(string trainData)
        {
            List<Info> data = new List<Info>();
            //string name = "uk12_xy.csv";
            string path = @"C:\Users\Vasil\source\repos\C#OOP\Homework_from_AI\Homework5\Naïve Bayes Classifier\congressional+voting+records\" + trainData;
            if (File.Exists(path))
            {
                //Console.WriteLine("Exists");               
                string line;

                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader(path);

                while ((line = file.ReadLine()!) != null)
                {
                    data.Add(new Info(line.Split(",")));
                }

                file.Close();
            }
            else
            {
                Console.WriteLine("Error couldnt load file");
            }

            return data.ToArray();
        }
        private void TrainNaiveBayes(Info[] processedTrainData)
        {

            // Initialize variables
            Dictionary<string, int> countClass = new Dictionary<string, int>();  //Count of occurrences for each class
            Dictionary<string, Dictionary<int, Dictionary<string, int>>> CountResultGivenClass = new Dictionary<string, Dictionary<int, Dictionary<string, int>>>();  // Count of occurrences for each word given each class
                                                                                                                              // int totalExamples = 0;  // Total number of training examples
            //Info[] processedTrainData = ProcessData(trainData);
            int numberOfExamples = processedTrainData.Length;
            // Process each training example
            foreach (var example in processedTrainData)
            {
                string classLabel = example.Class;
                if (!countClass.ContainsKey(classLabel))
                    countClass[classLabel] = 0;

                countClass[classLabel] += 1;  // Increment class count

                var info = example.Results;

                // Increment count for word given class


                for (int i = 0; i < info.Length; i++)
                {
                    if (!CountResultGivenClass.ContainsKey(classLabel))
                        CountResultGivenClass[classLabel] = new Dictionary<int, Dictionary<string, int>>();
                    if (!CountResultGivenClass[classLabel].ContainsKey(i))
                        CountResultGivenClass[classLabel][i] = new Dictionary<string, int>();
                    if (!CountResultGivenClass[classLabel][i].ContainsKey(info[i]))
                        CountResultGivenClass[classLabel][i][info[i]] = 0;
                    
                        CountResultGivenClass[classLabel][i][info[i]] += 1;
                }

            }

            Classes = new string[countClass.Count];          
            countClass.Keys.CopyTo(Classes, 0);

            //Calculate prior probabilities and conditional probabilities
            priorProbabilities = new Dictionary<string, double>();
            conditionalProbabilities = new Dictionary<int, Dictionary<string, Dictionary<string, double>>>();
            int K = countClass.Count;
            int A = 3;

            foreach (var example in processedTrainData)
            {
                string classLabel = example.Class;
                priorProbabilities[classLabel] = (double)(countClass[classLabel] + LAMBDA) / (numberOfExamples + K * LAMBDA);

                var info = example.Results;

                for (int i = 0; i < info.Length; i++)
                {
                    //work on incorporating value of attrinute probabilty
                    if(!conditionalProbabilities.ContainsKey(i))
                        conditionalProbabilities[i] = new Dictionary<string, Dictionary<string, double>>();
                    if (!conditionalProbabilities[i].ContainsKey(info[i]))
                        conditionalProbabilities[i][info[i]] = new Dictionary<string, double>();

                    conditionalProbabilities[i][info[i]][classLabel] = (double)(CountResultGivenClass[classLabel][i][info[i]] + LAMBDA) / (countClass[classLabel] + LAMBDA * A);
                }
            }

        }

        private (string, double) PredictNaiveBayes(Info testExample)
        {
            //Initialize variables
            string bestClass = "None";
            double bestLogScore = double.NegativeInfinity;
            double currentLogScore;

            //Info[] prpcessedTestData = ProcessData(testData);

            //Iterate over each class
            
            foreach(var classLabel in Classes)
            {
                currentLogScore = Math.Log(priorProbabilities[classLabel]);  //Initialize with prior probability

                //Calculate the likelihood using Naive Bayes assumption
                var data = testExample.Results;
                for(int i = 0;i < data.Length;i++)
                {
                    //Increment log score based on log probability
                    if (!conditionalProbabilities[i].ContainsKey(data[i]))
                        currentLogScore += 0.0000000001;
                    else if (!conditionalProbabilities[i][data[i]].ContainsKey(classLabel))
                        currentLogScore += 0.0000000001;
                    else
                    currentLogScore += Math.Log(conditionalProbabilities[i][data[i]][classLabel]);  

                }

                // Update best class if the current log score is higher
                if( currentLogScore > bestLogScore)
                {
                    bestLogScore = currentLogScore;
                    bestClass = classLabel;
                }
               
            }
            return (bestClass, Math.Exp(bestLogScore));
        }

        private double GroupTest(Info[] testData)
        {
            int total = 0;
            int count = testData.Length;
            foreach(var test in testData)
            {
                var result = PredictNaiveBayes(test);
                //Console.WriteLine($"true class: {test.Class}, predicted class: {result.Item1}, accuracity: {result.Item2}");
                //Console.WriteLine();
                total += result.Item1 == test.Class ? 1 : 0;
            }
            Console.WriteLine($"accuracity: {(double)total/count}");
            return (double)total / count;
        }
    

    
        //public NaiveBayesClassifier(string trainData, string testData)
        //{
        //    var train = ProcessData(trainData);
        //    var test = ProcessData(testData);
        //    TrainNaiveBayes(train);
        //    var result = PredictNaiveBayes(test);
        //    foreach (var word in priorProbabilities)
        //        Console.WriteLine(word);
        //    Console.WriteLine();
        //    for (int i = 0; i < conditionalProbabilities.Count; i++)
        //    {
        //        foreach (var example in conditionalProbabilities[i])
        //            Console.WriteLine(example);
        //    }

        //    Console.WriteLine();
        //    Console.WriteLine($"best class:{result.Item1}, accuracity:{result.Item2}");
        //    Console.WriteLine(Math.Log(0.4));
        //    Console.WriteLine(Math.Log(0.6));
        //}

        public NaiveBayesClassifier()
        {

        }

        public void GetRandomTrainAndTestData(string initalData)
        {
            var totalInfo = ProcessData(initalData);
            //int length = totalInfo.Length;
            int lengthBlock = (int)Math.Ceiling(totalInfo.Length / 10.0);
            int[] order = new int[totalInfo.Length];
            Random random = new Random();
            int temp;
            int r;
            double total = 0;
            

            for(int i = 0; i < order.Length; i++)
                order[i] = i;
            for (int i = 0; i < order.Length; i++)
            {
                temp = order[i];
                r = random.Next(order.Length);
                order[i] = order[r];
                order[r] = temp;
            }


            List<Info> listOrigin = new List<Info>(totalInfo);

            List<Info> train = new List<Info>();
            Info info = new Info();
            info.Class = "none";


            List<Info> test = new List<Info>();
            Console.WriteLine("test start");
            for (int i = 0;i < 10;i++) 
            {
                test.Clear();
                train = listOrigin.ToList();
                for (int j = 0 ;j < lengthBlock && ((i * lengthBlock + j) < totalInfo.Length);j++)
                {
                    test.Add(totalInfo[order[i * lengthBlock + j]]);
                    //train.RemoveAt(order[i * lengthBlock + j]);
                    train[order[i * lengthBlock + j]] = info;                   
                }
                train.RemoveAll(x=> x.Class == "none");
                TrainNaiveBayes(train.ToArray());
                Console.WriteLine($"----------test No{i+1}----------");
                total += GroupTest(test.ToArray());
                Console.WriteLine();
               
            }
            Console.WriteLine($"average: {total/10.0}");
            //int trainLength = 
        }
    }
}
