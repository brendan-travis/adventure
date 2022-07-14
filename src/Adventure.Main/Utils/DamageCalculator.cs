using Adventure.Main.Utils.Interfaces;

namespace Adventure.Main.Utils;

public class DamageCalculator : IDamageCalculator
{
    private const int BaseDamage = 50;
    private const int BaseDefence = 45;
    private const int DamageRandomRange = 1500;

    private Random Random { get; } = new();

    public int Calculate(int actorAttackSkill, int targetDefenceSkill)
    {
        if (targetDefenceSkill > actorAttackSkill) targetDefenceSkill = actorAttackSkill;

        
        var random = this.Random.Next(DamageRandomRange) / 100m;
        var attackValue = actorAttackSkill * BaseDamage +
                          (int)(actorAttackSkill * random);
        var defenceValue = targetDefenceSkill * BaseDefence;

        return attackValue - defenceValue;
    }
}