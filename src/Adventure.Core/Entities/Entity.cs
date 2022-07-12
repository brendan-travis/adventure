namespace Adventure.Core.Entities;

public class Entity
{
    public Entity(string name, int maxHealth)
    {
        this.Name = name;
        this.MaxHealth = maxHealth;
        this.CurrentHealth = maxHealth;
    }
    
    public int CurrentHealth { get; set; }

    public int MaxHealth { get; set; }

    public string Name { get; set; }
}