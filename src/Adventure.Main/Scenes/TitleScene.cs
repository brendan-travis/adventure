using Adventure.Main.Scenes.Interfaces;
using Adventure.Main.UserInterface.Interfaces;

namespace Adventure.Main.Scenes;

internal class TitleScene : ITitleScene
{
    public TitleScene(IMessageReader messageReader, IDebugScene debugScene, IMessageWriter messageWriter)
    {
        this.MessageReader = messageReader;
        this.DebugScene = debugScene;
        this.MessageWriter = messageWriter;
    }

    private IMessageReader MessageReader { get; }

    private IDebugScene DebugScene { get; }

    private IMessageWriter MessageWriter { get; }

    public void ProcessTitleScene()
    {
        while (true)
        {
            var selectedOption = this.MessageReader.ShowChoices(new List<string>
            {
                "New Game",
                "Load Game",
                #if DEBUG
                "Debug",
                #endif
                "Quit"
            });

            switch (selectedOption)
            {
                case "New Game":
                    this.MessageWriter.WriteMessage("Not yet implemented.");
                    break;
                case "Load Game":
                    this.MessageWriter.WriteMessage("Not yet implemented.");
                    break;
                case "Debug":
                    this.DebugScene.BeginTestBattle1();
                    break;
                case "Quit":
                    return;
                default:
                    continue;
            }
        }
    }
}