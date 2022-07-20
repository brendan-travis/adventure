using Adventure.Main.Entities;

namespace Adventure.Main.Utils.Interfaces;

public interface IDamageCalculator
{
    int Calculate(int actorAttackStat, int targetDefenceStat, Skill skillUsed);
}