using Adventure.Ui.Azure.Ui.Interfaces;

namespace Adventure.Ui.Azure.Ui;

public class UiManager : IUiManager
{
    private const int ScreenCharLength = 3386;

    public char[] UiLayer0 { get; private set; }
    public char[] UiLayer1 { get; private set; }
    public char[] UiLayer2 { get; private set; }
    public char[] UiLayer3 { get; private set; }
    public char[] UiLayer4 { get; private set; }

    public char[][] UiLayer0Rows { get; private set; }
    public char[][] UiLayer1Rows { get; private set; }
    public char[][] UiLayer2Rows { get; private set; }
    public char[][] UiLayer3Rows { get; private set; }
    public char[][] UiLayer4Rows { get; private set; }

    private char[] DefaultUiRow { get; } =
        @"1                                                                                                                      "
            .ToCharArray();

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

        var allDefaultRows = new char[28][];
        for (var i = 0; i < 28; i++)
        {
            allDefaultRows[i] = this.DefaultUiRow;
        }

        this.UiLayer0Rows = allDefaultRows;
        this.UiLayer1Rows = allDefaultRows;
        this.UiLayer2Rows = allDefaultRows;
        this.UiLayer3Rows = allDefaultRows;
        this.UiLayer4Rows = allDefaultRows;
    }

    public void UpdateUi(string screen, int layer = 0)
    {
        if (screen.Length != ScreenCharLength)
        {
    #if DEBUG
            throw new Exception(
                $"Screen is not the required length. Found {screen.Length}, expected {ScreenCharLength}");
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
        var arrayToDraw = new char[ScreenCharLength];
        Array.Copy(this.UiLayer4, arrayToDraw, ScreenCharLength);

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

    public void UpdateUi(char[][] screen, int layer = 0)
    {
        switch (layer)
        {
            case 0:
            default:
                this.UiLayer0Rows = screen;
                break;
            case 1:
                this.UiLayer1Rows = screen;
                break;
            case 2:
                this.UiLayer2Rows = screen;
                break;
            case 3:
                this.UiLayer3Rows = screen;
                break;
            case 4:
                this.UiLayer4Rows = screen;
                break;
        }
        
        Console.Clear();
        for (var i = 0; i < 28; i++)
        {
            var rowToDraw = new string(screen[i]);
            Console.WriteLine(rowToDraw);
        }
    }

}