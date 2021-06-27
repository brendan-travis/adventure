using System;
using System.Collections.Generic;
using System.Linq;

namespace Adventure.Core.Extensions
{
    /// <summary>
    /// Provides various helpers for <see cref="IEnumerable{T}"/> values.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Asserts the <see cref="IEnumerable{T}"/> value is not null or empty.
        /// Throws exceptions if the <see cref="IEnumerable{T}"/> value is invalid.
        /// </summary>
        /// <param name="target">The <see cref="IEnumerable{T}"/> to validate.</param>
        /// <param name="parameterName">
        /// The name of the <see cref="IEnumerable{T}"/> being validated, used for the <see cref="Exception"/> messages.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="target"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <see cref="target"/> is empty.</exception>
        public static void NotNullOrEmpty(this IEnumerable<object> target, string parameterName)
        {
            if (target == null)
                throw new ArgumentNullException(parameterName);

            if (!target.Any())
                throw new ArgumentException($"{parameterName} cannot be empty", parameterName);
        }
    }
}