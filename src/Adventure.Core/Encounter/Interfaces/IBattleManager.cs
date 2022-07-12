using Adventure.Core.Entities;

namespace Adventure.Core.Encounter.Interfaces;

public interface IBattleManager
{
    public void ProcessPlayerTurn(Entity player, Entity opponent);

    public void ProcessOpponentTurn(Entity player, Entity opponent);

    public void ProcessVictory(Entity player, Entity opponent);

    public void ProcessLoss(Entity player);
}