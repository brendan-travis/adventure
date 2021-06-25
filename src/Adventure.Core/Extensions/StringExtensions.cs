using System;

namespace Adventure.Core.Extensions
{
    /// <summary>
    /// Provides various helpers for <see cref="string"/> values.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Validates the <see cref="string"/> value to make sure it is not null or empty.
        /// Throws exceptions if the <see cref="string"/> value is invalid.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to validate.</param>
        /// <param name="parameterName">
        /// The name of the <see cref="string"/> being validated, used for the <see cref="Exception"/> messages.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="value"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <see cref="value"/> is empty.</exception>
        public static void NotNullOrEmpty(this string value, string parameterName)
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);

            if (value.Trim() == string.Empty)
                throw new ArgumentException($"{parameterName} cannot be empty", parameterName);
        }
    }
}