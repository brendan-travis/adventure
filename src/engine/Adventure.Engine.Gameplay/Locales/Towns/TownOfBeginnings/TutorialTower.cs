using Adventure.Core.Ui;
using Adventure.Engine.Gameplay.Locales.Towns.TownOfBeginnings.Interfaces;

namespace Adventure.Engine.Gameplay.Locales.Towns.TownOfBeginnings;

public class TutorialTower : ITutorialTower
{
    public TutorialTower(IMessageWriter messageWriter)
    {
        MessageWriter = messageWriter;
    }

    private IMessageWriter MessageWriter { get; }

    public void Exit()
    {
        throw new NotImplementedException();
    }

    public void InitialFloor()
    {
        this.MessageWriter.WriteMessage(
            "You awake to find yourself on the top floor of a tall tower. " +
            "The walls and floor are made of cold stone with decorations " +
            "dotted around the room. ");
        this.MessageWriter.WriteMessage(
            "There is a staircase leading down in the corner and a man in " +
            "the centre, staring at you.");

        this.MessageWriter.WriteMessage("This is the end.");
    }
}