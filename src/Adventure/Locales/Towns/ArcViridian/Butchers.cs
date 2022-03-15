using Adventure.Locales.Base;
using Adventure.Managers;
using Adventure.Models;

namespace Adventure.Locales.Towns.ArcViridian;

public class Butchers : ILocale
{
    public ILocale GoTo()
    {
        UiManager.LocaleBar.Type = LocaleType.Town;
        UiManager.LocaleBar.Name = "Arc Viridian - Butchers";
        UiManager.RedrawUi();

        var choice = UiManager.ShowChoices(new List<string>
        {
            "Go back to the shops"
        });

        return choice switch
        {
            "Go back to the shops" => new ShoppingDistrict(),
            _ => this
        };
    }
}