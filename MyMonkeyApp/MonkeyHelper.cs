namespace MyMonkeyApp;

/// <summary>
/// Static helper class for managing monkey data and providing monkey-related operations.
/// </summary>
public static class MonkeyHelper
{
    private static readonly List<Monkey> _monkeys;
    private static readonly Random _random = new();
    private static int _accessCount = 0;

    static MonkeyHelper()
    {
        _monkeys = new List<Monkey>
        {
            new Monkey
            {
                Name = "Baboon",
                Location = "Africa & Arabia",
                Population = 100000,
                Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg"
            },
            new Monkey
            {
                Name = "Capuchin Monkey",
                Location = "Central & South America",
                Population = 23000,
                Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg"
            },
            new Monkey
            {
                Name = "Red-shanked douc",
                Location = "Vietnam",
                Population = 1300,
                Details = "The red-shanked douc is an endangered species of Old World monkey endemic to Indochina.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg"
            },
            new Monkey
            {
                Name = "Japanese Macaque",
                Location = "Japan",
                Population = 114000,
                Details = "The Japanese macaque, is a terrestrial Old World monkey species that is native to Japan.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/macaque.jpg"
            },
            new Monkey
            {
                Name = "Mandrill",
                Location = "Southern Cameroon, Gabon, Equatorial Guinea, and Congo",
                Population = 7000,
                Details = "The mandrill is a primate of the Old World monkey family, closely related to the baboons.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/mandrill.jpg"
            },
            new Monkey
            {
                Name = "Proboscis Monkey",
                Location = "Borneo",
                Population = 7000,
                Details = "The proboscis monkey or long-nosed monkey is an arboreal Old World monkey with an unusually large nose.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/proboscis.jpg"
            },
            new Monkey
            {
                Name = "Blue Monkey",
                Location = "Central and East Africa",
                Population = 200000,
                Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/blue.jpg"
            },
            new Monkey
            {
                Name = "Squirrel Monkey",
                Location = "Central & South America",
                Population = 300000,
                Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/squirrel.jpg"
            },
            new Monkey
            {
                Name = "Golden Lion Tamarin",
                Location = "Brazil",
                Population = 3200,
                Details = "The golden lion tamarin, also known as the golden marmoset, is a small New World monkey.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/tamarin.jpg"
            },
            new Monkey
            {
                Name = "Howler Monkey",
                Location = "Central & South America",
                Population = 100000,
                Details = "Howler monkeys are among the largest of the New World monkeys and are known for their loud calls.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/howler.jpg"
            }
        };
    }

    /// <summary>
    /// Gets all available monkey species.
    /// </summary>
    /// <returns>A list of all monkeys in the collection.</returns>
    public static List<Monkey> GetMonkeys()
    {
        return _monkeys;
    }

    /// <summary>
    /// Gets a random monkey from the collection and tracks access count.
    /// </summary>
    /// <returns>A randomly selected monkey, or null if no monkeys are available.</returns>
    public static Monkey? GetRandomMonkey()
    {
        if (_monkeys.Count == 0)
            return null;

        _accessCount++;
        var index = _random.Next(_monkeys.Count);
        return _monkeys[index];
    }

    /// <summary>
    /// Finds a monkey by its name (case-insensitive).
    /// </summary>
    /// <param name="name">The name of the monkey to find.</param>
    /// <returns>The monkey with the specified name, or null if not found.</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        return _monkeys.FirstOrDefault(m => 
            m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets the number of times a random monkey has been accessed.
    /// </summary>
    /// <returns>The access count for random monkey selections.</returns>
    public static int GetAccessCount()
    {
        return _accessCount;
    }
}
