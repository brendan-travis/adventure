using Adventure.Main.Adapters.Interfaces;

namespace Adventure.Main.Adapters;

internal class ConsoleAdapter : IConsoleAdapter
{
    public int BufferWidth { get => Console.BufferWidth; set => Console.BufferWidth = value; }
    public int CursorTop { get => Console.CursorTop; set => Console.CursorTop = value; }
    public ConsoleColor ForegroundColor { get => Console.ForegroundColor; set => Console.ForegroundColor = value; }

    public ConsoleKeyInfo ReadKey(bool intercept) => Console.ReadKey(intercept);
    public void ResetColor() => Console.ResetColor();
    public void SetCursorPosition(int left, int top) => Console.SetCursorPosition(left, top);
    public void Write(string? value) => Console.Write(value);
    public void WriteLine() => Console.WriteLine();
}