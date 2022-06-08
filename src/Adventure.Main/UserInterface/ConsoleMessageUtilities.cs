using Adventure.Main.Adapters.Interfaces;
using Adventure.Main.UserInterface.Interfaces;

namespace Adventure.Main.UserInterface;

internal class ConsoleMessageUtilities : IConsoleMessageUtilities
{
    public ConsoleMessageUtilities(IConsoleAdapter consoleAdapter)
    {
        this.ConsoleAdapter = consoleAdapter;
    }

    private IConsoleAdapter ConsoleAdapter { get; }
    
    public void ClearPreviousLines(int linesToClear)
    {
        for (var i = 0; i < linesToClear; i++)
        {
            this.ConsoleAdapter.SetCursorPosition(0, this.ConsoleAdapter.CursorTop - 1);
            this.ConsoleAdapter.Write(new string(' ', this.ConsoleAdapter.BufferWidth));
            this.ConsoleAdapter.SetCursorPosition(0, this.ConsoleAdapter.CursorTop - 1);
        }
    }
}