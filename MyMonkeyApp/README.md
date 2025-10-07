# MyMonkeyApp

A C# console application for exploring monkey species data with an interactive menu interface.

## Features

- **List All Monkeys**: Display a comprehensive list of all monkey species with detailed information
- **Search by Name**: Find and view details for a specific monkey species (case-insensitive search)
- **Random Monkey**: Get a randomly selected monkey species (with access tracking)
- **ASCII Art**: Enjoy random monkey-themed ASCII art on startup for visual appeal

## Monkey Species Included

The application includes data for 10 monkey species:
- Baboon
- Capuchin Monkey
- Red-shanked Douc
- Japanese Macaque
- Mandrill
- Proboscis Monkey
- Blue Monkey
- Squirrel Monkey
- Golden Lion Tamarin
- Howler Monkey

## Requirements

- .NET 9.0 SDK or later

## Running the Application

1. Navigate to the MyMonkeyApp directory:
   ```bash
   cd MyMonkeyApp
   ```

2. Build the application:
   ```bash
   dotnet build
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

## Usage

Once the application starts, you'll see a welcome banner with ASCII art and a main menu with four options:

```
1. 📋 List all monkeys
2. 🔍 Get details for a specific monkey
3. 🎲 Get a random monkey
4. 🚪 Exit
```

Simply enter the number corresponding to your choice and press Enter.

### Example: Searching for a Monkey

1. Select option `2` from the main menu
2. Enter the monkey name (e.g., "Mandrill")
3. View the detailed information including location, population, and description

## Code Structure

- **Monkey.cs**: Data model representing a monkey species
- **MonkeyHelper.cs**: Static helper class managing monkey data and operations
- **Program.cs**: Main application with interactive console UI

## Features Highlight

- ✅ File-scoped namespaces for cleaner code
- ✅ Nullable reference types to prevent null reference exceptions
- ✅ XML documentation comments for all public methods
- ✅ Comprehensive error handling with try-catch blocks
- ✅ Color-coded console output for better readability
- ✅ Input validation and user-friendly error messages
- ✅ Random ASCII art variations for visual interest
