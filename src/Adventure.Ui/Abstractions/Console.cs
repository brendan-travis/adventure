using System;
using Adventure.Ui.Abstractions.Interfaces;

namespace Adventure.Ui.Abstractions
{
    public class Console : IConsole
    {
        public ConsoleColor ForegroundColor
        {
             get => System.Console.ForegroundColor;
             set => System.Console.ForegroundColor = value;
        }

        public string ReadLine() =>  System.Console.ReadLine();

        public void ResetColor() => System.Console.ResetColor();

        public void Write(string input) => System.Console.Write(input);

        public void WriteLine(string input) => System.Console.WriteLine(input);
    }
}
