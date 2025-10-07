namespace MyMonkeyApp.Models;

/// <summary>
/// Represents statistical information about the monkey collection
/// </summary>
public class MonkeyStatistics
{
    /// <summary>
    /// Total number of monkey species in the collection
    /// </summary>
    public int TotalSpecies { get; set; }

    /// <summary>
    /// Combined population of all monkey species
    /// </summary>
    public int TotalPopulation { get; set; }

    /// <summary>
    /// Number of endangered species (population < 5000)
    /// </summary>
    public int EndangeredSpecies { get; set; }

    /// <summary>
    /// Average population across all species
    /// </summary>
    public int AveragePopulation { get; set; }

    /// <summary>
    /// Largest population among all species
    /// </summary>
    public int LargestPopulation { get; set; }

    /// <summary>
    /// Smallest population among all species
    /// </summary>
    public int SmallestPopulation { get; set; }

    /// <summary>
    /// Number of times random monkey has been accessed
    /// </summary>
    public int RandomAccessCount { get; set; }

    /// <summary>
    /// Number of unique geographic locations
    /// </summary>
    public int UniqueLocations { get; set; }

    /// <summary>
    /// Percentage of endangered species
    /// </summary>
    public double EndangeredPercentage => TotalSpecies > 0 ? 
        Math.Round((double)EndangeredSpecies / TotalSpecies * 100, 1) : 0;

    /// <summary>
    /// Returns a formatted string representation of the statistics
    /// </summary>
    public override string ToString()
    {
        return $"Species: {TotalSpecies}, Population: {TotalPopulation:N0}, " +
               $"Endangered: {EndangeredSpecies} ({EndangeredPercentage}%), " +
               $"Random Access: {RandomAccessCount}";
    }
}