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
                "Offensive Skill",
                "Defensive Skill",
                "Support Skill",
                "Use Item",
                "Run Away",
            });

            switch (choice)
            {
                case "Offensive Skill":
                    var offensiveSkill = UiManager.ShowChoices(new List<string>
                    {
                        "Crimson Slash (1)",
                        "Starlight Strike (10)",
                        "Quick Slash (4)"
                    });
                    
                    OpposingTeam.Clear();

                    break;
                case "Defensive Skill":
                    var defensiveSkill = UiManager.ShowChoices(new List<string>
                    {
                        "Block [[(1),Green]]",
                        "Little Aegis [[(13),Green]]"
                    });

                    break;
                case "Support Skill":
                    var supportSkill = UiManager.ShowChoices(new List<string>
                    {
                        "Breathe Echoes [[(10),Green]]",
                        "Gather Strength [[(2),Green]]"
                    });

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