using System.ComponentModel;

namespace Problem1
{
    public class Product
    {
        #region Fields
        private decimal price;
        private static long cnt;
        public readonly string ID;
        private static Random? rnd = new();
        public List<int> WeeklyPurchases;

        #endregion
        #region ExampleTable
        static List<Product> products = new List<Product>()
            {   new Product("Electric sander", Type.M, new List<int>(){99, 82, 81, 79}, 157.98m),
                new Product("Power saw", Type.M, new List<int>{ 99, 86, 90, 94 }, 99.99m),
                new Product("Sledge hammer",Type.F, new List<int>{ 93, 92, 80, 87}, 21.50m),
                new Product("Hammer",       Type.M, new List<int>{ 97, 89, 85, 82}, 11.99m),
                new Product("Lawn mower",   Type.F, new List<int>{ 35, 72, 91, 70}, 139.50m),
                new Product("Screwdriver",  Type.F, new List<int>{ 88, 94, 65, 91}, 56.99m),
                new Product("Jig saw",      Type.M, new List<int>{ 75, 84, 91, 39}, 11.00m),
                new Product("Wrench",       Type.F, new List<int>{ 97, 92, 81, 60}, 17.50m),
                new Product("Sledge hammer",Type.M, new List<int>{ 75, 84, 91, 39}, 21.50m),
                new Product("Hammer",       Type.F, new List<int>{ 94, 92, 91, 91}, 11.99m),
                new Product("Lawn mower",   Type.M, new List<int>{ 96, 85, 91, 60}, 179.50m),
                new Product("Screwdriver",  Type.M, new List<int>{ 96, 85, 51, 30}, 66.99m),
            };
        #endregion
        #region Constructors
        public Product(string description, Type category, List<int> weeklyPurchases, decimal price)
        {
            Description = description;
            Category = category;
            WeeklyPurchases = weeklyPurchases;
            Price = price;

            rnd = new System.Random();
            Quarter = (YearlyQuarter)(1 + rnd.Next(4));
            ID = ((char)(category)).ToString() + $"{cnt++:D6}";
        }

        public Product() : this("", Type.M, new List<int>(), 0m)
        {

        }

        public Product(Product p) : this(p.Description, p.Category, p.WeeklyPurchases, p.Price)
        {

        }
        #endregion
        #region Properties
        public Type Category
        {
            get;
            set;
            
        }

        public string Description
        {
            get;
            set;
            
        }

        public decimal Price
        {
            get => price;
            set
            {
                price = value >= 0m ? value : 0m;
            }
        }

        public YearlyQuarter Quarter
        {
            get;
            set;
            
        }
        #endregion
        #region LINQ
        public static void GroupByCategoryCountDescending()
        {
            var sort = products
                        .GroupBy(product => product.Category)
                        .OrderByDescending(group => group.Count())
                        .Select(group => new { Category = (char)group.Key, Count = group.Count() });

            foreach (var item in sort)
            {
                Console.WriteLine($"Category group: {item.Category}");
                Console.WriteLine($"    Number of products of Type {item.Category} in this group {item.Count}");
            }
        }

        public static void GroupByQtrAndProductPriceAvg()
        {
            var sort = products
                        .GroupBy(product => product.Quarter)
                        .OrderBy(group => group.Key)
                        .Select(group => new { Quarter = group.Key, Average = group.Select(p => p.Price).Average() });

            foreach (var item in sort)
            {
                Console.WriteLine($"Quarter group: {item.Quarter}");
                Console.WriteLine($"    Average price per quarter {item.Average:C}");

            }
        }

        public static void GroupByQtrCategoryWeeklySum()
        {
            var sort2 =
                 from product in products
                 group product by product.Quarter into g1
                 from g2 in (from product in g1
                             group product by product.Category)
                 group g2 by g1.Key into g3
                 orderby g3.Key
                 select (Key: g3.Key, Content: (from g1 in g3
                                                select (Key: g1.Key, Content: (from p in g1
                                                                               select (Description: p.Description, Sum: p.WeeklyPurchases.Sum())))));


            foreach (var quarter in sort2)
            {
                Console.WriteLine($"Quarter group: {quarter.Key}");
                foreach (var category in quarter.Content)
                {
                    Console.WriteLine($"    Category group: {category.Key}");
                    foreach (var product in category.Content)
                        Console.WriteLine("         " + product);
                    Console.WriteLine();
                }

            }
        }

        public static void GroupByQtrCategoryAndProducts()
        {
            var sort2 =
                from product in products
                group product by product.Quarter into g1
                from g2 in (from product in g1
                            orderby product.Category
                            group product by product.Category)
                group g2 by g1.Key into g3
                orderby g3.Key
                select (Key: g3.Key, Content: (from g1 in g3
                                               select (Key: g1.Key, Content: (from p in g1
                                                                              orderby p.Category
                                                                              select p))));


            foreach (var quarter in sort2)
            {
                Console.WriteLine($"Quarter group: {quarter.Key}");
                foreach (var category in quarter.Content)
                {
                    Console.WriteLine($"    Category group: {category.Key}");
                    foreach (var product in category.Content)
                        Console.WriteLine("         " + product);
                    Console.WriteLine();
                }

            }
        }

        public static void GroupByQtrMinMaxPrice()
        {
            var sort =
                from product in products
                group product by product.Quarter into g
                orderby g.Key
                let seq = (from p in g
                           select p.Price)
                select new { Key = g.Key, MinPrice = seq.Min(), MaxPrice = seq.Max() };

            foreach (var quarter in sort)
            {
                Console.WriteLine($"Quarter group {quarter.Key}:");
                Console.WriteLine($"        Min price per Quarter: {quarter.MinPrice:C}");
                Console.WriteLine($"        Max price per Quarter: {quarter.MaxPrice:C}");
            }
        }

        #endregion
        #region GeneralMethods
        public override string ToString()
        {
            string str = $"ID:  {ID},   ";
            str += "WeeklyPurchases:    ";
            foreach (var item in WeeklyPurchases)
            {
                str += item.ToString() + " ";
            }
            return str;
        } 
        #endregion
    }

    public enum YearlyQuarter
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4
    }

    public enum Type
    {
        M = 'M',
        F = 'F'
    }
}
