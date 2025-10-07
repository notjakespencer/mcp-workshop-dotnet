using MyMonkeyApp;

// Display welcome ASCII art
DisplayWelcomeBanner();

// Main application loop
bool running = true;
while (running)
{
    DisplayMenu();
    var choice = Console.ReadLine()?.Trim();

    Console.WriteLine();

    try
    {
        switch (choice)
        {
            case "1":
                ListAllMonkeys();
                break;
            case "2":
                GetMonkeyByName();
                break;
            case "3":
                GetRandomMonkey();
                break;
            case "4":
                running = false;
                Console.WriteLine("Thank you for using the Monkey App! Goodbye! 🐒");
                break;
            default:
                Console.WriteLine("❌ Invalid option. Please try again.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ An error occurred: {ex.Message}");
    }

    if (running)
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}

/// <summary>
/// Displays the welcome banner with ASCII art.
/// </summary>
static void DisplayWelcomeBanner()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(@"
    ╔═══════════════════════════════════════════════════════════╗
    ║                                                           ║
    ║          🐵  WELCOME TO THE MONKEY APP  🐵              ║
    ║                                                           ║
    ║              Explore the World of Monkeys!                ║
    ║                                                           ║
    ╚═══════════════════════════════════════════════════════════╝
    ");
    Console.ResetColor();

    // Display random ASCII monkey art
    DisplayRandomMonkeyArt();
    Console.WriteLine();
}

/// <summary>
/// Displays the main menu options.
/// </summary>
static void DisplayMenu()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\n╔════════════════════════════════╗");
    Console.WriteLine("║         MAIN MENU              ║");
    Console.WriteLine("╚════════════════════════════════╝");
    Console.ResetColor();
    Console.WriteLine();
    Console.WriteLine("  1. 📋 List all monkeys");
    Console.WriteLine("  2. 🔍 Get details for a specific monkey");
    Console.WriteLine("  3. 🎲 Get a random monkey");
    Console.WriteLine("  4. 🚪 Exit");
    Console.WriteLine();
    Console.Write("Enter your choice (1-4): ");
}

/// <summary>
/// Lists all available monkeys.
/// </summary>
static void ListAllMonkeys()
{
    var monkeys = MonkeyHelper.GetMonkeys();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("🌍 All Available Monkeys:");
    Console.WriteLine(new string('═', 80));
    Console.ResetColor();

    foreach (var monkey in monkeys)
    {
        DisplayMonkeyInfo(monkey);
        Console.WriteLine(new string('-', 80));
    }

    Console.WriteLine($"\nTotal monkeys: {monkeys.Count}");
}

/// <summary>
/// Gets and displays details for a specific monkey by name.
/// </summary>
static void GetMonkeyByName()
{
    Console.Write("Enter the name of the monkey: ");
    var name = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("❌ Name cannot be empty.");
        return;
    }

    var monkey = MonkeyHelper.GetMonkeyByName(name);

    if (monkey == null)
    {
        Console.WriteLine($"❌ Monkey '{name}' not found.");
        Console.WriteLine("\n💡 Tip: Try listing all monkeys to see available options.");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✅ Found: {monkey.Name}");
        Console.WriteLine(new string('═', 80));
        Console.ResetColor();
        DisplayMonkeyInfo(monkey);
    }
}

/// <summary>
/// Gets and displays a random monkey.
/// </summary>
static void GetRandomMonkey()
{
    var monkey = MonkeyHelper.GetRandomMonkey();

    if (monkey == null)
    {
        Console.WriteLine("❌ No monkeys available.");
        return;
    }

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("🎲 Random Monkey Selected!");
    Console.WriteLine(new string('═', 80));
    Console.ResetColor();

    DisplayMonkeyInfo(monkey);
    
    var accessCount = MonkeyHelper.GetAccessCount();
    Console.WriteLine($"\n📊 Random monkey has been accessed {accessCount} time(s).");
}

/// <summary>
/// Displays detailed information about a monkey.
/// </summary>
/// <param name="monkey">The monkey to display.</param>
static void DisplayMonkeyInfo(Monkey monkey)
{
    Console.WriteLine($"  🐒 Name:       {monkey.Name}");
    Console.WriteLine($"  📍 Location:   {monkey.Location}");
    Console.WriteLine($"  👥 Population: {monkey.Population:N0}");
    
    if (!string.IsNullOrWhiteSpace(monkey.Details))
    {
        Console.WriteLine($"  📝 Details:    {monkey.Details}");
    }
    
    if (!string.IsNullOrWhiteSpace(monkey.Image))
    {
        Console.WriteLine($"  🖼️  Image:      {monkey.Image}");
    }
}

/// <summary>
/// Displays random ASCII art of monkeys.
/// </summary>
static void DisplayRandomMonkeyArt()
{
    var artChoices = new[]
    {
        @"
            __,__
   .--.  .-'_..._''.  .--.
  ( () \/ __     __ \/ () )
   \ \_/ .'  \ /  '. \_/ /
    \  .'  () | ()  '.  /
     >/   _.- | -._   \<
    ((___.'   |   '.___))",

        @"
         .='  '=.
        /      _\
       |.-'``'-.| 
        \      /
      _/`-...-'\_ 
     (__) || (__)",

        @"
           @@@@@@@@@
        @@@@@@@@@@@@@@@
      @@@@@@@@@@@@@@@@@@@
     @@@@@@  @@@  @@@@@@@
     @@@@@@  @@@  @@@@@@@
     @@@@@@ ___ @@@@@@@@
      @@@@@|   |@@@@@@
       @@@@@@@@@@@@@
        @@@@@@@@@@@"
    };

    var random = new Random();
    var selectedArt = artChoices[random.Next(artChoices.Length)];
    
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine(selectedArt);
    Console.ResetColor();
}
