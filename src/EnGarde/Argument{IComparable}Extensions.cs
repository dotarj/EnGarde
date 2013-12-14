using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EnGarde
{
    public static partial class ArgumentExtensions
    {
        /// <summary>
        /// Determines whether the argument value is greater than the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is greater than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not greater than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThan<T>(this Argument<T> argument, T value, string message = null) where T : IComparable<T>
        {
            Argument.Assert(argument, ParameterNames.Argument).Not().IsNull();

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            Exception exception;

            if (!ValidateIsGreaterThan(argument, value, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsGreaterThan<T>(Argument<T> argument, T value, string message, out Exception exception) where T : IComparable<T>
        {
            if (argument.Value.CompareTo(value) > 0)
            {
                if (argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        /// <summary>
        /// Determines whether the argument value is greater than the given value.
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
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is greater than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not greater than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThan<T>(this Argument<T> argument, T value, IComparer<T> comparer, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).Not().IsNull();
            Argument.Assert(comparer, ParameterNames.Comparer).Not().IsNull();

            Exception exception;

            if (!ValidateIsGreaterThan(argument, value, comparer, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsGreaterThan<T>(Argument<T> argument, T value, IComparer<T> comparer, string message, out Exception exception)
        {
            if (comparer.Compare(argument.Value, value) > 0)
            {
                if (argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        /// <summary>
        /// Determines whether the argument value is greater than or equal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is greater or equal than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not greater or equal than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThanOrEqualTo<T>(this Argument<T> argument, T value, string message = null) where T : IComparable<T>
        {
            Argument.Assert(argument, ParameterNames.Argument).Not().IsNull();

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            Exception exception;

            if (!ValidateIsGreaterThanOrEqualTo(argument, value, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsGreaterThanOrEqualTo<T>(Argument<T> argument, T value, string message, out Exception exception) where T : IComparable<T>
        {
            if (argument.Value.CompareTo(value) >= 0)
            {
                if (argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        /// <summary>
        /// Determines whether the argument value is greater than or queal to the given value.
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
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is greater or equal than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not greater or equal than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThanOrEqualTo<T>(this Argument<T> argument, T value, IComparer<T> comparer, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).Not().IsNull();
            Argument.Assert(comparer, ParameterNames.Comparer).Not().IsNull();

            Exception exception;

            if (!ValidateIsGreaterThanOrEqualTo(argument, value, comparer, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsGreaterThanOrEqualTo<T>(Argument<T> argument, T value, IComparer<T> comparer, string message, out Exception exception)
        {
            if (comparer.Compare(argument.Value, value) >= 0)
            {
                if (argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        /// <summary>
        /// Determines whether the argument value is equal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is equal to given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not equal to given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsEqualTo<T>(this Argument<T> argument, T value, string message = null) where T : IEquatable<T>
        {
            Argument.Assert(argument, ParameterNames.Argument).Not().IsNull();

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            Exception exception;

            if (!ValidateIsEqualTo(argument, value, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsEqualTo<T>(Argument<T> argument, T value, string message, out Exception exception) where T : IEquatable<T>
        {
            if (argument.Value.Equals(value))
            {
                if (argument.IsNegativeAssertion)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

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

        /// <summary>
        /// Determines whether the argument value is equal to the given value.
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
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is equal to given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not equal to given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsEqualTo<T>(this Argument<T> argument, T value, IEqualityComparer<T> comparer, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).Not().IsNull();
            Argument.Assert(comparer, ParameterNames.Comparer).Not().IsNull();

            Exception exception;

            if (!ValidateIsEqualTo(argument, value, comparer, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsEqualTo<T>(Argument<T> argument, T value, IEqualityComparer<T> comparer, string message, out Exception exception)
        {
            if (comparer.Equals(argument.Value, value))
            {
                if (argument.IsNegativeAssertion)
                {
                    exception = new ArgumentException(message, argument.ParameterName);

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

        /// <summary>
        /// Determines whether the argument value is less than or equal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is less or equal than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not less or equal than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThanOrEqualTo<T>(this Argument<T> argument, T value, string message = null) where T : IComparable<T>
        {
            Argument.Assert(argument, ParameterNames.Argument).Not().IsNull();

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            Exception exception;

            if (!ValidateIsLessThanOrEqualTo(argument, value, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsLessThanOrEqualTo<T>(Argument<T> argument, T value, string message, out Exception exception) where T : IComparable<T>
        {
            if (argument.Value.CompareTo(value) <= 0)
            {
                if (argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        /// <summary>
        /// Determines whether the argument value is less than or queal to the given value.
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
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is less or equal than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not less or equal than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThanOrEqualTo<T>(this Argument<T> argument, T value, IComparer<T> comparer, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).Not().IsNull();
            Argument.Assert(comparer, ParameterNames.Comparer).Not().IsNull();

            Exception exception;

            if (!ValidateIsLessThanOrEqualTo(argument, value, comparer, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsLessThanOrEqualTo<T>(Argument<T> argument, T value, IComparer<T> comparer, string message, out Exception exception)
        {
            if (comparer.Compare(argument.Value, value) <= 0)
            {
                if (argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        /// <summary>
        /// Determines whether the argument value is less than the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="value">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is less than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not less than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThan<T>(this Argument<T> argument, T value, string message = null) where T : IComparable<T>
        {
            Argument.Assert(argument, ParameterNames.Argument).Not().IsNull();

            if (argument.Value == null)
            {
                throw new InvalidOperationException(Messages.ArgumentValueIsNull);
            }

            Exception exception;

            if (!ValidateIsLessThan(argument, value, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsLessThan<T>(Argument<T> argument, T value, string message, out Exception exception) where T : IComparable<T>
        {
            if (argument.Value.CompareTo(value) < 0)
            {
                if (argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }

            exception = null;

            return true;
        }

        /// <summary>
        /// Determines whether the argument value is less than the given value.
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
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is less than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not less than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThan<T>(this Argument<T> argument, T value, IComparer<T> comparer, string message = null)
        {
            Argument.Assert(argument, ParameterNames.Argument).Not().IsNull();
            Argument.Assert(comparer, ParameterNames.Comparer).Not().IsNull();

            Exception exception;

            if (!ValidateIsLessThan(argument, value, comparer, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsLessThan<T>(Argument<T> argument, T value, IComparer<T> comparer, string message, out Exception exception)
        {
            if (comparer.Compare(argument.Value, value) < 0)
            {
                if (argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }
            else
            {
                if (!argument.IsNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(argument.ParameterName, argument.Value, message);

                    return false;
                }
            }

            exception = null;

            return true;
        }
    }
}
