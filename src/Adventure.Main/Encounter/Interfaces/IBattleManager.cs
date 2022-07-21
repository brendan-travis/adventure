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
    public bool ProcessPlayerTurn(PlayableEntity player, IList<NonPlayableEntity> opponents);

    public void ProcessOpponentTurn(PlayableEntity player, NonPlayableEntity opponent);

    public void ProcessVictory(PlayableEntity player, IList<NonPlayableEntity> opponents);

    public void ProcessLoss(PlayableEntity player);
}