using System.Text.RegularExpressions;
using Adventure.Models;

namespace Adventure.UserInterface;

public static class UiManager
{
    public static StatusBar StatusBar { get; set; } = new();
    public static LocaleBar LocaleBar { get; set; } = new();

    public static void DrawUi()
    {
        Console.Clear();
        
        WriteMessage($"[[{StatusBar.CharacterName},Blue]] " +
                     $"Lvl.[[{StatusBar.Level},Magenta]] " +
                     $"HP.[[{StatusBar.HealthPoints},Red]]/[[{StatusBar.HealthPointsTotal},Red]] " +
                     $"Sta.[[{StatusBar.Stamina},Green]]/[[{StatusBar.StaminaTotal},Green]]");
        
        if (LocaleBar.Type != LocaleType.Unknown)
        {
            WriteMessage(LocaleBar.Type == LocaleType.Battle
                ? $"{LocaleBar.Type}"
                : $"{LocaleBar.Type}: [[{LocaleBar.Name},Blue]]");
        }

        WriteMessage("");
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

    public static void AwaitUserConfirmation()
    {
        Console.WriteLine("");
        Console.WriteLine("Press enter to continue");
        while (true)
        {
            var input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.Enter)
            {
                break;
            }
        }
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