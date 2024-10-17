internal class Program
{
    public static void Main(string[] args)
    {
        // prompt the user for input
        Console.WriteLine("Please enter a sentence:");
        string? sentence = Console.ReadLine()??""; // read input sentence
        string[] words  =  sentence!.Split(); // split sentence into words

        // use LINQ to sort the words and convert to lowercase
        var sortedWords =
           from word in words
           let lowerCaseWord = word.ToLower()
           orderby lowerCaseWord
           select lowerCaseWord;

        Console.WriteLine("\nYou entered:"); // display header
        Console.WriteLine(sentence); // display the input
        Console.Write("\nDistinct words:"); // display header

        // display only the distinct words
        foreach (var word in sortedWords.Distinct())
            Console.Write(" {0}", word);

        Console.WriteLine(); // output end of line
    } // end Main

}