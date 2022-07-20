using Adventure.Main.Entities;
using Adventure.Main.Utils.Interfaces;

namespace Adventure.Main.Utils;

public class DamageCalculator : IDamageCalculator
{
    private const int BaseDamage = 50;
    private const int BaseDefence = 45;
    private const int DamageRandomRange = 1500;

    public DamageCalculator(IRandomUtils randomUtils)
    {
        this.RandomUtils = randomUtils;
    }

    private Random Random { get; } = new();
    
    private IRandomUtils RandomUtils { get; }

    public int Calculate(int actorAttackStat, int targetDefenceStat, Skill skilLUsed)
    {
        if (targetDefenceStat > actorAttackStat) targetDefenceStat = actorAttackStat;
        
        var attackModifier = this.Random.Next(DamageRandomRange) / 100f;
        var skillModifier = this.RandomUtils.NextFloat(skilLUsed.MinimumDamageModifier, skilLUsed.MaximumDamageModifier);
        var attackValue = (actorAttackStat * BaseDamage +
                          (actorAttackStat * attackModifier))
                          * skillModifier;
        var defenceValue = targetDefenceStat * BaseDefence;

        var result = (int)attackValue - defenceValue;
        if (result < 0) result = 0;

        return result;
    }
}