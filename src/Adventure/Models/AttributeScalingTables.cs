namespace Adventure.Models;

public static class AttributeScalingTables
{
    public static Dictionary<int, int> ConstitutionToHp => new()
    {
        { 1, 10 },
        { 2, 13 },
        { 3, 16 },
        { 4, 19 },
        { 5, 22 }
    };

    public static Dictionary<int, int> EnduranceToStamina => new()
    {
        { 1, 2 },
        { 2, 4 },
        { 3, 6 },
        { 4, 8 },
        { 5, 10 },
    };
}