using Adventure.Main.UserInterface.Interfaces;

namespace Adventure.Main.UserInterface;

public class ConsoleMessageUtilities : IConsoleMessageUtilities
{
    public void ClearPreviousLines(int linesToClear)
    {
        for (var i = 0; i < linesToClear; i++)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}