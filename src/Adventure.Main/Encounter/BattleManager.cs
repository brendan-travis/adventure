using Adventure.Main.Encounter.Interfaces;
using Adventure.Main.Entities;

namespace Adventure.Main.Encounter;

public class BattleManager : IBattleManager
{
    public void ProcessPlayerTurn(Entity player, Entity opponent)
    {
        throw new NotImplementedException();
    }

    public void ProcessOpponentTurn(Entity player, Entity opponent)
    {
        throw new NotImplementedException();
    }

    public void ProcessVictory(Entity player, Entity opponent)
    {
        throw new NotImplementedException();
    }

    public void ProcessLoss(Entity player)
    {
        throw new NotImplementedException();
    }
}