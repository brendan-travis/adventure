namespace Adventure.Main.UserInterface.Interfaces;

/// <summary>
/// Provides various UI related activities related to drawing data and displaying it to the user.
/// </summary>
public interface IMessageWriter
{
    /// <summary>
    /// Writes a simple message to the UI.
    /// </summary>
    /// <param name="message">The message to write.</param>
    public void WriteMessage(string message);
}