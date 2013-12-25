using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace EnGarde.Benchmark
{
    public static class Argument
    {
        [DebuggerStepThrough]
        public static Argument<T> Assert<T>(T value, string parameterName)
        {
            return new Argument<T>(value, parameterName);
        }

        public static Argument<T> AssertUsingExpressionWithoutCompilation<T>(Expression<Func<T>> parameter)
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

        public static Argument<T> AssertUsingFieldInfoReader<T>(Func<T> parameter)
        {
            var fieldInfoReader = new FieldInfoReader<T>(parameter);
            var fieldInfo = fieldInfoReader.GetFieldToken();

            var parameterName = fieldInfo.Name;
            var value = parameter();

            return new Argument<T>(value, parameterName);
        }

        public static Argument<T> AssertUsingExpressionCompilation<T>(Expression<Func<T>> parameter)
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

            var value = parameter.Compile()();

            return new Argument<T>(value, parameterName);
        }
    }
}
