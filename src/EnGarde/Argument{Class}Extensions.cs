using System;
using System.Diagnostics;

namespace EnGarde
{
    public static class ArgumentClassExtensions
    {
        /// <summary>
        /// Checks whether the argument value is not null.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> value is null.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsNull<T>(this Argument<T> argument, string message = null) where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            Exception exception;

            if (!ValidateIsNull(argument, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        internal static bool ValidateIsNull<T>(Argument<T> argument, string message, out Exception exception)
        {
            if (argument.Value == null)
            {
                if (argument.IsNegativeAssertion)
                {
                    exception = new ArgumentNullException(argument.ParameterName, message);

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