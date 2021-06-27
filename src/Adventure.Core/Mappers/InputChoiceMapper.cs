using System;
using System.Collections.Generic;
using System.Linq;
using Adventure.Core.Exceptions;
using Adventure.Core.Mappers.Interfaces;
using Adventure.Core.Models;

namespace Adventure.Core.Mappers
{
    public class InputChoiceMapper : IInputChoiceMapper
    {
        public IEnumerable<InputChoice> MapToInputChoices(IEnumerable<string> choices)
        {
            var usedCommands = new List<string>();

            return choices.Select(x =>
            {
                var i = 0;
                var j = 1;
                string command = null;

                while(command == null)
                {
                    if (i+j > x.Length)
                    {
                        i = 0;
                        j++;
                    }
                    
                    if (j > x.Length)
                    {
                        throw new NonUniqueCommandException();
                    }

                    var attemptedCommand = x.Substring(i,j);

                    if (!usedCommands.Any(y => string.Equals(y, attemptedCommand, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        command = attemptedCommand;
                        usedCommands.Add(attemptedCommand);
                    }

                    i++;
                }

                return new InputChoice (command, x);
            });
        }
    }
}
