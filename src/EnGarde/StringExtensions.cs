using System;
using System.Diagnostics;
using System.Linq;

namespace EnGarde
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks whether the argument value is not null.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> value is null.</exception>
        [DebuggerStepThrough]
        public static Argument<string> IsNotNull(this Argument<string> argument, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();

            if (argument.Value == null)
            {
                throw new ArgumentNullException(argument.ParameterName, message);
            }
            
            return argument;
        }

        /// <summary>
        /// Checks whether the argument value is not empty.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is empty.</exception>
        [DebuggerStepThrough]
        public static Argument<string> IsNotEmpty(this Argument<string> argument, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            if (argument.Value.Length == 0)
            {
                throw new ArgumentException(message, argument.ParameterName);
            }

            return argument;
        }

        /// <summary>
        /// Checks whether the argument value is not whitespace.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is whitespace.</exception>
        [DebuggerStepThrough]
        public static Argument<string> IsNotWhitespace(this Argument<string> argument, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            if (!ContainsNonWhitespaceCharacters(argument.Value))
            {
                throw new ArgumentException(message, argument.ParameterName);
            }

            return argument;
        }

        /// <summary>
        /// Checks whether the argument value is not null or empty.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is empty.</exception>
        [DebuggerStepThrough]
        public static Argument<string> IsNotNullOrEmpty(this Argument<string> argument, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();

            if (argument.Value == null)
            {
                throw new ArgumentNullException(argument.ParameterName, message);
            }

            if (argument.Value.Length == 0)
            {
                throw new ArgumentException(message, argument.ParameterName);
            }

            return argument;
        }

        /// <summary>
        /// Checks whether the argument value is not null or whitespace.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is whitespace.</exception>
        [DebuggerStepThrough]
        public static Argument<string> IsNotNullOrWhitespace(this Argument<string> argument, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();

            if (argument.Value == null)
            {
                throw new ArgumentNullException(argument.ParameterName, message);
            }

            if (!ContainsNonWhitespaceCharacters(argument.Value))
            {
                throw new ArgumentException(message, argument.ParameterName);
            }

            return argument;
        }

        private static bool ContainsNonWhitespaceCharacters(string value)
        {
            return value.Any(character => !Char.IsWhiteSpace(character));
        }
    }
}
