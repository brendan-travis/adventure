using Adventure.Core.GameplayEngine;
using Adventure.Core.Ui;
using Adventure.Core.Ui.Constants;

namespace Adventure.Engine.Gameplay.Crimson.Core;

public class GameplayManager : IGameplayManager
{
    public GameplayManager(ITitleScreen titleScreen)
    {
        this.TitleScreen = titleScreen;
    }

    private ITitleScreen TitleScreen { get; }
    
    public void StartGame()
    {
        this.TitleScreen.DrawTitleScreen();

        string? chosenOption = null;
        while (chosenOption == null)
        {
            chosenOption = this.TitleScreen.ShowTitleScreenOptions();

            if (chosenOption != TitleScreenOptions.Exit)
            {
                chosenOption = null;
            }
        }
    }
}