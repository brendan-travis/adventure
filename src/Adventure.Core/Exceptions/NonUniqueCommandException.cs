using System;

namespace Adventure.Core.Exceptions
{
    /// <summary>
    /// Represents errors that occur when the commands extracted from a list of choices aren't unique.
    /// </summary>
    public class NonUniqueCommandException : Exception
    {
        private new const string Message = "The choices provided do not contain unique commands.";

        public NonUniqueCommandException()
            : base(Message)
        {
        }

        public NonUniqueCommandException(Exception inner)
            : base(Message, inner)
        {
        }
    }
}