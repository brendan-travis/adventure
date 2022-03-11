using Adventure.Locales.Base;
using Adventure.Models;
using Adventure.UserInterface;

namespace Adventure.Locales.Towns.ArcViridian;

public class ShoppingDistrict : ITown
{
    public ILocale GoTo()
    {
        UiManager.LocaleBar.Type = LocaleType.Town;
        UiManager.LocaleBar.Name = "Arc Viridian - Shopping District";
        UiManager.DrawUi();

        while (true)
        {
            var choice = UiManager.ShowChoices(new List<string>
            {
                "Go to the butchers",
                "Go to the main square",
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
                "Go to the butchers" => new Butchers(),
                "Go to the main square" => new ArcViridian(),
                _ => this
            };
        }
    }

    public void Examine()
    {
        UiManager.DrawUi();
        UiManager.WriteMessage(
            "Rows and rows of shops are spread out to create a bustling marketplace.");
        UiManager.WriteMessage();
    }
}