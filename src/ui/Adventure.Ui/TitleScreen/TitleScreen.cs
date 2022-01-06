using Adventure.Core.Ui;
using Adventure.Core.Ui.Constants;

namespace Adventure.Ui.TitleScreen;

public class TitleScreen : ITitleScreen
{
    private const string Title = @"
  ___      _                 _                    _ 
 / _ \    | |               | |                  | |
/ /_\ \ __| |_   _____ _ __ | |_ _   _ _ __ ___  | |
|  _  |/ _` \ \ / / _ \ '_ \| __| | | | '__/ _ \ | |
| | | | (_| |\ V /  __/ | | | |_| |_| | | |  __/ |_|
\_| |_/\__,_| \_/ \___|_| |_|\__|\__,_|_|  \___| (_)";

    public TitleScreen(IMessageWriter messageWriter, IMessageReader messageReader)
    {
        MessageWriter = messageWriter;
        MessageReader = messageReader;
    }

    private IMessageWriter MessageWriter { get; }
    
    private IMessageReader MessageReader { get; }

    public void DrawTitleScreen()
    {
        this.MessageWriter.WriteMessage(Title);
        this.MessageWriter.WriteBlankLine();
    }

    public string ShowTitleScreenOptions()
    {
#if DEBUG
        var options = new []
        {
            TitleScreenOptions.NewGame,
            TitleScreenOptions.LoadGame,
            TitleScreenOptions.Debug,
            TitleScreenOptions.Exit
        };
#else
        var options = new []
        {
            TitleScreenOptions.NewGame,
            TitleScreenOptions.LoadGame,
            TitleScreenOptions.Exit
        };
#endif

        return this.MessageReader.ReadMessage("Enter an options", options);
    }
}