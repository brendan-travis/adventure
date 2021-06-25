using System;

namespace Adventure.Core.Exceptions
{
    /// <summary>
    /// Represents errors that occur when the command key cannot be found in the provided choice.
    /// </summary>
    public class InvalidCommandKeyException : Exception
    {
        private new const string Message = "The choice provided does not contain provided command key.";
        
        public InvalidCommandKeyException()
            : base(Message)
        {
        }

        public InvalidCommandKeyException(Exception inner)
            : base(Message, inner)
        {
        }
    }
}