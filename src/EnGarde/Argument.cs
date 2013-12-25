using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace EnGarde
{
    /// <summary>
    /// Contains a static method for validating an argument value.
    /// </summary>
    public static class Argument
    {
        /// <summary>
        /// Creates an <see cref="Argument{T}"/> for validating an argument value.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="value">The argument value.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>A wrapper object containing the actual argument value.</returns>
        [DebuggerStepThrough]
        public static Argument<T> Assert<T>(T value, string parameterName)
        {
            return new Argument<T>(value, parameterName);
        }

        /// <summary>
        /// Creates an <see cref="Argument{T}"/> for validating an argument value.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <returns>A wrapper object containing the actual argument value.</returns>
        public static Argument<T> Assert<T>(Expression<Func<T>> parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(ParameterNames.Parameter);
            }

            var memberExpression = parameter.Body as MemberExpression;

            if (memberExpression == null || memberExpression.Expression as ConstantExpression == null)
            {
                throw new ArgumentException(Messages.MustSelectParameter, ParameterNames.Parameter);
            }

            var constantExpression = memberExpression.Expression as ConstantExpression;

            if (constantExpression == null)
            {
                throw new ArgumentException(Messages.MustSelectParameter, ParameterNames.Parameter);
            }

            var parameterName = memberExpression.Member.Name;

            var type = constantExpression.Value.GetType();
            var field = type.GetField(parameterName);

            var value = (T)field.GetValue(constantExpression.Value);

            return new Argument<T>(value, parameterName);
        }
    }
}
