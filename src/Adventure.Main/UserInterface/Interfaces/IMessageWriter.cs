using Adventure.Main.Entities;

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

    /// <summary>
    /// Redraws the screen to remove temporary information.
    /// Also used to update static informational objects on screen.
    /// </summary>
    /// <param name="currentCharacter">The current player's character.</param>
    /// <param name="battleOpponent">The battle opponent. Can be omitted if not in a battle.</param>
    public void RedrawUi(Entity currentCharacter, Entity? battleOpponent = null);
}