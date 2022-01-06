using Adventure.Core.GameplayEngine;
using Adventure.Core.Ui;
using Adventure.Core.Ui.Constants;

namespace Adventure.Engine.Gameplay.Crimson.Core;

public class GameplayManager : IGameplayManager
{
    public GameplayManager(ITitleScreen titleScreen, IMessageWriter messageWriter)
    {
        this.TitleScreen = titleScreen;
        MessageWriter = messageWriter;
    }

    private ITitleScreen TitleScreen { get; }
    
    private IMessageWriter MessageWriter { get; }
    
    public void StartGame()
    {
        this.TitleScreen.DrawTitleScreen();

        string? chosenOption = null;
        while (chosenOption == null)
        {
            chosenOption = this.TitleScreen.ShowTitleScreenOptions();

            switch (chosenOption)
            {
                case TitleScreenOptions.Exit:
                    this.MessageWriter.WriteMessage("Shutting down, thanks for playing!");
                    break;
                default:
                    chosenOption = null;
                    break;
            }
        }
    }
}