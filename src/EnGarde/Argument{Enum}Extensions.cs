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

            Argument.Assert(argument, ParameterNames.Argument).Not().IsNull();

            Exception exception;

            if (!ValidateIsDefined(argument, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsDefined<T>(Argument<T> argument, string message, out Exception exception)
        {
            if (!Enum.IsDefined(typeof(T), argument.Value))
            {
                if (!argument.IsNegativeAssertion)
                {
                    exception = new InvalidEnumArgumentException(argument.ParameterName, Convert.ToInt32(argument.Value), typeof(T));

                    return false;
                }
            }
            else
            {
                if (argument.IsNegativeAssertion)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

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
            
            Argument.Assert(argument, ParameterNames.Argument).Not().IsNull();

            Exception exception;

            if (!ValidateHasFlag(argument, flag, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateHasFlag<T>(Argument<T> argument, T flag, string message, out Exception exception) where T : struct, IConvertible
        {
            var underlyingValue = Convert.ToInt64(argument.Value);
            var flagUnderlyingValue = Convert.ToInt64(flag);

            if ((flagUnderlyingValue & underlyingValue) != underlyingValue)
            {
                if (!argument.IsNegativeAssertion)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

                    return false;
                }
            }
            else
            {
                if (argument.IsNegativeAssertion)
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
