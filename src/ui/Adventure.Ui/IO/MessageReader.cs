using System.Text;
using Adventure.Core.Ui;

namespace Adventure.Ui.IO;

public class MessageReader : IMessageReader
{
    public MessageReader(IMessageWriter messageWriter)
    {
        MessageWriter = messageWriter;
    }

    private IMessageWriter MessageWriter { get; }

    public string ReadMessage(string messagePrompt)
    {
        string? input = null;

        while (string.IsNullOrWhiteSpace(input))
        {
            this.MessageWriter.WriteMessage(messagePrompt);

            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                this.MessageWriter.WriteMessage("Invalid input!");
            }
        }

        return input;
    }

    public string ReadMessage(string messagePrompt, string[] options)
    {
        var sb = new StringBuilder();

        var i = 0;
        foreach (var option in options)
        {
            sb.Append($"[{i + 1}] {option}{Environment.NewLine}");
            i++;
        }

        var chosenOption = 0;
        while (chosenOption == 0)
        {
            this.MessageWriter.WriteMessage(sb.ToString());

            Console.Write(">> ");
            var inputIsNumber = int.TryParse(Console.ReadLine() ?? "0", out chosenOption);

            if (!inputIsNumber || chosenOption <= 0 || chosenOption > options.Length)
            {
                this.MessageWriter.WriteMessage("Invalid input!");
                chosenOption = 0;
            }

            this.MessageWriter.WriteBlankLine();
        }

        return options[chosenOption - 1];
    }
}