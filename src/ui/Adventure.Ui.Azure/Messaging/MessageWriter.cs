using Adventure.Core.Ui;

namespace Adventure.Ui.Azure.Messaging;

public class MessageWriter : IMessageWriter
{
    public void WriteMessage(string message)
    {
        Console.WriteLine(message);
    }
}