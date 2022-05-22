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
                            new("Crimson Slash", 1, TargetType.SingleOpponent) { BaseDamage = 10 },
                            new("Starlight Strike", 10, TargetType.AllOpponents),
                            new("Quick Slash", 4, TargetType.SingleOpponent),
                            new("Block", 1, TargetType.Self),
                            new("Little Aegis", 13, TargetType.Self),
                            new("Breathe Echoes", 10, TargetType.Self),
                            new("Gather Strength", 2, TargetType.Self)
                        });

                        if (CharacterManager.CurrentCharacter.Stats.CurrentStamina >= skill.StaminaCost) continue;
                        UiManager.WriteMessage("You do not have enough stamina to use that.");
                        UiManager.AwaitUserConfirmation();
                        UiManager.RedrawUi();
                        skill = null;
                    }

                    switch (skill.TargetType)
                    {
                        case TargetType.SingleOpponent:
                            UiManager.RedrawUi();
                            var target = UiManager.ShowChoices(opposingTeam);

                            CharacterManager.CurrentCharacter.Stats.CurrentStamina -= skill.StaminaCost;
                            UiManager.RedrawUi();
                            UiManager.WriteMessage($"You used {skill.Name}.");
                            UiManager.AwaitUserConfirmation();

                            UiManager.WriteMessage($"{target.Name} took 0 damage");
                            UiManager.AwaitUserConfirmation();
                            break;
                        case TargetType.AllOpponents:
                        {
                            CharacterManager.CurrentCharacter.Stats.CurrentStamina -= skill.StaminaCost;
                            UiManager.RedrawUi();
                            UiManager.WriteMessage($"You used {skill.Name}.");
                            UiManager.AwaitUserConfirmation();

                            foreach (var opponent in opposingTeam)
                            {
                                UiManager.WriteMessage($"{opponent.Name} took 0 damage");
                            }

                            UiManager.AwaitUserConfirmation();
                            break;
                        }
                        case TargetType.Self:
                            CharacterManager.CurrentCharacter.Stats.CurrentStamina -= skill.StaminaCost;
                            UiManager.RedrawUi();
                            UiManager.WriteMessage($"You used {skill.Name}.");
                            UiManager.AwaitUserConfirmation();
                            
                            UiManager.WriteMessage("But nothing happened.");
                            UiManager.AwaitUserConfirmation();

                            break;
                        default:
                            throw new ArgumentException("The target type of the skills is not yet handled.");
                    }

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
            
            // Enemies turn here
        }

        InBattle = false;
        UiManager.RedrawUi();
    }
}