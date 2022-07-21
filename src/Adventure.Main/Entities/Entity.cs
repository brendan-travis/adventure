namespace Adventure.Main.Entities;

public abstract class Entity
{
    protected Entity(string name, int maxHealth, int maxStamina, int restoredStamina, int attack, int defence,
        List<Skill> skills)
    {
        this.Name = name;
        this.MaxHealth = maxHealth;
        this.CurrentHealth = maxHealth;
        this.MaxStamina = maxStamina;
        this.RestoredStamina = restoredStamina;
        this.CurrentStamina = maxStamina;
        this.StatSet = new StatSet(attack, defence);
        this.Skills.AddRange(skills);
    }

    public int CurrentHealth { get; set; }

    public int MaxHealth { get; set; }

    public int CurrentStamina { get; set; }

    public int MaxStamina { get; set; }

    public int RestoredStamina { get; set; }

    public string Name { get; set; }

    public StatSet StatSet { get; set; }

    public List<Skill> Skills { get; } = new();
}