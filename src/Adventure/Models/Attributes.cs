namespace Adventure.Models;

public class Attributes
{
    /// <summary>
    /// Determines the maximum HP.
    /// </summary>
    public int Constitution { get; set; } = 1;
    
    /// <summary>
    /// Determines the maximum Stamina.
    /// </summary>
    public int Stamina { get; set; } = 1;
    
    /// <summary>
    /// Determines how much Stamina is recovered per turn.
    /// </summary>
    public int Endurance { get; set; } = 1;

    /// <summary>
    /// Determines the effectiveness of Skills.
    /// </summary>
    public int Arcane { get; set; } = 1;
    
    /// <summary>
    /// Determines the defense of the entity.
    /// </summary>
    public int Resistance { get; set; } = 1;

    /// <summary>
    /// Determines turn order.
    /// </summary>
    public int Celerity { get; set; } = 1;
}