using Adventure.Main.Entities;

namespace Adventure.Main.Encounter.Interfaces;

public interface IBattleManager
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="player"></param>
    /// <param name="opponents"></param>
    /// <returns>True if the player has run away from battle.</returns>
    public bool ProcessPlayerTurn(Entity player, IList<Entity> opponents);

    public void ProcessOpponentTurn(Entity player, Entity opponent);

    public void ProcessVictory(Entity player, IList<Entity> opponents);

    public void ProcessLoss(Entity player);
}