internal class Program
{
    private static void Main(string[] args)
    {
        // initialize array of invoices
        Invoice[] invoices = {
         new Invoice( 83, "Electric sander", 7, 57.98M ),
         new Invoice( 24, "Power saw", 18, 99.99M ),
         new Invoice( 7, "Sledge hammer", 11, 21.5M ),
         new Invoice( 77, "Hammer", 76, 11.99M ),
         new Invoice( 39, "Lawn mower", 3, 79.5M ),
         new Invoice( 68, "Screwdriver", 106, 6.99M ),
         new Invoice( 56, "Jig saw", 21, 11M ),
         new Invoice( 3, "Wrench", 34, 7.5M ) }; // end initializer list

        // use LINQ to sort invoices by description
        var sortedByDescription =
           from item in invoices
           orderby item.PartDescription
           select item;

        // display invoices, sorted by description
        Display(sortedByDescription, "Sorted by description:");

        // use LINQ to sort invoices by price
        var sortedByPrice =
           from item in invoices
           orderby item.Price
           select item;

        // display invoices, sorted by price
        Display(sortedByPrice, "Sorted by price:");

        // use LINQ to select description and quantity, sort by quantity
        var descriptionAndQuantity =
           from item in invoices
           orderby item.Quantity
           select new { item.PartDescription, item.Quantity };

        // display description and quantity, sorted by quantity
        Display(descriptionAndQuantity,
           "Select description and quantity, sort by quantity:");

        // use LINQ to select description and calculated
        // invoice total; sort by invoice total
        var descriptionAndTotal =
           from item in invoices
           let total = item.Quantity * item.Price
           orderby total
           select new { item.PartDescription, InvoiceTotal = total };

        // display description and calculated invoice total
        Display(descriptionAndTotal,
           "Select description and invoice total, sort by invoice total:");

        // use LINQ to select description and calculated
        // invoice total; sort by invoice total using TupleValue
        var descriptionAndTotalTuple =
           from item in invoices
           let total = item.Quantity * item.Price
           orderby total
           select (item.PartDescription,  total );

        // display description and calculated invoice total
        Display(descriptionAndTotalTuple,
           "Select description and invoice total tuple, sort by invoice total:");

        // use LINQ to filter previous query results on range of totals
        var totalBetween200And500 =
           from item in descriptionAndTotal
           where item.InvoiceTotal > 200M && item.InvoiceTotal < 500M
           select item;

        // display filtered descriptions and invoice totals
        Display(totalBetween200And500, string.Format(
           "Invoice totals between {0:C} and {1:C}:", 200, 500));

        // Groups of invoices  below and above $12 price sorted by price
        var groupedGreaterThan12 =
            from item in invoices
            orderby item.Price
            group item by (item.Price > 12m) into de
            select new { Key = de.Key, Detail = de };

        foreach (var item in groupedGreaterThan12)
        {
            Console.WriteLine("Category: {0}", (item.Key) ? "Price below $12" : "Price above $12");
            foreach (var itemDetail in item.Detail)
                Console.WriteLine("{0}", itemDetail);

        }
        // Groups of invoices  (0, 10],(10, 20], above 20 price sorted by price
        var groupedGreater =
            from item in invoices
            orderby item.Price
            group item by findInterval(item.Price) into de
            select new { Key = de.Key, Detail = de };

        string[] titles = new string[]{"Invoices with prices below $10",
                                      "Invoices with prices between $10 and $20",
                                      "Invoices with prices above $20"};
        Console.WriteLine();
        foreach (var item in groupedGreater)
        {
            Console.WriteLine("Category: {0}", titles[item.Key]);
            foreach (var itemDetail in item.Detail)
                Console.WriteLine("{0}", itemDetail);

        }

    } // end Main
    private static int findInterval(decimal price)
    {
      //  return (price <= 10) ? 0 : ((price > 20) ? 2 : 1);
        return price switch
        {
            var e when e <= 10 => 0,
            var e when e>20 => 2,
            _ => 1,

        };
    }
    // display a sequence of any type, each on a separate line
    public static void Display<T>(IEnumerable<T> data, string header)
    {
        Console.WriteLine(header); // display header

        // display each item on the console
        foreach (var item in data)
            Console.WriteLine(item);

        Console.WriteLine(); // add a blank line between data sets
    } // end method Display
}