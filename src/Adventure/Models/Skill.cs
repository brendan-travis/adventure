namespace Adventure.Models;

public class Skill
{
    public Skill(string name, int staminaCost, SkillType type)
    {
        Name = name;
        StaminaCost = staminaCost;
        Type = type;
    }
    
    public string Name { get; set; }

    public int StaminaCost { get; set; }

    public SkillType Type { get; set; }

    public int BaseDamage { get; set; }
}