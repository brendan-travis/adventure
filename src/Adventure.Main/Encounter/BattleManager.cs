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
                this.MessageWriter.WriteMessage($"[[{player.Name},Blue]] swings at [[{opponent.Name},Green]].");
                this.MessageReader.WaitForInput();
                this.MessageWriter.WriteMessage($"[[{opponent.Name},Green]] took 610 damage.");
                opponent.CurrentHealth -= 610;
                if (opponent.CurrentHealth < 0) opponent.CurrentHealth = 0; 
                break;
            case "RUN AWAY":
                this.MessageWriter.WriteMessage("You could not escape.");
                break;
        }
    }

    public void ProcessOpponentTurn(Entity player, Entity opponent)
    {
        this.MessageWriter.WriteMessage($"[[{opponent.Name},Green]] swings at [[{player.Name},Blue]].");
        this.MessageReader.WaitForInput();
        this.MessageWriter.WriteMessage($"[[{opponent.Name},Green]] attacks for 70 damage.");
        player.CurrentHealth -= 70;
        if (player.CurrentHealth < 0) player.CurrentHealth = 0; 
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