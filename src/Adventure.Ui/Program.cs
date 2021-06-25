using System.Collections.Generic;
using Adventure.Ui.Abstractions.Interfaces;
using Adventure.Ui.Extensions;
using Adventure.Ui.Input.Interfaces;
using Adventure.Core.Constants;
using Adventure.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Adventure.Ui
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .RegisterUiDependencies()
                .RegisterCoreDependencies()
                .BuildServiceProvider();

            var reader = serviceProvider.GetService<IReader>();
            var console = serviceProvider.GetService<IConsole>();

            console.WriteLine(AsciiArt.Title);

            var choice = reader.ShowChoices(new List<string>{ "New game", "Load game", "Exit" });
            switch(choice)
            {
                case("New game"):
                    console.WriteLine("You have chosen to create a new game");
                    break;
                case("Load game"):
                    console.WriteLine("You have chosen to load an existing game");
                    break;
            }
        }
    }
}
