using MyMonkeyApp.Models;
using MyMonkeyApp.Services;

namespace MyMonkeyApp;

/// <summary>
/// Main program class for the Monkey Console Application
/// </summary>
class Program
{
    private static readonly Random _random = new();

    /// <summary>
    /// Array of monkey-themed ASCII art
    /// </summary>
    private static readonly string[] MonkeyArt = new[]
    {
        @"
    🐵 Welcome to Monkey Explorer! 🐵
        .-""-.
       /     \
      | () () |
       \  ^  /
        |||||
        |||||
",
        @"
      🍌 Banana Time! 🍌
       .--..--..--..--..--.
      (    (    (    (    (
       '--'  '--'  '--'  '--'
         🐒 Going bananas! 🐒
",
        @"
    🌴 Monkey Business 🌴
         .-.   .-.
        (   ) (   )
         '-'   '-'
          |     |
        .-|     |-.
       (  |     |  )
        '-|     |-'
          |_____|
",
        @"
      🎯 Random Monkey Generator 🎯
            .-""""""-.
           /        \
          |  ^    ^  |
          |     o    |
           \   ___  /
            '-----'
             🐵🎲
",
        @"
    🔍 Monkey Detective 🔍
         .-""-.
        /  👀  \
       | 🔍   👀 |
        \   👃  /
         '-----'
       Finding monkeys...
"
    };

    static void Main(string[] args)
    {
        Console.Clear();
        DisplayRandomArt();
        
        Console.WriteLine("🐵 Welcome to the Monkey Explorer Console App! 🐵");
        Console.WriteLine("Discover amazing monkey species from around the world!");
        Console.WriteLine();

        bool running = true;
        while (running)
        {
            DisplayMenu();
            var choice = GetUserChoice();

            switch (choice)
            {
                case 1:
                    ListAllMonkeys();
                    break;
                case 2:
                    GetMonkeyByName();
                    break;
                case 3:
                    GetRandomMonkey();
                    break;
                case 4:
                    ExitApplication();
                    running = false;
                    break;
                default:
                    Console.WriteLine("❌ Invalid choice! Please select 1-4.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    /// <summary>
    /// Displays random ASCII art
    /// </summary>
    private static void DisplayRandomArt()
    {
        var randomArt = MonkeyArt[_random.Next(MonkeyArt.Length)];
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(randomArt);
        Console.ResetColor();
    }

    /// <summary>
    /// Displays the main menu options
    /// </summary>
    private static void DisplayMenu()
    {
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║           🐵 MONKEY MENU 🐵            ║");
        Console.WriteLine("╠════════════════════════════════════════╣");
        Console.WriteLine("║  1. 📋 List all monkeys                ║");
        Console.WriteLine("║  2. 🔍 Get details for a specific      ║");
        Console.WriteLine("║     monkey by name                     ║");
        Console.WriteLine("║  3. 🎲 Get a random monkey             ║");
        Console.WriteLine("║  4. 🚪 Exit app                        ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.Write("\nPlease select an option (1-4): ");
    }

    /// <summary>
    /// Gets and validates user input for menu choice
    /// </summary>
    /// <returns>The selected menu option</returns>
    private static int GetUserChoice()
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 4)
            {
                return choice;
            }
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("❌ Invalid input! Please enter a number between 1-4: ");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Lists all available monkeys in a formatted table
    /// </summary>
    private static void ListAllMonkeys()
    {
        Console.Clear();
        DisplayRandomArt();
        
        Console.WriteLine("📋 ALL MONKEY SPECIES");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        
        var monkeys = MonkeyHelper.GetMonkeys();
        var stats = MonkeyHelper.GetStatistics();
        
        Console.WriteLine($"Total Species: {stats.TotalSpecies} | Total Population: {stats.TotalPopulation:N0} | Endangered: {stats.EndangeredSpecies}");
        Console.WriteLine();

        // Table header
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{"Name",-20} {"Location",-25} {"Population",-12} {"Status",-15}");
        Console.WriteLine(new string('-', 75));
        Console.ResetColor();

        // Display each monkey
        foreach (var monkey in monkeys.OrderBy(m => m.Name))
        {
            var statusColor = monkey.IsEndangered ? ConsoleColor.Red : ConsoleColor.Green;
            var status = monkey.ConservationStatus.ToString();
            
            Console.Write($"{monkey.Name,-20} {monkey.Location,-25} {monkey.Population,-12:N0} ");
            
            Console.ForegroundColor = statusColor;
            Console.WriteLine($"{status,-15}");
            Console.ResetColor();
        }
        
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("🔍 Tip: Use option 2 to get detailed information about any monkey!");
        Console.ResetColor();
    }

    /// <summary>
    /// Gets details for a specific monkey by name
    /// </summary>
    private static void GetMonkeyByName()
    {
        Console.Clear();
        DisplayRandomArt();
        
        Console.WriteLine("🔍 FIND MONKEY BY NAME");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.Write("Enter the monkey name: ");
        
        var name = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Please enter a valid monkey name!");
            Console.ResetColor();
            return;
        }

        var monkey = MonkeyHelper.GetMonkeyByName(name);
        
        if (monkey == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ No monkey found with the name '{name}'");
            Console.ResetColor();
            
            // Suggest similar names
            var suggestions = MonkeyHelper.SearchMonkeysByName(name);
            if (suggestions.Any())
            {
                Console.WriteLine("\n💡 Did you mean one of these?");
                foreach (var suggestion in suggestions.Take(3))
                {
                    Console.WriteLine($"   • {suggestion.Name}");
                }
            }
            return;
        }

        DisplayMonkeyDetails(monkey);
    }

    /// <summary>
    /// Gets and displays a random monkey
    /// </summary>
    private static void GetRandomMonkey()
    {
        Console.Clear();
        DisplayRandomArt();
        
        Console.WriteLine("🎲 RANDOM MONKEY GENERATOR");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        
        var monkey = MonkeyHelper.GetRandomMonkey();
        
        if (monkey == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ No monkeys available!");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("🎉 Here's your random monkey! 🎉");
        Console.ResetColor();
        Console.WriteLine();
        
        DisplayMonkeyDetails(monkey);
        
        var stats = MonkeyHelper.GetStatistics();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"📊 Random monkeys accessed: {stats.RandomAccessCount} times");
        Console.ResetColor();
    }

    /// <summary>
    /// Displays detailed information about a monkey
    /// </summary>
    /// <param name="monkey">The monkey to display details for</param>
    private static void DisplayMonkeyDetails(Monkey monkey)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"🐵 {monkey.Name}");
        Console.ResetColor();
        
        Console.WriteLine($"📍 Location: {monkey.Location}");
        Console.WriteLine($"👥 Population: {monkey.Population:N0}");
        Console.WriteLine($"🌍 Coordinates: {monkey.Coordinates}");
        
        // Conservation status with color coding
        Console.Write("🛡️  Conservation Status: ");
        var statusColor = monkey.ConservationStatus switch
        {
            ConservationStatus.CriticallyEndangered => ConsoleColor.DarkRed,
            ConservationStatus.Endangered => ConsoleColor.Red,
            ConservationStatus.Vulnerable => ConsoleColor.Yellow,
            _ => ConsoleColor.Green
        };
        
        Console.ForegroundColor = statusColor;
        Console.WriteLine(monkey.ConservationStatus);
        Console.ResetColor();
        
        Console.WriteLine($"🔗 Image: {monkey.Image}");
        Console.WriteLine();
        Console.WriteLine("📖 Details:");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"   {monkey.Details}");
        Console.ResetColor();
    }

    /// <summary>
    /// Displays exit message and application statistics
    /// </summary>
    private static void ExitApplication()
    {
        Console.Clear();
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
    🐵 Thanks for exploring monkeys! 🐵
         .-""-.
        /     \
       | () () |
        \  ^  /
         |||||
         |||||
        Goodbye!
");
        Console.ResetColor();

        var stats = MonkeyHelper.GetStatistics();
        Console.WriteLine("📊 Session Statistics:");
        Console.WriteLine($"   • Total species available: {stats.TotalSpecies}");
        Console.WriteLine($"   • Random monkeys accessed: {stats.RandomAccessCount}");
        Console.WriteLine($"   • Endangered species: {stats.EndangeredSpecies}");
        Console.WriteLine();
        Console.WriteLine("🌍 Keep exploring and learning about our amazing world! 🌍");
    }
}