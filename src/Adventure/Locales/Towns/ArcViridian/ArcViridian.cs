using Adventure.Locales.Base;
using Adventure.Models;
using Adventure.UserInterface;

namespace Adventure.Locales.Towns.ArcViridian;

public class ArcViridian : ITown
{
    public ILocale GoTo()
    {
        UiManager.LocaleBar.Type = LocaleType.Town;
        UiManager.LocaleBar.Name = "Arc Viridian";
        UiManager.DrawUi();

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
        UiManager.DrawUi();
        UiManager.WriteMessage(
            "A great tiled square stretches out in front of you");
        UiManager.WriteMessage("");
    }
}