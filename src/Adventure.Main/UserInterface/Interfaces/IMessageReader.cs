namespace Adventure.Main.UserInterface.Interfaces;

/// <summary>
/// Provides various UI related activities related to reading in data from the user.
/// </summary>
public interface IMessageReader
{
    /// <summary>
    /// Presents the user with a list of choices and returns the selected option.
    /// </summary>
    /// <param name="choices">The choices to display. The return value will be one of these options.</param>
    /// <typeparam name="T">
    /// The type of the inputs. <see cref="string"/> is the most basic acceptable type but additional types can be
    /// handled to allow for better customised message prompts.
    /// </typeparam>
    /// <returns></returns>
    public T ShowChoices<T>(IList<T> choices);
}