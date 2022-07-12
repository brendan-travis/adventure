﻿using Adventure.Core.Encounter.Interfaces;
using Adventure.Core.Entities;
using Adventure.Core.Scenes.Interfaces;

namespace Adventure.Core.Scenes;

public class EncounterScene : IEncounterScene
{
    public EncounterScene(IBattleManager battleManager)
    {
        this.BattleManager = battleManager;
    }

    private IBattleManager BattleManager { get; }
    
    public void ProcessEncounter(Entity player, Entity opponent)
    {
        // Process Battle
        var participants = new List<Entity> { player, opponent };

        while (participants.Any(p => p.CurrentHealth != 0))
        {
            foreach (var participant in participants)
            {
                if (participants.Any(p => p.CurrentHealth != 0))
                {
                    break;
                }

                if (participant == player) this.BattleManager.ProcessPlayerTurn(player, opponent);
                else this.BattleManager.ProcessOpponentTurn(player, opponent);
            }
        }

        if (player.CurrentHealth != 0) this.BattleManager.ProcessVictory(player, opponent);
        else this.BattleManager.ProcessLoss(player);
    }
}