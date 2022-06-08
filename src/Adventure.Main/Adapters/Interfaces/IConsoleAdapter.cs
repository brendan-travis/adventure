namespace Adventure.Main.Adapters.Interfaces;

/// <inheritdoc cref="Console"/>
public interface IConsoleAdapter
{
    #region Properties

    /// <inheritdoc cref="Console.BufferWidth"/> 
    public int BufferWidth { get; set; }

    /// <inheritdoc cref="Console.CursorTop"/> 
    public int CursorTop { get; set; }

    /// <inheritdoc cref="Console.ForegroundColor"/> 
    public ConsoleColor ForegroundColor { get; set; }

    #endregion

    #region Methods

    /// <inheritdoc cref="Console.ReadKey(bool)"/> 
    public ConsoleKeyInfo ReadKey(bool intercept);

    /// <inheritdoc cref="Console.ResetColor()"/> 
    public void ResetColor();

    /// <inheritdoc cref="Console.SetCursorPosition(int, int)"/> 
    public void SetCursorPosition(int left, int top);

    /// <inheritdoc cref="Console.Write(string)"/> 
    public void Write(string? value);

    /// <inheritdoc cref="Console.WriteLine()"/> 
    public void WriteLine();

    #endregion
}