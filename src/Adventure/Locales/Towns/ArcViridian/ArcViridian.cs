using Adventure.Locales.Base;
using Adventure.Managers;
using Adventure.Models;

namespace Adventure.Locales.Towns.ArcViridian;

public class ArcViridian : ITown
{
    public ILocale GoTo()
    {
        UiManager.LocaleBar.Type = LocaleType.Town;
        UiManager.LocaleBar.Name = "Arc Viridian";
        UiManager.RedrawUi();

        while (true)
        {
            var choice = UiManager.ShowChoices(new List<string>
            {
                "Go to the shops",
                "Go to the Gatestone",
                "Examine"
            });

            switch (choice)
            {
                case "Examine":
                    this.Examine();
                    continue;
            }

            return choice switch
            {
                "Go to the shops" => new ShoppingDistrict(),
                "Go to the Gatestone" => new Gatestone(),
                _ => this
            };
        }
    }

    public void Examine()
    {
        UiManager.RedrawUi();
        UiManager.WriteMessage(
            "A great tiled square stretches out in front of you");
        UiManager.WriteMessage();
    }
}