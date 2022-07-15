using System.Collections;
using Adventure.Main.Encounter.Interfaces;
using Adventure.Main.Entities;
using Adventure.Main.Scenes.Interfaces;
using Adventure.Main.UserInterface.Interfaces;

namespace Adventure.Main.Scenes;

public class EncounterScene : IEncounterScene
{
    public EncounterScene(IBattleManager battleManager, IMessageReader messageReader, IMessageWriter messageWriter)
    {
        this.BattleManager = battleManager;
        this.MessageReader = messageReader;
        this.MessageWriter = messageWriter;
    }

    private IBattleManager BattleManager { get; }

    private IMessageReader MessageReader { get; }

    private IMessageWriter MessageWriter { get; }

    public void ProcessEncounter(Entity player, IList<Entity> opponents)
    {
        this.MessageWriter.RedrawUi(player, opponents);        
        
        var participants = new Queue<Entity>();
        participants.Enqueue(player);
        foreach (var opponent in opponents) participants.Enqueue(opponent);
        
        var inBattle = true;

        while (inBattle)
        {
            var currentParticipant = participants.Dequeue();
            
            if (currentParticipant == player) this.BattleManager.ProcessPlayerTurn(player, opponents);
            else this.BattleManager.ProcessOpponentTurn(player, currentParticipant);

            participants.Enqueue(currentParticipant);

            participants = new Queue<Entity>(participants.Where(participant => participant.CurrentHealth > 0));

            if ((participants.Count == 1 && participants.First() == player) ||
                participants.All(participant => participant != player))
            {
                inBattle = false;
            }
            
            this.MessageReader.WaitForInput();
            this.MessageWriter.RedrawUi(player, opponents);
        }

        if (player.CurrentHealth > 0) this.BattleManager.ProcessVictory(player, opponents);
        else this.BattleManager.ProcessLoss(player);

        this.MessageReader.WaitForInput();
        this.MessageWriter.RedrawUi(player);
    }
}