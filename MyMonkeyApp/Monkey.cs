namespace MyMonkeyApp;

/// <summary>
/// Represents a monkey species with its characteristics and habitat information.
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the name of the monkey species.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the location where the monkey species is commonly found.
    /// </summary>
    public required string Location { get; set; }

    /// <summary>
    /// Gets or sets the population count of the monkey species.
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Gets or sets the details about the monkey species.
    /// </summary>
    public string? Details { get; set; }

    /// <summary>
    /// Gets or sets the URL to an image of the monkey species.
    /// </summary>
    public string? Image { get; set; }
}
