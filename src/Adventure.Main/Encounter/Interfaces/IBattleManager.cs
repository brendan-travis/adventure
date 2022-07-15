using Adventure.Main.Entities;

namespace Adventure.Main.Encounter.Interfaces;

public interface IBattleManager
{
    public void ProcessPlayerTurn(Entity player, IList<Entity> opponents);

    public void ProcessOpponentTurn(Entity player, Entity opponent);

    public void ProcessVictory(Entity player, IList<Entity> opponents);

    public void ProcessLoss(Entity player);
}