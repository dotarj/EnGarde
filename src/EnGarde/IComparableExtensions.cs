using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EnGarde
{
    public static class IComparableExtensions
    {
        /// <summary>
        /// Checks whether the argument value is greater than the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is not greater than the given value.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThan<T>(this Argument<T> argument, T value, string message = null) where T : IComparable<T>
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            if (argument.Value.CompareTo(value) <= 0)
            {
                throw new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);
            }

            return argument;
        }

        /// <summary>
        /// Checks whether the argument value is greater than the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is not greater than the given value.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThan<T>(this Argument<T> argument, T value, IComparer<T> comparer, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();
            Argument.Assert(comparer, ParameterNames.Comparer).IsNotNull();

            if (comparer.Compare(argument.Value, value) <= 0)
            {
                throw new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);
            }

            return argument;
        }

        /// <summary>
        /// Checks whether the argument value is greater than or equal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is not greater than or equal to the given value.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThanOrEqualTo<T>(this Argument<T> argument, T value, string message = null) where T : IComparable<T>
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            if (argument.Value.CompareTo(value) < 0)
            {
                throw new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);
            }

            return argument;
        }

        /// <summary>
        /// Checks whether the argument value is greater than or queal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is not greater than or equal to the given value.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThanOrEqualTo<T>(this Argument<T> argument, T value, IComparer<T> comparer, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();
            Argument.Assert(comparer, ParameterNames.Comparer).IsNotNull();

            if (comparer.Compare(argument.Value, value) < 0)
            {
                throw new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);
            }

            return argument;
        }

        /// <summary>
        /// Checks whether the argument value is equal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is not equal to given value.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsEqualTo<T>(this Argument<T> argument, T value, string message = null) where T : IEquatable<T>
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            if (!argument.Value.Equals(value))
            {
                throw new ArgumentException(message, argument.ParameterName);
            }

            return argument;
        }

        /// <summary>
        /// Checks whether the argument value is equal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not equal to the given value.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsEqualTo<T>(this Argument<T> argument, T value, IEqualityComparer<T> comparer, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();
            Argument.Assert(comparer, ParameterNames.Comparer).IsNotNull();

            if (!comparer.Equals(argument.Value, value))
            {
                throw new ArgumentException(message, argument.ParameterName);
            }

            return argument;
        }

        /// <summary>
        /// Checks whether the argument value is not equal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is equal to given value.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsNotEqualTo<T>(this Argument<T> argument, T value, string message = null) where T : IEquatable<T>
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            if (argument.Value.Equals(value))
            {
                throw new ArgumentException(message, argument.ParameterName);
            }

            return argument;
        }

        /// <summary>
        /// Checks whether the argument value is not equal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is equal to the given value.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsNotEqualTo<T>(this Argument<T> argument, T value, IEqualityComparer<T> comparer, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();
            Argument.Assert(comparer, ParameterNames.Comparer).IsNotNull();

            if (comparer.Equals(argument.Value, value))
            {
                throw new ArgumentException(message, argument.ParameterName);
            }

            return argument;
        }

        /// <summary>
        /// Checks whether the argument value is less than or equal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is not less than or equal to the given value.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThanOrEqualTo<T>(this Argument<T> argument, T value, string message = null) where T : IComparable<T>
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            if (argument.Value.CompareTo(value) > 0)
            {
                throw new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);
            }

            return argument;
        }

        /// <summary>
        /// Checks whether the argument value is less than or queal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is not less than or equal to the given value.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThanOrEqualTo<T>(this Argument<T> argument, T value, IComparer<T> comparer, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();
            Argument.Assert(comparer, ParameterNames.Comparer).IsNotNull();

            if (comparer.Compare(argument.Value, value) > 0)
            {
                throw new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);
            }

            return argument;
        }

        /// <summary>
        /// Checks whether the argument value is less than the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is not less than the given value.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThan<T>(this Argument<T> argument, T value, string message = null) where T : IComparable<T>
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            if (argument.Value.CompareTo(value) >= 0)
            {
                throw new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);
            }

            return argument;
        }

        /// <summary>
        /// Checks whether the argument value is less than the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is not less than the given value.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThan<T>(this Argument<T> argument, T value, IComparer<T> comparer, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).IsNotNull();
            Argument.Assert(comparer, ParameterNames.Comparer).IsNotNull();

            if (comparer.Compare(argument.Value, value) >= 0)
            {
                throw new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);
            }

            return argument;
        }
    }
}
