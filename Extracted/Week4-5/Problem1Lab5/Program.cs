using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace Problem1Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ demo with Invoice objects.");

            Invoice[] invoices =
            {
               new Invoice(83, "Electric sander", 7  , 57.98m),
               new Invoice(24, "Power saw      ", 18 , 99.99m),
               new Invoice(7 , "Sledge hammer  ", 11 , 21.5m),
               new Invoice(77, "Hammer         ", 76 , 11.99m),
               new Invoice(83, "Electric sander", 71  , 57.98m),
               new Invoice(24, "Power saw      ", 181 , 99.99m),
               new Invoice(7 , "Sledge hammer  ", 111 , 21.5m),
               new Invoice(77, "Hammer         ", 761 , 11.99m),
               new Invoice(39, "Lawn mower     ", 3  , 79.50m),
               new Invoice(68, "Screwdriver    ", 106, 6.99m),
               new Invoice(56, "Jig saw        ", 21 , 11.00m),
               new Invoice(3 , "Wrench         " , 34 , 7.50m )
            };

            // sort by  description ascending
            // declare LINQ
            var sortedByDescription = from invoice in invoices
                                      orderby invoice.PartDescription, invoice.Quantity descending
                                      select invoice;
            Console.WriteLine("SORTED INVOICES ASCENDING");
            foreach (var invoice in sortedByDescription)
            {
                Console.WriteLine($"Invoice description: {invoice.PartDescription}: {invoice}");
            }
            Console.WriteLine("SORTED INVOICES Descending with lambdas");
            var sortedByDescriptionLambda = invoices
                                          .OrderByDescending(invoice => invoice.PartDescription)
                                          .ThenByDescending(invoice => invoice.Quantity);
            foreach (var invoice in sortedByDescriptionLambda)
            {
                Console.WriteLine($"Invoice description: {invoice.PartDescription}: {invoice}");
            }

            //Select the PartDescription and Quantity and sort the results by Quantity
            Console.WriteLine("Select the PartDescription and Quantity and sort the results by Quantity");
            var sortByQuantity = from invoice in invoices
                                 orderby invoice.Quantity
                                 select (Description: invoice.PartDescription, Quantity: invoice.Quantity);
            foreach (var invoice in sortByQuantity)
            {
                Console.WriteLine($"Invoice description: {invoice.Description}: " +
                                  $"Quantity:{invoice.Quantity}");
            }

            Console.WriteLine("Lambda:Select the PartDescription and Quantity and sort the results by Quantity");
            var sortByQuantityLambda = invoices
                                       .OrderBy(invoice => invoice.Quantity)
                                       .Select(inv => (Description: inv.PartDescription, Quantity: inv.Quantity));
            foreach (var invoice in sortByQuantityLambda)
            {
                Console.WriteLine($"Invoice description: {invoice.Description}: " +
                                  $"Quantity:{invoice.Quantity}");
            }
            //select from each Invoice the PartDescription and the value of the Invoice (i.e., Quantity * Price).
            Console.WriteLine("Select from each Invoice the PartDescription and the value of the Invoice");
            var sortByInvoiceValue= from invoice in invoices
                                    let  invoiceValue = invoice.Quantity *invoice.Price
                                    orderby invoiceValue descending
                                    select new {Description = invoice.PartDescription,InvoiceValue= invoiceValue };
            foreach (var invoice in sortByInvoiceValue)
            {
                Console.WriteLine($"Invoices sorted by value: {invoice.Description}: " +
                                  $"Quantity:{invoice.InvoiceValue}");
            }
            Console.WriteLine("Lambda:Select from each Invoice the PartDescription and the value of the Invoice");

            var sortByInvoiceValueLambda = invoices
                                           .Where(inv=>inv.Price > 70) // Filter invoices by price
                                           .Select(inv => new
                                           {
                                               Description = inv.PartDescription,
                                               InvoiceValue = inv.Quantity * inv.Price
                                           })
                                           .OrderBy(inv => inv.Description);
            foreach (var invoice in sortByInvoiceValueLambda)
            {
                Console.WriteLine($"Invoices sorted by value: {invoice.Description}: " +
                                  $"Quantity:{invoice.InvoiceValue}");
            }
            // Group invoices in two groups

            var groupInvoicesInTwo = from invoice in invoices
                                     group invoice by GroupInvoices(invoice.Price) into grp
                                      select grp;

            foreach (var group in groupInvoicesInTwo)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static string GroupInvoices(decimal price) {
            return price switch
            {
                <12m => "Prices below $12",
                >=12m => "Prices above $12"
            };
        }
    }
}