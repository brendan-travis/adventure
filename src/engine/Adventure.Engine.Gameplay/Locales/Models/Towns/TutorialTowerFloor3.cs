using Adventure.Core.Ui;

namespace Adventure.Engine.Gameplay.Locales.Models.Towns;

public class TutorialTowerFloor3 : Locale
{
    public TutorialTowerFloor3(IMessageWriter messageWriter, IMessageReader messageReader)
    {
        MessageWriter = messageWriter;
        MessageReader = messageReader;

        this.MessageWriter.WriteMessage("[[Tutorial Tower - Floor 3]]");
        this.MessageReader.ReadMessage("", new[]{"Examine"});
    }
    
    private IMessageWriter MessageWriter { get; }
    
    private IMessageReader MessageReader { get; }
    
    public override void Examine()
    {
        throw new NotImplementedException();
    }
}