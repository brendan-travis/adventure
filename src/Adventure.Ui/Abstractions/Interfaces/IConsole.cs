using System;

namespace Adventure.Ui.Abstractions.Interfaces
{
    /// <summary>
    /// [Proxy] Represents the standard input, output, and error streams for console applications. This class cannot be inherited.
    /// </summary>
    public interface IConsole
    {
        /// <summary>
        /// Gets or sets the foreground color of the console.
        /// </summary>
        /// <value>
        /// A System.ConsoleColor that specifies the foreground color of the console; that
        /// is, the color of each character that is displayed. The default is gray.
        /// </value>
        ConsoleColor ForegroundColor { get; set; }

        /// <summary>
        /// Reads the next line of characters from the standard input stream.
        /// </summary>
        /// <returns>
        /// The next line of characters from the input stream, or null if no more lines
        /// are available.
        /// </returns>
        string ReadLine();

        /// <summary>
        /// Sets the foreground and background console colors to their defaults.
        /// </summary>
        void ResetColor();

        /// <summary>
        /// Writes the specified string value to the standard output stream.
        /// </summary>
        /// <param name="input">The value to write.</param>
        void Write(string input);

        /// <summary>
        /// Writes the specified string value, followed by the current line terminator, to
        /// the standard output stream.
        /// </summary>
        /// <param name="input"></param>
        void WriteLine(string input);
    }
}