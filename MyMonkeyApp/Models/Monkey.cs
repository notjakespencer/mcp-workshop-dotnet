namespace MyMonkeyApp.Models;

/// <summary>
/// Represents a monkey species with location, population, and descriptive information
/// </summary>
public class Monkey
{
    /// <summary>
    /// The name of the monkey species
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The geographic location where this monkey species is found
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Detailed description of the monkey species
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// URL to an image of the monkey species
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Current population count of this species
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Geographic latitude coordinate
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Geographic longitude coordinate
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Geographic coordinates as a formatted string
    /// </summary>
    public string Coordinates => $"{Latitude:F2}, {Longitude:F2}";

    /// <summary>
    /// Indicates if this is an endangered species (population < 5000)
    /// </summary>
    public bool IsEndangered => Population < 5000;

    /// <summary>
    /// Conservation status based on population
    /// </summary>
    public ConservationStatus ConservationStatus => Population switch
    {
        < 500 => ConservationStatus.CriticallyEndangered,
        < 2000 => ConservationStatus.Endangered,
        < 10000 => ConservationStatus.Vulnerable,
        _ => ConservationStatus.LeastConcern
    };

    /// <summary>
    /// Returns a formatted string representation of the monkey
    /// </summary>
    public override string ToString()
    {
        return $"{Name} ({Location}) - Population: {Population:N0}";
    }
}