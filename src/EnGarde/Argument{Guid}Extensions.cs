using System;
using System.Diagnostics;

namespace EnGarde
{
    public static partial class ArgumentExtensions
    {
        /// <summary>
        /// Determines whether the argument value is not an empty guid.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is an empty guid (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not an empty guid (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<Guid> IsEmpty(this Argument<Guid> argument, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).Not().IsNull();

            Exception exception;

            if (!ValidateIsEmpty(argument, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsEmpty(Argument<Guid> argument, string message, out Exception exception)
        {
            if (argument.Value.Equals(Guid.Empty))
            {
                if (argument.IsNegativeAssertion)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegativeAssertion)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }

            exception = null;

            return true;
        }
    }
}
