using System;
using System.Diagnostics;

namespace EnGarde
{
    public static class ArgumentExtensions
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
        public static Argument<T> IsNotNull<T>(this Argument<T> argument, string message = null) where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value == null)
            {
                throw new ArgumentNullException(argument.ParameterName, message);
            }

            return argument;
        }

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
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();

            if (!argument.Value.HasValue)
            {
                throw new ArgumentNullException(argument.ParameterName, message);
            }

            return argument;
        }

        /// <summary>
        /// Checks whether the argument value does not equal the default value for the argument value type.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is the default value.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsNotDefault<T>(this Argument<T> argument, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();

            if (default(T) == null && argument.Value == null)
            {
                throw new ArgumentNullException(argument.ParameterName, message);
            }

            if (default(T).Equals(argument.Value))
            {
                throw new ArgumentException(message, argument.ParameterName);
            }

            return argument;
        }
    }
}