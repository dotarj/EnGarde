using System;
using System.Diagnostics;

namespace EnGarde
{
    public static partial class ArgumentExtensions
    {
        /// <summary>
        /// Checks whether the nullable argument value has a value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> value is null.</exception>
        [DebuggerStepThrough]
        public static Argument<T?> HasValue<T>(this Argument<T?> argument, string message = null) where T : struct
        {
            Argument.Assert(argument, ParameterNames.Argument).Not().IsNull();

            Exception exception;

            if (!ValidateHasValue(argument, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateHasValue<T>(Argument<T?> argument, string message, out Exception exception) where T : struct
        {
            if (argument.Value.HasValue)
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
                    exception = new ArgumentNullException(argument.ParameterName, message);

                    return false;
                }
            }

            exception = null;
            
            return true;
        }
    }
}