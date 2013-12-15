using System;
using System.ComponentModel;
using System.Diagnostics;

namespace EnGarde
{
    public static partial class ArgumentExtensions
    {
        /// <summary>
        /// Determines whether the argument value is a defined enum value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><typeparamref name="T"/> is not an enum type.</exception>
        /// <exception cref="InvalidEnumArgumentException"><paramref name="argument"/> value is not a defined enum value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is a defined enum value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsDefined<T>(this Argument<T> argument, string message = null) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException(string.Format(Messages.GenericTypeParameterMustBeEnum, typeof(T).Name));
            }

            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            Exception exception;

            if (!ValidateIsDefined(argument.Value, argument.IsNegativeAssertion, argument.ParameterName, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        /// <summary>
        /// Determines whether the argument value is a defined enum value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><typeparamref name="T"/> is not an enum type.</exception>
        /// <exception cref="InvalidEnumArgumentException"><paramref name="argument"/> value is not a defined enum value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is a defined enum value (if not negated).</exception>
        //[DebuggerStepThrough]
        public static Argument<T?> IsDefined<T>(this Argument<T?> argument, string message = null) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException(string.Format(Messages.GenericTypeParameterMustBeEnum, typeof(T).Name));
            }

            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value.HasValue)
            {
                Exception exception;

                if (!ValidateIsDefined(argument.Value.Value, argument.IsNegativeAssertion, argument.ParameterName, message, out exception))
                {
                    throw exception;
                }
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsDefined<T>(T value, bool isNegativeAssertion, string parameterName, string message, out Exception exception)
        {
            if (!Enum.IsDefined(typeof(T), value))
            {
                if (!isNegativeAssertion)
                {
                    exception = new InvalidEnumArgumentException(parameterName, Convert.ToInt32(value), typeof(T));

                    return false;
                }
            }
            else
            {
                if (isNegativeAssertion)
                {
                    exception = new ArgumentException(message, parameterName);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        /// <summary>
        /// Determines whether the argument value has one or more bit fields set.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><typeparamref name="T"/> is not an enum type.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value does not have one or more bit fields set (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value does have one or more bit fields set (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> HasFlag<T>(this Argument<T> argument, T flag, string message = null) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException(string.Format(Messages.GenericTypeParameterMustBeEnum, typeof(T).Name));
            }

            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            Exception exception;

            if (!ValidateHasFlag(argument.Value, argument.IsNegativeAssertion, flag, argument.ParameterName, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        /// <summary>
        /// Determines whether the argument value has one or more bit fields set.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><typeparamref name="T"/> is not an enum type.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value does not have one or more bit fields set (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value does have one or more bit fields set (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T?> HasFlag<T>(this Argument<T?> argument, T flag, string message = null) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException(string.Format(Messages.GenericTypeParameterMustBeEnum, typeof(T).Name));
            }

            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value.HasValue)
            {
                Exception exception;

                if (!ValidateHasFlag(argument.Value.Value, argument.IsNegativeAssertion, flag, argument.ParameterName, message, out exception))
                {
                    throw exception;
                }
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateHasFlag<T>(T value, bool isNegativeAssertion, T flag, string parameterName, string message, out Exception exception) where T : struct, IConvertible
        {
            var underlyingValue = Convert.ToInt64(value);
            var flagUnderlyingValue = Convert.ToInt64(flag);

            if ((flagUnderlyingValue & underlyingValue) != underlyingValue)
            {
                if (!isNegativeAssertion)
                {
                    exception = new ArgumentException(message, parameterName);

                    return false;
                }
            }
            else
            {
                if (isNegativeAssertion)
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
