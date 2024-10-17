namespace Naïve_Bayes_Classifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NaiveBayesClassifier a = new NaiveBayesClassifier("train1", "test1");
            NaiveBayesClassifier a = new NaiveBayesClassifier();
            a.GetRandomTrainAndTestData("house-votes-84.data");
            //myDictionary.cou//house-votes-84.data
        }
    }
}
