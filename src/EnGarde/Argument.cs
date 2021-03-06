﻿// Copyright (c) Arjen Post. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace EnGarde
{
    /// <summary>
    /// Contains a static method for validating an argument value.
    /// </summary>
    public static class Ensure
    {
        /// <summary>
        /// Creates an <see cref="Argument{T}"/> for validating an argument value.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="value">The argument value.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>A wrapper object containing the actual argument value.</returns>
        [DebuggerStepThrough]
        public static IArgument<T> That<T>(T value, string parameterName)
        {
            return new Argument<T>(value, parameterName);
        }

        /// <summary>
        /// Creates an <see cref="Argument{T}"/> for validating an argument value.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <returns>A wrapper object containing the actual argument value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameter"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="parameter"/> does not select a parameter.</exception>
        public static IArgument<T> That<T>(Expression<Func<T>> parameter)
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

            var value = (T)field.GetValue(constantExpression.Value);

            return new Argument<T>(value, parameterName);
        }
    }
}
