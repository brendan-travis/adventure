using System;
using Adventure.Core.Exceptions;
using Adventure.Core.Extensions;

namespace Adventure.Core.Models
{
    public class InputChoice
    {
        public InputChoice(string commandKey, string choice)
        {
            commandKey.NotNullOrEmpty(nameof(commandKey));
            choice.NotNullOrEmpty(nameof(choice));
            
            this.CommandKey = commandKey;
            this.Choice = choice;
        }
        
        public string CommandKey { get; set; }

        public string Choice { get; set; }

        public string FormattedChoice 
        {
            get
            {
                if (!this.Choice.Contains(this.CommandKey))
                {
                    throw new InvalidCommandKeyException();
                }
                
                var splitCommand = this.Choice.Split(this.CommandKey, 2);

                return $"{splitCommand[0]}[{this.CommandKey}]{splitCommand[1]}";
            }
        }
    }
}
