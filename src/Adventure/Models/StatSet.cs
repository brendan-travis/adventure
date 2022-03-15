namespace Adventure.Models;

public class StatSet
{
    public int CurrentHp { get; set; } = 10;

    // TODO - make this computed from stat tables
    public int MaximumHp { get; set; } = 10;

    public int CurrentStamina { get; set; } = 10;

    // TODO - make this computed from stat tables
    public int MaximumStamina { get; set; } = 10;
}