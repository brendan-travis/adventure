namespace Adventure.Models;

public class Entity
{
    public Entity(string name, Attributes? skills = null)
    {
        Name = name;
        Attributes = skills ?? new Attributes();
        Stats = new Stats(Attributes);
    }
    
    public string Name { get; }

    public Attributes Attributes { get; }

    public Stats Stats { get; }
    
    public int Level =>
        this.Attributes.Arcane +
        this.Attributes.Celerity +
        this.Attributes.Constitution +
        this.Attributes.Endurance +
        this.Attributes.Resistance +
        this.Attributes.Stamina;
}