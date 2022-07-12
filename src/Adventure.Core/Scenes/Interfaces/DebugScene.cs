using Adventure.Core.Entities;
using Adventure.Core.UserInterface.Interfaces;

namespace Adventure.Core.Scenes.Interfaces;

public class DebugScene : IDebugScene
{
    public DebugScene(IMessageWriter messageWriter, IEncounterScene encounterScene)
    {
        this.MessageWriter = messageWriter;
        this.EncounterScene = encounterScene;
    }

    private IMessageWriter MessageWriter { get; }

    private IEncounterScene EncounterScene { get; }

    public void BeginTestBattle1()
    {
        this.MessageWriter.WriteMessage("DEBUG: Beginning sample battle with a Slime.");

        var player = new Entity("Arven the Hero", 5000);
        var opponent = new Entity("Slime", 1000);

        this.EncounterScene.ProcessEncounter(player, opponent);
    }
}