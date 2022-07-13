using Adventure.Main.Encounter.Interfaces;
using Adventure.Main.Entities;
using Adventure.Main.UserInterface.Interfaces;

namespace Adventure.Main.Encounter;

public class BattleManager : IBattleManager
{
    public BattleManager(IMessageReader messageReader, IMessageWriter messageWriter)
    {
        this.MessageReader = messageReader;
        this.MessageWriter = messageWriter;
    }

    private IMessageReader MessageReader { get; }
    
    private IMessageWriter MessageWriter { get; }
    
    public void ProcessPlayerTurn(Entity player, Entity opponent)
    {
        var choice = this.MessageReader.ShowChoices(new List<string> { "Attack", "Run away" });

        switch (choice.ToUpper())
        {
            case "ATTACK":
                this.MessageWriter.WriteMessage($"[[{opponent.Name},Green]] took 1100 damage.");
                opponent.CurrentHealth -= 1100;
                if (opponent.CurrentHealth < 0) opponent.CurrentHealth = 0; 
                this.MessageWriter.WriteMessage($"[[{opponent.Name},Green]] has [[{opponent.CurrentHealth},Yellow]] remaining.");
                break;
            case "RUN AWAY":
                this.MessageWriter.WriteMessage("You could not escape.");
                break;
        }
    }

    public void ProcessOpponentTurn(Entity player, Entity opponent)
    {
        this.MessageWriter.WriteMessage($"[[{opponent.Name},Green]] attacks for 70 damage.");
        player.CurrentHealth -= 110;
        if (player.CurrentHealth < 0) player.CurrentHealth = 0; 
        this.MessageWriter.WriteMessage($"[[{player.Name},Green]] has [[{player.CurrentHealth},Yellow]] remaining.");
    }

    public void ProcessVictory(Entity player, Entity opponent)
    {
        this.MessageWriter.WriteMessage("You win!");
    }

    public void ProcessLoss(Entity player)
    {
        this.MessageWriter.WriteMessage("You lose!");
    }
}