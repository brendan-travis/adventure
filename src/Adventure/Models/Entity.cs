namespace Adventure.Models;

public class Entity
{
    public Entity(string name, SkillSet? skills = null)
    {
        Name = name;
        Skills = skills ?? new SkillSet();
        Stats = new StatSet(Skills);
    }
    
    public string Name { get; }

    public SkillSet Skills { get; }

    public StatSet Stats { get; }
    
    public int Level =>
        this.Skills.Agility +
        this.Skills.Arcane +
        this.Skills.Celerity +
        this.Skills.Constitution +
        this.Skills.Endurance +
        this.Skills.Resistance +
        this.Skills.Stamina +
        this.Skills.Strength;
}