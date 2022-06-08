using System.Text.RegularExpressions;
using Adventure.Core.UserInterface.Interfaces;

namespace Adventure.Main.UserInterface;

internal class ConsoleMessageWriter : IMessageWriter
{
    public void WriteMessage(string message)
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
}