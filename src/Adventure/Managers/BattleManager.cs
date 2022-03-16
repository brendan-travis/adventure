using Adventure.Models;

namespace Adventure.Managers;

public static class BattleManager
{
    public static bool InBattle { get; set; }

    public static IList<Entity> OpposingTeam { get; set; }
    
    public static void BeginBattle(IList<Entity> opposingTeam)
    {
        InBattle = true;
        OpposingTeam = opposingTeam;

        while (opposingTeam.Sum(entity => entity.Stats.CurrentHp) > 0)
        {
            UiManager.RedrawUi();
            var choice = UiManager.ShowChoices(new List<string>
            {
                "Fight",
                "Use Item",
                "Run Away",
            });

            switch (choice)
            {
                case "Fight":
                    var skill = UiManager.ShowChoices(new List<string>
                    {
                        "Crimson Slash [[(1), Green]]",
                        "Starlight Strike [[(10), Green]]",
                        "Quick Slash [[(4), Green]]",
                        "Block [[(1), Green]]",
                        "Little Aegis [[(13), Green]]",
                        "Breathe Echoes [[(10), Green]]",
                        "Gather Strength [[(2), Green]]"
                    });
                    
                    OpposingTeam.Clear();

                    break;
                case "Use Item":
                    var item = UiManager.ShowChoices(new List<string>
                    {
                        "Potion"
                    });

                    break;
                case "Run Away":
                    UiManager.WriteMessage("You managed to get away");
                    UiManager.AwaitUserConfirmation();
                    
                    OpposingTeam.Clear();

                    break;
            }
        }

        InBattle = false;
        UiManager.RedrawUi();
    }
}