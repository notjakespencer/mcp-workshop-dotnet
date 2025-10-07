namespace MyMonkeyApp.Models;

/// <summary>
/// Conservation status categories for monkey species
/// </summary>
public enum ConservationStatus
{
    LeastConcern,
    Vulnerable,
    Endangered,
    CriticallyEndangered
}

/// <summary>
/// Geographic regions for categorizing monkey habitats
/// </summary>
public enum GeographicRegion
{
    Africa,
    Asia,
    CentralAmerica,
    SouthAmerica,
    NorthAmerica,
    Other
}

/// <summary>
/// Classification of monkey types
/// </summary>
public enum MonkeyType
{
    OldWorld,
    NewWorld,
    Pet
}

/// <summary>
/// Primary diet classifications
/// </summary>
public enum DietType
{
    Omnivore,
    Herbivore,
    Frugivore,
    Insectivore
}

/// <summary>
/// Habitat type preferences
/// </summary>
public enum HabitatType
{
    TropicalRainforest,
    DeciduousForest,
    Savanna,
    Mountains,
    Urban,
    Coastal
}