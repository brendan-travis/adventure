using System.Text;
using Adventure.Ui.Azure.Ui.Interfaces;

namespace Adventure.Ui.Azure.Ui;

public class UiManager : IUiManager
{
    private const int screenCharLength = 3386;

    public char[] UiLayer0 { get; private set; }
    public char[] UiLayer1 { get; private set; }
    public char[] UiLayer2 { get; private set; }
    public char[] UiLayer3 { get; private set; }
    public char[] UiLayer4 { get; private set; }

    private char[] DefaultUiLayer { get; } =
        @"                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       
                                                                                                                       "
            .ToCharArray();

    public UiManager()
    {
        this.UiLayer0 = this.DefaultUiLayer;
        this.UiLayer1 = this.DefaultUiLayer;
        this.UiLayer2 = this.DefaultUiLayer;
        this.UiLayer3 = this.DefaultUiLayer;
        this.UiLayer4 = this.DefaultUiLayer;
    }

    public void UpdateUi(string screen, int layer = 0)
    {
        if (screen.Length != screenCharLength)
        {
#if DEBUG
            throw new Exception(
                $"Screen is not the required length. Found {screen.Length}, expected {screenCharLength}");
#else
            return;
#endif
        }

        switch (layer)
        {
            case 0:
            default:
                this.UiLayer0 = screen.ToCharArray();
                break;
            case 1:
                this.UiLayer1 = screen.ToCharArray();
                break;
            case 2:
                this.UiLayer2 = screen.ToCharArray();
                break;
            case 3:
                this.UiLayer3 = screen.ToCharArray();
                break;
            case 4:
                this.UiLayer4 = screen.ToCharArray();
                break;
        }

        // Start with top layer
        var arrayToDraw = new char[screenCharLength];
        Array.Copy(this.UiLayer4, arrayToDraw, screenCharLength);

        for (var i = 0; i < arrayToDraw.Length; i++)
        {
            // Draw layer 3 if space is not occupied
            if (arrayToDraw[i] == ' ' && this.UiLayer3[i] != ' ')
            {
                arrayToDraw[i] = this.UiLayer3[i];
            }

            // Draw layer 2 if space is not occupied
            if (arrayToDraw[i] == ' ' && this.UiLayer2[i] != ' ')
            {
                arrayToDraw[i] = this.UiLayer2[i];
            }

            // Draw layer 1 if space is not occupied
            if (arrayToDraw[i] == ' ' && this.UiLayer1[i] != ' ')
            {
                arrayToDraw[i] = this.UiLayer1[i];
            }

            // Draw layer 0 if space is not occupied
            if (arrayToDraw[i] == ' ' && this.UiLayer0[i] != ' ')
            {
                arrayToDraw[i] = this.UiLayer0[i];
            }
        }

        // Redraw screen
        Console.Clear();
        var screenToDraw = new string(arrayToDraw);
        Console.WriteLine(screenToDraw);
    }
}