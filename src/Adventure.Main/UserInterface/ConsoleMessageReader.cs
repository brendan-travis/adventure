using Adventure.Main.Adapters.Interfaces;
using Adventure.Main.Entities;
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
        if (!choices.Any())
        {
            throw new ArgumentException($"The input parameter {nameof(choices)} cannot be empty.");
        }
        
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
                case IList<NonPlayableEntity> entityChoices:
                    foreach (var choice in entityChoices)
                    {
                        this.MessageWriter.WriteMessage(choice == entityChoices[index]
                            ? $"[[> {choice.Name}, Cyan]]"
                            : $"  {choice.Name}");
                    }

                    break;
                case IList<Skill> skillChoices:
                    foreach (var choice in skillChoices)
                    {
                        this.MessageWriter.WriteMessage(choice == skillChoices[index]
                            ? $"[[> {choice.Name} - {choice.StaminaCost}, Cyan]]"
                            : $"  {choice.Name} - {choice.StaminaCost}");
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

    public void WaitForInput()
    {
        this.ConsoleAdapter.ReadKey(true);
    }
}