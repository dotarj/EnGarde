using System;
using System.ComponentModel;
using System.Diagnostics;

namespace EnGarde
{
    public static class ArgumentEnumExtensions
    {
        /// <summary>
        /// Checks whether the argument value is a defined enum value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><typeparamref name="T"/> is not an enum type.</exception>
        /// <exception cref="InvalidEnumArgumentException"><paramref name="argument"/> value is not a defined enum value.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsDefinedEnumValue<T>(this Argument<T> argument, string message = null) where T : struct, IConvertible
        {
            Argument.Assert(argument, ParameterNames.Argument).Not().IsNull();

            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException(string.Format(Messages.GenericTypeParameterMustBeEnum, typeof(T).Name));
            }

            Exception exception;

            if (!ValidateIsDefinedEnumValue(argument, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsDefinedEnumValue<T>(Argument<T> argument, string message, out Exception exception)
        {
            if (!Enum.IsDefined(typeof(T), argument.Value))
            {
                if (argument.IsNegativeAssertion)
                {
                    exception = new InvalidEnumArgumentException(argument.ParameterName, Convert.ToInt32(argument.Value), typeof(T));

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
