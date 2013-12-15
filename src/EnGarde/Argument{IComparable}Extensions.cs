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
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is greater than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not greater than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThan<T>(this Argument<T> argument, T otherValue, string message = null) where T : IComparable<T>
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

            if (!ValidateIsGreaterThan(argument.Value, argument.IsNegativeAssertion, otherValue, argument.ParameterName, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        /// <summary>
        /// Determines whether the argument value is greater than the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is greater than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not greater than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T?> IsGreaterThan<T>(this Argument<T?> argument, T otherValue, string message = null) where T : struct, IComparable<T>
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value.HasValue)
            {
                Exception exception;

                if (!ValidateIsGreaterThan(argument.Value.Value, argument.IsNegativeAssertion, otherValue, argument.ParameterName, message, out exception))
                {
                    throw exception;
                }
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsGreaterThan<T>(T value, bool isNegativeAssertion, T otherValue, string parameterName, string message, out Exception exception) where T : IComparable<T>
        {
            if (value.CompareTo(otherValue) > 0)
            {
                if (isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

                    return false;
                }
            }
            else
            {
                if (!isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

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
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is greater than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not greater than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThan<T>(this Argument<T> argument, T otherValue, IComparer<T> comparer, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(ParameterNames.Comparer);
            }

            Exception exception;

            if (!ValidateIsGreaterThan(argument.Value, argument.IsNegativeAssertion, otherValue, comparer, argument.ParameterName, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        /// <summary>
        /// Determines whether the argument value is greater than the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is greater than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not greater than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T?> IsGreaterThan<T>(this Argument<T?> argument, T otherValue, IComparer<T> comparer, string message = null) where T : struct
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(ParameterNames.Comparer);
            }

            if (argument.Value.HasValue)
            {
                Exception exception;

                if (!ValidateIsGreaterThan(argument.Value.Value, argument.IsNegativeAssertion, otherValue, comparer, argument.ParameterName, message, out exception))
                {
                    throw exception;
                }
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsGreaterThan<T>(T value, bool isNegativeAssertion, T otherValue, IComparer<T> comparer, string parameterName, string message, out Exception exception)
        {
            if (comparer.Compare(value, otherValue) > 0)
            {
                if (isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

                    return false;
                }
            }
            else
            {
                if (!isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

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
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is greater or equal than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not greater or equal than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThanOrEqualTo<T>(this Argument<T> argument, T otherValue, string message = null) where T : IComparable<T>
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

            if (!ValidateIsGreaterThanOrEqualTo(argument.Value, argument.IsNegativeAssertion, otherValue, argument.ParameterName, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        /// <summary>
        /// Determines whether the argument value is greater than or equal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is greater or equal than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not greater or equal than the given value (if not negated).</exception>
        //[DebuggerStepThrough]
        public static Argument<T?> IsGreaterThanOrEqualTo<T>(this Argument<T?> argument, T otherValue, string message = null) where T : struct, IComparable<T>
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value.HasValue)
            {
                Exception exception;

                if (!ValidateIsGreaterThanOrEqualTo(argument.Value.Value, argument.IsNegativeAssertion, otherValue, argument.ParameterName, message, out exception))
                {
                    throw exception;
                }
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsGreaterThanOrEqualTo<T>(T value, bool isNegativeAssertion, T otherValue, string parameterName, string message, out Exception exception) where T : IComparable<T>
        {
            if (value.CompareTo(otherValue) >= 0)
            {
                if (isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

                    return false;
                }
            }
            else
            {
                if (!isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

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
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is greater or equal than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not greater or equal than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThanOrEqualTo<T>(this Argument<T> argument, T otherValue, IComparer<T> comparer, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(ParameterNames.Comparer);
            }

            Exception exception;

            if (!ValidateIsGreaterThanOrEqualTo(argument.Value, argument.IsNegativeAssertion, otherValue, comparer, argument.ParameterName, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        /// <summary>
        /// Determines whether the argument value is greater than or queal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is greater or equal than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not greater or equal than the given value (if not negated).</exception>
        //[DebuggerStepThrough]
        public static Argument<T?> IsGreaterThanOrEqualTo<T>(this Argument<T?> argument, T otherValue, IComparer<T> comparer, string message = null) where T : struct
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(ParameterNames.Comparer);
            }

            if (argument.Value.HasValue)
            {
                Exception exception;

                if (!ValidateIsGreaterThanOrEqualTo(argument.Value.Value, argument.IsNegativeAssertion, otherValue, comparer, argument.ParameterName, message, out exception))
                {
                    throw exception;
                }
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsGreaterThanOrEqualTo<T>(T value, bool isNegativeAssertion, T otherValue, IComparer<T> comparer, string parameterName, string message, out Exception exception)
        {
            if (comparer.Compare(value, otherValue) >= 0)
            {
                if (isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

                    return false;
                }
            }
            else
            {
                if (!isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

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
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is equal to given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not equal to given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsEqualTo<T>(this Argument<T> argument, T otherValue, string message = null) where T : IEquatable<T>
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

            if (!ValidateIsEqualTo(argument.Value, argument.IsNegativeAssertion, otherValue, argument.ParameterName, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        /// <summary>
        /// Determines whether the argument value is equal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is equal to given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not equal to given value (if not negated).</exception>
        //[DebuggerStepThrough]
        public static Argument<T?> IsEqualTo<T>(this Argument<T?> argument, T otherValue, string message = null) where T : struct, IEquatable<T>
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value.HasValue)
            {
                Exception exception;

                if (!ValidateIsEqualTo(argument.Value.Value, argument.IsNegativeAssertion, otherValue, argument.ParameterName, message, out exception))
                {
                    throw exception;
                }
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsEqualTo<T>(T value, bool isNegativeAssertion, T otherValue, string parameterName, string message, out Exception exception) where T : IEquatable<T>
        {
            if (value.Equals(otherValue))
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
        /// Determines whether the argument value is equal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is equal to given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not equal to given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsEqualTo<T>(this Argument<T> argument, T otherValue, IEqualityComparer<T> comparer, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(ParameterNames.Comparer);
            }

            Exception exception;

            if (!ValidateIsEqualTo(argument.Value, argument.IsNegativeAssertion, otherValue, comparer, argument.ParameterName, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        /// <summary>
        /// Determines whether the argument value is equal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is equal to given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not equal to given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T?> IsEqualTo<T>(this Argument<T?> argument, T otherValue, IEqualityComparer<T> comparer, string message = null) where T : struct
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(ParameterNames.Comparer);
            }

            if (argument.Value.HasValue)
            {
                Exception exception;

                if (!ValidateIsEqualTo(argument.Value.Value, argument.IsNegativeAssertion, otherValue, comparer, argument.ParameterName, message, out exception))
                {
                    throw exception;
                }
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsEqualTo<T>(T value, bool isNegativeAssertion, T otherValue, IEqualityComparer<T> comparer, string parameterName, string message, out Exception exception)
        {
            if (comparer.Equals(value, otherValue))
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
        /// Determines whether the argument value is less than or equal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is less or equal than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not less or equal than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThanOrEqualTo<T>(this Argument<T> argument, T otherValue, string message = null) where T : IComparable<T>
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

            if (!ValidateIsLessThanOrEqualTo(argument.Value, argument.IsNegativeAssertion, otherValue, argument.ParameterName, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        /// <summary>
        /// Determines whether the argument value is less than or equal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is less or equal than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not less or equal than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T?> IsLessThanOrEqualTo<T>(this Argument<T?> argument, T otherValue, string message = null) where T : struct, IComparable<T>
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value.HasValue)
            {
                Exception exception;

                if (!ValidateIsLessThanOrEqualTo(argument.Value.Value, argument.IsNegativeAssertion, otherValue, argument.ParameterName, message, out exception))
                {
                    throw exception;
                }
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsLessThanOrEqualTo<T>(T value, bool isNegativeAssertion, T otherValue, string parameterName, string message, out Exception exception) where T : IComparable<T>
        {
            if (value.CompareTo(otherValue) <= 0)
            {
                if (isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

                    return false;
                }
            }
            else
            {
                if (!isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

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
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is less or equal than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not less or equal than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThanOrEqualTo<T>(this Argument<T> argument, T otherValue, IComparer<T> comparer, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(ParameterNames.Comparer);
            }

            Exception exception;

            if (!ValidateIsLessThanOrEqualTo(argument.Value, argument.IsNegativeAssertion, otherValue, comparer, argument.ParameterName, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        /// <summary>
        /// Determines whether the argument value is less than or queal to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is less or equal than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not less or equal than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T?> IsLessThanOrEqualTo<T>(this Argument<T?> argument, T otherValue, IComparer<T> comparer, string message = null) where T : struct
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(ParameterNames.Comparer);
            }

            if (argument.Value.HasValue)
            {
                Exception exception;

                if (!ValidateIsLessThanOrEqualTo(argument.Value.Value, argument.IsNegativeAssertion, otherValue, comparer, argument.ParameterName, message, out exception))
                {
                    throw exception;
                }
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsLessThanOrEqualTo<T>(T value, bool isNegativeAssertion, T otherValue, IComparer<T> comparer, string parameterName, string message, out Exception exception)
        {
            if (comparer.Compare(value, otherValue) <= 0)
            {
                if (isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

                    return false;
                }
            }
            else
            {
                if (!isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

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
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is less than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not less than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThan<T>(this Argument<T> argument, T otherValue, string message = null) where T : IComparable<T>
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

            if (!ValidateIsLessThan(argument.Value, argument.IsNegativeAssertion, otherValue, argument.ParameterName, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        /// <summary>
        /// Determines whether the argument value is less than the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is less than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not less than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T?> IsLessThan<T>(this Argument<T?> argument, T otherValue, string message = null) where T : struct, IComparable<T>
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (argument.Value.HasValue)
            {
                Exception exception;

                if (!ValidateIsLessThan(argument.Value.Value, argument.IsNegativeAssertion, otherValue, argument.ParameterName, message, out exception))
                {
                    throw exception;
                }
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsLessThan<T>(T value, bool isNegativeAssertion, T otherValue, string parameterName, string message, out Exception exception) where T : IComparable<T>
        {
            if (value.CompareTo(otherValue) < 0)
            {
                if (isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

                    return false;
                }
            }
            else
            {
                if (!isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

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
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is less than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not less than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThan<T>(this Argument<T> argument, T otherValue, IComparer<T> comparer, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(ParameterNames.Comparer);
            }

            Exception exception;

            if (!ValidateIsLessThan(argument.Value, argument.IsNegativeAssertion, otherValue, comparer, argument.ParameterName, message, out exception))
            {
                throw exception;
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        /// <summary>
        /// Determines whether the argument value is less than the given value.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="argument">A wrapper object containing the actual argument value.</param>
        /// <param name="otherValue">A value to compare with the argument value.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> object instance to perform the comparison.</param>
        /// <param name="message">The message that describes the error, if the validation of the argument value failed.</param>
        /// <returns>The original wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="argument"/> value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> value is less than the given value (if negated).</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> value is not less than the given value (if not negated).</exception>
        [DebuggerStepThrough]
        public static Argument<T?> IsLessThan<T>(this Argument<T?> argument, T otherValue, IComparer<T> comparer, string message = null) where T : struct
        {
            if (argument == null)
            {
                throw new ArgumentNullException(ParameterNames.Argument);
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(ParameterNames.Comparer);
            }

            if (argument.Value.HasValue)
            {
                Exception exception;

                if (!ValidateIsLessThan(argument.Value.Value, argument.IsNegativeAssertion, otherValue, comparer, argument.ParameterName, message, out exception))
                {
                    throw exception;
                }
            }

            argument.IsNegativeAssertion = false;

            return argument;
        }

        private static bool ValidateIsLessThan<T>(T value, bool isNegativeAssertion, T otherValue, IComparer<T> comparer, string parameterName, string message, out Exception exception)
        {
            if (comparer.Compare(value, otherValue) < 0)
            {
                if (isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

                    return false;
                }
            }
            else
            {
                if (!isNegativeAssertion)
                {
                    exception = new ArgumentOutOfRangeException(parameterName, value, message);

                    return false;
                }
            }

            exception = null;

            return true;
        }
    }
}
