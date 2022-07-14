namespace Adventure.Main.Entities;

public class Entity
{
    public Entity(string name, int maxHealth, int attack, int defence)
    {
        this.Name = name;
        this.MaxHealth = maxHealth;
        this.CurrentHealth = maxHealth;
        this.Attack = attack;
        this.Defence = defence;
    }

    public int CurrentHealth { get; set; }

    public int MaxHealth { get; set; }

    public string Name { get; set; }

    public int Attack { get; set; }
    
    public int Defence { get; set; }
}