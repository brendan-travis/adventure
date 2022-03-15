using Adventure.Locales.Base;
using Adventure.Managers;
using Adventure.Models;

namespace Adventure.Locales.Towns.ArcViridian;

public class ShoppingDistrict : ITown
{
    public ILocale GoTo()
    {
        UiManager.LocaleBar.Type = LocaleType.Town;
        UiManager.LocaleBar.Name = "Arc Viridian - Shopping District";
        UiManager.RedrawUi();

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
        UiManager.RedrawUi();
        UiManager.WriteMessage(
            "Rows and rows of shops are spread out to create a bustling marketplace.");
        UiManager.WriteMessage();
    }
}