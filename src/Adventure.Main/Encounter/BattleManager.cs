using Adventure.Main.Encounter.Interfaces;
using Adventure.Main.Entities;
using Adventure.Main.UserInterface.Interfaces;
using Adventure.Main.Utils.Interfaces;

namespace Adventure.Main.Encounter;

public class BattleManager : IBattleManager
{
    public BattleManager(IMessageReader messageReader, IMessageWriter messageWriter, IDamageCalculator damageCalculator)
    {
        this.MessageReader = messageReader;
        this.MessageWriter = messageWriter;
        this.DamageCalculator = damageCalculator;
    }

    private IMessageReader MessageReader { get; }

    private IMessageWriter MessageWriter { get; }

    private IDamageCalculator DamageCalculator { get; }

    private Random Random { get; } = new();

    public bool ProcessPlayerTurn(PlayableEntity player, IList<NonPlayableEntity> opponents)
    {
        player.CurrentStamina += player.RestoredStamina;
        if (player.CurrentStamina > player.MaxStamina)
            player.CurrentStamina = player.MaxStamina;
        this.MessageWriter.RedrawUi(player, opponents);
        
        var choice = this.MessageReader.ShowChoices(new List<string> { "Attack", "Run away" });

        switch (choice.ToUpper())
        {
            case "ATTACK":
                Skill skill;
                do
                {
                    skill = this.MessageReader.ShowChoices(player.Skills);
                    if (skill.StaminaCost > player.CurrentStamina)
                    {
                        this.MessageWriter.WriteMessage("You do not have enough stamina to do that.");
                        this.MessageReader.WaitForInput();
                        this.MessageWriter.RedrawUi(player, opponents);
                    }
                } while (skill.StaminaCost > player.CurrentStamina);

                player.CurrentStamina -= skill.StaminaCost;
                
                var opponent = this.MessageReader.ShowChoices(opponents.Where(o => o.CurrentHealth > 0).ToList());

                this.MessageWriter.WriteMessage($"[[{player.Name},Blue]] uses [[{skill.Name},Yellow]].");
                this.MessageReader.WaitForInput();

                var damage = this.DamageCalculator.Calculate(player.StatSet.Attack, opponent.StatSet.Defence, skill);

                this.MessageWriter.WriteMessage($"[[{opponent.Name},Green]] took {damage} damage.");
                opponent.CurrentHealth -= damage;
                if (opponent.CurrentHealth < 0) opponent.CurrentHealth = 0;

                if (opponent.CurrentHealth == 0)
                {
                    this.MessageReader.WaitForInput();
                    this.MessageWriter.WriteMessage($"[[{opponent.Name},Green]] has been defeated.");
                }

                break;
            case "RUN AWAY":
                var runAwayCheck = this.Random.Next(2);

                if (runAwayCheck == 0)
                {
                    this.MessageWriter.WriteMessage("You could not escape.");
                }
                else
                {
                    this.MessageWriter.WriteMessage("You managed to escape.");
                    
                    return true;
                }
                
                break;
        }

        return false;
    }

    public void ProcessOpponentTurn(PlayableEntity player, NonPlayableEntity opponent)
    {
        opponent.CurrentStamina += opponent.RestoredStamina;
        var availableSkills = opponent.Skills.Where(s => s.StaminaCost <= opponent.CurrentStamina).ToList();
        var skill = availableSkills[this.Random.Next(availableSkills.Count)];
        opponent.CurrentStamina -= skill.StaminaCost;
        
        this.MessageWriter.WriteMessage($"[[{opponent.Name},Green]] uses [[{skill.Name},Yellow]].");
        this.MessageReader.WaitForInput();

        var damage = this.DamageCalculator.Calculate(opponent.StatSet.Attack, player.StatSet.Defence, skill);

        this.MessageWriter.WriteMessage($"[[{opponent.Name},Green]] attacks for {damage} damage.");
        player.CurrentHealth -= damage;
        if (player.CurrentHealth < 0) player.CurrentHealth = 0;

        if (player.CurrentHealth == 0)
        {
            this.MessageReader.WaitForInput();
            this.MessageWriter.WriteMessage($"[[{player.Name},Blue]] has fallen.");
        }
    }

    public void ProcessVictory(PlayableEntity player, IList<NonPlayableEntity> opponents)
    {
        var xpGranted = opponents.Sum(o => o.XpGranted);
        
        player.CurrentHealth = player.MaxHealth;
        player.CurrentXp += xpGranted; 
        
        this.MessageWriter.WriteMessage("You win!");
        this.MessageReader.WaitForInput();
        this.MessageWriter.WriteMessage($"You earned {xpGranted} xp.");
    }

    public void ProcessLoss(PlayableEntity player)
    {
        var xpLost = player.CurrentXp / 2;
        player.CurrentXp -= xpLost;
        
        this.MessageWriter.WriteMessage("You lose!");
        this.MessageReader.WaitForInput();
        this.MessageWriter.WriteMessage($"You lose {xpLost} xp.");
    }
}