using Adventure.Debug;
using Adventure.Locales.Base;
using Adventure.Locales.Towns.ArcViridian;
using Adventure.Managers;
using Adventure.Models;

CharacterManager.CurrentCharacter = new Entity("Arven the Hero");


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
            break;
        case "Quit Game":
            return;
    }
}