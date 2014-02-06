// Copyright (c) Arjen Post. See License.txt in the project root for license information.

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
        public static IValidatedArgument<Guid> IsEmpty(this IArgument<Guid> argument, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            Exception exception;

            if (!ValidateIsEmpty(argument.Value, argument.IsNegated, argument.ParameterName, message, out exception))
            {
                throw exception;
            }

            return argument.AsValidatedArgument();
        }

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
        public static IValidatedArgument<Guid?> IsEmpty(this IArgument<Guid?> argument, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value.HasValue)
            {
                Exception exception;

                if (!ValidateIsEmpty(argument.Value.Value, argument.IsNegated, argument.ParameterName, message, out exception))
                {
                    throw exception;
                }
            }

            return argument.AsValidatedArgument();
        }

        private static bool ValidateIsEmpty(Guid value, bool isNegativeAssertion, string parameterName, string message, out Exception exception)
        {
            if (value.Equals(Guid.Empty))
            {
                if (isNegativeAssertion)
                {
                    exception = new ArgumentException(message, parameterName);

                    return false;
                }
            }
            else
            {
                if (!isNegativeAssertion)
                {
                    exception = new ArgumentException(message, parameterName);

                    return false;
                }
            }

            exception = null;

            return true;
        }
    }
}
