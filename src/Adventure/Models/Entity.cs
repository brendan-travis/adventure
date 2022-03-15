namespace Adventure.Models;

public class Entity
{
    public string Name { get; init; }
    
    public SkillSet Skills { get; init; } = new();
    
    public StatSet Stats { get; } = new();
    
    public int Level =>
        this.Skills.Agility +
        this.Skills.Arcane +
        this.Skills.Constitution +
        this.Skills.Endurance +
        this.Skills.Resistance +
        this.Skills.Stamina +
        this.Skills.Strength;
}