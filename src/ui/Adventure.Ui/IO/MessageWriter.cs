using Adventure.Core.Ui;

namespace Adventure.Ui.IO;

public class MessageWriter : IMessageWriter
{
    private const int MessageDelay = 1_000;
    
    public void WriteMessage(string message)
    {
        Thread.Sleep(MessageDelay);
        Console.WriteLine(message);
    }

    public void WriteBlankLine()
    {
        Console.WriteLine();
    }

    public void NewSection()
    {
        Thread.Sleep(MessageDelay);
        Console.WriteLine(@"

-------------------------------------------------------------------

");
    }
}