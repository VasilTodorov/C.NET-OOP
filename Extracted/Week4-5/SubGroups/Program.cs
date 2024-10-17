class Program
{/// <summary>
 ///  group SubGroup to create list of Continents where 
 ///  each Continent has it own counties and 
 ///  each country has its own cities like this table
 ///  
 /// </summary>
 /// <param name="args"></param>
    static void Main(string[] args)
    {
        City[] cities =
          {
              new City(){ContinentName ="Europe", CountryName="Germany", CityName="Berlin" },
              new City(){ContinentName ="Europe", CountryName="Germany", CityName="Frankfurt" },
              new City(){ContinentName ="Europe", CountryName="France", CityName="Paris" },
              new City(){ContinentName ="Europe", CountryName="France", CityName="Marseille" },
              new City(){ContinentName ="Asia", CountryName="Japan", CityName="Tokyo" },
              new City(){ContinentName ="Asia", CountryName="Korea", CityName="Seul" }

            };
        var grouped = cities
                     .GroupBy(x => x.CountryName) // group cities by country
                     .GroupBy(x => x.First().ContinentName);// group countries  by continent

        // Outline properties for the headings and the elements of each subgroups
        var final = grouped.Select(g1 =>
         new {
             ContinentName = g1.Key, // the heading for the largest group
             Countries = g1.Select(g2 =>
                 new {
                CountryName = g2.Key,// the heading for the inner group
                Cities = g2.Select(x => new City { CityName = x.CityName }).ToList()// The elements of the second subgroup
            }).ToList() // The elements of the first subgroup
         });

        foreach (var continent in final)
        {
            Console.WriteLine("{0} , Count of countries: {1}", continent.ContinentName, continent.Countries.Count());
            Console.WriteLine("{0, 19}", "Countries");
            foreach (var country in continent.Countries)
            {
                Console.WriteLine("{0, 20} , Count of cities: {1}", country.CountryName, country.Cities.Count());
                Console.WriteLine("{0, 19}", "Cities");
                foreach (var city in country.Cities)
                {
                    Console.WriteLine("{0, 30}", city.CityName);
                }
            }

        }
    }
}