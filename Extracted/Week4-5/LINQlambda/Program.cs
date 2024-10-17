using InvoicesLINQ;

class Program
{
    static void Main(string[] args)
    {
        Invoice[] invoices =
        {
               new Invoice( 83, "Electric sander", 7, 57.98m),
               new Invoice(24,"Power saw", 18, 99.99m),
               new Invoice(7, "Sledge hammer", 11, 21.50m),
               new Invoice(77, "Hammer", 76, 11.99m),
               new Invoice(39, "Lawn mower", 3, 79.50m),
               new Invoice(68, "Screwdriver", 106, 6.99m),
               new Invoice(68, "Screwdriver", 10, 6.99m),
               new Invoice(68, "Screwdriver", 1, 6.99m),
               new Invoice(56, "Jig saw", 21, 11.00m),
               new Invoice(3, "Wrench", 34, 7.50m),
            };
        // Invoices sorted by Description ascending
        var sortedByDescription = invoices
                                  .OrderBy(invoice => invoice.PartDescription)
                                  .ThenByDescending(invoice => invoice.Quantity)
                                  .Select(invoice => invoice);

        Display(sortedByDescription);
        //invoices projected to display Description and total prce

        // projected by description and total price
        Console.WriteLine("Projected by description and total price");
        var descriptionTotalPrice = invoices
                                   .Select(invoice => new
                                   {
                                       invoice.PartDescription,
                                       TotalPrice = invoice.Price * invoice.Quantity
                                   });

        Display(descriptionTotalPrice);
        foreach (var item in descriptionTotalPrice)
        {
            Console.WriteLine("Desription: {0, 30}, price: {1, 10:C}",
                                           item.PartDescription,
                                           item.TotalPrice);

        }
        // sorted by Total price3


        Console.WriteLine("Sorted by total price");
        // sorted by Total price3
        var descriptionTotalPriceSorted = descriptionTotalPrice
                                          .AsParallel()// execute a pararllel query
                                          .OrderByDescending(i => i.TotalPrice)
                                          .Select(i => i);

        foreach (var item in descriptionTotalPriceSorted)
        {
            Console.WriteLine("Desription: {0, 30}, price: {1, 10:C}",
                                           item.PartDescription,
                                           item.TotalPrice);

        }

        // Filter by total price
        var pricceAbove500 = descriptionTotalPrice
                            .Where(item => item.TotalPrice > 100m)
                            .Select(item => item)
                            .OrderByDescending(item => item.TotalPrice);
        Console.WriteLine("Prices above 100");
        Display(pricceAbove500);

        // Grouping by PartID
        var groupByPartId = invoices
                            .GroupBy(item => GroupName(item.PartNumber))
                            .Select(item => item);
        Console.WriteLine("Items groupped by even/odd partnumber");
        foreach (var groups in groupByPartId)
        {
            Console.WriteLine("Group name:{0}, Number of elements in group: {1}", groups.Key, groups.Count());
            foreach (var item in groups)
            {
                Console.WriteLine(item);
            }

        }

        // Grouping by TotalPrice below 100, between 100 and 500, above 500
        var groupByTotalPrice = descriptionTotalPrice
                            .GroupBy(item => GroupPrice(item.TotalPrice) )
                            .Select(item => item)
                            .OrderBy(item => item.Key[0]);

        Console.WriteLine("Items groupped by total price");
        foreach (var groups in groupByTotalPrice)
        {
            Console.WriteLine("Group name:{0, -20}, Number of elements in group: {1,10}\n", groups.Key, groups.Count());
            foreach (var item in groups)
            {
                Console.WriteLine("Description:{0,20}, Total price: {1,10}",
                                                     item.PartDescription, item.TotalPrice);
            }

        }
    }
    private static string GroupPrice(decimal price)
    {
        //if (price < 100m)
        //{
        //    return "1. Price below 100";
        //}
        //else
        //{
        //    if (price > 500m)
        //    {
        //        return "3. Price above 500";
        //    }
        //    else
        //    {
        //        return "2. Price between 100 and 500";
        //    }
        //}
        return price switch
        {
            < 100m              => "1. Price below 100",
            >= 100m and <= 500m => "2. Price between 100 and 500",
            > 500m              => "3. Price above 500"
        };

    }
    private enum RemainderTypes { ZERO = 0, ONE = 1 }
    private static string Remainders(int number)
    {
        string[] outputString = { "0", "1", "2" };
        // return ((RemainderTypes)  number).ToString();
        return outputString[number];
    }
    private static string GroupName(int number)
    {
        return number % 2 == 0 ? "Even part number" : "Odd part number";
    }
    private static void Display<T>(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }
}