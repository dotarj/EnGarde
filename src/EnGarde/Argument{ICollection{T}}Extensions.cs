// Copyright (c) Arjen Post. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EnGarde
{
    public static partial class ArgumentExtensions
    {
        /// <summary>
        /// Determines whether the argument value contains the specified item.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">The object to locate in the <see cref="ICollection{T}"/>.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value contains the specified item (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value does not contain the specified item (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<ICollection<T>> Contains<T>(this IArgument<ICollection<T>> argument, T value, string message = null)
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

            if (!ValidateContains(argument, value, message, out exception))
            {
                throw exception;
            }

            return argument.AsValidatedArgument();
        }

        internal static bool ValidateContains<T>(IArgument<ICollection<T>> argument, T value, string message, out Exception exception)
        {
            if (argument.Value.Contains(value))
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
        /// Determines whether the argument value contains items.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value contains items (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value does not contain items (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<ICollection<T>> IsEmpty<T>(this IArgument<ICollection<T>> argument, string message = null)
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

        internal static bool ValidateIsEmpty<T>(IArgument<ICollection<T>> argument, string message, out Exception exception)
        {
            if (argument.Value.Count == 0)
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
    }
}