namespace Adventure.Main.Entities;

public class NonPlayableEntity : Entity
{
    public NonPlayableEntity(string name, int maxHealth, int maxStamina, int restoredStamina, int attack, int defence,
        List<Skill> skills, int xpGranted) : base(name, maxHealth, maxStamina, restoredStamina, attack, defence, skills)
    {
        this.XpGranted = xpGranted;
    }

    public int XpGranted { get; set; }
}