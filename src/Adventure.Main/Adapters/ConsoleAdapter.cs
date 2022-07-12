using System.Runtime.Versioning;
using Adventure.Main.Adapters.Interfaces;

namespace Adventure.Main.Adapters;

internal class ConsoleAdapter : IConsoleAdapter
{
    [SupportedOSPlatform("windows")]
    public int BufferWidth
    {
        get => Console.BufferWidth;
        set => Console.BufferWidth = value;
    }

    public int CursorTop
    {
        get => Console.CursorTop;
        set => Console.CursorTop = value;
    }

    public ConsoleColor ForegroundColor
    {
        get => Console.ForegroundColor;
        set => Console.ForegroundColor = value;
    }

    public void WriteLine(string format, object arg0) => Console.WriteLine(format, arg0);

    public void WriteLine(string format, object arg0, object arg1) => Console.WriteLine(format, arg0, arg1);

    public void WriteLine(string format, object arg0, object arg1, object arg2) =>
        Console.WriteLine(format, arg0, arg1, arg2);

    public void WriteLine(string format, object[] arg) => Console.WriteLine(format, arg);

    public void Write(string format, object arg0) => Console.Write(format, arg0);

    public void Write(string format, object arg0, object arg1) => Console.Write(format, arg0, arg1);

    public void Write(string format, object arg0, object arg1, object arg2) => Console.Write(format, arg0, arg1, arg2);

    public void Write(string format, object[] arg) => Console.Write(format, arg);

    public void Write(bool value) => Console.Write(value);

    public void Write(char value) => Console.Write(value);

    public void Write(char[] buffer) => Console.Write(buffer);

    public void Write(char[] buffer, int index, int count) => Console.Write(buffer, index, count);

    public void Write(double value) => Console.Write(value);

    public void Write(decimal value) => Console.Write(value);

    public void Write(float value) => Console.Write(value);

    public void Write(int value) => Console.Write(value);

    public void Write(uint value) => Console.Write(value);

    public void Write(long value) => Console.Write(value);

    public void Write(ulong value) => Console.Write(value);

    public void Write(object value) => Console.Write(value);

    public void Write(string value) => Console.Write(value);

    public ConsoleKeyInfo ReadKey() => Console.ReadKey();

    public ConsoleKeyInfo ReadKey(bool intercept) => Console.ReadKey(intercept);

    public void ResetColor() => Console.ResetColor();

    [SupportedOSPlatform("windows")]
    public void SetBufferSize(int width, int height) => Console.SetBufferSize(width, height);

    [SupportedOSPlatform("windows")]
    public void SetWindowPosition(int left, int top) => Console.SetWindowPosition(left, top);

    [SupportedOSPlatform("windows")]
    public void SetWindowSize(int width, int height) => Console.SetWindowSize(width, height);

    public ValueTuple<int, int> GetCursorPosition() => Console.GetCursorPosition();

    public void Beep() => Console.Beep();

    [SupportedOSPlatform("windows")]
    public void Beep(int frequency, int duration) => Console.Beep(frequency, duration);

    [SupportedOSPlatform("windows")]
    public void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft,
        int targetTop) =>
        Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop);

    [SupportedOSPlatform("windows")]
    public void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft,
        int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor) =>
        Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar,
            sourceForeColor, sourceBackColor);

    public void Clear() => Console.Clear();

    public void SetCursorPosition(int left, int top) => Console.SetCursorPosition(left, top);

    public Stream OpenStandardInput() => Console.OpenStandardInput();

    public Stream OpenStandardInput(int bufferSize) => Console.OpenStandardInput(bufferSize);

    public Stream OpenStandardOutput() => Console.OpenStandardOutput();

    public Stream OpenStandardOutput(int bufferSize) => Console.OpenStandardOutput(bufferSize);

    public Stream OpenStandardError() => Console.OpenStandardError();

    public Stream OpenStandardError(int bufferSize) => Console.OpenStandardError(bufferSize);

    public void SetIn(TextReader newIn) => Console.SetIn(newIn);

    public void SetOut(TextWriter newOut) => Console.SetOut(newOut);

    public void SetError(TextWriter newError) => Console.SetError(newError);

    public int Read() => Console.Read();

    public string? ReadLine() => Console.ReadLine();

    public void WriteLine() => Console.WriteLine();

    public void WriteLine(bool value) => Console.WriteLine(value);

    public void WriteLine(char value) => Console.WriteLine(value);

    public void WriteLine(char[] buffer) => Console.WriteLine(buffer);

    public void WriteLine(char[] buffer, int index, int count) => Console.WriteLine(buffer, index, count);

    public void WriteLine(decimal value) => Console.WriteLine(value);

    public void WriteLine(double value) => Console.WriteLine(value);

    public void WriteLine(float value) => Console.WriteLine(value);

    public void WriteLine(int value) => Console.WriteLine(value);

    public void WriteLine(uint value) => Console.WriteLine(value);

    public void WriteLine(long value) => Console.WriteLine(value);

    public void WriteLine(ulong value) => Console.WriteLine(value);

    public void WriteLine(object value) => Console.WriteLine(value);

    public void WriteLine(string value) => Console.WriteLine(value);
}