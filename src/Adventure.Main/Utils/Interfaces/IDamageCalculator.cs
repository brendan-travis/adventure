namespace Adventure.Main.Utils.Interfaces;

public interface IDamageCalculator
{
    int Calculate(int actorAttackSkill, int targetDefenceSkill);
}