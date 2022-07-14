﻿using Adventure.Main.Encounter.Interfaces;
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

    public void ProcessPlayerTurn(Entity player, Entity opponent)
    {
        var choice = this.MessageReader.ShowChoices(new List<string> { "Attack", "Run away" });

        switch (choice.ToUpper())
        {
            case "ATTACK":
                this.MessageWriter.WriteMessage($"[[{player.Name},Blue]] swings at [[{opponent.Name},Green]].");
                this.MessageReader.WaitForInput();

                var damage = this.DamageCalculator.Calculate(player.Attack);

                this.MessageWriter.WriteMessage($"[[{opponent.Name},Green]] took {damage} damage.");
                opponent.CurrentHealth -= damage;
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

        var damage = this.DamageCalculator.Calculate(opponent.Attack);

        this.MessageWriter.WriteMessage($"[[{opponent.Name},Green]] attacks for {damage} damage.");
        player.CurrentHealth -= damage;
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