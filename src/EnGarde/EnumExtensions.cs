using System;
using System.ComponentModel;
using System.Diagnostics;

namespace EnGarde
{
    public static class EnumExtensions
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
        public static Argument<T> IsDefinedEnumValue<T>(this Argument<T> argument) where T : struct, IConvertible
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();

            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException(string.Format(Messages.GenericTypeParameterMustBeEnum, typeof(T).Name));
            }

            if (!Enum.IsDefined(typeof(T), argument.Value))
            {
                throw new InvalidEnumArgumentException(argument.ParameterName, Convert.ToInt32(argument.Value), typeof(T));
            }

            return argument;
        }
    }
}
