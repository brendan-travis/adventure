using Adventure.Core.Scenes.Interfaces;
using Adventure.Core.UserInterface.Interfaces;

namespace Adventure.Core.Scenes;

internal class TitleScreen : ITitleScreen
{
    public TitleScreen(IMessageReader messageReader)
    {
        this.MessageReader = messageReader;
    }

    private IMessageReader MessageReader { get; }
    
    public void ProcessTitleScreen()
    {
        // Show Options on screen
        var selectedOption = this.MessageReader.ShowChoices(new List<string>
        {
            "New Game",
            "Load Game",
            "Quit"
        });

        // Read selected option from user
        // Call forwarding services
    }
}