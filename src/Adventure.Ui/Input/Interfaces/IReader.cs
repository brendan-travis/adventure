using System.Collections.Generic;

namespace Adventure.Ui.Input.Interfaces
{
    /// <summary>
    /// Provides functionality to read input from a user.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Displays a list of choices to the user and returns the selected one.
        /// Will continuously loop until the user selects a valid choice.
        /// </summary>
        /// <param name="choices">A <see cref="IList{T}"/> of <see cref="string"/> values of the choices to display.</param>
        /// <returns>The user chosen choice from the list of input values.</returns>
        string ShowChoices(IList<string> choices);
    }
}