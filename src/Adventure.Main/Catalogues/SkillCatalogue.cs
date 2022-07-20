using Adventure.Main.Entities;

namespace Adventure.Main.Catalogues;

public static class SkillCatalogue
{
    public static Skill Strike => new("Strike");

    public static Skill QuickStrike => new("Quick Strike");

    public static Skill Bash => new("Bash");

    public static Skill PlayAround => new("Play Around");
}