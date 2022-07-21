using Adventure.Main.Entities;

namespace Adventure.Main.Catalogues;

public static class SkillCatalogue
{
    public static Skill Strike => new(
        name: "Strike",
        minimumDamageModifier: 1,
        maximumDamageModifier: 1,
        staminaCost: 3);

    public static Skill QuickStrike => new(
        name: "Quick Strike",
        minimumDamageModifier: 0.95f,
        maximumDamageModifier: 1,
        staminaCost: 1);

    public static Skill Bash => new(
        name: "Bash",
        minimumDamageModifier: 1,
        maximumDamageModifier: 1,
        staminaCost: 2);

    public static Skill PlayAround => new(
        name: "Play Around",
        minimumDamageModifier: 0,
        maximumDamageModifier: 0,
        staminaCost: 0);
}