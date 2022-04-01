namespace Adventure.Models;

public class Stats
{
    public Stats(Attributes linkedSkills)
    {
        LinkedSkills = linkedSkills;

        CurrentHp = MaximumHp;
        CurrentStamina = MaximumStamina;
    }

    private Attributes LinkedSkills { get; }

    public int CurrentHp { get; set; }

    public int MaximumHp => AttributeScalingTables.ConstitutionToHp[LinkedSkills.Constitution];

    public int CurrentStamina { get; set; }

    // TODO - make this computed from stat tables
    public int MaximumStamina { get; set; } = 10;
}