namespace Adventure.Main.Entities;

public class PlayableEntity : Entity
{
    public PlayableEntity(string name, int maxHealth, int maxStamina, int restoredStamina, int attack, int defence,
        List<Skill> skills) : base(name, maxHealth, maxStamina, restoredStamina, attack, defence, skills)
    {
    }

    public int CurrentXp { get; set; }
}