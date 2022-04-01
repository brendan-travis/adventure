using System.Text.RegularExpressions;
using Adventure.Models;
using System;

namespace Adventure.Managers;

public static class UiManager
{
    public static LocaleBar LocaleBar { get; set; } = new();

    public static void RedrawUi()
    {
        Console.Clear();

        // Player status bar 
        WriteMessage($"[[{CharacterManager.CurrentCharacter.Name},Blue]] " +
                     $"Lvl.[[{CharacterManager.CurrentCharacter.Level},Magenta]] " +
                     $"HP.[[{CharacterManager.CurrentCharacter.Stats.CurrentHp},Red]]/" +
                     $"[[{CharacterManager.CurrentCharacter.Stats.MaximumHp},Red]] " +
                     $"Sta.[[{CharacterManager.CurrentCharacter.Stats.CurrentStamina},Green]]/" +
                     $"[[{CharacterManager.CurrentCharacter.Stats.MaximumStamina},Green]] " +
                     $"+[[{AttributeScalingTables.EnduranceToStamina[CharacterManager.CurrentCharacter.Attributes.Endurance]},Green]]");

        // Locale bar
        switch (LocaleBar.Type)
        {
            case LocaleType.Battle:
                WriteMessage($"{LocaleBar.Type}");
                break;
            case LocaleType.Special:
                WriteMessage($"{LocaleBar.Name}");
                break;
            case LocaleType.Unknown:
                break;
            case LocaleType.Town:
            case LocaleType.Field:
            case LocaleType.Dungeon:
            default:
                WriteMessage($"{LocaleBar.Type}: [[{LocaleBar.Name},Blue]]");
                break;
        }

        WriteMessage();

        // Opposing team in battle
        if (BattleManager.InBattle)
        {
            foreach (var entity in BattleManager.OpposingTeam)
            {
                WriteMessage($"* [[{entity.Name},Red]] " +
                             $"Lvl.[[{entity.Level},Magenta]] " +
                             $"HP.[[{entity.Stats.CurrentHp},Red]]/" +
                             $"[[{entity.Stats.MaximumHp},Red]]");
            }

            WriteMessage();
        }
    }

    public static void ClearUi()
    {
        Console.Clear();
    }

    public static void WriteMessage()
    {
        Console.WriteLine();
    }

    public static void WriteMessage(string message)
    {
        var pieces = Regex.Split(message, @"(\[\[[^\]]*\]\])");

        foreach (var piece in pieces)
        {
            if (piece.StartsWith("[[") && piece.EndsWith("]]"))
            {
                var sub = piece.Split(',');

                Console.ForegroundColor = Enum.Parse<ConsoleColor>(sub[1][..^2]);
                Console.Write(sub[0].Substring(2, sub[0].Length - 2));
                Console.ResetColor();
            }
            else
            {
                Console.Write(piece);
            }
        }

        Console.WriteLine();
    }

    public static string ShowChoices(IList<string> choices)
    {
        var index = 0;

        while (true)
        {
            foreach (var choice in choices)
            {
                WriteMessage(choice == choices[index] ? $"[[> {choice}, Cyan]]" : $"  {choice}");
            }

            var input = Console.ReadKey(true);

            ClearPreviousLines(choices.Count);

            switch (input.Key)
            {
                case ConsoleKey.DownArrow:
                    if (index < choices.Count - 1)
                    {
                        index++;
                    }

                    break;
                case ConsoleKey.UpArrow:
                    if (index > 0)
                    {
                        index--;
                    }

                    break;
                case ConsoleKey.Enter:
                    return choices[index];
            }
        }
    }

    public static Skill ShowChoices(IList<Skill> choices)
    {
        var index = 0;

        while (true)
        {
            foreach (var choice in choices)
            {
                WriteMessage(choice == choices[index]
                    ? $"[[> {choice.Name}, Cyan]] ([[{choice.StaminaCost}, Green]])"
                    : $"  {choice.Name} ([[{choice.StaminaCost}, Green]])");
            }

            var input = Console.ReadKey(true);

            ClearPreviousLines(choices.Count);

            switch (input.Key)
            {
                case ConsoleKey.DownArrow:
                    if (index < choices.Count - 1)
                    {
                        index++;
                    }

                    break;
                case ConsoleKey.UpArrow:
                    if (index > 0)
                    {
                        index--;
                    }

                    break;
                case ConsoleKey.Enter:
                    return choices[index];
            }
        }
    }

    public static void AwaitUserConfirmation()
    {
        while (true)
        {
            var input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.Enter)
            {
                break;
            }
        }
    }

    public static void WriteDialog(string speaker, string message)
    {
        WriteMessage($"[[[{speaker}],Yellow]]");
        WriteMessage($"    \"{message}\"");
        WriteMessage();
    }

    private static void ClearPreviousLines(int linesToClear)
    {
        for (var i = 0; i < linesToClear; i++)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}