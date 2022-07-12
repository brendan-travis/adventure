using Adventure.Core.Encounter.Interfaces;
using Adventure.Core.Entities;

namespace Adventure.Core.Encounter;

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