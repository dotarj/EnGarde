// Copyright (c) Arjen Post. See License.txt in the project root for license information.

using System;
using System.Diagnostics;

namespace EnGarde
{
    public static partial class ArgumentExtensions
    {
        /// <summary>
        /// Determines whether an instance of the current <see cref="Type"/> can be assigned from an instance of the 
        /// specified Type.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="otherValue">The type to compare with the current type.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is assignable from the specified type (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not assignable from the specified type (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<Type> IsAssignableFrom(this IArgument<Type> argument, Type otherValue, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            Exception exception;

            if (!ValidateIsAssignableFrom(argument, otherValue, message, out exception))
            {
                throw exception;
            }

            return argument.AsValidatedArgument();
        }

        private static bool ValidateIsAssignableFrom(IArgument<Type> argument, Type otherValue, string message, out Exception exception)
        {
            if (argument.Value.IsAssignableFrom(otherValue))
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
        /// Determines whether the class represented by the current <see cref="Type"/> derives from the class represented 
        /// by the specified Type.
        /// </summary>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="otherValue">The type to compare with the current type.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value derives from the specified type (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value does not derive from the specified type (if not negated).</exception>
        [DebuggerStepThrough]
        public static IValidatedArgument<Type> IsSubclassOf(this IArgument<Type> argument, Type otherValue, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            Exception exception;

            if (!ValidateIsSubclassOf(argument, otherValue, message, out exception))
            {
                throw exception;
            }

            return argument.AsValidatedArgument();
        }

        private static bool ValidateIsSubclassOf(IArgument<Type> argument, Type otherValue, string message, out Exception exception)
        {
            if (argument.Value.IsSubclassOf(otherValue))
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