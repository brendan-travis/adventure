namespace Adventure.Models;

public class SkillSet
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
    /// Determines the effectiveness of Offensive Skills.
    /// </summary>
    public int Strength { get; set; } = 1;
    
    /// <summary>
    /// Determines the effectiveness of Defensive Skills.
    /// </summary>
    public int Agility { get; set; } = 1;
    
    /// <summary>
    /// Determines the effectiveness of Support Skills.
    /// </summary>
    public int Arcane { get; set; } = 1;
    
    /// <summary>
    /// Determines the defense of the entity.
    /// </summary>
    public int Resistance { get; set; } = 1;
}