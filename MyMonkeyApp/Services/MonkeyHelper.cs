using MyMonkeyApp.Models;

namespace MyMonkeyApp.Services;

/// <summary>
/// Static helper class for managing monkey data and providing access methods
/// </summary>
public static class MonkeyHelper
{
    private static readonly Random _random = new();
    private static List<Monkey>? _monkeys;
    private static int _randomAccessCount = 0;
    private static readonly object _lockObject = new();

    /// <summary>
    /// Gets the total number of times a random monkey has been accessed
    /// </summary>
    public static int RandomAccessCount 
    { 
        get 
        { 
            lock (_lockObject) 
            { 
                return _randomAccessCount; 
            } 
        } 
    }

    /// <summary>
    /// Gets all available monkeys from the data source
    /// </summary>
    /// <returns>A list of all monkey species</returns>
    public static List<Monkey> GetMonkeys()
    {
        if (_monkeys == null)
        {
            InitializeMonkeyData();
        }
        
        return _monkeys ?? new List<Monkey>();
    }

    /// <summary>
    /// Gets a random monkey from the collection and increments the access counter
    /// </summary>
    /// <returns>A randomly selected monkey, or null if no monkeys are available</returns>
    public static Monkey? GetRandomMonkey()
    {
        var monkeys = GetMonkeys();
        
        if (monkeys.Count == 0)
        {
            return null;
        }

        lock (_lockObject)
        {
            _randomAccessCount++;
        }

        var randomIndex = _random.Next(monkeys.Count);
        return monkeys[randomIndex];
    }

    /// <summary>
    /// Finds a monkey by name (case-insensitive search)
    /// </summary>
    /// <param name="name">The name of the monkey to find</param>
    /// <returns>The monkey with the matching name, or null if not found</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return null;
        }

        var monkeys = GetMonkeys();
        return monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Searches for monkeys whose names contain the specified search term
    /// </summary>
    /// <param name="searchTerm">The term to search for in monkey names</param>
    /// <returns>A list of monkeys with names containing the search term</returns>
    public static List<Monkey> SearchMonkeysByName(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return new List<Monkey>();
        }

        var monkeys = GetMonkeys();
        return monkeys.Where(m => 
            m.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    /// <summary>
    /// Gets monkeys filtered by location
    /// </summary>
    /// <param name="location">The location to filter by</param>
    /// <returns>A list of monkeys from the specified location</returns>
    public static List<Monkey> GetMonkeysByLocation(string location)
    {
        if (string.IsNullOrWhiteSpace(location))
        {
            return new List<Monkey>();
        }

        var monkeys = GetMonkeys();
        return monkeys.Where(m => 
            m.Location.Contains(location, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    /// <summary>
    /// Gets endangered monkeys (population < 5000)
    /// </summary>
    /// <returns>A list of endangered monkey species</returns>
    public static List<Monkey> GetEndangeredMonkeys()
    {
        var monkeys = GetMonkeys();
        return monkeys.Where(m => m.IsEndangered).ToList();
    }

    /// <summary>
    /// Gets statistics about the monkey collection
    /// </summary>
    /// <returns>A summary of monkey collection statistics</returns>
    public static MonkeyStatistics GetStatistics()
    {
        var monkeys = GetMonkeys();
        
        return new MonkeyStatistics
        {
            TotalSpecies = monkeys.Count,
            TotalPopulation = monkeys.Sum(m => m.Population),
            EndangeredSpecies = monkeys.Count(m => m.IsEndangered),
            AveragePopulation = monkeys.Count > 0 ? (int)monkeys.Average(m => m.Population) : 0,
            LargestPopulation = monkeys.Count > 0 ? monkeys.Max(m => m.Population) : 0,
            SmallestPopulation = monkeys.Count > 0 ? monkeys.Min(m => m.Population) : 0,
            RandomAccessCount = RandomAccessCount,
            UniqueLocations = monkeys.Select(m => m.Location).Distinct().Count()
        };
    }

    /// <summary>
    /// Resets the random access counter
    /// </summary>
    public static void ResetRandomAccessCount()
    {
        lock (_lockObject)
        {
            _randomAccessCount = 0;
        }
    }

    /// <summary>
    /// Forces a refresh of the monkey data from the source
    /// </summary>
    public static void RefreshData()
    {
        _monkeys = null;
        InitializeMonkeyData();
    }

    /// <summary>
    /// Initializes the monkey data collection with hardcoded data from MCP server
    /// </summary>
    private static void InitializeMonkeyData()
    {
        // Data retrieved from MCP monkey server
        _monkeys = new List<Monkey>
        {
            new Monkey
            {
                Name = "Baboon",
                Location = "Africa & Asia",
                Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg",
                Population = 10000,
                Latitude = -8.783195,
                Longitude = 34.508523
            },
            new Monkey
            {
                Name = "Capuchin Monkey",
                Location = "Central & South America",
                Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg",
                Population = 23000,
                Latitude = 12.769013,
                Longitude = -85.602364
            },
            new Monkey
            {
                Name = "Blue Monkey",
                Location = "Central and East Africa",
                Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/bluemonkey.jpg",
                Population = 12000,
                Latitude = 1.957709,
                Longitude = 37.297204
            },
            new Monkey
            {
                Name = "Squirrel Monkey",
                Location = "Central & South America",
                Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/saimiri.jpg",
                Population = 11000,
                Latitude = -8.783195,
                Longitude = -55.491477
            },
            new Monkey
            {
                Name = "Golden Lion Tamarin",
                Location = "Brazil",
                Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/tamarin.jpg",
                Population = 19000,
                Latitude = -14.235004,
                Longitude = -51.92528
            },
            new Monkey
            {
                Name = "Howler Monkey",
                Location = "South America",
                Details = "Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/alouatta.jpg",
                Population = 8000,
                Latitude = -8.783195,
                Longitude = -55.491477
            },
            new Monkey
            {
                Name = "Japanese Macaque",
                Location = "Japan",
                Details = "The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/macasa.jpg",
                Population = 1000,
                Latitude = 36.204824,
                Longitude = 138.252924
            },
            new Monkey
            {
                Name = "Mandrill",
                Location = "Southern Cameroon, Gabon, and Congo",
                Details = "The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/mandrill.jpg",
                Population = 17000,
                Latitude = 7.369722,
                Longitude = 12.354722
            },
            new Monkey
            {
                Name = "Proboscis Monkey",
                Location = "Borneo",
                Details = "The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the south-east Asian island of Borneo.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/borneo.jpg",
                Population = 15000,
                Latitude = 0.961883,
                Longitude = 114.55485
            },
            new Monkey
            {
                Name = "Sebastian",
                Location = "Seattle",
                Details = "This little trouble maker lives in Seattle with James and loves traveling on adventures with James and tweeting @MotzMonkeys. He by far is an Android fanboy and is getting ready for the new Google Pixel 9!",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/sebastian.jpg",
                Population = 1,
                Latitude = 47.606209,
                Longitude = -122.332071
            },
            new Monkey
            {
                Name = "Henry",
                Location = "Phoenix",
                Details = "An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. His favorite platform is iOS by far and is excited for the new iPhone Xs!",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/henry.jpg",
                Population = 1,
                Latitude = 33.448377,
                Longitude = -112.074037
            },
            new Monkey
            {
                Name = "Red-shanked douc",
                Location = "Vietnam",
                Details = "The red-shanked douc is a species of Old World monkey, among the most colourful of all primates. The douc is an arboreal and diurnal monkey that eats and sleeps in the trees of the forest.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg",
                Population = 1300,
                Latitude = 16.111648,
                Longitude = 108.262122
            },
            new Monkey
            {
                Name = "Mooch",
                Location = "Seattle",
                Details = "An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. Her favorite platform is iOS by far and is excited for the new iPhone 16!",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/Mooch.PNG",
                Population = 1,
                Latitude = 47.608013,
                Longitude = -122.335167
            }
        };
    }
}