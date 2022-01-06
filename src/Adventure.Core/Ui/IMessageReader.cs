namespace Adventure.Core.Ui;

public interface IMessageReader
{
    string ReadMessage(string messagePrompt);
    
    string ReadMessage(string messagePrompt, string[] options);
}