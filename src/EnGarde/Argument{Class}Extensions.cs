// Copyright (c) Arjen Post. See License.txt in the project root for license information.

using System;
using System.Diagnostics;

namespace EnGarde
{
    public static partial class ArgumentExtensions
    {
        /// <summary>
        /// Determines whether the argument value is not null.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> value is null (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not null (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<T> IsNull<T>(this IArgument<T> argument, string message = null) where T : class
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

        internal static bool ValidateIsNull<T>(IArgument<T> argument, string message, out Exception exception)
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
    }
}