namespace Adventure.Main.Adapters.Interfaces;

/// <inheritdoc cref="Console"/>
public interface IConsoleAdapter
{
    #region Properties

    /// <inheritdoc cref="Console.BufferWidth"/> 
    public int BufferWidth { get; set; }

    /// <inheritdoc cref="Console.CursorTop"/> 
    public int CursorTop { get; set; }

    /// <inheritdoc cref="Console.ForegroundColor"/> 
    public ConsoleColor ForegroundColor { get; set; }

    #endregion

    #region Methods

    /// <inheritdoc cref="System.Console.WriteLine(System.String, System.Object)"/>
    public void WriteLine(string format, object arg0);

    /// <inheritdoc cref="System.Console.WriteLine(System.String, System.Object, System.Object)"/>
    public void WriteLine(string format, object arg0, object arg1);

    /// <inheritdoc cref="System.Console.WriteLine(System.String, System.Object, System.Object, System.Object)"/>
    public void WriteLine(string format, object arg0, object arg1, object arg2);

    /// <inheritdoc cref="System.Console.WriteLine(System.String, System.Object[])"/>
    public void WriteLine(string format, object[] arg);

    /// <inheritdoc cref="System.Console.Write(System.String, System.Object)"/>
    public void Write(string format, object arg0);

    /// <inheritdoc cref="System.Console.Write(System.String, System.Object, System.Object)"/>
    public void Write(string format, object arg0, object arg1);

    /// <inheritdoc cref="System.Console.Write(System.String, System.Object, System.Object, System.Object)"/>
    public void Write(string format, object arg0, object arg1, object arg2);

    /// <inheritdoc cref="System.Console.Write(System.String, System.Object[])"/>
    public void Write(string format, object[] arg);

    /// <inheritdoc cref="System.Console.Write(Boolean)"/>
    public void Write(bool value);

    /// <inheritdoc cref="System.Console.Write(Char)"/>
    public void Write(char value);

    /// <inheritdoc cref="System.Console.Write(Char[])"/>
    public void Write(char[] buffer);

    /// <inheritdoc cref="System.Console.Write(Char[], Int32, Int32)"/>
    public void Write(char[] buffer, int index, int count);

    /// <inheritdoc cref="System.Console.Write(Double)"/>
    public void Write(double value);

    /// <inheritdoc cref="System.Console.Write(System.Decimal)"/>
    public void Write(decimal value);

    /// <inheritdoc cref="System.Console.Write(Single)"/>
    public void Write(float value);

    /// <inheritdoc cref="System.Console.Write(Int32)"/>
    public void Write(int value);

    /// <inheritdoc cref="System.Console.Write(UInt32)"/>
    public void Write(uint value);

    /// <inheritdoc cref="System.Console.Write(Int64)"/>
    public void Write(long value);

    /// <inheritdoc cref="System.Console.Write(UInt64)"/>
    public void Write(ulong value);

    /// <inheritdoc cref="System.Console.Write(System.Object)"/>
    public void Write(object value);

    /// <inheritdoc cref="System.Console.Write(System.String)"/>
    public void Write(string value);

    /// <inheritdoc cref="System.Console.ReadKey()"/>
    public ConsoleKeyInfo ReadKey();

    /// <inheritdoc cref="System.Console.ReadKey(Boolean)"/>
    public ConsoleKeyInfo ReadKey(bool intercept);

    /// <inheritdoc cref="System.Console.ResetColor()"/>
    public void ResetColor();

    /// <inheritdoc cref="System.Console.SetBufferSize(Int32, Int32)"/>
    public void SetBufferSize(int width, int height);

    /// <inheritdoc cref="System.Console.SetWindowPosition(Int32, Int32)"/>
    public void SetWindowPosition(int left, int top);

    /// <inheritdoc cref="System.Console.SetWindowSize(Int32, Int32)"/>
    public void SetWindowSize(int width, int height);

    /// <inheritdoc cref="System.Console.GetCursorPosition()"/>
    public ValueTuple<int,int> GetCursorPosition();

    /// <inheritdoc cref="System.Console.Beep()"/>
    public void Beep();

    /// <inheritdoc cref="System.Console.Beep(Int32, Int32)"/>
    public void Beep(int frequency, int duration);

    /// <inheritdoc cref="System.Console.MoveBufferArea(Int32, Int32, Int32, Int32, Int32, Int32)"/>
    public void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop);

    /// <inheritdoc cref="System.Console.MoveBufferArea(Int32, Int32, Int32, Int32, Int32, Int32, Char, System.ConsoleColor, System.ConsoleColor)"/>
    public void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor);

    /// <inheritdoc cref="System.Console.Clear()"/>
    public void Clear();

    /// <inheritdoc cref="System.Console.SetCursorPosition(Int32, Int32)"/>
    public void SetCursorPosition(int left, int top);

    /// <inheritdoc cref="System.Console.OpenStandardInput()"/>
    public Stream OpenStandardInput();

    /// <inheritdoc cref="System.Console.OpenStandardInput(Int32)"/>
    public Stream OpenStandardInput(int bufferSize);

    /// <inheritdoc cref="System.Console.OpenStandardOutput()"/>
    public Stream OpenStandardOutput();

    /// <inheritdoc cref="System.Console.OpenStandardOutput(Int32)"/>
    public Stream OpenStandardOutput(int bufferSize);

    /// <inheritdoc cref="System.Console.OpenStandardError()"/>
    public Stream OpenStandardError();

    /// <inheritdoc cref="System.Console.OpenStandardError(Int32)"/>
    public Stream OpenStandardError(int bufferSize);

    /// <inheritdoc cref="System.Console.SetIn(System.IO.TextReader)"/>
    public void SetIn(TextReader newIn);

    /// <inheritdoc cref="System.Console.SetOut(System.IO.TextWriter)"/>
    public void SetOut(TextWriter newOut);

    /// <inheritdoc cref="System.Console.SetError(System.IO.TextWriter)"/>
    public void SetError(TextWriter newError);

    /// <inheritdoc cref="System.Console.Read()"/>
    public int Read();

    /// <inheritdoc cref="System.Console.ReadLine()"/>
    public string? ReadLine();

    /// <inheritdoc cref="System.Console.WriteLine()"/>
    public void WriteLine();

    /// <inheritdoc cref="System.Console.WriteLine(Boolean)"/>
    public void WriteLine(bool value);

    /// <inheritdoc cref="System.Console.WriteLine(Char)"/>
    public void WriteLine(char value);

    /// <inheritdoc cref="System.Console.WriteLine(Char[])"/>
    public void WriteLine(char[] buffer);

    /// <inheritdoc cref="System.Console.WriteLine(Char[], Int32, Int32)"/>
    public void WriteLine(char[] buffer, int index, int count);

    /// <inheritdoc cref="System.Console.WriteLine(System.Decimal)"/>
    public void WriteLine(decimal value);

    /// <inheritdoc cref="System.Console.WriteLine(Double)"/>
    public void WriteLine(double value);

    /// <inheritdoc cref="System.Console.WriteLine(Single)"/>
    public void WriteLine(float value);

    /// <inheritdoc cref="System.Console.WriteLine(Int32)"/>
    public void WriteLine(int value);

    /// <inheritdoc cref="System.Console.WriteLine(UInt32)"/>
    public void WriteLine(uint value);

    /// <inheritdoc cref="System.Console.WriteLine(Int64)"/>
    public void WriteLine(long value);

    /// <inheritdoc cref="System.Console.WriteLine(UInt64)"/>
    public void WriteLine(ulong value);

    /// <inheritdoc cref="System.Console.WriteLine(System.Object)"/>
    public void WriteLine(object value);

    /// <inheritdoc cref="System.Console.WriteLine(System.String)"/>
    public void WriteLine(string value);

    #endregion
}