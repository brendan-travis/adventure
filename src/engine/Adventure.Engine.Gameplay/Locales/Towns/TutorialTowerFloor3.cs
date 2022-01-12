using Adventure.Core.Ui;
using Adventure.Engine.Gameplay.Locales.Towns.Interfaces;

namespace Adventure.Engine.Gameplay.Locales.Towns;

public class TutorialTowerFloor3 : ITutorialTowerFloor3
{
    public TutorialTowerFloor3(IMessageWriter messageWriter, IMessageReader messageReader)
    {
        MessageWriter = messageWriter;
        MessageReader = messageReader;
    }
    
    private IMessageWriter MessageWriter { get; }
    
    private IMessageReader MessageReader { get; }
    
    public Type Process()
    {
        this.MessageWriter.WriteMessage("[[Tutorial Tower - Floor 3]]");
        this.MessageReader.ReadMessage("", new[]{"Examine"});

        return typeof(TutorialTowerFloor3);
    }
}