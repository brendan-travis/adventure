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

    public void ProcessEncounter(Entity player, Entity opponent)
    {
        this.MessageWriter.RedrawUi(player, opponent);        
        
        var participants = new List<Entity> { player, opponent };

        while (participants.All(p => p.CurrentHealth != 0))
        {
            foreach (var participant in participants.TakeWhile(_ => participants.All(p => p.CurrentHealth != 0)))
            {
                if (participant == player) this.BattleManager.ProcessPlayerTurn(player, opponent);
                else this.BattleManager.ProcessOpponentTurn(player, opponent);

                this.MessageReader.WaitForInput();
                this.MessageWriter.RedrawUi(player, opponent);
            }
        }

        if (player.CurrentHealth != 0) this.BattleManager.ProcessVictory(player, opponent);
        else this.BattleManager.ProcessLoss(player);

        this.MessageReader.WaitForInput();
        this.MessageWriter.RedrawUi(player);
    }
}