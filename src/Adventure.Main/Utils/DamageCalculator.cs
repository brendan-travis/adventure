using Adventure.Main.Utils.Interfaces;

namespace Adventure.Main.Utils;

public class DamageCalculator : IDamageCalculator
{
    private const int baseDamage = 50;
    
    public int Calculate(int attackSkill)
    {
        return attackSkill * baseDamage;
    }
}