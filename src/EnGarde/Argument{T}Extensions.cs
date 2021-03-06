﻿// Copyright (c) Arjen Post. See License.txt in the project root for license information.

using System;
using System.Diagnostics;

namespace EnGarde
{
    public static partial class ArgumentExtensions
    {
        /// <summary>
        /// Determines whether the argument value does not equal the default value for the argument value type.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is the default value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not the default value (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<T> IsDefault<T>(this IArgument<T> argument, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            Exception exception;

            if (default(T) == null)
            {
                if (!ArgumentExtensions.ValidateIsNull(argument, message, out exception))
                {
                    throw exception;
                }
            }
            else
            {
                if (!ValidateIsDefault(argument.Value, argument.IsNegated, argument.ParameterName, message, out exception))
                {
                    throw exception;
                }
            }

            return argument.AsValidatedArgument();
        }

        /// <summary>
        /// Determines whether the argument value does not equal the default value for the argument value type.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is the default value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not the default value (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<T?> IsDefault<T>(this IArgument<T?> argument, string message = null) where T : struct
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            Exception exception;

            if (argument.Value.HasValue)
            {
                if (!ValidateIsDefault(argument.Value.Value, argument.IsNegated, argument.ParameterName, message, out exception))
                {
                    throw exception;
                }
            }

            return argument.AsValidatedArgument();
        }

        private static bool ValidateIsDefault<T>(T value, bool isNegativeAssertion, string parameterName, string message, out Exception exception)
        {
            if (default(T).Equals(value))
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

        /// <summary>
        /// Determines whether the specified condition is satisfied.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">The result of the condition.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentException">The condition is satisfied (if negated).</exception>
        /// <exception cref="ArgumentException">The condition is not satisfied (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<T> Satisfies<T>(this IArgument<T> argument, bool value, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            Exception exception;

            if (!ValidateSatisfies(value, argument.IsNegated, argument.ParameterName, message, out exception))
            {
                throw exception;
            }

            return argument.AsValidatedArgument();
        }

        private static bool ValidateSatisfies(bool value, bool isNegativeAssertion, string parameterName, string message, out Exception exception)
        {
            if (value)
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