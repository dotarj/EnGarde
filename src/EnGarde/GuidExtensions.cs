using System;
using System.Diagnostics;

namespace EnGarde
{
    public static class GuidExtensions
    {
        /// <summary>
        /// Checks whether the argument value is not an empty guid.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is an empty guid.</exception>
        [DebuggerStepThrough]
        public static Argument<Guid> IsNotEmpty(this Argument<Guid> argument, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();

            if (argument.Value.Equals(Guid.Empty))
            {
                throw new ArgumentException(message, argument.ParameterName);
            }

            return argument;
        }
    }
}
