namespace SortedListSample
{
    public class Example
    {
        public static void Main()
        {
            // Create a new sorted list of strings, with string
            // keys.
            //use a Comparison delegate with Comparer<string>.Create()
            SortedList<string, string> openWith = 
                new  (Comparer<string>.Create((a, b) => -a.CompareTo(b)))
            {
                // Add some elements to the list. There are no 
                // duplicate keys, but some of the values are duplicates.
                { "txt", "notepad.exe" },
                { "bmp", "paint.exe" },
                { "dib", "paint.exe" },
                { "rtf", "wordpad.exe" }
            };

            // The Add method throws an exception if the new key is 
            // already in the list.
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }

            // The Item property is another name for the indexer, so you 
            // can omit its name when accessing elements. 
            Console.WriteLine("For key = \"rtf\", value = {0}.",
                openWith["rtf"]);

            // The indexer can be used to change the value associated
            // with a key.
            openWith["rtf"] = "winword.exe";
            Console.WriteLine("For key = \"rtf\", value = {0}.",
                openWith["rtf"]);

            // If a key does not exist, setting the indexer for that key
            // adds a new key/value pair.
            openWith["doc"] = "winword.exe";

            // The indexer throws an exception if the requested key is
            // not in the list.
            try
            {
                Console.WriteLine("For key = \"tif\", value = {0}.",
                    openWith["tif"]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            // When a program often has to try keys that turn out not to
            // be in the list, TryGetValue can be a more efficient 
            // way to retrieve values.
            string value = "";
            if (openWith.TryGetValue("tif", out value!))
            {
                Console.WriteLine("For key = \"tif\", value = {0}.", value);
            }
            else
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            // ContainsKey can be used to test keys before inserting 
            // them.
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Console.WriteLine("Value added for key = \"ht\": {0}",
                    openWith["ht"]);
            }

            // When you use foreach to enumerate list elements,
            // the elements are retrieved as KeyValuePair objects.
            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }

            // To get the values alone, use the Values property.
            IList<string> ilistValues = openWith.Values;

            // The elements of the list are strongly typed with the 
            // type that was specified for the SorteList values.
            Console.WriteLine();
            foreach (string s in ilistValues)
            {
                Console.WriteLine("Value = {0}", s);
            }

            // The Values property is an efficient way to retrieve
            // values by index.
            Console.WriteLine("\nIndexed retrieval using the Values " +
                "property: Values[2] = {0}", openWith.Values[2]);

            // To get the keys alone, use the Keys property.
            IList<string> ilistKeys = openWith.Keys;

            // The elements of the list are strongly typed with the 
            // type that was specified for the SortedList keys.
            Console.WriteLine();
            foreach (string s in ilistKeys)
            {
                Console.WriteLine("Key = {0}", s);
            }

            // The Keys property is an efficient way to retrieve
            // keys by index.
            Console.WriteLine("\nIndexed retrieval using the Keys " +
                "property: Keys[2] = {0}", openWith.Keys[2]);

            // Use the Remove method to remove a key/value pair.
            Console.WriteLine("\nRemove(\"doc\")");
            openWith.Remove("doc");

            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("Key \"doc\" is not found.");
            }
            // Sort openwith by values option 1
            List<KeyValuePair<string, string>> myList = openWith.ToList();

            myList.Sort(
                (KeyValuePair<string, string> pair1,KeyValuePair<string, string> pair2)
                => pair1.Value.CompareTo(pair2.Value)       
            );
            Console.WriteLine("Sorted by values.....");
            foreach (var entry in myList)
            {
                Console.WriteLine("Value:{0}, Key: {1}", entry.Value, entry.Key);
            }
            // Sort openwith by values option 2
            var output = openWith.OrderByDescending(e => e.Value).Select(e =>e);
            Console.WriteLine("Sorted by values using OrderBy.....");
            foreach (var entry in output)
            {
                Console.WriteLine("Value:{0}, Key: {1}", entry.Value, entry.Key);
            }

        }
    }
}
