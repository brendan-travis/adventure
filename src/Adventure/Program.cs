using Adventure.Debug;
using Adventure.Locales.Base;
using Adventure.Locales.Towns.ArcViridian;
using Adventure.Managers;
using Adventure.Models;

CharacterManager.CurrentCharacter = new Entity("Arven the Hero");


try
{
    while (true)
    {
        UiManager.ClearUi();
        var choice = UiManager.ShowChoices(new List<string>
        {
            "New Game",
            "Quit Game",
            "Debug"
        });

        switch (choice)
        {
            case "Debug":
                new DebugMenu().Launch();
                break;
            case "New Game":
                ILocale currentLocation = new ArcViridian();
                while (true)
                {
                    currentLocation = currentLocation.GoTo();
                }
            case "Quit Game":
                return;
        }
    }
}
catch (Exception e)
{
    Console.Clear();
    
    Console.WriteLine(@"Unfortunately, the application has run into a serious error and must shut down.

Press any key to close the application window.");

    Console.ReadKey(true);
}

Console.WriteLine("Shutting down ...");