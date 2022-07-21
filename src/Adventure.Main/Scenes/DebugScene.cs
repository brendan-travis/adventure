using Adventure.Main.Catalogues;
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

    public void ShowMainDebugMenu()
    {
        while (true)
        {
            this.MessageWriter.RedrawUi();
            var choice = this.MessageReader.ShowChoices(new List<string> { "Test Battle A", "Back" });

            switch (choice.ToUpper())
            {
                case "TEST BATTLE A":
                    this.BeginTestBattle();
                    break;
                case "BACK":
                    return;
                default:
                    continue;
            }
        }
    }

    private void BeginTestBattle()
    {
        this.MessageWriter.WriteMessage("DEBUG: Beginning sample battle with a Slime.");
        this.MessageReader.WaitForInput();

        var player = new PlayableEntity("Arven the Hero", 5000, 10, 3, 10, 10,
            new List<Skill> { SkillCatalogue.Strike, SkillCatalogue.QuickStrike });
        var opponents = new List<NonPlayableEntity>
        {
            new("Slime A", 1000, 5, 1, 4, 1, new List<Skill> { SkillCatalogue.Bash, SkillCatalogue.PlayAround }, 10),
            new("Slime B", 1000, 5, 1, 4, 1, new List<Skill> { SkillCatalogue.Bash, SkillCatalogue.PlayAround }, 10)
        };

        this.EncounterScene.ProcessEncounter(player, opponents);
    }
}