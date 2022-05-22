namespace Adventure.Models;

public class Skill
{
    public Skill(string name, int staminaCost, TargetType targetType)
    {
        Name = name;
        StaminaCost = staminaCost;
        TargetType = targetType;
    }
    
    public string Name { get; set; }

    public int StaminaCost { get; set; }

    public TargetType TargetType { get; set; }

    public int BaseDamage { get; set; }
}