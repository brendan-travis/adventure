using System.Text.RegularExpressions;
using Adventure.Managers;
using Adventure.Models;

namespace Adventure.Debug;

public class DebugMenu
{
    public void Launch()
    {
        UiManager.LocaleBar.Type = LocaleType.Special;
        UiManager.LocaleBar.Name = "Hall of Debug";

        while (true)
        {
            UiManager.RedrawUi();
            var choice = UiManager.ShowChoices(new List<string>
            {
                "Test Dialog",
                "Battle a Slime",
                "Return to Main Menu"
            });

            switch (choice)
            {
                case "Test Dialog":
                    this.TestDialog();
                    break;
                case "Battle a Slime":
                    this.BattleASlime();
                    break;
                case "Return to Main Menu":
                    return;
            }
        }
    }

    private void TestDialog()
    {
        UiManager.RedrawUi();
        UiManager.WriteDialog("Pim", "This is a test message sent from the debug menu!");
        UiManager.AwaitUserConfirmation();
        UiManager.WriteDialog("Pom", "And this is another message that simulates a conversation!");
        UiManager.AwaitUserConfirmation();
        UiManager.WriteDialog("Pim", "It's easy to control the flow and require user input between messages.");
        UiManager.AwaitUserConfirmation();
        UiManager.WriteDialog("Pom", "Like that!");
        UiManager.AwaitUserConfirmation();

        UiManager.RedrawUi();
        UiManager.WriteDialog("Pim", "Or even clear the previous messages!");
        UiManager.AwaitUserConfirmation();
        UiManager.WriteDialog("Pom", "It's a good way to group parts of a conversation.");
        UiManager.AwaitUserConfirmation();

        UiManager.RedrawUi();
        UiManager.WriteDialog("Pim", "...");
        UiManager.AwaitUserConfirmation();
        UiManager.WriteDialog("Pom", "...");
        UiManager.AwaitUserConfirmation();
        UiManager.WriteDialog("Pim & Pom", "Bye!");
        UiManager.AwaitUserConfirmation();
    }

    private void BattleASlime()
    {
        var slimes = new List<Entity>
        {
            new("Slime A", new SkillSet
            {
                Agility = 0,
                Arcane = 0
            }),
            new("Slime B", new SkillSet
            {
                Constitution = 2
            }),
            new("Slime C")
        };
        
        BattleManager.BeginBattle(slimes);
        
        return;

        while (true)
        {
            UiManager.RedrawUi();
            UiManager.WriteMessage($"* [[{slimes[0].Name},Red]] Lvl.[[{slimes[0].Level},Magenta]] HP.[[{slimes[0].Stats.CurrentHp},Red]]/[[{slimes[0].Stats.MaximumHp},Red]]");
            UiManager.WriteMessage($"* [[{slimes[1].Name},Red]] Lvl.[[{slimes[1].Level},Magenta]] HP.[[{slimes[1].Stats.CurrentHp},Red]]/[[{slimes[1].Stats.MaximumHp},Red]]");
            UiManager.WriteMessage($"* [[{slimes[2].Name},Red]] Lvl.[[{slimes[2].Level},Magenta]] HP.[[{slimes[2].Stats.CurrentHp},Red]]/[[{slimes[2].Stats.MaximumHp},Red]]");
            UiManager.WriteMessage();

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

                    var target = UiManager.ShowChoices(slimes.Select(s => s.Name).ToList());
                    
                    UiManager.WriteMessage($"You used {Regex.Replace(offensiveSkill, @"\(.*?\)", "")} against {target}.");
                    UiManager.AwaitUserConfirmation();
                    
                    UiManager.WriteMessage("It missed!");
                    UiManager.AwaitUserConfirmation();
                    
                    UiManager.WriteMessage($"{slimes[0]} used {Regex.Replace("Starlight Strike (10)", @"\(.*?\)", "")}.");
                    UiManager.AwaitUserConfirmation();
                    
                    UiManager.WriteMessage("CRITICAL HIT!");
                    UiManager.WriteMessage("You took 45 damage.");
                    UiManager.AwaitUserConfirmation();
                    
                    UiManager.WriteMessage("[[You have perished., Red]]");
                    UiManager.AwaitUserConfirmation();

                    return;
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
                    return;
            }
        }
    }
}