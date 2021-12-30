using Adventure.Core.Ui;
using Adventure.Core.Ui.Constants;
using Adventure.Ui.Azure.Ui.Interfaces;

namespace Adventure.Ui.Azure.TitleScreen;

public class TitleScreen : ITitleScreen
{
    public TitleScreen(IUiManager uiManager)
    {
        this.UiManager = uiManager;
    }

    private IUiManager UiManager { get; }

    private string? SelectedOption { get; set; } = TitleScreenOptions.NewGame;

    #region Screens

    private string Title { get; } =
        @"                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                    _       _                 _                    _                                   
                                   / \   __| |_   _____ _ __ | |_ _   _ _ __ ___  | |                                  
                                  / _ \ / _` \ \ / / _ \ '_ \| __| | | | '__/ _ \ | |                                  
                                 / ___ \ (_| |\ V /  __/ | | | |_| |_| | | |  __/ |_|                                  
                                /_/   \_\__,_| \_/ \___|_| |_|\__|\__,_|_|  \___| (_)                                  
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       ";

    private string Menu { get; } =
        @"                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                    ╓────────────────╖                                                 
                                                    ║    New Game    ║                                                 
                                                    ║    Load Game   ║                                                 
                                                    ║    Exit        ║                                                 
                                                    ╙────────────────╜                                                 
                                                                                                                       
                                                                                                                       ";

    private string MenuWithDebugOption { get; } =
        @"                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                    ╓────────────────╖                                                 
                                                    ║    New Game    ║                                                 
                                                    ║    Load Game   ║                                                 
                                                    ║    Debug       ║                                                 
                                                    ║    Exit        ║                                                 
                                                    ╙────────────────╜                                                 
                                                                                                                       
                                                                                                                       ";

    #endregion

    public void DrawTitleScreen()
    {
        this.UiManager.UpdateUi(this.Title, 0);
    }

    public string? ShowTitleScreenOptions()
    {
        while (true)
        {
#if DEBUG
            this.UiManager.UpdateUi(
                this.MenuWithDebugOption.Replace($"  {this.SelectedOption}", $"> {this.SelectedOption}"), 1);
#else
        this.UiManager.UpdateUi(
            this.Menu.Replace($"  {this.SelectedOption}", $"> {this.SelectedOption}"), 1);
#endif

            var userInput = Console.ReadKey();

            switch (userInput.Key)
            {
                case ConsoleKey.Enter:
                    return this.SelectedOption;
                case ConsoleKey.UpArrow:
                    switch (this.SelectedOption)
                    {
                        case TitleScreenOptions.LoadGame:
                            this.SelectedOption = TitleScreenOptions.NewGame;
                            break;
                        case TitleScreenOptions.Debug:
                            this.SelectedOption = TitleScreenOptions.LoadGame;
                            break;
                        case TitleScreenOptions.Exit:
#if DEBUG
                            this.SelectedOption = TitleScreenOptions.Debug;
#else
                            this.SelectedOption = TitleScreenOptions.LoadGame;
#endif
                            break;
                    }

                    break;
                case ConsoleKey.DownArrow:
                    switch (this.SelectedOption)
                    {
                        case TitleScreenOptions.NewGame:
                            this.SelectedOption = TitleScreenOptions.LoadGame;
                            break;
                        case TitleScreenOptions.LoadGame:
#if DEBUG
                            this.SelectedOption = TitleScreenOptions.Debug;
#else
                            this.SelectedOption = TitleScreenOptions.Exit;
#endif
                            break;
                        case TitleScreenOptions.Debug:
                            this.SelectedOption = TitleScreenOptions.Exit;
                            break;
                    }

                    break;
            }
        }
    }
}