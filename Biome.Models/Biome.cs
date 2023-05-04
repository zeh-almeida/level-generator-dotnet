using GeneratorCommons;

namespace Biomes.Model;

/// <summary>
/// Defines the Biome model
/// </summary>
/// <see href="https://github.com/zeh-almeida/level-generator/blob/master/requirements/definitions/biome_definition.md"/>
public class Biome :
    IEquatable<Biome>,
    IComparable<Biome>
{
    #region Properties
    /// <summary>
    /// Name of the Biome. Unique identifier.
    /// </summary>
    /// <see href="https://github.com/zeh-almeida/level-generator/blob/master/requirements/definitions/biome_definition.md#name"/>
    public string Name { set; get; }

    /// <summary>
    /// Maximum room size when using this biome
    /// </summary>
    /// <see href="https://github.com/zeh-almeida/level-generator/blob/master/requirements/definitions/biome_definition.md#maximum-room-size"/>
    public short MaxRoomSize { set; get; }

    /// <summary>
    /// Minimum room size when using this biome
    /// </summary>
    /// <see href="https://github.com/zeh-almeida/level-generator/blob/master/requirements/definitions/biome_definition.md#minimum-room-size"/>
    public short MinRoomSize { set; get; }

    /// <summary>
    /// Relationship between biomes
    /// </summary>
    /// <see href="https://github.com/zeh-almeida/level-generator/blob/master/requirements/definitions/biome_definition.md#affinity-map"/>
    public ICollection<Affinity> Affinities { get; }
    #endregion

    #region Constructors
    /// <summary>
    /// Instantiates a new Biome with default properties
    /// </summary>
    /// <param name="name">Name of the Biome</param>
    /// <exception cref="ArgumentException">If name is null or empty</exception>
    public Biome(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

        this.Name = name;
        this.MaxRoomSize = Constants.DefaultTileSize;
        this.MinRoomSize = Constants.DefaultTileSize;

        this.Affinities = new HashSet<Affinity>();
    }
    #endregion

    #region Equality
    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is not null
            && obj is Biome biome
            && this.Equals(biome);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return this.Name.GetHashCode();
    }

    /// <inheritdoc/>
    public bool Equals(Biome? other)
    {
        return other is not null
            && this.Name.Equals(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }
    #endregion

    #region Comparison
    /// <inheritdoc/>
    public int CompareTo(Biome? other)
    {
        return other is null
            ? 1
            : this.Name.CompareTo(other.Name);
    }
    #endregion
}
