// Copyright (c) Arjen Post. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Linq;

namespace EnGarde
{
    public static partial class ArgumentExtensions
    {
        /// <summary>
        /// Determines whether the argument value is not null.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> value is null (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is null (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<string> IsNull(this IArgument<string> argument, string message = null)
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

            return argument.AsValidatedArgument();
        }

        private static bool ValidateIsNull(IArgument<string> argument, string message, out Exception exception)
        {
            if (argument.Value == null)
            {
                if (argument.IsNegated)
                {
                    exception = new ArgumentNullException(argument.ParameterName, message);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegated)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        /// <summary>
        /// Determines whether the argument value is not empty.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is empty (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not empty (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<string> IsEmpty(this IArgument<string> argument, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            Exception exception;

            if (!ValidateIsEmpty(argument, message, out exception))
            {
                throw exception;
            }

            return argument.AsValidatedArgument();
        }

        private static bool ValidateIsEmpty(IArgument<string> argument, string message, out Exception exception)
        {
            if (argument.Value.Length == 0)
            {
                if (argument.IsNegated)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegated)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        /// <summary>
        /// Determines whether the argument value is not whitespace.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is whitespace (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not whitespace (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<string> IsWhitespace(this IArgument<string> argument, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            Exception exception;

            if (!ValidateIsWhitespace(argument, message, out exception))
            {
                throw exception;
            }

            return argument.AsValidatedArgument();
        }

        private static bool ValidateIsWhitespace(IArgument<string> argument, string message, out Exception exception)
        {
            if (!ContainsNonWhitespaceCharacters(argument.Value))
            {
                if (argument.IsNegated)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegated)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        private static bool ContainsNonWhitespaceCharacters(string value)
        {
            return value.Any(character => !Char.IsWhiteSpace(character));
        }

        /// <summary>
        /// Determines whether the argument value is not null or empty.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> value is null (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is empty (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not null (if not negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not empty (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<string> IsNullOrEmpty(this IArgument<string> argument, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            Exception exception;

            if (!ValidateIsNullOrEmpty(argument, message, out exception))
            {
                throw exception;
            }

            return argument.AsValidatedArgument();
        }

        private static bool ValidateIsNullOrEmpty(IArgument<string> argument, string message, out Exception exception)
        {
            if (argument.Value == null)
            {
                if (argument.IsNegated)
                {
                    exception = new ArgumentNullException(argument.ParameterName, message);

                    return false;
                }
            }
            else if (argument.Value.Length == 0)
            {
                if (argument.IsNegated)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegated)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        /// <summary>
        /// Determines whether the argument value is not null or whitespace.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> value is null (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is whitespace (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not null (if not negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not whitespace (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<string> IsNullOrWhitespace(this IArgument<string> argument, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            Exception exception;

            if (!ValidateIsNullOrWhitespace(argument, message, out exception))
            {
                throw exception;
            }

            return argument.AsValidatedArgument();
        }

        private static bool ValidateIsNullOrWhitespace(IArgument<string> argument, string message, out Exception exception)
        {
            if (argument.Value == null)
            {
                if (argument.IsNegated)
                {
                    exception = new ArgumentNullException(argument.ParameterName, message);

                    return false;
                }
            }
            else if (!ContainsNonWhitespaceCharacters(argument.Value))
            {
                if (argument.IsNegated)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegated)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        /// <summary>
        /// Determines whether the argument value starts with the given value.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A <see cref="String"/> object to compare to.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> does start with the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> does not start with the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<string> StartsWith(this IArgument<string> argument, string value, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            Exception exception;

            if (!ValidateStartsWith(argument, value, StringComparison.CurrentCulture, message, out exception))
            {
                throw exception;
            }

            return argument.AsValidatedArgument();
        }

        private static bool ValidateStartsWith(IArgument<string> argument, string value, StringComparison comparisonType, string message, out Exception exception)
        {
            if (argument.Value.StartsWith(value, comparisonType))
            {
                if (argument.IsNegated)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegated)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        /// <summary>
        /// Determines whether the argument value starts with the given value.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A <see cref="String"/> object to compare to.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values that determines how this string and value are compared.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> does start with the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> does not start with the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<string> StartsWith(this IArgument<string> argument, string value, StringComparison comparisonType, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            Exception exception;

            if (!ValidateStartsWith(argument, value, comparisonType, message, out exception))
            {
                throw exception;
            }

            return argument.AsValidatedArgument();
        }

        /// <summary>
        /// Determines whether the argument value ends with the given value.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A <see cref="String"/> object to compare to.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> does end with the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> does not end with the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<string> EndsWith(this IArgument<string> argument, string value, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            Exception exception;

            if (!ValidateEndsWith(argument, value, StringComparison.CurrentCulture, message, out exception))
            {
                throw exception;
            }

            return argument.AsValidatedArgument();
        }

        private static bool ValidateEndsWith(IArgument<string> argument, string value, StringComparison comparisonType, string message, out Exception exception)
        {
            if (argument.Value.EndsWith(value, comparisonType))
            {
                if (argument.IsNegated)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegated)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        /// <summary>
        /// Determines whether the argument value ends with the given value.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A <see cref="String"/> object to compare to.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values that determines how this string and value are compared.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> does end with the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> does not end with the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<string> EndsWith(this IArgument<string> argument, string value, StringComparison comparisonType, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            Exception exception;

            if (!ValidateEndsWith(argument, value, comparisonType, message, out exception))
            {
                throw exception;
            }

            return argument.AsValidatedArgument();
        }

        /// <summary>
        /// Determines whether the argument value contains with the given value.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A <see cref="String"/> object to compare to.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> does contain the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> does not contain the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<string> Contains(this IArgument<string> argument, string value, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            Exception exception;

            if (!ValidateContainsWith(argument, value, StringComparison.CurrentCulture, message, out exception))
            {
                throw exception;
            }

            return argument.AsValidatedArgument();
        }

        private static bool ValidateContainsWith(IArgument<string> argument, string value, StringComparison comparisonType, string message, out Exception exception)
        {
            if (argument.Value.IndexOf(value, comparisonType) >= 0)
            {
                if (argument.IsNegated)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegated)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        /// <summary>
        /// Determines whether the argument value contains with the given value.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A <see cref="String"/> object to compare to.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values that determines how this string and value are compared.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> does contain the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> does not contain the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<string> Contains(this IArgument<string> argument, string value, StringComparison comparisonType, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            Exception exception;

            if (!ValidateContainsWith(argument, value, comparisonType, message, out exception))
            {
                throw exception;
            }

            return argument.AsValidatedArgument();
        }
    }
}
