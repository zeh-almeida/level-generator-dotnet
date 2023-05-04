namespace Biomes.Model;

/// <summary>
/// Determines the available Affinity Levels for Biomes
/// </summary>
/// <see cref="Biome.Affinities"/>
/// <see href="https://github.com/zeh-almeida/level-generator/blob/master/requirements/definitions/biome_definition.md#affinity"/>
public enum AffinityValue
{
    /// <summary>
    /// Biomes with this affinity can be paired anytime
    /// </summary>
    /// <see href="https://github.com/zeh-almeida/level-generator/blob/master/requirements/definitions/biome_definition.md#neutral-affinity"/>
    Neutral = 0,

    /// <summary>
    /// Biomes with this affinity prefer to be connected
    /// </summary>
    /// <see href="https://github.com/zeh-almeida/level-generator/blob/master/requirements/definitions/biome_definition.md#positive-affinity"/>
    Positive = 1,

    /// <summary>
    /// Biomes with this affinity cannot be connected in any way
    /// </summary>
    /// <see href="https://github.com/zeh-almeida/level-generator/blob/master/requirements/definitions/biome_definition.md#negative-affinity"/>
    Negative = 2
}

/// <summary>
/// Relationship between two distinct Biomes
/// </summary>
/// <see href="https://github.com/zeh-almeida/level-generator/blob/master/requirements/definitions/biome_definition.md#affinity"/>
public sealed record Affinity
{
    #region Properties
    /// <summary>
    /// <see cref="Biome"/> on the giving end of the relationship
    /// </summary>
    public Biome Left { get; }

    /// <summary>
    /// <see cref="Biome"/> on the receiving end of the relationship
    /// </summary>
    public Biome Right { get; }

    /// <summary>
    /// Level of Affinity between the two biomes
    /// </summary>
    public AffinityValue Value { get; }
    #endregion

    #region Constructors
    /// <summary>
    /// Creates a new affinity relationship between two <see cref="Biome"/>s
    /// </summary>
    /// <param name="left">Biome on the left side of the relationship</param>
    /// <param name="right">Biome on the right side of the relationship</param>
    /// <param name="affinity">Kind of affinity between the biomes. Defaults to <see cref="AffinityValue.Neutral"/></param>
    /// <exception cref="ArgumentNullException">If any parameter is null</exception>
    /// <exception cref="ArgumentException">If left equals the right</exception>
    /// <see href="https://github.com/zeh-almeida/level-generator/blob/master/requirements/definitions/biome_definition.md#affinity"/>
    public Affinity(
        Biome left,
        Biome right,
        AffinityValue affinity = AffinityValue.Neutral)
    {
        ArgumentNullException.ThrowIfNull(left, nameof(left));
        ArgumentNullException.ThrowIfNull(right, nameof(right));

        if (left.Equals(right))
        {
            throw new ArgumentException("Biomes must be different", nameof(right));
        }

        this.Left = left;
        this.Right = right;
        this.Value = affinity;
    }
    #endregion
}
