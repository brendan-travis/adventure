using Adventure.Core.UserInterface.Interfaces;
using Adventure.Main.Adapters.Interfaces;
using Adventure.Main.UserInterface.Interfaces;

namespace Adventure.Main.UserInterface;

internal class ConsoleMessageReader : IMessageReader
{
    public ConsoleMessageReader(IMessageWriter messageWriter, IConsoleMessageUtilities consoleMessageUtilities,
        IConsoleAdapter consoleAdapter)
    {
        this.MessageWriter = messageWriter;
        this.ConsoleMessageUtilities = consoleMessageUtilities;
        this.ConsoleAdapter = consoleAdapter;
    }

    private IMessageWriter MessageWriter { get; }

    private IConsoleMessageUtilities ConsoleMessageUtilities { get; }

    private IConsoleAdapter ConsoleAdapter { get; }

    public T ShowChoices<T>(IList<T> choices)
    {
        var index = 0;

        while (true)
        {
            switch (choices)
            {
                case IList<string> stringChoices:
                    foreach (var choice in stringChoices)
                    {
                        this.MessageWriter.WriteMessage(choice == stringChoices[index]
                            ? $"[[> {choice}, Cyan]]"
                            : $"  {choice}");
                    }

                    break;
                default:
                    throw new ArgumentException(
                        $"The type of the {nameof(choices)} parameter was invalid. {typeof(T)} is not valid.");
            }

            var input = this.ConsoleAdapter.ReadKey(true);
            this.ConsoleMessageUtilities.ClearPreviousLines(choices.Count);

            switch (input.Key)
            {
                case ConsoleKey.DownArrow:
                    if (index < choices.Count - 1)
                    {
                        index++;
                    }

                    break;
                case ConsoleKey.UpArrow:
                    if (index > 0)
                    {
                        index--;
                    }

                    break;
                case ConsoleKey.Enter:
                    return choices[index];
                default:
                    continue;
            }
        }
    }
}