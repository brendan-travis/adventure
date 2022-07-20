namespace Adventure.Main.Entities;

public class Entity
{
    public Entity(string name, int maxHealth, int attack, int defence, List<Skill> skills)
    {
        this.Name = name;
        this.MaxHealth = maxHealth;
        this.CurrentHealth = maxHealth;
        this.StatSet = new StatSet(attack, defence);
        this.Skills.AddRange(skills);
    }

    public int CurrentHealth { get; set; }

    public int MaxHealth { get; set; }

    public string Name { get; set; }

    public StatSet StatSet { get; set; }

    public List<Skill> Skills { get; } = new();
}