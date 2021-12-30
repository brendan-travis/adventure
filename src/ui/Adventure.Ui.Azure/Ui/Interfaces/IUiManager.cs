namespace Adventure.Ui.Azure.Ui.Interfaces;

public interface IUiManager
{
    public char[] UiLayer0 { get; }
    public char[] UiLayer1 { get; }
    public char[] UiLayer2 { get; }
    public char[] UiLayer3 { get; }
    public char[] UiLayer4 { get; }
    
    public void UpdateUi(string screen, int layer = 0);
}