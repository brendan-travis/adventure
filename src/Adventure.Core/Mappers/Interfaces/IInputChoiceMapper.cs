using System.Collections.Generic;
using Adventure.Core.Models;

namespace Adventure.Core.Mappers.Interfaces
{
    /// <summary>
    /// Provides various mapping functionality around the <see cref="InputChoice"/> class.
    /// </summary>
    public interface IInputChoiceMapper
    {
        /// <summary>
        /// Maps a <see cref="IEnumerable{T}"/> of <see cref="string"/> values to a <see cref="IEnumerable{T}"/> of <see cref="InputChoice"/> values.
        /// Extracts a unique command value for each choice passed in.
        /// </summary>
        /// <param name="choices">The values to map. </param>
        /// <returns>The mapped values formatted as <see cref="InputChoice"/> values.</returns>
        IEnumerable<InputChoice> MapToInputChoices(IEnumerable<string> choices);
    }
}
