using System;
using System.Collections.Generic;
using System.Linq;
using Adventure.Core.Extensions;
using Adventure.Core.Mappers.Interfaces;
using Adventure.Ui.Abstractions.Interfaces;
using Adventure.Ui.Input.Interfaces;

namespace Adventure.Ui.Input
{
    public class Reader : IReader
    {
        public Reader(IConsole console, IInputChoiceMapper inputChoiceMapper)
        {
            this.Console = console;
            this.InputChoiceMapper = inputChoiceMapper;
        }

        private IConsole Console { get; }

        private IInputChoiceMapper InputChoiceMapper { get; }

        public string ShowChoices(IList<string> choices)
        {
            choices.NotNullOrEmpty(nameof(choices));

            var availableChoices = this.InputChoiceMapper.MapToInputChoices(choices).ToList();

            var choice = string.Empty;
            var firstTimeRun = true;

            while (!availableChoices.Any(x =>
                string.Equals(choice, x.CommandKey, StringComparison.InvariantCultureIgnoreCase)))
            {
                if (!firstTimeRun)
                {
                    this.Console.WriteLine("");
                    this.Console.ForegroundColor = ConsoleColor.Red;
                    this.Console.WriteLine("That input was not valid. Please try again.");
                    this.Console.ResetColor();
                }

                firstTimeRun = false;

                this.Console.WriteLine("");
                foreach (var command in availableChoices)
                {
                    this.Console.WriteLine(command.FormattedChoice);
                }

                this.Console.WriteLine("");
                this.Console.Write("Please enter your choice: ");
                choice = this.Console.ReadLine().ToLower();
            }

            return availableChoices
                .First(x => string.Equals(choice, x.CommandKey, StringComparison.InvariantCultureIgnoreCase)).Choice;
        }
    }
}