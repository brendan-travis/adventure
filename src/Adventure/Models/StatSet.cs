namespace Adventure.Models;

public class StatSet
{
    public StatSet(SkillSet linkedSkills)
    {
        LinkedSkills = linkedSkills;

        CurrentHp = MaximumHp;
        CurrentStamina = MaximumStamina;
    }

    private SkillSet LinkedSkills { get; }

    public int CurrentHp { get; set; }

    public int MaximumHp => SkillTables.Hp[LinkedSkills.Constitution];

    public int CurrentStamina { get; set; }

    // TODO - make this computed from stat tables
    public int MaximumStamina { get; set; } = 10;
}