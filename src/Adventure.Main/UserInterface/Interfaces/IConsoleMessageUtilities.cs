namespace Adventure.Main.UserInterface.Interfaces;

/// <summary>
/// A helper class that provides many useful functions specifically relating to the Console UI.
/// </summary>
public interface IConsoleMessageUtilities
{
    /// <summary>
    /// Clears the previous, specified number of lines from the Console output.
    /// Works backwards, from the bottom to the top.
    /// </summary>
    /// <param name="linesToClear">The number of lines to clear from the console.</param>
    public void ClearPreviousLines(int linesToClear);
}