using System.Text.RegularExpressions;
using Adventure.Main.Adapters.Interfaces;
using Adventure.Main.Entities;
using Adventure.Main.UserInterface.Interfaces;

namespace Adventure.Main.UserInterface;

internal class ConsoleMessageWriter : IMessageWriter
{
    public ConsoleMessageWriter(IConsoleAdapter consoleAdapter)
    {
        this.ConsoleAdapter = consoleAdapter;
    }

    private IConsoleAdapter ConsoleAdapter { get; }

    public void WriteMessage(string message)
    {
        var pieces = Regex.Split(message, @"(\[\[[^\]]*\]\])");

        foreach (var piece in pieces)
        {
            if (piece.StartsWith("[[") && piece.EndsWith("]]"))
            {
                var sub = piece.Split(',');

                this.ConsoleAdapter.ForegroundColor = Enum.Parse<ConsoleColor>(sub[1][..^2]);
                this.ConsoleAdapter.Write(sub[0].Substring(2, sub[0].Length - 2));
                this.ConsoleAdapter.ResetColor();
            }
            else
            {
                this.ConsoleAdapter.Write(piece);
            }
        }

        this.ConsoleAdapter.WriteLine();
    }

    public void RedrawUi(Entity? currentCharacter = null, IList<Entity>? battleOpponents = null)
    {
        this.ConsoleAdapter.Clear();

        // Player status bar 
        if (currentCharacter != null)
        {
            this.WriteMessage($"[[{currentCharacter.Name},Blue]] " +
                              $"Lv.[[{currentCharacter.StatSet.TotalLevel},Yellow]] " +
                              $"HP.[[{currentCharacter.CurrentHealth},Red]]/" +
                              $"[[{currentCharacter.MaxHealth},Red]] " +
                              $"St.[[{currentCharacter.CurrentStamina},Green]]/" +
                              $"[[{currentCharacter.MaxStamina},Green]] " +
                              $"(+[[{currentCharacter.RestoredStamina}, Green]])");
        }

        // Battle data
        if (battleOpponents != null)
        {
            this.ConsoleAdapter.WriteLine();
            foreach (var opponent in battleOpponents.Where(o => o.CurrentHealth > 0))
            {
                this.WriteMessage($"* [[{opponent.Name},Red]] " +
                                  $"Lv.[[{opponent.StatSet.TotalLevel},Yellow]] " +
                                  $"HP.[[{opponent.CurrentHealth},Red]]/" +
                                  $"[[{opponent.MaxHealth},Red]] ");
            }
        }

        this.ConsoleAdapter.WriteLine();
    }
}