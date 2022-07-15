using Adventure.Main.Entities;
using Adventure.Main.Scenes.Interfaces;
using Adventure.Main.UserInterface.Interfaces;

namespace Adventure.Main.Scenes;

public class DebugScene : IDebugScene
{
    public DebugScene(IMessageWriter messageWriter, IEncounterScene encounterScene, IMessageReader messageReader)
    {
        this.MessageWriter = messageWriter;
        this.EncounterScene = encounterScene;
        this.MessageReader = messageReader;
    }

    private IMessageWriter MessageWriter { get; }

    private IEncounterScene EncounterScene { get; }
    
    private IMessageReader MessageReader { get; }

    public void BeginTestBattle()
    {
        this.MessageWriter.WriteMessage("DEBUG: Beginning sample battle with a Slime.");
        this.MessageReader.WaitForInput();
        
        var player = new Entity("Arven the Hero", 5000, 10, 8);
        var opponents = new List<Entity>
        {
            new("Slime A", 1000, 4, 1),
            new("Slime B", 1000, 4, 1)
        };

        this.EncounterScene.ProcessEncounter(player, opponents);
    }
}