// Copyright (c) Arjen Post. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace EnGarde
{
    /// <summary>
    /// Provides a set of static methods for argument validation.
    /// </summary>
    public static class IValidatedArgumentExtensions
    {
        /// <summary>
        /// Creates an <see cref="Argument{T}"/> for validating an argument value.
        /// </summary>
        /// <typeparam name="TPrevious">The previous argument type.</typeparam>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">A wrapper object containing the previous argument value.</param>
        /// <param name="value">The argument value.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>A wrapper object containing the actual argument value.</returns>
        [DebuggerStepThrough]
        public static IArgument<TPrevious> That<TPrevious, T>(this IValidatedArgument<T> argument, TPrevious value, string parameterName)
        {
            return new Argument<TPrevious>(value, parameterName);
        }

        /// <summary>
        /// Creates an <see cref="Argument{T}"/> for validating an argument value.
        /// </summary>
        /// <typeparam name="TPrevious">The previous argument type.</typeparam>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">A wrapper object containing the previous argument value.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>A wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameter"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="parameter"/> does not select a parameter.</exception>
        public static IArgument<TPrevious> That<TPrevious, T>(this IValidatedArgument<T> argument, Expression<Func<TPrevious>> parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(ParameterNames.Parameter);
            }

            var memberExpression = parameter.Body as MemberExpression;

            if (memberExpression == null)
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

            var value = (TPrevious)field.GetValue(constantExpression.Value);

            return new Argument<TPrevious>(value, parameterName);
        }
    }
}
