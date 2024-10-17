internal class Program
{
    public static void Main(string[] args)
    {
        List<char> theList = new List<char>(); // create character list
                                               // create random number generator
        Random randomNumber = new Random();

        // we index into the alphabet to convert 
        // numbers 0-25 to letters a-z
     

        // generate 30 random letters
        for (int i = 0; i < 30; i++)
        {
            // generate number from 0 to 25 to
            // select a letter from the string
            int letterNumber = randomNumber.Next(26);

            // convert the letter number to the actual letter
            char letter = (char) ('a' + letterNumber);
            theList.Add(letter); // add the letter to the List
        } // end for

        Display(theList, "Generated List:"); // display original List

        // sort theList in ascending order (the default)
        var ascending =
           from letter in theList
           orderby letter
           select letter;

        // display ascending order
        Display(ascending, "Ascending order:");

        // sort the list in descending order
        var descending =
           from letter in theList
           orderby letter descending
           select letter;

        // display descending order
        Display(descending, "Descending order:");

        // display distinct letters in the List in ascending order
        Display(ascending.Distinct(),
           "Ascending order, no duplicates:");
    } // end Main

    // display the results of a LINQ query, along with a header
    public static void Display(IEnumerable<char> data, string header)
    {
        Console.WriteLine(header); // display header

        // display each item
        foreach (var item in data)
            Console.Write("{0} ", item);

        Console.WriteLine(); // output end of line
    } // end method Display
}