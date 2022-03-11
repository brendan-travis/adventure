using Adventure.Locales.Base;
using Adventure.Models;
using Adventure.UserInterface;

namespace Adventure.Locales.Towns.ArcViridian;

public class Gatestone : ILocale
{
    public ILocale GoTo()
    {
        UiManager.LocaleBar.Type = LocaleType.Town;
        UiManager.LocaleBar.Name = "Arc Viridian - Gatestone";
        UiManager.DrawUi();
        
        var choice = UiManager.ShowChoices(new List<string>
        {
            "Go to the main square"
        });

        return choice switch
        {
            "Go to the main square" => new ArcViridian(),
            _ => this
        };
    }
}