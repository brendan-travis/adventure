namespace Adventure.Models;

public static class SkillTables
{
    public static Dictionary<int, int> Hp => new()
    {
        { 1, 10 },
        { 2, 13 },
        { 3, 16 },
        { 4, 19 },
        { 5, 22 }
    };
}