using Adventure.Main.Entities;

namespace Adventure.Main.Catalogues;

public static class SkillCatalogue
{
    public static Skill Strike => new("Strike", 1, 1);

    public static Skill QuickStrike => new("Quick Strike", 0.95f, 1);

    public static Skill Bash => new("Bash", 1, 1);

    public static Skill PlayAround => new("Play Around", 0, 0);
}