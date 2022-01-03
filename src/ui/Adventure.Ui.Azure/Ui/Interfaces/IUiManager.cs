namespace Adventure.Ui.Azure.Ui.Interfaces;

public interface IUiManager
{
    public char[] UiLayer0 { get; }
    public char[] UiLayer1 { get; }
    public char[] UiLayer2 { get; }
    public char[] UiLayer3 { get; }
    public char[] UiLayer4 { get; }
    
    public char[][] UiLayer0Rows { get; }
    public char[][] UiLayer1Rows { get; }
    public char[][] UiLayer2Rows { get; }
    public char[][] UiLayer3Rows { get; }
    public char[][] UiLayer4Rows { get; }
    
    public void UpdateUi(string screen, int layer = 0);

    public void UpdateUi(char[][] screen, int layer = 0);
}