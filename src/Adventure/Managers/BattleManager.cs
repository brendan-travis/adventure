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
                    Skill? skill = null;

                    while (skill is null)
                    {
                        UiManager.RedrawUi();
                        skill = UiManager.ShowChoices(new List<Skill>
                        {
                            new("Crimson Slash", 1, SkillType.Damage) { BaseDamage = 10 },
                            new("Starlight Strike", 10, SkillType.Damage),
                            new("Quick Slash", 4, SkillType.Damage),
                            new("Block", 1, SkillType.Damage),
                            new("Little Aegis", 13, SkillType.Damage),
                            new("Breathe Echoes", 10, SkillType.Damage),
                            new("Gather Strength", 2, SkillType.Damage)
                        });

                        if (CharacterManager.CurrentCharacter.Stats.CurrentStamina >= skill.StaminaCost) continue;
                        UiManager.WriteMessage("You do not have enough stamina to use that.");
                        UiManager.AwaitUserConfirmation();
                        UiManager.RedrawUi();
                        skill = null;
                    }

                    CharacterManager.CurrentCharacter.Stats.CurrentStamina -= skill.StaminaCost;
                    UiManager.RedrawUi();
                    UiManager.WriteMessage($"You used {skill.Name}.");
                    UiManager.AwaitUserConfirmation();
                    
                    UiManager.WriteMessage($"{opposingTeam[0]} took 0 damage");
                    UiManager.AwaitUserConfirmation();

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

            CharacterManager.CurrentCharacter.Stats.CurrentStamina +=
                AttributeScalingTables.EnduranceToStamina[CharacterManager.CurrentCharacter.Attributes.Endurance];
        }

        InBattle = false;
        UiManager.RedrawUi();
    }
}