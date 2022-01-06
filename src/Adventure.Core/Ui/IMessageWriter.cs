namespace Adventure.Core.Ui;

public interface IMessageWriter
{
    void WriteMessage(string message);

    void WriteBlankLine();

    void NewSection();
}